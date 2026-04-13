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

        public string Rack1ID { get; } = "RK01";
        public string Rack2ID { get; } = "RK02";
        public string Rack3ID { get; } = "RK03";
        public string Rack4ID { get; } = "RK04";
        public string Rack5ID { get; } = "RK05";
        public string Rack6ID { get; } = "RK06";
        public string PodAID { get; } = "PODA";
        public string PodBID { get; } = "PODB";
        public string PodCID { get; } = "PODC";
        public string PodDID { get; } = "PODD";
        public string PodEID { get; } = "PODE";
        public string PodFID { get; } = "PODF";
        public string PodGID { get; } = "PODG";
        public string PodHID { get; } = "PODH";
        public string PodIID { get; } = "PODI";
        public string PodJID { get; } = "PODJ";
        public string PodKID { get; } = "PODK";
        public string PodLID { get; } = "PODL";
        public string PodMID { get; } = "PODM";
        public string PodNID { get; } = "PODN";
        public string PodOID { get; } = "PODO";
        public string PodPID { get; } = "PODP";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rack>().HasData(
                new Rack { RackID = Rack1ID, RackName = "Rack 1" },
                new Rack { RackID = Rack2ID, RackName = "Rack 2" },
                new Rack { RackID = Rack3ID, RackName = "Rack 3" },
                new Rack { RackID = Rack4ID, RackName = "Rack 4" },
                new Rack { RackID = Rack5ID, RackName = "Rack 5" },
                new Rack { RackID = Rack6ID, RackName = "Rack 6" }
                );

            modelBuilder.Entity<Device>().HasData(
                // Rack 1 devices
                new Device { DeviceID = PodAID, DeviceName = "Pod A", Type = Enums.DeviceType.Pod, RackID = Rack1ID }, // pod A
                new Device { DeviceID = PodBID, DeviceName = "Pod B", Type = Enums.DeviceType.Pod, RackID = Rack1ID }, // pod B
                new Device { DeviceID = PodCID, DeviceName = "Pod C", Type = Enums.DeviceType.Pod, RackID = Rack1ID }, // pod C
                new Device { DeviceID = PodDID, DeviceName = "Pod D", Type = Enums.DeviceType.Pod, RackID = Rack1ID }, // pod D
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = Rack1ID },
                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = Rack1ID },
                new Device { DeviceID = "FRWA", DeviceName = "ASA 5505 Series Firewall - Bloc A", Type = Enums.DeviceType.Firewall, RackID = Rack1ID },
                new Device { DeviceID = "FRWB", DeviceName = "ASA 5505 Series Firewall - Bloc B", Type = Enums.DeviceType.Firewall, RackID = Rack1ID },
                new Device { DeviceID = "FRWC", DeviceName = "ASA 5505 Series Firewall - Bloc C", Type = Enums.DeviceType.Firewall, RackID = Rack1ID },
                new Device { DeviceID = "FRWD", DeviceName = "ASA 5505 Series Firewall - Bloc D", Type = Enums.DeviceType.Firewall, RackID = Rack1ID },

                // POD A devices
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = Rack1ID, PodID = PodAID }, // router 1
                new Device { DeviceID = "RT02", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = Rack1ID, PodID = PodAID }, // router 2
                new Device { DeviceID = "RT03", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = Rack1ID, PodID = PodAID }, // router 3

                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = Rack1ID, PodID = PodAID }, // switch 1
                new Device { DeviceID = "SW02", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = Rack1ID, PodID = PodAID }, // switch 2
                new Device { DeviceID = "SW03", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = Rack1ID, PodID = PodAID }, // switch 3

                // POD B devices
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = Rack1ID, PodID = PodBID }, // router 1
                new Device { DeviceID = "RT02", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = Rack1ID, PodID = PodBID }, // router 2
                new Device { DeviceID = "RT03", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = Rack1ID, PodID = PodBID }, // router 3

                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = Rack1ID, PodID = PodBID }, // switch 1
                new Device { DeviceID = "SW02", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = Rack1ID, PodID = PodBID }, // switch 2
                new Device { DeviceID = "SW03", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = Rack1ID, PodID = PodBID }, // switch 3

                // POD C devices
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = Rack1ID, PodID = PodCID }, // router 1
                new Device { DeviceID = "RT02", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = Rack1ID, PodID = PodCID }, // router 2
                new Device { DeviceID = "RT03", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = Rack1ID, PodID = PodCID }, // router 3

                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = Rack1ID, PodID = PodCID }, // switch 1
                new Device { DeviceID = "SW02", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = Rack1ID, PodID = PodCID }, // switch 2
                new Device { DeviceID = "SW03", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = Rack1ID, PodID = PodCID }, // switch 3

                // POD D devices
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = Rack1ID, PodID = PodDID }, // router 1
                new Device { DeviceID = "RT02", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = Rack1ID, PodID = PodDID }, // router 2
                new Device { DeviceID = "RT03", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = Rack1ID, PodID = PodDID }, // router 3

                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = Rack1ID, PodID = PodDID }, // switch 1
                new Device { DeviceID = "SW02", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = Rack1ID, PodID = PodDID }, // switch 2
                new Device { DeviceID = "SW03", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = Rack1ID, PodID = PodDID }, // switch 3

                // End of Rack 1 devices

                // Rack 2 devices

                // End of Rack 2 devices

                // Rack 3 devices
                new Device { DeviceID = "SRVMGMT", DeviceName = "Management Server", Type = Enums.DeviceType.Server, RackID = Rack3ID }, // management server
                new Device { DeviceID = "SRV01", DeviceName = "Host 1 Server", Type = Enums.DeviceType.Server, RackID = Rack3ID }, // host 1 server
                new Device { DeviceID = "SRV02", DeviceName = "Host 2 Server", Type = Enums.DeviceType.Server, RackID = Rack3ID }, // host 2 server
                new Device { DeviceID = "SWMGMT", DeviceName = "Management Switch", Type = Enums.DeviceType.Switch, RackID = Rack3ID }, // management switch
                new Device { DeviceID = "SWCLST", DeviceName = "Cluster Switch", Type = Enums.DeviceType.Switch, RackID = Rack3ID }, // cluster switch
                new Device { DeviceID = "SWCTRL", DeviceName = "NL Control Switch", Type = Enums.DeviceType.Switch, RackID = Rack3ID }, // NL control switch
                new Device { DeviceID = "SRVBCK", DeviceName = "Backup Server", Type = Enums.DeviceType.Server, RackID = Rack3ID }, // backup server

                // End of Rack 3 devices

                // Rack 4 devices
                new Device { DeviceID = "PODI", DeviceName = "Pod I", Type = Enums.DeviceType.Pod, RackID = Rack4ID }, // pod I
                new Device { DeviceID = "PODJ", DeviceName = "Pod J", Type = Enums.DeviceType.Pod, RackID = Rack4ID }, // pod J
                new Device { DeviceID = "PODK", DeviceName = "Pod K", Type = Enums.DeviceType.Pod, RackID = Rack4ID }, // pod K
                new Device { DeviceID = "PODL", DeviceName = "Pod L", Type = Enums.DeviceType.Pod, RackID = Rack4ID }, // pod L
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, RackID = Rack4ID },
                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, RackID = Rack4ID },
                new Device { DeviceID = "FRWI", DeviceName = "ASA 5505 Series Firewall - Bloc I", Type = Enums.DeviceType.Firewall, RackID = Rack4ID },
                new Device { DeviceID = "FRWJ", DeviceName = "ASA 5505 Series Firewall - Bloc J", Type = Enums.DeviceType.Firewall, RackID = Rack4ID },
                new Device { DeviceID = "FRWK", DeviceName = "ASA 5505 Series Firewall - Bloc K", Type = Enums.DeviceType.Firewall, RackID = Rack4ID },
                new Device { DeviceID = "FRWL", DeviceName = "ASA 5505 Series Firewall - Bloc L", Type = Enums.DeviceType.Firewall, RackID = Rack4ID },

                // Pod I devices
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, PodID = PodIID, RackID = Rack4ID },
                new Device { DeviceID = "RT02", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, PodID = PodIID, RackID = Rack4ID },
                new Device { DeviceID = "RT03", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, PodID = PodIID, RackID = Rack4ID },
                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, PodID = PodIID, RackID = Rack4ID },
                new Device { DeviceID = "SW02", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, PodID = PodIID, RackID = Rack4ID },
                new Device { DeviceID = "SW03", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, PodID = PodIID, RackID = Rack4ID },

                // Pod J devices
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, PodID = PodJID, RackID = Rack4ID },
                new Device { DeviceID = "RT02", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, PodID = PodJID, RackID = Rack4ID },
                new Device { DeviceID = "RT03", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, PodID = PodJID, RackID = Rack4ID },
                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, PodID = PodJID, RackID = Rack4ID },
                new Device { DeviceID = "SW02", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, PodID = PodJID, RackID = Rack4ID },
                new Device { DeviceID = "SW03", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, PodID = PodJID, RackID = Rack4ID },

                // Pod K devices
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, PodID = PodKID, RackID = Rack4ID },
                new Device { DeviceID = "RT02", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, PodID = PodKID, RackID = Rack4ID },
                new Device { DeviceID = "RT03", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, PodID = PodKID, RackID = Rack4ID },
                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, PodID = PodKID, RackID = Rack4ID },
                new Device { DeviceID = "SW02", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, PodID = PodKID, RackID = Rack4ID },
                new Device { DeviceID = "SW03", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, PodID = PodKID, RackID = Rack4ID },

                // Pod L devices
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, PodID = PodLID, RackID = Rack4ID },
                new Device { DeviceID = "RT02", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, PodID = PodLID, RackID = Rack4ID },
                new Device { DeviceID = "RT03", DeviceName = "Cisco 1900 Series Router", Type = Enums.DeviceType.Router, PodID = PodLID, RackID = Rack4ID },
                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, PodID = PodLID, RackID = Rack4ID },
                new Device { DeviceID = "SW02", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, PodID = PodLID, RackID = Rack4ID },
                new Device { DeviceID = "SW03", DeviceName = "Catalyst 2900 Plus Series Switch", Type = Enums.DeviceType.Switch, PodID = PodLID, RackID = Rack4ID },

                // End of Rack 4 devices

                // Rack 5 devices

                // End of Rack 5 devices
                );
        }
    }
}
