using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiringManagementSystem.Classes
{
    public class Device
    {
        public required string DeviceID { get; set; }
        public required string DeviceName { get; set; }
        public required DeviceType Type { get; set; }
        public string? RackID { get; set; }

        public string? PodID { get; set; } // Optional property to associate a device with a pod

        public Device GetDeviceByID(string deviceID)
        {
            // Implementation to retrieve a device by its ID from the database
            // SEED DATA FIRST, THEN IMPLEMENT THIS METHOD
            // Fixed: Provide non-null values for required parameters and properties
            return new Device
            {
                DeviceID = "PlaceholderID",
                DeviceName = "PlaceholderName",
                Type = DeviceType.Router,
                RackID = string.Empty,
                PodID = string.Empty
            };
        }
    }
}
