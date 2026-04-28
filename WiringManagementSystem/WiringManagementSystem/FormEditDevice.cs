using System.Data;
using WiringManagementSystem.Classes;

namespace WiringManagementSystem
{
    public partial class FrmEditDevice : Form
    {
        public Device EditedDevice { get; private set; }

        public List<Device> pods;

        private string originalDeviceId;

        private readonly string originalDeviceNotes;

        public FrmEditDevice(Device deviceToEdit)
        {
            InitializeComponent();

            WMContext WMDB = new WMContext();

            pods = WMDB.Devices.Where(d => d.Type == DeviceType.Pod).ToList();

            // Save the ID
            originalDeviceId = deviceToEdit.DeviceID;
            originalDeviceNotes = deviceToEdit.Notes;

            // Load Device Types enum into the dropdown
            cmbEditDeviceType.DataSource = Enum.GetValues(typeof(DeviceType));

            // Load Racks and Pods from the database
            using (WMDB)
            {
                var racks = WMDB.Racks.ToList();
                cmbEditRack.DataSource = racks;
                cmbEditRack.DisplayMember = "RackName";
                cmbEditRack.ValueMember = "RackID";

                pods.Insert(0, new Device { DeviceID = "", DeviceName = "--- No Pod ---", Type = DeviceType.Pod, RackID = "" });
                cmbEditPod.DisplayMember = "DeviceName";
                cmbEditPod.ValueMember = "DeviceID";
            }

            // Pre-fill screen with the existing device's data
            txtEditDeviceName.Text = deviceToEdit.DeviceName;
            cmbEditDeviceType.SelectedItem = deviceToEdit.Type;
            cmbEditRack.SelectedValue = deviceToEdit.RackID;
            cmbEditPod.DataSource = pods.Where(p => p.RackID == cmbEditRack.SelectedValue.ToString() || string.IsNullOrEmpty(p.RackID)).ToList();
            cmbEditPod.SelectedValue = string.IsNullOrEmpty(deviceToEdit.PodID) ? "" : deviceToEdit.PodID;

            if (deviceToEdit.Type == DeviceType.Pod)
            {
                cmbEditPod.Enabled = false;
            }
        }

        private void cmbEditRack_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEditPod.DataSource = pods.Where(d => (d.RackID == cmbEditRack.SelectedValue.ToString() && d.Type == DeviceType.Pod) || string.IsNullOrEmpty(d.RackID)).ToList();
        }

        private void cmdEditDeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the user selects "Pod" as the device type, disable the Pod dropdown since a pod can't belong to another pod
            if ((DeviceType)cmbEditDeviceType.SelectedItem == DeviceType.Pod)
            {
                cmbEditPod.SelectedValue = ""; // Reset to "No Pod" option
                cmbEditPod.Enabled = false;
            }
            else
            {
                cmbEditPod.Enabled = true;
            }
        }

        // Saves changes and closes the form with DialogResult.OK. The calling code will handle the actual database update.
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEditDeviceName.Text))
            {
                MessageBox.Show("Please enter a device name.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedPodId = cmbEditPod.SelectedValue?.ToString();

            // Package up the new details into a Device object using the original ID 
            EditedDevice = new Device
            {
                DeviceID = originalDeviceId,
                RackID = cmbEditRack.SelectedValue?.ToString(),
                PodID = string.IsNullOrEmpty(selectedPodId) ? null : selectedPodId,
                Type = (DeviceType)cmbEditDeviceType.SelectedItem,
                DeviceName = txtEditDeviceName.Text,
                Notes = originalDeviceNotes
            };
            using (var WMDB = new WMContext())
            {
                var row = WMDB.Devices.FirstOrDefault(d => d.DeviceID == EditedDevice.DeviceID);
                if (row != null)
                {
                    row.DeviceName = EditedDevice.DeviceName;
                    row.Type = EditedDevice.Type;
                    row.RackID = EditedDevice.RackID;
                    row.PodID = EditedDevice.PodID;
                    row.Notes = EditedDevice.Notes;
                    WMDB.SaveChanges();
                }
            }

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
