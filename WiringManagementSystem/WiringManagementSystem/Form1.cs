using Microsoft.EntityFrameworkCore;
using WiringManagementSystem.Classes;
using Microsoft.Data.Sqlite;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using Microsoft.Identity.Client;

namespace WiringManagementSystem
{
    public partial class WMForm : Form
    {
        readonly string connectionString = "Data Source=WMDB.sqlite";

        WMContext wmdb = new WMContext();

        public WMForm()
        {
            InitializeComponent();
        }

        // Initialize the database context and load data into the tree view when the form loads
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            wmdb.Database.EnsureCreated();

            // NOTE: This loads from the WMDB.SQLite file in bin\Debug\net8.0-windows
            wmdb.Racks.Load();

            wmdb.Devices.Load();

            // Queries all racks & devices
            var racks = wmdb.Racks.ToList();
            var devices = wmdb.Devices.ToList();

            BuildTreeView(racks, devices);
        }

        // Probably unnecessary, but disposes of database context on form closing
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            wmdb?.Dispose();
            wmdb = null;
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
                }
            }

            //If there is no node under the mouse, clear the selection
            if (clickedNode == null)
            {
                tree_WiringManagement.SelectedNode = null;
            }
        }

        // Add a new node to the tree view, either as a child of the selected node or as a new root node if no node is selected
        // NOTE: Must use the correct ID for RackID: ex."RK01" and PodID: ex."PODA" for the TreeView to recongize where to insert node.
        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            // Open the form
            FrmAddDevice addDeviceForm = new FrmAddDevice();

            // Wait for the user to hit "Add"
            if (addDeviceForm.ShowDialog() == DialogResult.OK)
            {
                // Grab the new device data
                Device newDevice = addDeviceForm.CreatedDevice;

                // Save to database immediately
                try
                {
                    wmdb.Devices.Add(newDevice);
                    wmdb.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving to database: " + ex.Message);
                    return; // Stop running if the database fails
                }

                // Create the node with DeviceName and Tag array
                TreeNode node = new TreeNode(newDevice.DeviceName);
                node.Tag = new[] { newDevice.DeviceID, newDevice.Type.ToString(), newDevice.RackID, newDevice.PodID };

                // Find the correct Rack and Pod
                TreeNode targetParent = null;

                // Search through all Root Nodes (Racks)
                foreach (TreeNode rackNode in tree_WiringManagement.Nodes)
                {
                    
                    if (rackNode.Tag != null && rackNode.Tag.ToString() == newDevice.RackID)
                    {
                        targetParent = rackNode; // Target parent becomes the Rack node by default

                        // If the user also typed in a PodID, we need to search inside this Rack
                        if (!string.IsNullOrEmpty(newDevice.PodID))
                        {
                            foreach (TreeNode podNode in rackNode.Nodes)
                            {
                                var tagData = podNode.Tag as object[];
                                // tagData[0] is the DeviceID. We check if it matches the PodID they entered
                                if (tagData != null && tagData.Length > 0 && tagData[0].ToString() == newDevice.PodID)
                                {
                                    targetParent = podNode; // Target parent becomes the Pod node instead of the Rack node
                                    break; // Stop searching pods
                                }
                            }
                        }
                        break; // Stop searching racks
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
                        // Fallback: If they typed a Rack that doesn't exist, just add it to the main tree
                        tree_WiringManagement.Nodes.Add(node);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding node to form: " + ex.Message);
                }
            }
        }

        // Edits the selected node's text to match what's in text box
        // TODO: Change this to open a new window which allows the user to edit details for a new node
        private void btnEditDevice_Click(object sender, EventArgs e)
        {
            //tree_WiringManagement.SelectedNode.Text = txtBox.Text;
            FrmEditDevice editDeviceForm = new FrmEditDevice();
            editDeviceForm.ShowDialog();
        }

        // Edits the selected node's text to match what's in text box
        // TODO: Change this to open a new window which allows the user to enter notes for connections
        private void btnEditConnection_Click(object sender, EventArgs e)
        {
            tree_WiringManagement.SelectedNode.Text = txtBox.Text;
        }

        // Delete the selected node and all of its children
        // TODO: Change this to open a confirmation dialog before deleting, then delete the corresponding entry in the database as well
        private void btnDeleteDevice_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.None;

            var selectedNode = tree_WiringManagement.SelectedNode;

            if (tree_WiringManagement.SelectedNode == null)
            {
                MessageBox.Show("Please select a node to delete.");
                return;
            }

            if (selectedNode.GetNodeCount(true) > 0)
            {
                result = confirmDeletion(result, true);
            }
            else
            {
                result = confirmDeletion(result, false);
            }

            if (result == DialogResult.Yes)
            {
                // Delete selected node & all child nodes

                tree_WiringManagement.Nodes.Remove(tree_WiringManagement.SelectedNode);
            }
        }

        private DialogResult confirmDeletion(DialogResult result, bool showChildNodes)
        {
            return MessageBox.Show(
                $"Are you sure you want to delete {tree_WiringManagement.SelectedNode.Text}?" + (showChildNodes ? $"\nThis will also delete {tree_WiringManagement.SelectedNode.GetNodeCount(true)} child devices!" : ""),
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
