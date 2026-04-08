using WiringManagementSystem.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WiringManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Handle mouse down event on the tree view to clear selection when clicking outside of any node
        private void treeView_MouseDown(object sender, MouseEventArgs e)
        {
            //Get the node at the current mouse pointer coordinates
            TreeNode clickedNode = tree_WiringManagement.GetNodeAt(e.X, e.Y);

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
