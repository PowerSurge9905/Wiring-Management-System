namespace WiringManagementSystem
{
    partial class WMForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <paramname="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tree_WiringManagement = new TreeView();
            sqlDataAdapter1 = new Microsoft.Data.SqlClient.SqlDataAdapter();
            lst_Description = new ListBox();
            btnAddDevice = new Button();
            btnEditDevice = new Button();
            btnDeleteDevice = new Button();
            lblNotes = new Label();
            btnReloadTree = new Button();
            txtNotes = new TextBox();
            btnSaveNotes = new Button();
            SuspendLayout();
            // 
            // tree_WiringManagement
            // 
            tree_WiringManagement.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tree_WiringManagement.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tree_WiringManagement.Location = new Point(12, 41);
            tree_WiringManagement.Name = "tree_WiringManagement";
            tree_WiringManagement.Size = new Size(513, 198);
            tree_WiringManagement.TabIndex = 0;
            tree_WiringManagement.NodeMouseClick += tree_WiringManagement_NodeMouseClick;
            tree_WiringManagement.ControlAdded += tree_WiringManagement_ControlAdded;
            tree_WiringManagement.MouseDown += treeView_MouseDown;
            // 
            // lst_Description
            // 
            lst_Description.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lst_Description.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lst_Description.FormattingEnabled = true;
            lst_Description.Location = new Point(12, 245);
            lst_Description.Name = "lst_Description";
            lst_Description.Size = new Size(513, 84);
            lst_Description.TabIndex = 1;
            lst_Description.TabStop = false;
            // 
            // btnAddDevice
            // 
            btnAddDevice.Location = new Point(12, 12);
            btnAddDevice.Name = "btnAddDevice";
            btnAddDevice.Size = new Size(111, 23);
            btnAddDevice.TabIndex = 2;
            btnAddDevice.Text = "Add Device";
            btnAddDevice.UseVisualStyleBackColor = true;
            btnAddDevice.Click += btnAddDevice_Click;
            // 
            // btnEditDevice
            // 
            btnEditDevice.Location = new Point(146, 12);
            btnEditDevice.Name = "btnEditDevice";
            btnEditDevice.Size = new Size(111, 23);
            btnEditDevice.TabIndex = 3;
            btnEditDevice.Text = "Edit Device";
            btnEditDevice.UseVisualStyleBackColor = true;
            btnEditDevice.Click += btnEditDevice_Click;
            // 
            // btnDeleteDevice
            // 
            btnDeleteDevice.Location = new Point(280, 12);
            btnDeleteDevice.Name = "btnDeleteDevice";
            btnDeleteDevice.Size = new Size(111, 23);
            btnDeleteDevice.TabIndex = 5;
            btnDeleteDevice.Text = "Delete Device";
            btnDeleteDevice.UseVisualStyleBackColor = true;
            btnDeleteDevice.Click += btnDeleteDevice_Click;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(12, 339);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(41, 15);
            lblNotes.TabIndex = 7;
            lblNotes.Text = "Notes:";
            // 
            // btnReloadTree
            // 
            btnReloadTree.Location = new Point(414, 12);
            btnReloadTree.Name = "btnReloadTree";
            btnReloadTree.Size = new Size(111, 23);
            btnReloadTree.TabIndex = 10;
            btnReloadTree.Text = "Refresh";
            btnReloadTree.UseVisualStyleBackColor = true;
            btnReloadTree.Click += btnReloadTree_Click;
            // 
            // txtNotes
            // 
            txtNotes.Enabled = false;
            txtNotes.Location = new Point(12, 364);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(513, 106);
            txtNotes.TabIndex = 11;
            // 
            // btnSaveNotes
            // 
            btnSaveNotes.Location = new Point(414, 335);
            btnSaveNotes.Name = "btnSaveNotes";
            btnSaveNotes.Size = new Size(111, 23);
            btnSaveNotes.TabIndex = 12;
            btnSaveNotes.Text = "Save Notes";
            btnSaveNotes.UseVisualStyleBackColor = true;
            btnSaveNotes.Click += btnSaveNotes_Click;
            // 
            // WMForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 513);
            Controls.Add(btnSaveNotes);
            Controls.Add(txtNotes);
            Controls.Add(btnReloadTree);
            Controls.Add(lblNotes);
            Controls.Add(btnDeleteDevice);
            Controls.Add(btnEditDevice);
            Controls.Add(btnAddDevice);
            Controls.Add(lst_Description);
            Controls.Add(tree_WiringManagement);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "WMForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Wiring Management System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView tree_WiringManagement;
        private Microsoft.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private ListBox lst_Description;
        private Button btnAddDevice;
        private Button btnEditDevice;
        private Button btnDeleteDevice;
        private Label lblNotes;
        private Button btnReloadTree;
        private TextBox txtNotes;
        private Button btnSaveNotes;
    }
}
