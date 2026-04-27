using WiringManagementSystem.Classes;

namespace WiringManagementSystem
{
    public partial class FrmAddDevice : Form
    {
        // Setup Pod Dropdown
        // Had to move pod declaration here to be able to access the "No Pod" device from anywhere in the form
        public List<Device> pods = new List<Device>();

        public Device CreatedDevice { get; private set; }

        public FrmAddDevice(string existingRackId, string existingPodId)
        {
            InitializeComponent();

            // Load the device type enum into the dropdown
            cmbAddDeviceType.DataSource = Enum.GetValues(typeof(DeviceType));

            // Load Racks and Pods from the database into the dropdowns
            using (WMContext ctx = new WMContext())
            {
                pods = ctx.Devices.Where(d => d.Type == DeviceType.Pod).ToList();

                // Setup Rack Dropdown
                var racks = ctx.Racks.ToList();
                cmbAddRack.DataSource = racks;
                cmbAddRack.DisplayMember = "RackName";
                cmbAddRack.ValueMember = "RackID";

                // Add a "Blank" option for devices that don't belong in a pod
                pods.Insert(0, new Device { DeviceID = "", DeviceName = "--- No Pod ---", Type = DeviceType.Pod, RackID = "" });
                cmbAddPod.DataSource = pods.Where(p => p.RackID == cmbAddRack.SelectedValue.ToString() || string.IsNullOrEmpty(p.RackID)).ToList();
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

        // When the user changes the rack selection, only allows pods that are in the selected rack
        private void cmbAddRack_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rackId = cmbAddRack.SelectedValue?.ToString() ?? "Rack1";
            cmbAddPod.DataSource = pods
                .Where(d => (d.RackID == rackId && d.Type == DeviceType.Pod) || string.IsNullOrEmpty(d.RackID))
                .ToList();
        }

        // When the user changes the device type selection, disable the Pod dropdown if they select "Pod" since a pod can't belong to another pod
        private void cmdAddDeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the user selects "Pod" as the device type, disable the Pod dropdown since a pod can't belong to another pod
            if ((DeviceType)cmbAddDeviceType.SelectedItem == DeviceType.Pod)
            {
                cmbAddPod.SelectedValue = ""; // Reset to "No Pod" option
                cmbAddPod.Enabled = false;
            }
            else
            {
                cmbAddPod.Enabled = true;
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

            // Just incase the combobox gets set to an incorrect value
            if (cmbAddDeviceType.SelectedItem == null)
            {
                MessageBox.Show("Please select a device type.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Build new device based on form inputs
            CreatedDevice = new Device
            {
                DeviceID = Guid.NewGuid().ToString(),
                RackID = cmbAddRack.SelectedValue?.ToString(),
                PodID = string.IsNullOrEmpty(selectedPodId) ? null : selectedPodId,
                Type = (DeviceType)cmbAddDeviceType.SelectedItem,
                DeviceName = txtAddDeviceName.Text
            };

            using (WMContext ctx = new WMContext())
            {
                ctx.Devices.Add(CreatedDevice);
                ctx.SaveChanges();
            }

            // Tell the main form we successfully created a device
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