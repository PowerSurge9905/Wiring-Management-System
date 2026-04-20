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
            btnAdd = new Button();
            btnCancel = new Button();
            lblEditDeviceType = new Label();
            lblEditRackNumber = new Label();
            lblEditPod = new Label();
            txtEditPod = new TextBox();
            txtEditRack = new TextBox();
            comboBoxEditDeviceType = new ComboBox();
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
            // btnAdd
            // 
            btnAdd.Location = new Point(98, 175);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "&Edit";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(189, 175);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
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
            // txtEditPod
            // 
            txtEditPod.Location = new Point(111, 57);
            txtEditPod.Name = "txtEditPod";
            txtEditPod.Size = new Size(153, 23);
            txtEditPod.TabIndex = 1;
            // 
            // txtEditRack
            // 
            txtEditRack.Location = new Point(111, 21);
            txtEditRack.Name = "txtEditRack";
            txtEditRack.Size = new Size(153, 23);
            txtEditRack.TabIndex = 0;
            // 
            // comboBoxEditDeviceType
            // 
            comboBoxEditDeviceType.FormattingEnabled = true;
            comboBoxEditDeviceType.Location = new Point(111, 97);
            comboBoxEditDeviceType.Name = "comboBoxEditDeviceType";
            comboBoxEditDeviceType.Size = new Size(153, 23);
            comboBoxEditDeviceType.TabIndex = 2;
            // 
            // FrmEditDevice
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(321, 229);
            Controls.Add(comboBoxEditDeviceType);
            Controls.Add(txtEditRack);
            Controls.Add(txtEditPod);
            Controls.Add(lblEditPod);
            Controls.Add(lblEditRackNumber);
            Controls.Add(lblEditDeviceType);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(txtEditDeviceName);
            Controls.Add(lblEditDeviceName);
            Name = "FrmEditDevice";
            Text = "Edit Device";
            Load += FormEditDevice_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEditDeviceName;
        private TextBox txtEditDeviceName;
        private Button btnAdd;
        private Button btnCancel;
        private Label lblEditDeviceType;
        private Label lblEditRackNumber;
        private Label lblEditPod;
        private TextBox txtEditPod;
        private TextBox txtEditRack;
        private ComboBox comboBoxEditDeviceType;
    }
}