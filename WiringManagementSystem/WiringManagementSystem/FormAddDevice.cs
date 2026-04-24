using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WiringManagementSystem.Classes;

namespace WiringManagementSystem
{
    public partial class FrmAddDevice : Form
    {
        public Device CreatedDevice { get; private set; }

        public FrmAddDevice(string existingRackId, string existingPodId)
        {
            InitializeComponent();

            // Load the device type enum into the dropdown
            cmbAddDeviceType.DataSource = Enum.GetValues(typeof(DeviceType));

            // Load Racks and Pods from the database into the dropdowns
            using (WMContext db = new WMContext())
            {
                // Setup Rack Dropdown
                var racks = db.Racks.ToList();
                cmbAddRack.DataSource = racks;
                cmbAddRack.DisplayMember = "RackName";
                cmbAddRack.ValueMember = "RackID";

                // Setup Pod Dropdown
                var pods = db.Devices.Where(d => d.Type == DeviceType.Pod).ToList();

                // Add a "Blank" option for devices that don't belong in a pod
                pods.Insert(0, new Device { DeviceID = "", DeviceName = "--- No Pod ---", Type = DeviceType.Pod, RackID = "" });

                cmbAddPod.DataSource = pods;
                cmbAddPod.DisplayMember = "DeviceName";
                cmbAddPod.ValueMember = "DeviceID";
            }

            // Auto-Select the dropdowns based on what the user clicked in the main form
            if (!string.IsNullOrEmpty(existingRackId))
            {
                cmbAddRack.SelectedValue = existingRackId;
            }

            if (!string.IsNullOrEmpty(existingPodId))
            {
                cmbAddPod.SelectedValue = existingPodId;
            }
            else
            {
                cmbAddPod.SelectedValue = ""; // Select the "--- No Pod ---" option by default
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Prevent the user from saving a blank device name
            if (string.IsNullOrWhiteSpace(txtAddDeviceName.Text))
            {
                MessageBox.Show("Please enter a device name.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Grab the hidden Pod ID from the dropdown
            string selectedPodId = cmbAddPod.SelectedValue?.ToString();

            // Build new device based on form inputs
            CreatedDevice = new Device
            {
                DeviceID = Guid.NewGuid().ToString(),
                RackID = cmbAddRack.SelectedValue?.ToString(),
                PodID = string.IsNullOrEmpty(selectedPodId) ? null : selectedPodId,
                Type = (DeviceType)cmbAddDeviceType.SelectedItem,
                DeviceName = txtAddDeviceName.Text

                
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}