using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiringManagementSystem.Classes;

namespace WiringManagementSystem
{
    public partial class FrmAddDevice : Form
    {
        public Classes.Device CreatedDevice { get; private set; }
        public FrmAddDevice()
        {
            InitializeComponent();

            comboBoxAddDeviceType.DataSource = Enum.GetValues(typeof(Classes.DeviceType));
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            // If device name is empty, show error and return
            if (string.IsNullOrWhiteSpace(txtAddDeviceName.Text))
            {
                MessageBox.Show("Please enter a device name.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new SqliteConnection(Globals.connectionString))
            {

            }

                // Build new device based on form inputs
                CreatedDevice = new Device
                {

                    DeviceID = Guid.NewGuid().ToString(),  // Auto generated ID
                    RackID = txtAddRack.Text,
                    PodID = txtAddPod.Text,
                    Type = (DeviceType)comboBoxAddDeviceType.SelectedItem,
                    DeviceName = txtAddDeviceName.Text

                };

            // Tell the main form we successfully created a device
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAddRack_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
