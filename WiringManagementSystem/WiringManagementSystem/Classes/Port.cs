using WiringManagementSystem.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiringManagementSystem.Classes
{
    internal class Port
    {
        public required string PortID { get; set; }
        public required string PortName { get; set; }
        public string? Connection { get; set; }
        public required PortStatus Status { get; set; }
        public Port GetPortByID(string portID)
        {
            // Implementation to retrieve a port by its ID from the database
            // SEED DATA FIRST, THEN IMPLEMENT THIS METHOD
            return new Port(); // Placeholder return statement
        }
        public string BuildPortID(string RackID, string DeviceID)
        {
            // Implementation to build a unique PortID based on RackID and DeviceID
            // FIGURE OUT ADDRESS STUCTURE, THEN IMPLEMENT THIS METHOD
            return $"{RackID}-{DeviceID}-Port"; // Placeholder return statement
        }
    }
}
