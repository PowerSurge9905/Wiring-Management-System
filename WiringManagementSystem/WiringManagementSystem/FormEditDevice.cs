using System.Data;
using WiringManagementSystem.Classes;

namespace WiringManagementSystem
{
    public partial class FrmEditDevice : Form
    {
        public Device EditedDevice { get; private set; }

        private string originalDeviceId;

        public FrmEditDevice(Device deviceToEdit)
        {
            InitializeComponent();

            // Save the ID
            originalDeviceId = deviceToEdit.DeviceID;

            // Load Device Types enum into the dropdown
            cmbEditDeviceType.DataSource = Enum.GetValues(typeof(DeviceType));

            // Load Racks and Pods from the database
            using (WMContext db = new WMContext())
            {
                var racks = db.Racks.ToList();
                cmbEditRack.DataSource = racks;
                cmbEditRack.DisplayMember = "RackName";
                cmbEditRack.ValueMember = "RackID";

                var pods = db.Devices.Where(d => d.Type == DeviceType.Pod).ToList();
                pods.Insert(0, new Device { DeviceID = "", DeviceName = "--- No Pod ---", Type = DeviceType.Pod, RackID = "" });
                cmbEditPod.DataSource = pods;
                cmbEditPod.DisplayMember = "DeviceName";
                cmbEditPod.ValueMember = "DeviceID";
            }

            // Pre-fill screen with the existing device's data
            txtEditDeviceName.Text = deviceToEdit.DeviceName;
            cmbEditDeviceType.SelectedItem = deviceToEdit.Type;
            cmbEditRack.SelectedValue = deviceToEdit.RackID;
            cmbEditPod.SelectedValue = string.IsNullOrEmpty(deviceToEdit.PodID) ? "" : deviceToEdit.PodID;
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
                DeviceName = txtEditDeviceName.Text
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmEditDevice_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
