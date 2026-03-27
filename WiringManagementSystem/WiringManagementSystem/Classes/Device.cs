using WiringManagementSystem.Classes.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiringManagementSystem.Classes
{
    internal class Device
    {
        public required string DeviceID { get; set; }
        public required string DeviceName { get; set; }
        public required DeviceType Type { get; set; }
        public string? RackID { get; set; }
        public Dictionary</*PortID*/string, /*ConnectedPortID*/string?>? Ports { get; set; }
        // Figure out how to implement outlets, maybe they inherit Port?
        public Dictionary<string, string?>? Outlets { get; set; }

        public Device GetDeviceByID(string deviceID)
        {
            // Implementation to retrieve a device by its ID from the database
            // SEED DATA FIRST, THEN IMPLEMENT THIS METHOD
            return new Device(); // Placeholder return statement
        }
    }
}
