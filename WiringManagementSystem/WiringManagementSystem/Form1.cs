using Microsoft.EntityFrameworkCore;
using WiringManagementSystem.Classes;
using Microsoft.Data.Sqlite;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using Microsoft.Identity.Client;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace WiringManagementSystem
{
    public partial class WMForm : Form
    {
        // Forces the application to look in the same directory as this class for the Wiring Management Database (WMDB) file
        readonly string connectionString = $"Data Source={Path.Combine(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\")), "WMDB.sqlite")}";

        // Prepare queries and lists for loading the racks and devices from the database
        string rackQuery = "SELECT * FROM Racks";
        string deviceQuery = "SELECT * FROM Devices";
        List<Rack> racks = new List<Rack>();
        List<Device> devices = new List<Device>();

        // Constructor for the main form, responsible for initializing the form and loading data from the database
        public WMForm()
        {
            InitializeComponent();
            try
            {
                // Open a connection to WMDB
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                // Declare queries to be used on WMDB
                using var rackCommand = new SqliteCommand(rackQuery, connection);
                using var deviceCommand = new SqliteCommand(deviceQuery, connection);

                // Declare readers for executing the queries
                using var rackReader = rackCommand.ExecuteReader();
                using var deviceReader = deviceCommand.ExecuteReader();

                // Check if the rack reader has rows, if not show error message, otherwise read through the racks and add them to the racks list
                if (rackReader == null || !rackReader.HasRows)
                {
                    MessageBox.Show("Error loading rack data from database.");
                }
                else
                {
                    while (rackReader.Read())
                    {
                        var rackID = rackReader.GetString(0);
                        var rackName = rackReader.GetString(1);
                        racks.Add(new Rack { RackID = rackID, RackName = rackName });
                    }
                }

                // Check if the device reader has rows, if not show error message, otherwise read through the devices and add them to the devices list
                if (deviceReader == null || !deviceReader.HasRows)
                {
                    MessageBox.Show("Error loading device data from database.");
                }
                else
                {
                    while (deviceReader.Read())
                    {
                        var deviceID = deviceReader.GetString(0);
                        var deviceName = deviceReader.GetString(1);
                        var type = (DeviceType)deviceReader.GetInt32(2);
                        var rackID = deviceReader.GetString(3);
                        var podID = deviceReader.IsDBNull(4) ? null : deviceReader.GetString(4);
                        /* 
                         * Important: Notes cannot be stored as a list in the database
                         * Instead, they are stored as a single string delimited by the Unicode character '•' (U+2022) (Alt Code 0149)
                         * It was chosen because it is unlikely to be used in any notes, and does not appear on a US QWERTY keyboard
                         * The following code splits the notes string back into a list for ease of use
                         */
                        var notes = deviceReader.IsDBNull(5) ? null : deviceReader.GetString(5).Split('•').ToList();
                        devices.Add(new Device { DeviceID = deviceID, DeviceName = deviceName, Type = type, RackID = rackID, PodID = podID, Notes = notes });
                    }
                }
            }
            catch (SqliteException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Database Error!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception!");
            }

            BuildTreeView(racks, devices);
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
        // TODO: Change this to open a new window which allows the user to input details for a new node
        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            //------Temporary comment until new form is implemented correctly------//

            //TreeNode node = new TreeNode(txtBox.Text);
            //try
            //{
            //    if (tree_WiringManagement.SelectedNode != null)
            //    {
            //        tree_WiringManagement.SelectedNode.Nodes.Add(node);
            //        tree_WiringManagement.SelectedNode.Expand();
            //    }
            //    else
            //    {
            //        tree_WiringManagement.Nodes.Add(node);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error adding node: " + ex.Message);
            //}


            //Create an instance of the form
            FrmAddDevice addDeviceForm = new FrmAddDevice();

            //Show the form
            addDeviceForm.ShowDialog();

        }

        // Edits the selected node's text to match what's in text box
        // TODO: Change this to open a new window which allows the user to edit details for a new node
        private void btnEditDevice_Click(object sender, EventArgs e)
        {

            //------Temporary comment until new form is implemented correctly------//

            //tree_WiringManagement.SelectedNode.Text = txtBox.Text;


            //Create an instance of the form
            FrmEditDevice editDeviceForm = new FrmEditDevice();

            //Show the form
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
