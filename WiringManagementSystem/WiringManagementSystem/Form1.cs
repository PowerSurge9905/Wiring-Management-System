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

            wmdb.Racks.Load();

            wmdb.Devices.Load();
            // Queries all racks

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
        // TODO: Change this to open a new window which allows the user to input details for a new node
        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode(txtBox.Text);
            try
            {
                if (tree_WiringManagement.SelectedNode != null)
                {
                    tree_WiringManagement.SelectedNode.Nodes.Add(node);
                    tree_WiringManagement.SelectedNode.Expand();
                }
                else
                {
                    tree_WiringManagement.Nodes.Add(node);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding node: " + ex.Message);
            }
        }

        // Edits the selected node's text to match what's in text box
        // TODO: Change this to open a new window which allows the user to edit details for a new node
        private void btnEditDevice_Click(object sender, EventArgs e)
        {
            tree_WiringManagement.SelectedNode.Text = txtBox.Text;
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
            tree_WiringManagement.Nodes.Remove(tree_WiringManagement.SelectedNode);
        }
    }
}
