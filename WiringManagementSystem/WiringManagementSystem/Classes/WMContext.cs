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
            modelBuilder.Entity<Rack>().HasData(
                new Rack { RackID = "RK01", RackName = "Rack 1" },
                new Rack { RackID = "RK02", RackName = "Rack 2" },
                new Rack { RackID = "RK03", RackName = "Rack 3" },
                new Rack { RackID = "RK04", RackName = "Rack 4" },
                new Rack { RackID = "RK05", RackName = "Rack 5" },
                new Rack { RackID = "RK06", RackName = "Rack 6" }
                );

            modelBuilder.Entity<Device>().HasData(
                // Rack 1 devices
                new Device { DeviceID = "PODA", DeviceName = "Pod A", Type = Enums.DeviceType.Pod, RackID = "RK01" }, // pod A
                new Device { DeviceID = "PODB", DeviceName = "Pod B", Type = Enums.DeviceType.Pod, RackID = "RK01" }, // pod B
                new Device { DeviceID = "PODC", DeviceName = "Pod C", Type = Enums.DeviceType.Pod, RackID = "RK01" }, // pod C
                new Device { DeviceID = "PODD", DeviceName = "Pod D", Type = Enums.DeviceType.Pod, RackID = "RK01" }, // pod D
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = "RK01" },
                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = "RK01" },
                new Device { DeviceID = "FRWA", DeviceName = "ASA 5505 Series Firewall - Bloc A", Type = Enums.DeviceType.Firewall, RackID = "RK01" },
                new Device { DeviceID = "FRWB", DeviceName = "ASA 5505 Series Firewall - Bloc B", Type = Enums.DeviceType.Firewall, RackID = "RK01" },
                new Device { DeviceID = "FRWC", DeviceName = "ASA 5505 Series Firewall - Bloc C", Type = Enums.DeviceType.Firewall, RackID = "RK01" },
                new Device { DeviceID = "FRWD", DeviceName = "ASA 5505 Series Firewall - Bloc D", Type = Enums.DeviceType.Firewall, RackID = "RK01" },

                // POD A devices
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = "RK01", PodID = "PODA" }, // router 1
                new Device { DeviceID = "RT02", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = "RK01", PodID = "PODA" }, // router 2
                new Device { DeviceID = "RT03", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = "RK01", PodID = "PODA" }, // router 3

                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = "RK01", PodID = "PODA" }, // switch 1
                new Device { DeviceID = "SW02", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = "RK01", PodID = "PODA" }, // switch 2
                new Device { DeviceID = "SW03", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = "RK01", PodID = "PODA" }, // switch 3

                // POD B devices
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = "RK01", PodID = "PODB" }, // router 1
                new Device { DeviceID = "RT02", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = "RK01", PodID = "PODB" }, // router 2
                new Device { DeviceID = "RT03", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = "RK01", PodID = "PODB" }, // router 3

                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = "RK01", PodID = "PODB" }, // switch 1
                new Device { DeviceID = "SW02", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = "RK01", PodID = "PODB" }, // switch 2
                new Device { DeviceID = "SW03", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = "RK01", PodID = "PODB" }, // switch 3

                // POD C devices
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = "RK01", PodID = "PODC" }, // router 1
                new Device { DeviceID = "RT02", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = "RK01", PodID = "PODC" }, // router 2
                new Device { DeviceID = "RT03", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = "RK01", PodID = "PODC" }, // router 3

                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = "RK01", PodID = "PODC" }, // switch 1
                new Device { DeviceID = "SW02", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = "RK01", PodID = "PODC" }, // switch 2
                new Device { DeviceID = "SW03", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = "RK01", PodID = "PODC" }, // switch 3

                // POD D devices
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = "RK01", PodID = "PODD" }, // router 1
                new Device { DeviceID = "RT02", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = "RK01", PodID = "PODD" }, // router 2
                new Device { DeviceID = "RT03", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = "RK01", PodID = "PODD" }, // router 3

                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = "RK01", PodID = "PODD" }, // switch 1
                new Device { DeviceID = "SW02", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = "RK01", PodID = "PODD" }, // switch 2
                new Device { DeviceID = "SW03", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = "RK01", PodID = "PODD" }, // switch 3
                
                // Rack 2 devices


                // Rack 3 devices
                new Device { DeviceID = "SRVMGMT", DeviceName = "Management Server", Type = Enums.DeviceType.Server, RackID = "RK03" }, // management server
                new Device { DeviceID = "SRV01", DeviceName = "Host 1 Server", Type = Enums.DeviceType.Server, RackID = "RK03" }, // host 1 server
                new Device { DeviceID = "SRV02", DeviceName = "Host 2 Server", Type = Enums.DeviceType.Server, RackID = "RK03" }, // host 2 server
                new Device { DeviceID = "SWMGMT", DeviceName = "Management Switch", Type = Enums.DeviceType.Switch, RackID = "RK03" }, // management switch
                new Device { DeviceID = "SWCLST", DeviceName = "Cluster Switch", Type = Enums.DeviceType.Switch, RackID = "RK03" }, // cluster switch
                new Device { DeviceID = "SWCTRL", DeviceName = "NL Control Switch", Type = Enums.DeviceType.Switch, RackID = "RK03" }, // NL control switch
                new Device { DeviceID = "SRVBCK", DeviceName = "Backup Server", Type = Enums.DeviceType.Server, RackID = "RK03" } // backup server
                );
        }
    }
}
