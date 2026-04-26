namespace WiringManagementSystem
{
    partial class FrmEditDevice
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
            lblEditDeviceName = new Label();
            txtEditDeviceName = new TextBox();
            btnEdit = new Button();
            btnCancel = new Button();
            lblEditDeviceType = new Label();
            lblEditRackNumber = new Label();
            lblEditPod = new Label();
            cmbEditDeviceType = new ComboBox();
            cmbEditRack = new ComboBox();
            cmbEditPod = new ComboBox();
            SuspendLayout();
            // 
            // lblEditDeviceName
            // 
            lblEditDeviceName.AutoSize = true;
            lblEditDeviceName.Location = new Point(20, 138);
            lblEditDeviceName.Name = "lblEditDeviceName";
            lblEditDeviceName.Size = new Size(78, 15);
            lblEditDeviceName.TabIndex = 9;
            lblEditDeviceName.Text = "Device name:";
            // 
            // txtEditDeviceName
            // 
            txtEditDeviceName.Location = new Point(111, 130);
            txtEditDeviceName.Name = "txtEditDeviceName";
            txtEditDeviceName.Size = new Size(153, 23);
            txtEditDeviceName.TabIndex = 3;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(98, 175);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "&Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(189, 175);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblEditDeviceType
            // 
            lblEditDeviceType.AutoSize = true;
            lblEditDeviceType.Location = new Point(20, 100);
            lblEditDeviceType.Name = "lblEditDeviceType";
            lblEditDeviceType.Size = new Size(71, 15);
            lblEditDeviceType.TabIndex = 8;
            lblEditDeviceType.Text = "Device type:";
            // 
            // lblEditRackNumber
            // 
            lblEditRackNumber.AutoSize = true;
            lblEditRackNumber.Location = new Point(18, 29);
            lblEditRackNumber.Name = "lblEditRackNumber";
            lblEditRackNumber.Size = new Size(80, 15);
            lblEditRackNumber.TabIndex = 6;
            lblEditRackNumber.Text = "Rack number:";
            // 
            // lblEditPod
            // 
            lblEditPod.AutoSize = true;
            lblEditPod.Location = new Point(20, 65);
            lblEditPod.Name = "lblEditPod";
            lblEditPod.Size = new Size(31, 15);
            lblEditPod.TabIndex = 7;
            lblEditPod.Text = "Pod:";
            // 
            // cmbEditDeviceType
            // 
            cmbEditDeviceType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditDeviceType.FormattingEnabled = true;
            cmbEditDeviceType.Location = new Point(111, 97);
            cmbEditDeviceType.Name = "cmbEditDeviceType";
            cmbEditDeviceType.Size = new Size(153, 23);
            cmbEditDeviceType.TabIndex = 2;
            // 
            // cmbEditRack
            // 
            cmbEditRack.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditRack.FormattingEnabled = true;
            cmbEditRack.Location = new Point(111, 29);
            cmbEditRack.Name = "cmbEditRack";
            cmbEditRack.Size = new Size(153, 23);
            cmbEditRack.TabIndex = 10;
            // 
            // cmbEditPod
            // 
            cmbEditPod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditPod.FormattingEnabled = true;
            cmbEditPod.Location = new Point(111, 62);
            cmbEditPod.Name = "cmbEditPod";
            cmbEditPod.Size = new Size(153, 23);
            cmbEditPod.TabIndex = 11;
            // 
            // FrmEditDevice
            // 
            AcceptButton = btnEdit;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(321, 229);
            Controls.Add(cmbEditPod);
            Controls.Add(cmbEditRack);
            Controls.Add(cmbEditDeviceType);
            Controls.Add(lblEditPod);
            Controls.Add(lblEditRackNumber);
            Controls.Add(lblEditDeviceType);
            Controls.Add(btnCancel);
            Controls.Add(btnEdit);
            Controls.Add(txtEditDeviceName);
            Controls.Add(lblEditDeviceName);
            Name = "FrmEditDevice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Device";
            Load += FrmEditDevice_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEditDeviceName;
        private TextBox txtEditDeviceName;
        private Button btnEdit;
        private Button btnCancel;
        private Label lblEditDeviceType;
        private Label lblEditRackNumber;
        private Label lblEditPod;
        private TextBox txtEditPod;
        private TextBox txtEditRack;
        private ComboBox cmbEditDeviceType;
        private ComboBox cmbEditRack;
        private ComboBox cmbEditPod;
    }
}