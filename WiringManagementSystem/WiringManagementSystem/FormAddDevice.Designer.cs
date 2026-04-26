namespace WiringManagementSystem
{
    partial class FrmAddDevice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblAddDeviceName = new Label();
            txtAddDeviceName = new TextBox();
            btnAdd = new Button();
            btnCancel = new Button();
            lblAddDeviceType = new Label();
            lblAddRackNumber = new Label();
            lblAddPod = new Label();
            txtAddPod = new TextBox();
            txtAddRack = new TextBox();
            comboBoxAddDeviceType = new ComboBox();
            SuspendLayout();
            // 
            // lblAddDeviceName
            // 
            lblAddDeviceName.AutoSize = true;
            lblAddDeviceName.Location = new Point(21, 137);
            lblAddDeviceName.Name = "lblAddDeviceName";
            lblAddDeviceName.Size = new Size(78, 15);
            lblAddDeviceName.TabIndex = 0;
            lblAddDeviceName.Text = "Device name:";
            // 
            // txtAddDeviceName
            // 
            txtAddDeviceName.Location = new Point(112, 129);
            txtAddDeviceName.Name = "txtAddDeviceName";
            txtAddDeviceName.Size = new Size(153, 23);
            txtAddDeviceName.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(99, 174);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "&Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(190, 174);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblAddDeviceType
            // 
            lblAddDeviceType.AutoSize = true;
            lblAddDeviceType.Location = new Point(21, 99);
            lblAddDeviceType.Name = "lblAddDeviceType";
            lblAddDeviceType.Size = new Size(71, 15);
            lblAddDeviceType.TabIndex = 4;
            lblAddDeviceType.Text = "Device type:";
            // 
            // lblAddRackNumber
            // 
            lblAddRackNumber.AutoSize = true;
            lblAddRackNumber.Location = new Point(19, 28);
            lblAddRackNumber.Name = "lblAddRackNumber";
            lblAddRackNumber.Size = new Size(80, 15);
            lblAddRackNumber.TabIndex = 6;
            lblAddRackNumber.Text = "Rack number:";
            // 
            // lblAddPod
            // 
            lblAddPod.AutoSize = true;
            lblAddPod.Location = new Point(21, 64);
            lblAddPod.Name = "lblAddPod";
            lblAddPod.Size = new Size(31, 15);
            lblAddPod.TabIndex = 7;
            lblAddPod.Text = "Pod:";
            // 
            // txtAddPod
            // 
            txtAddPod.Location = new Point(112, 56);
            txtAddPod.Name = "txtAddPod";
            txtAddPod.Size = new Size(153, 23);
            txtAddPod.TabIndex = 1;
            // 
            // txtAddRack
            // 
            txtAddRack.Location = new Point(112, 20);
            txtAddRack.Name = "txtAddRack";
            txtAddRack.Size = new Size(153, 23);
            txtAddRack.TabIndex = 0;
            txtAddRack.TextChanged += txtAddRack_TextChanged;
            // 
            // comboBoxAddDeviceType
            // 
            comboBoxAddDeviceType.FormattingEnabled = true;
            comboBoxAddDeviceType.Location = new Point(112, 96);
            comboBoxAddDeviceType.Name = "comboBoxAddDeviceType";
            comboBoxAddDeviceType.Size = new Size(153, 23);
            comboBoxAddDeviceType.TabIndex = 2;
            // 
            // FrmAddDevice
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(321, 229);
            Controls.Add(comboBoxAddDeviceType);
            Controls.Add(txtAddRack);
            Controls.Add(txtAddPod);
            Controls.Add(lblAddPod);
            Controls.Add(lblAddRackNumber);
            Controls.Add(lblAddDeviceType);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(txtAddDeviceName);
            Controls.Add(lblAddDeviceName);
            Name = "FrmAddDevice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Device";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAddDeviceName;
        private TextBox txtAddDeviceName;
        private Button btnAdd;
        private Button btnCancel;
        private Label lblAddDeviceType;
        private Label lblAddRackNumber;
        private Label lblAddPod;
        private TextBox txtAddPod;
        private TextBox txtAddRack;
        private ComboBox comboBoxAddDeviceType;
    }
}