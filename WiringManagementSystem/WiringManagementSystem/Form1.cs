using Microsoft.EntityFrameworkCore;
using WiringManagementSystem.Classes;
using Microsoft.Data.Sqlite;
using Microsoft.IdentityModel.Tokens;

namespace WiringManagementSystem
{
    public partial class WMForm : Form
    {
        private WMContext? dbContext;

        protected string connectionString = "Data Source=WMDB.sqlite";

        public WMForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.dbContext = new WMContext();

            this.dbContext.Database.EnsureCreated();

            this.dbContext.Racks.Load();

            this.dbContext.Devices.Load();

            // Queries all racks
            var racks = this.dbContext.Racks.Select(r => new
            {
                r.RackID,
                r.RackName
            }).ToList();

            // Queries all devices
            var devices = this.dbContext.Devices.Select(d => new
            {
                d.DeviceID,
                d.DeviceName,
                d.Type,
                d.RackID,
                d.PodID
            }).ToList();

            foreach (var rack in racks)
            {
                tree_WiringManagement.Nodes.Add(rack.RackName);
                tree_WiringManagement.Nodes[tree_WiringManagement.Nodes.Count - 1].Tag = rack.RackID;
                var selectDevices = devices.Where(d => d.RackID == rack.RackID).Where(d => string.IsNullOrEmpty(d.PodID)).ToList();
                foreach (var device in selectDevices)
                {
                    var currentNode = tree_WiringManagement.Nodes[tree_WiringManagement.Nodes.Count - 1];
                    currentNode.Nodes.Add(device.DeviceName);
                    currentNode.Nodes[currentNode.Nodes.Count - 1].Tag = new[] { device.DeviceID, device.Type.ToString(), device.RackID, device.PodID };
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            this.dbContext?.Dispose();
            this.dbContext = null;
        }

        //Handle mouse down event on the tree view to clear selection when clicking outside of any node
        private void treeView_MouseDown(object sender, MouseEventArgs e)
        {
            //Get the node at the current mouse pointer coordinates
            TreeNode clickedNode = tree_WiringManagement.GetNodeAt(e.X, e.Y);

            lst_Description.Items.Clear();
            if (clickedNode != null)
            {
                lst_Description.Items.Add($"Name: {clickedNode.Text}");
                var tag = clickedNode.Tag as object[];
                if (tag != null)
                {
                    lst_Description.Items.Add($"Type: {tag[1]}");
                    lst_Description.Items.Add($"Rack: {clickedNode.Parent.Text}");
                    if (!string.IsNullOrEmpty(tag[3]?.ToString()))
                        lst_Description.Items.Add($"PodID: {tag[3]}");
                }
            }

            //If there is no node under the mouse, clear the selection
            if (clickedNode == null)
            {
                tree_WiringManagement.SelectedNode = null;
            }
        }

        //Add a new node to the tree view, either as a child of the selected node or as a new root node if no node is selected
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

        //Edits the selected node's text to match what's in text box
        private void btnEditDevice_Click(object sender, EventArgs e)
        {
            tree_WiringManagement.SelectedNode.Text = txtBox.Text;
        }

        //Edits the selected node's text to match what's in text box
        private void btnEditConnection_Click(object sender, EventArgs e)
        {
            tree_WiringManagement.SelectedNode.Text = txtBox.Text;
        }

        //Delete the selected node and all of its children
        private void btnDeleteDevice_Click(object sender, EventArgs e)
        {
            tree_WiringManagement.Nodes.Remove(tree_WiringManagement.SelectedNode);
        }
    }
}
