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
        //public Rack GetRackByID(string rackID)
        //{
        //    return new Rack();
        //}
    }
}
