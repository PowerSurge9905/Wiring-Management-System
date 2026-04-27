using WiringManagementSystem.Classes;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.IdentityModel.Tokens;


namespace WiringManagementSystem
{
    public partial class WMForm : Form
    {
        // Prepare lists for loading the racks and devices from the database
        WMContext WMDB = new WMContext();
        List<Rack> racks = new List<Rack>();
        List<Device> devices = new List<Device>();

        // Constructor for the main form, responsible for initializing the form and loading data from the database
        public WMForm()
        {
            InitializeComponent();
            try
            {
                QueryLists();
                BuildTreeView(racks, devices);
            }
            catch (SqliteException ex)
            {
                txtNotes.Text = "Error loading from database: " + ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception!");
            }
        }

        private void QueryLists()
        {
            try
            {
                racks = WMDB.Racks.ToList();
                devices = WMDB.Devices.ToList();
            }
            catch (SqliteException ex)
            {
                txtNotes.Text = "Error loading from database: " + ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception!");
            }
        }

        // Builds the tree view based on the supplied lists of racks and devices
        public void BuildTreeView(List<Rack> racks, List<Device> devices)
        {
            // Clear existing nodes before rebuilding the tree view
            tree_WiringManagement.Nodes.Clear();
            // Loop through each rack and add it as a root node
            foreach (var rack in racks)
            {
                TreeNode rackNode = new TreeNode(rack.RackName);
                rackNode.Tag = rack.RackID;
                tree_WiringManagement.Nodes.Add(rackNode);

                // Query devices that are in the current rack and not in a pod
                var rackDevices = devices.Where(d => d.RackID == rack.RackID && string.IsNullOrEmpty(d.PodID)).ToList();
                // Loop through each device in the rack and add it as a child node under the rack node
                foreach (var device in rackDevices)
                {
                    TreeNode deviceNode = new TreeNode(device.DeviceName);
                    deviceNode.Tag = new[] { device.DeviceID, device.Type.ToString(), device.RackID, device.PodID };
                    rackNode.Nodes.Add(deviceNode);

                    // If the device is a pod, query for devices that are in that pod and add them as child nodes under the pod node
                    if (device.Type == DeviceType.Pod)
                    {
                        var podDevices = devices.Where(d => d.PodID == device.DeviceID).ToList();
                        foreach (var podDevice in podDevices)
                        {
                            TreeNode podDeviceNode = new TreeNode(podDevice.DeviceName);
                            podDeviceNode.Tag = new[] { podDevice.DeviceID, podDevice.Type.ToString(), podDevice.RackID, podDevice.PodID };
                            deviceNode.Nodes.Add(podDeviceNode);
                        }
                    }
                }
            }
        }

        //Handle mouse down event on the tree view to clear selection when clicking outside of any node
        private void treeView_MouseDown(object sender, MouseEventArgs e)
        {
            //Get the node at the current mouse pointer coordinates
            TreeNode clickedNode = tree_WiringManagement.GetNodeAt(e.X, e.Y);

            // Clear out details list, then populate with clicked node details
            lst_Description.Items.Clear();
            if (clickedNode != null)
            {
                lst_Description.Items.Add($"Name: {clickedNode.Text}");
                var tag = clickedNode.Tag as object[];

                // Check if the clicked node is a root node or a pod, if so show number of devices contained within
                if (clickedNode.Parent == null || (tag != null && tag[1].ToString() == DeviceType.Pod.ToString()))
                {
                    lst_Description.Items.Add($"Number of Devices: {clickedNode.GetNodeCount(true)}");
                }

                // Check if the clicked node has a tag, display tag data if so
                // Should never be a root node
                if (tag != null && clickedNode.Parent != null)
                {
                    lst_Description.Items.Add($"Type: {tag[1]}");
                    // Check if the clicked node is in a pod, show rack and pod details if so, otherwise just show rack details
                    if (!string.IsNullOrEmpty(tag[3]?.ToString()))
                    {
                        lst_Description.Items.Add($"Rack: {clickedNode.Parent.Parent.Text}");
                        lst_Description.Items.Add($"Pod:  {clickedNode.Parent.Text}");
                    }
                    else
                    {
                        lst_Description.Items.Add($"Rack: {clickedNode.Parent.Text}");
                    }

                    txtNotes.Text = WMDB.Devices.Find(clickedNode.Tag.ToString())?.Notes;

                } else if (clickedNode.Parent == null)
                {
                    txtNotes.Text = WMDB.Racks.Find(clickedNode.Tag.ToString())?.Notes;
                }
            }

            // If there is no node under the mouse, clear the selection
            if (clickedNode == null)
            {
                tree_WiringManagement.SelectedNode = null;
            }
        }

        // Add a new node to the tree view, either as a child of the selected node or as a new root node if no node is selected
        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            string targetRackId = "";
            string targetPodId = "";

            TreeNode selectedNode = tree_WiringManagement.SelectedNode;

            // Check what the user clicked to extract the IDs for Auto-fill
            if (selectedNode != null)
            {
                if (selectedNode.Parent == null) // They clicked a Root Node (A Rack)
                {
                    targetRackId = selectedNode.Tag?.ToString();
                }
                else // They clicked a Child Node (A Device or a Pod)
                {
                    var tagArray = selectedNode.Tag as object[];
                    if (tagArray != null)
                    {
                        if (tagArray[1].ToString() == DeviceType.Pod.ToString())
                        {
                            targetPodId = tagArray[0]?.ToString();  // The Pod's DeviceID
                            targetRackId = tagArray[2]?.ToString(); // The Rack it belongs to
                        }
                        else
                        {
                            targetRackId = tagArray[2]?.ToString(); // A regular device's Rack
                            targetPodId = tagArray[3]?.ToString();  // A regular device's Pod
                        }
                    }
                }
            }

            // Open the form and pass the IDs
            FrmAddDevice addDeviceForm = new FrmAddDevice(targetRackId, targetPodId);

            // Wait for the user to hit "Add"
            if (addDeviceForm.ShowDialog() == DialogResult.OK)
            {
                Device newDevice = addDeviceForm.CreatedDevice;

                // Save to the SQLite database immediately
                try
                {
                    using (WMContext ctx = new WMContext())
                    {
                        ctx.Devices.Add(newDevice);
                        ctx.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving to database: " + ex.Message);
                    return; // Stop running if the database fails
                }

                // Create the visible node and assign the hidden Tag array
                TreeNode node = new TreeNode(newDevice.DeviceName);
                node.Tag = new[] { newDevice.DeviceID, newDevice.Type.ToString(), newDevice.RackID, newDevice.PodID };

                // Search the tree to find exactly where to put the new node
                TreeNode targetParent = null;

                foreach (TreeNode rackNode in tree_WiringManagement.Nodes)
                {
                    if (rackNode.Tag != null && rackNode.Tag.ToString() == newDevice.RackID)
                    {
                        targetParent = rackNode; // Target parent becomes the Rack node

                        if (!string.IsNullOrEmpty(newDevice.PodID))
                        {
                            foreach (TreeNode podNode in rackNode.Nodes)
                            {
                                var tagData = podNode.Tag as object[];
                                if (tagData != null && tagData.Length > 0 && tagData[0].ToString() == newDevice.PodID)
                                {
                                    targetParent = podNode; // Target parent becomes the Pod node instead
                                    break;
                                }
                            }
                        }
                        break; // Stop searching racks once we found the right one
                    }
                }

                // Insert the node exactly where it belongs
                try
                {
                    if (targetParent != null)
                    {
                        // Find the Rack or Pod and insert the new node as a child of that Rack or Pod
                        targetParent.Nodes.Add(node);
                        targetParent.Expand();
                    }
                    else
                    {
                        // Add it to the main tree if a parent wasn't found
                        tree_WiringManagement.Nodes.Add(node);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding node to form: " + ex.Message);
                }
            }
        }

        // Edits the selected node's and updates the tree view and database accordingly
        private void btnEditDevice_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tree_WiringManagement.SelectedNode;

            // If nothing is selected, show a warning message and exit the method
            if (selectedNode == null)
            {
                MessageBox.Show("Please select a device to edit.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedNode.Parent == null)
            {
                MessageBox.Show("This button is for editing devices. Please select a device, not a rack.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Extract the ID from the selected node's Tag array
            var tagArray = selectedNode.Tag as object[];
            if (tagArray == null) return;

            string deviceId = tagArray[0]?.ToString(); // tag[0] is always the DeviceID

            using (WMContext ctx = new WMContext())
            {
                // Fetch the exact device from the database
                Device deviceToEdit = ctx.Devices.Find(deviceId);

                if (deviceToEdit == null)
                {
                    MessageBox.Show("Device not found in database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Open your edit form and pass the device in
                FrmEditDevice editForm = new FrmEditDevice(deviceToEdit);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Grab the updated data from the form
                    Device updatedDevice = editForm.EditedDevice;

                    try
                    {
                        // Save the changes to the database first
                        ctx.Entry(deviceToEdit).CurrentValues.SetValues(updatedDevice);
                        ctx.SaveChanges();

                        // Figure out if the device was moved to a new Rack or Pod
                        string oldRackId = tagArray[2]?.ToString();
                        string oldPodId = tagArray[3]?.ToString();
                        bool locationChanged = (oldRackId != updatedDevice.RackID) || (oldPodId != updatedDevice.PodID);

                        // Instantly update the text on the screen and the hidden Tag data
                        selectedNode.Text = updatedDevice.DeviceName;
                        selectedNode.Tag = new[] { updatedDevice.DeviceID, updatedDevice.Type.ToString(), updatedDevice.RackID, updatedDevice.PodID };

                        // If it moved, we need to physically move the node on the treeview UI
                        if (locationChanged)
                        {
                            // Remove it out of its current folder
                            selectedNode.Remove();

                            // Search the tree to find exactly where to put the updated node based on its new RackID and PodID
                            TreeNode targetParent = null;

                            foreach (TreeNode rackNode in tree_WiringManagement.Nodes)
                            {
                                if (rackNode.Tag != null && rackNode.Tag.ToString() == updatedDevice.RackID)
                                {
                                    targetParent = rackNode; // Target parent becomes the Rack node

                                    if (!string.IsNullOrEmpty(updatedDevice.PodID))
                                    {
                                        foreach (TreeNode podNode in rackNode.Nodes)
                                        {
                                            var podTagData = podNode.Tag as object[];
                                            if (podTagData != null && podTagData.Length > 0 && podTagData[0].ToString() == updatedDevice.PodID)
                                            {
                                                targetParent = podNode; // Target parent becomes the Pod node instead
                                                break;
                                            }
                                        }
                                    }
                                    break; // Stop searching racks once we found the right one
                                }
                            }

                            // Drop the node exactly where it belongs
                            if (targetParent != null)
                            {
                                targetParent.Nodes.Add(selectedNode);
                                targetParent.Expand();
                            }
                            else
                            {
                                // Add it to the main tree if parent wasn't found
                                tree_WiringManagement.Nodes.Add(selectedNode);
                            }
                        }

                        // Keep the edited node highlighted and visible on the screen
                        tree_WiringManagement.SelectedNode = selectedNode;
                        selectedNode.EnsureVisible();
                        tree_WiringManagement.Focus();

                        // Clear the description box since the data just changed
                        lst_Description.Items.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving changes: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Edits the selected node's text to match what's in text box
        // TODO: Remove
        private void btnEditNotes_Click(object sender, EventArgs e)
        {
            tree_WiringManagement.SelectedNode.Text = txtNotes.Text;
        }

        // Delete the selected node and all of its children
        private void btnDeleteDevice_Click(object sender, EventArgs e)
        {
            List<Device> devicesToDelete = new List<Device>();

            var selectedNode = tree_WiringManagement.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("Please select a node to delete.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Asks for comfirmation
            DialogResult result = DialogResult.None;

            if (selectedNode.GetNodeCount(true) > 0)
            {
                result = confirmDeletion(result, true);
            }
            else
            {
                result = confirmDeletion(result, false);
            }

            // If they click "Yes", proceed with deletion
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (WMContext ctx = new WMContext())
                    {
                        // Is it a Root Node (A Rack)?
                        if (selectedNode.Parent == null)
                        {
                            // Racks store just their string ID in the Tag
                            string rackId = selectedNode.Tag?.ToString();
                            var rackToDelete = ctx.Racks.Find(rackId);

                            if (selectedNode.GetNodeCount(true) > 0)
                            {
                                foreach (TreeNode deviceNode in selectedNode.Nodes)
                                {
                                    var deviceTag = deviceNode.Tag as object[];
                                    if (deviceTag != null)
                                    {
                                        string deviceId = deviceTag[0]?.ToString();
                                        var deviceToDelete = ctx.Devices.Find(deviceId);
                                        if (deviceToDelete != null)
                                        {
                                            devicesToDelete.Add(deviceToDelete);
                                        }
                                        // If it's a Pod, we also need to delete its child devices
                                        if (deviceTag[1].ToString() == DeviceType.Pod.ToString())
                                        {
                                            foreach (TreeNode podChildNode in deviceNode.Nodes)
                                            {
                                                var podChildTag = podChildNode.Tag as object[];
                                                if (podChildTag != null)
                                                {
                                                    string podChildDeviceId = podChildTag[0]?.ToString();
                                                    var podChildDeviceToDelete = ctx.Devices.Find(podChildDeviceId);
                                                    if (podChildDeviceToDelete != null)
                                                    {
                                                        devicesToDelete.Add(podChildDeviceToDelete);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (rackToDelete != null)
                            {
                                foreach (var device in devicesToDelete)
                                {
                                    ctx.Devices.Remove(device);
                                }

                                ctx.Racks.Remove(rackToDelete);
                            }
                        }
                        // Otherwise, it is a Child Node (A Device or Pod)
                        else
                        {
                            if (selectedNode.GetNodeCount(true) > 0)
                            {
                                foreach (TreeNode childNode in selectedNode.Nodes)
                                {
                                    var childTag = childNode.Tag as object[];
                                    if (childTag != null)
                                    {
                                        string childDeviceId = childTag[0]?.ToString();
                                        var childDeviceToDelete = ctx.Devices.Find(childDeviceId);
                                        if (childDeviceToDelete != null)
                                        {
                                            devicesToDelete.Add(childDeviceToDelete);
                                        }
                                    }
                                }
                            }
                            // Devices/Pods store an array of data in the Tag
                            var tagArray = selectedNode.Tag as object[];
                            if (tagArray != null)
                            {
                                string deviceId = tagArray[0]?.ToString(); // tag[0] is the DeviceID
                                var deviceToDelete = ctx.Devices.Find(deviceId);

                                if (deviceToDelete != null)
                                {
                                    foreach (var device in devicesToDelete)
                                    {
                                        ctx.Devices.Remove(device);
                                    }

                                    ctx.Devices.Remove(deviceToDelete);
                                }
                            }
                        }

                        // Delete it from the database file
                        ctx.SaveChanges();
                    }

                    // Visually remove the node from the treeview UI
                    selectedNode.Remove();

                    // Clear the description box
                    lst_Description.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting from database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private DialogResult confirmDeletion(DialogResult result, bool showChildNodes)
        {
            return MessageBox.Show(
                $"Are you sure you want to delete {tree_WiringManagement.SelectedNode.Text}?" + (showChildNodes ? $"\nThis will also delete {tree_WiringManagement.SelectedNode.GetNodeCount(true)} child devices!" : ""),
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void btnReloadTree_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear out all nodes before querying the Rack and Device lists, then rebuilding the tree view
                tree_WiringManagement.Nodes.Clear();
                QueryLists();
                BuildTreeView(WMDB.Racks.ToList(), WMDB.Devices.ToList());
            }
            catch (SqliteException ex)
            {
                txtNotes.Text = "Error loading from database: " + ex.Message;
            }
            catch (Exception)
            {
            }
        }

        private void tree_WiringManagement_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            txtNotes.Enabled = true;
        }

        private void btnSaveNotes_Click(object sender, EventArgs e)
        {
            try
            {
                using (WMContext ctx = new WMContext())
                {
                    TreeNode selectedNode = tree_WiringManagement.SelectedNode;
                    if (selectedNode != null && selectedNode.Parent != null)
                    {
                        var tagArray = selectedNode.Tag as object[];
                        if (tagArray != null)
                        {
                            string deviceId = tagArray[0]?.ToString();
                            var deviceToUpdate = ctx.Devices.Find(deviceId);
                            if (deviceToUpdate != null)
                            {
                                deviceToUpdate.Notes = txtNotes.Text;
                                ctx.SaveChanges();
                            }
                        }
                    }
                    else if (selectedNode.Parent == null)
                    {
                        string rackId = selectedNode.Tag?.ToString();
                        var rackToUpdate = ctx.Racks.Find(rackId);
                        if (rackToUpdate != null)
                        {
                            if (txtNotes.Text.IsNullOrEmpty())
                            {
                                rackToUpdate.Notes = null; // Set to null if the text box is empty to avoid storing empty strings
                            }
                            else
                            {
                                rackToUpdate.Notes = txtNotes.Text;
                            }
                            ctx.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving notes: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
