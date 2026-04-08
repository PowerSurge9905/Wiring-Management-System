using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WiringManagementSystem.Classes
{
    internal class WMContext : DbContext
    {
        public DbSet<Rack> Racks { get; set; }
        public DbSet<Device> Devices { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add seed data later

            modelBuilder.Entity<Rack>().HasData(
                //new Rack { RackID = "R1", RackName = "RK01" },
                //new Rack { RackID = "R2", RackName = "RK02" },
                new Rack { RackID = "R3", RackName = "RK03" }//,
                //new Rack { RackID = "R4", RackName = "RK04" },
                //new Rack { RackID = "R5", RackName = "RK05" },
                //new Rack { RackID = "R6", RackName = "RK06" }
                );

            modelBuilder.Entity<Device>().HasData(
               new Device { DeviceID = "D1", DeviceName = "SRV01", Type = Enums.DeviceType.Server, RackID = "R3`" }, //management server
               new Device { DeviceID = "D2", DeviceName = "SRV02", Type = Enums.DeviceType.Server, RackID = "R3" }, //host 1 server
               new Device { DeviceID = "D3", DeviceName = "SRV02", Type = Enums.DeviceType.Server, RackID = "R3" }, //host 2 server
               new Device { DeviceID = "D3", DeviceName = "SW01", Type = Enums.DeviceType.Switch, RackID = "R3" }, //management switch
               new Device { DeviceID = "D4", DeviceName = "SW02", Type = Enums.DeviceType.Switch, RackID = "R3" }, //cluster switch
               new Device { DeviceID = "D5", DeviceName = "SW03", Type = Enums.DeviceType.Switch, RackID = "R3" }, //NL control switch
               new Device { DeviceID = "D6", DeviceName = "SRV02", Type = Enums.DeviceType.Server, RackID = "R3" }, //backup server
               new Device { DeviceID = "D7", DeviceName = "POD01", Type = Enums.DeviceType.Pod, RackID = "R3" } //pod1
               
               );
        }

    }
}
