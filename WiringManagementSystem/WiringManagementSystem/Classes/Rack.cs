using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiringManagementSystem.Classes
{
    internal class Rack
    {
        public required string RackID { get; set; }
        public required string RackName { get; set; }
        public List<string>? DevicesID { get; set; }
        public List<Device>? Devices { get; set; }
        public Rack GetRackByID(string rackID)
        {
            // Implementation to retrieve a rack by its ID from the database
            return new Rack
            {
                RackID = "PlaceholderID",
                RackName = "PlaceholderName",
                DevicesID = new List<string>(),
                Devices = new List<Device>()
            }; // Placeholder return statement
        }
    }
}
