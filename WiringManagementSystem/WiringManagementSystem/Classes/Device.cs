namespace WiringManagementSystem.Classes
{
    public class Device
    {
        public required string DeviceID { get; set; }
        public required string DeviceName { get; set; }
        public required DeviceType Type { get; set; }
        public string? RackID { get; set; }

        public string? PodID { get; set; } // Optional property to associate a device with a pod

        public List<string>? Notes { get; set; } // Optional property to store connections to other devices
    }
}
