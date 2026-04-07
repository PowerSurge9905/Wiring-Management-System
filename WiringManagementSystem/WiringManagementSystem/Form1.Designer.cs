namespace WiringManagementSystem
{
    partial class Form1
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
            listBox1 = new ListBox();
            btnAddDevice = new Button();
            btnEditDevice = new Button();
            btnEditConnection = new Button();
            btnDeleteDevice = new Button();
            txtBox = new TextBox();
            SuspendLayout();
            // 
            // tree_WiringManagement
            // 
            tree_WiringManagement.Location = new Point(12, 12);
            tree_WiringManagement.Name = "tree_WiringManagement";
            tree_WiringManagement.Size = new Size(513, 198);
            tree_WiringManagement.TabIndex = 0;
            tree_WiringManagement.MouseDown += treeView_MouseDown;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 216);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(513, 94);
            listBox1.TabIndex = 1;
            // 
            // btnAddDevice
            // 
            btnAddDevice.Location = new Point(12, 355);
            btnAddDevice.Name = "btnAddDevice";
            btnAddDevice.Size = new Size(110, 23);
            btnAddDevice.TabIndex = 2;
            btnAddDevice.Text = "Add Device";
            btnAddDevice.UseVisualStyleBackColor = true;
            btnAddDevice.Click += btnAddDevice_Click;
            // 
            // btnEditDevice
            // 
            btnEditDevice.Location = new Point(147, 355);
            btnEditDevice.Name = "btnEditDevice";
            btnEditDevice.Size = new Size(110, 23);
            btnEditDevice.TabIndex = 3;
            btnEditDevice.Text = "Edit Device";
            btnEditDevice.UseVisualStyleBackColor = true;
            btnEditDevice.Click += btnEditDevice_Click;
            // 
            // btnEditConnection
            // 
            btnEditConnection.Location = new Point(282, 355);
            btnEditConnection.Name = "btnEditConnection";
            btnEditConnection.Size = new Size(110, 23);
            btnEditConnection.TabIndex = 4;
            btnEditConnection.Text = "Edit Connections";
            btnEditConnection.UseVisualStyleBackColor = true;
            btnEditConnection.Click += btnEditConnection_Click;
            // 
            // btnDeleteDevice
            // 
            btnDeleteDevice.Location = new Point(415, 355);
            btnDeleteDevice.Name = "btnDeleteDevice";
            btnDeleteDevice.Size = new Size(110, 23);
            btnDeleteDevice.TabIndex = 5;
            btnDeleteDevice.Text = "Delete Device";
            btnDeleteDevice.UseVisualStyleBackColor = true;
            btnDeleteDevice.Click += btnDeleteDevice_Click;
            // 
            // txtBox
            // 
            txtBox.Location = new Point(12, 316);
            txtBox.Name = "txtBox";
            txtBox.Size = new Size(245, 23);
            txtBox.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 402);
            Controls.Add(txtBox);
            Controls.Add(btnDeleteDevice);
            Controls.Add(btnEditConnection);
            Controls.Add(btnEditDevice);
            Controls.Add(btnAddDevice);
            Controls.Add(listBox1);
            Controls.Add(tree_WiringManagement);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView tree_WiringManagement;
        private Microsoft.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private ListBox listBox1;
        private Button btnAddDevice;
        private Button btnEditDevice;
        private Button btnEditConnection;
        private Button btnDeleteDevice;
        private TextBox txtBox;
    }
}
