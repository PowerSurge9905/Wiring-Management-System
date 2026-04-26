using Microsoft.EntityFrameworkCore;

namespace WiringManagementSystem.Classes
{
    public class WMContext : DbContext
    {
        public WMContext()
        {
        }

        public WMContext(DbContextOptions<WMContext> options)
            : base(options)
        {
        }

        //readonly string connectionString = $"Data Source={Path.Combine(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\")), "WMDB.sqlite")}";
        readonly string connectionString = "Data Source=WMDB.sqlite";

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(Globals.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rack>().HasData(
                new Rack { RackID = Rack1ID, RackName = "Rack 1", Notes = new List<string> { "Note1", "Note2" } },
                new Rack { RackID = Rack2ID, RackName = "Rack 2" },
                new Rack { RackID = Rack3ID, RackName = "Rack 3" },
                new Rack { RackID = Rack4ID, RackName = "Rack 4" },
                new Rack { RackID = Rack5ID, RackName = "Rack 5" },
                new Rack { RackID = Rack6ID, RackName = "Rack 6" }
                );

            modelBuilder.Entity<Device>().HasData(
                // Rack 1 devices
                new Device { DeviceID = PodAID, DeviceName = "Pod A", Type = DeviceType.Pod, RackID = Rack1ID }, // Pod A
                new Device { DeviceID = PodBID, DeviceName = "Pod B", Type = DeviceType.Pod, RackID = Rack1ID }, // Pod B
                new Device { DeviceID = PodCID, DeviceName = "Pod C", Type = DeviceType.Pod, RackID = Rack1ID }, // Pod C
                new Device { DeviceID = PodDID, DeviceName = "Pod D", Type = DeviceType.Pod, RackID = Rack1ID }, // Pod D
                new Device { DeviceID = "RT00", DeviceName = "Cisco 1900 Series Router - Rack 1", Type = DeviceType.Router, RackID = Rack1ID},
                new Device { DeviceID = "SW00", DeviceName = "Catalyst 2900 Plus Series Switch - Rack 1", Type = DeviceType.Switch, RackID = Rack1ID },
                new Device { DeviceID = "FRWA", DeviceName = "ASA 5505 Series Firewall - Bloc A", Type = DeviceType.Firewall, RackID = Rack1ID }, // Pod A firewall
                new Device { DeviceID = "FRWB", DeviceName = "ASA 5505 Series Firewall - Bloc B", Type = DeviceType.Firewall, RackID = Rack1ID }, // Pod B firewall
                new Device { DeviceID = "FRWC", DeviceName = "ASA 5505 Series Firewall - Bloc C", Type = DeviceType.Firewall, RackID = Rack1ID }, // Pod C firewall
                new Device { DeviceID = "FRWD", DeviceName = "ASA 5505 Series Firewall - Bloc D", Type = DeviceType.Firewall, RackID = Rack1ID }, // Pod D firewall

                // POD A devices
                new Device { DeviceID = "RT01", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack1ID, PodID = PodAID }, // Pod A, router 1
                new Device { DeviceID = "RT02", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack1ID, PodID = PodAID }, // Pod A, router 2
                new Device { DeviceID = "RT03", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack1ID, PodID = PodAID }, // Pod A, router 3
                new Device { DeviceID = "SW01", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack1ID, PodID = PodAID }, // Pod A, switch 1
                new Device { DeviceID = "SW02", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack1ID, PodID = PodAID }, // Pod A, switch 2
                new Device { DeviceID = "SW03", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack1ID, PodID = PodAID }, // Pod A, switch 3

                // POD B devices
                new Device { DeviceID = "RT04", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack1ID, PodID = PodBID }, // Pod B, router 1
                new Device { DeviceID = "RT05", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack1ID, PodID = PodBID }, // Pod B, router 2
                new Device { DeviceID = "RT06", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack1ID, PodID = PodBID }, // Pod B, router 3
                new Device { DeviceID = "SW04", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack1ID, PodID = PodBID }, // Pod B, switch 1
                new Device { DeviceID = "SW05", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack1ID, PodID = PodBID }, // Pod B, switch 2
                new Device { DeviceID = "SW06", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack1ID, PodID = PodBID }, // Pod B, switch 3

                // POD C devices
                new Device { DeviceID = "RT07", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack1ID, PodID = PodCID }, // Pod C, router 1
                new Device { DeviceID = "RT08", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack1ID, PodID = PodCID }, // Pod C, router 2
                new Device { DeviceID = "RT09", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack1ID, PodID = PodCID }, // Pod C, router 3
                new Device { DeviceID = "SW07", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack1ID, PodID = PodCID }, // Pod C, switch 1
                new Device { DeviceID = "SW08", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack1ID, PodID = PodCID }, // Pod C, switch 2
                new Device { DeviceID = "SW09", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack1ID, PodID = PodCID }, // Pod C, switch 3

                // POD D devices
                new Device { DeviceID = "RT10", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack1ID, PodID = PodDID }, // Pod D, router 1
                new Device { DeviceID = "RT11", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack1ID, PodID = PodDID }, // Pod D, router 2
                new Device { DeviceID = "RT12", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack1ID, PodID = PodDID }, // Pod D, router 3
                new Device { DeviceID = "SW10", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack1ID, PodID = PodDID }, // Pod D, switch 1
                new Device { DeviceID = "SW11", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack1ID, PodID = PodDID }, // Pod D, switch 2
                new Device { DeviceID = "SW12", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack1ID, PodID = PodDID }, // Pod D, switch 3
                // End of Rack 1 devices

                // Rack 2 devices
                new Device { DeviceID = PodEID, DeviceName = "Pod E", Type = DeviceType.Pod, RackID = Rack2ID }, // Pod E
                new Device { DeviceID = PodFID, DeviceName = "Pod F", Type = DeviceType.Pod, RackID = Rack2ID }, // Pod F
                new Device { DeviceID = PodGID, DeviceName = "Pod G", Type = DeviceType.Pod, RackID = Rack2ID }, // Pod G
                new Device { DeviceID = PodHID, DeviceName = "Pod H", Type = DeviceType.Pod, RackID = Rack2ID }, // Pod H
                new Device { DeviceID = "RT13", DeviceName = "Cisco 1900 Series Router - Rack 2", Type = DeviceType.Router, RackID = Rack2ID },
                new Device { DeviceID = "SW13", DeviceName = "Catalyst 2900 Plus Series Switch - Rack 2", Type = DeviceType.Switch, RackID = Rack2ID },
                new Device { DeviceID = "FRWE", DeviceName = "ASA 5505 Series Firewall - Bloc E", Type = DeviceType.Firewall, RackID = Rack2ID }, // Pod E firewall
                new Device { DeviceID = "FRWF", DeviceName = "ASA 5505 Series Firewall - Bloc F", Type = DeviceType.Firewall, RackID = Rack2ID }, // Pod F firewall
                new Device { DeviceID = "FRWG", DeviceName = "ASA 5505 Series Firewall - Bloc G", Type = DeviceType.Firewall, RackID = Rack2ID }, // Pod G firewall
                new Device { DeviceID = "FRWH", DeviceName = "ASA 5505 Series Firewall - Bloc H", Type = DeviceType.Firewall, RackID = Rack2ID }, // Pod H firewall

                // Pod E devices
                new Device { DeviceID = "RT14", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack2ID, PodID = PodEID }, // router 1
                new Device { DeviceID = "RT15", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack2ID, PodID = PodEID }, // router 2
                new Device { DeviceID = "RT16", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack2ID, PodID = PodEID }, // router 3
                new Device { DeviceID = "SW14", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack2ID, PodID = PodEID }, // switch 1
                new Device { DeviceID = "SW15", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack2ID, PodID = PodEID }, // switch 2
                new Device { DeviceID = "SW16", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack2ID, PodID = PodEID }, // switch 3

                // Pod F devices
                new Device { DeviceID = "RT17", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack2ID, PodID = PodFID }, // router 1
                new Device { DeviceID = "RT18", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack2ID, PodID = PodFID }, // router 2
                new Device { DeviceID = "RT19", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack2ID, PodID = PodFID }, // router 3
                new Device { DeviceID = "SW17", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack2ID, PodID = PodFID }, // switch 1
                new Device { DeviceID = "SW18", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack2ID, PodID = PodFID }, // switch 2
                new Device { DeviceID = "SW19", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack2ID, PodID = PodFID }, // switch 3

                // Pod G devices
                new Device { DeviceID = "RT20", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack2ID, PodID = PodGID }, // router 1
                new Device { DeviceID = "RT21", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack2ID, PodID = PodGID }, // router 2
                new Device { DeviceID = "RT22", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack2ID, PodID = PodGID }, // router 3
                new Device { DeviceID = "SW20", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack2ID, PodID = PodGID }, // switch 1
                new Device { DeviceID = "SW21", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack2ID, PodID = PodGID }, // switch 2
                new Device { DeviceID = "SW22", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack2ID, PodID = PodGID }, // switch 3

                // Pod H devices
                new Device { DeviceID = "RT23", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack2ID, PodID = PodHID }, // router 1
                new Device { DeviceID = "RT24", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack2ID, PodID = PodHID }, // router 2
                new Device { DeviceID = "RT25", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack2ID, PodID = PodHID }, // router 3
                new Device { DeviceID = "SW23", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack2ID, PodID = PodHID }, // switch 1
                new Device { DeviceID = "SW24", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack2ID, PodID = PodHID }, // switch 2
                new Device { DeviceID = "SW25", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack2ID, PodID = PodHID }, // switch 3
                // End of Rack 2 devices

                // Rack 3 devices
                new Device { DeviceID = "SRVMGMT", DeviceName = "Management Server", Type = DeviceType.Server, RackID = Rack3ID }, // management server
                new Device { DeviceID = "SRV01", DeviceName = "Host 1 Server", Type = DeviceType.Server, RackID = Rack3ID }, // host 1 server
                new Device { DeviceID = "SRV02", DeviceName = "Host 2 Server", Type = DeviceType.Server, RackID = Rack3ID }, // host 2 server
                new Device { DeviceID = "SWMGMT", DeviceName = "Management Switch", Type = DeviceType.Switch, RackID = Rack3ID }, // management switch
                new Device { DeviceID = "SWCLST", DeviceName = "Cluster Switch", Type = DeviceType.Switch, RackID = Rack3ID }, // cluster switch
                new Device { DeviceID = "SWCTRL", DeviceName = "NL Control Switch", Type = DeviceType.Switch, RackID = Rack3ID }, // NL control switch
                new Device { DeviceID = "SRVBCK", DeviceName = "Backup Server", Type = DeviceType.Server, RackID = Rack3ID }, // backup server
                // End of Rack 3 devices

                // Rack 4 devices
                new Device { DeviceID = PodIID, DeviceName = "Pod I", Type = DeviceType.Pod, RackID = Rack4ID }, // Pod I
                new Device { DeviceID = PodJID, DeviceName = "Pod J", Type = DeviceType.Pod, RackID = Rack4ID }, // Pod J
                new Device { DeviceID = PodKID, DeviceName = "Pod K", Type = DeviceType.Pod, RackID = Rack4ID }, // Pod K
                new Device { DeviceID = PodLID, DeviceName = "Pod L", Type = DeviceType.Pod, RackID = Rack4ID }, // Pod L
                new Device { DeviceID = "RT26", DeviceName = "Cisco 1900 Series Router - Rack 4", Type = DeviceType.Router, RackID = Rack4ID },
                new Device { DeviceID = "SW26", DeviceName = "Catalyst 2900 Plus Series Switch - Rack 4", Type = DeviceType.Switch, RackID = Rack4ID },
                new Device { DeviceID = "FRWI", DeviceName = "ASA 5505 Series Firewall - Bloc I", Type = DeviceType.Firewall, RackID = Rack4ID }, // Pod I firewall
                new Device { DeviceID = "FRWJ", DeviceName = "ASA 5505 Series Firewall - Bloc J", Type = DeviceType.Firewall, RackID = Rack4ID }, // Pod J firewall
                new Device { DeviceID = "FRWK", DeviceName = "ASA 5505 Series Firewall - Bloc K", Type = DeviceType.Firewall, RackID = Rack4ID }, // Pod K firewall
                new Device { DeviceID = "FRWL", DeviceName = "ASA 5505 Series Firewall - Bloc L", Type = DeviceType.Firewall, RackID = Rack4ID }, // Pod L firewall

                // Pod I devices
                new Device { DeviceID = "RT27", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack4ID, PodID = PodIID }, // Pod I, router 1
                new Device { DeviceID = "RT28", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack4ID, PodID = PodIID }, // Pod I, router 2
                new Device { DeviceID = "RT29", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack4ID, PodID = PodIID }, // Pod I, router 3
                new Device { DeviceID = "SW27", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack4ID, PodID = PodIID }, // Pod I, switch 1
                new Device { DeviceID = "SW28", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack4ID, PodID = PodIID }, // Pod I, switch 2
                new Device { DeviceID = "SW29", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack4ID, PodID = PodIID }, // Pod I, switch 3
                
                // Pod J devices
                new Device { DeviceID = "RT30", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack4ID, PodID = PodJID }, // Pod J, router 1
                new Device { DeviceID = "RT31", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack4ID, PodID = PodJID }, // Pod J, router 2
                new Device { DeviceID = "RT32", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack4ID, PodID = PodJID }, // Pod J, router 3
                new Device { DeviceID = "SW30", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack4ID, PodID = PodJID }, // Pod J, switch 1
                new Device { DeviceID = "SW31", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack4ID, PodID = PodJID }, // Pod J, switch 2
                new Device { DeviceID = "SW32", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack4ID, PodID = PodJID }, // Pod J, switch 3
                // Pod K devices
                new Device { DeviceID = "RT33", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack4ID, PodID = PodKID }, // Pod K, router 1
                new Device { DeviceID = "RT34", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack4ID, PodID = PodKID }, // Pod K, router 2
                new Device { DeviceID = "RT35", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack4ID, PodID = PodKID }, // Pod K, router 3
                new Device { DeviceID = "SW33", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack4ID, PodID = PodKID }, // Pod K, switch 1
                new Device { DeviceID = "SW34", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack4ID, PodID = PodKID }, // Pod K, switch 2
                new Device { DeviceID = "SW35", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack4ID, PodID = PodKID }, // Pod K, switch 3

                // Pod L devices
                new Device { DeviceID = "RT36", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack4ID, PodID = PodLID }, // Pod L, router 1
                new Device { DeviceID = "RT37", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack4ID, PodID = PodLID }, // Pod L, router 2
                new Device { DeviceID = "RT38", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack4ID, PodID = PodLID }, // Pod L, router 3
                new Device { DeviceID = "SW36", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack4ID, PodID = PodLID }, // Pod L, switch 1
                new Device { DeviceID = "SW37", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack4ID, PodID = PodLID }, // Pod L, switch 2
                new Device { DeviceID = "SW38", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack4ID, PodID = PodLID }, // Pod L, switch 3
                // End of Rack 4 devices

                // Rack 5 devices
                new Device { DeviceID = PodMID, DeviceName = "Pod M", Type = DeviceType.Pod, RackID = Rack5ID }, // Pod M
                new Device { DeviceID = PodNID, DeviceName = "Pod N", Type = DeviceType.Pod, RackID = Rack5ID }, // Pod N
                new Device { DeviceID = PodOID, DeviceName = "Pod O", Type = DeviceType.Pod, RackID = Rack5ID }, // Pod O
                new Device { DeviceID = PodPID, DeviceName = "Pod P", Type = DeviceType.Pod, RackID = Rack5ID }, // Pod P
                new Device { DeviceID = "RT39", DeviceName = "Cisco 1900 Series Router - Rack 5", Type = DeviceType.Router, RackID = Rack5ID },
                new Device { DeviceID = "SW39", DeviceName = "Catalyst 2900 Plus Series Switch - Rack 5", Type = DeviceType.Switch, RackID = Rack5ID },
                new Device { DeviceID = "FRWM", DeviceName = "ASA 5505 Series Firewall - Bloc M", Type = DeviceType.Firewall, RackID = Rack5ID }, // Pod M firewall
                new Device { DeviceID = "FRWN", DeviceName = "ASA 5505 Series Firewall - Bloc N", Type = DeviceType.Firewall, RackID = Rack5ID }, // Pod N firewall
                new Device { DeviceID = "FRWO", DeviceName = "ASA 5505 Series Firewall - Bloc O", Type = DeviceType.Firewall, RackID = Rack5ID }, // Pod O firewall
                new Device { DeviceID = "FRWP", DeviceName = "ASA 5505 Series Firewall - Bloc P", Type = DeviceType.Firewall, RackID = Rack5ID }, // Pod P firewall

                // Pod M devices
                new Device { DeviceID = "RT40", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack5ID, PodID = PodMID }, // Pod M, router 1
                new Device { DeviceID = "RT41", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack5ID, PodID = PodMID }, // Pod M, router 2
                new Device { DeviceID = "RT42", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack5ID, PodID = PodMID }, // Pod M, router 3
                new Device { DeviceID = "SW40", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack5ID, PodID = PodMID }, // Pod M, switch 1
                new Device { DeviceID = "SW41", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack5ID, PodID = PodMID }, // Pod M, switch 2
                new Device { DeviceID = "SW42", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack5ID, PodID = PodMID }, // Pod M, switch 3

                // Pod N devices
                new Device { DeviceID = "RT43", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack5ID, PodID = PodNID }, // Pod N, router 1
                new Device { DeviceID = "RT44", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack5ID, PodID = PodNID }, // Pod N, router 2
                new Device { DeviceID = "RT45", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack5ID, PodID = PodNID }, // Pod N, router 3
                new Device { DeviceID = "SW43", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack5ID, PodID = PodNID }, // Pod N, switch 1
                new Device { DeviceID = "SW44", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack5ID, PodID = PodNID }, // Pod N, switch 2
                new Device { DeviceID = "SW45", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack5ID, PodID = PodNID }, // Pod N, switch 3

                // Pod O devices
                new Device { DeviceID = "RT46", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack5ID, PodID = PodOID }, // Pod O, router 1
                new Device { DeviceID = "RT47", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack5ID, PodID = PodOID }, // Pod O, router 2
                new Device { DeviceID = "RT48", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack5ID, PodID = PodOID }, // Pod O, router 3
                new Device { DeviceID = "SW46", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack5ID, PodID = PodOID }, // Pod O, switch 1
                new Device { DeviceID = "SW47", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack5ID, PodID = PodOID }, // Pod O, switch 2
                new Device { DeviceID = "SW48", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack5ID, PodID = PodOID }, // Pod O, switch 3

                // Pod P devices
                new Device { DeviceID = "RT49", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack5ID, PodID = PodPID }, // Pod P, router 1
                new Device { DeviceID = "RT50", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack5ID, PodID = PodPID }, // Pod P, router 2
                new Device { DeviceID = "RT51", DeviceName = "Cisco 1900 Series Router", Type = DeviceType.Router, RackID = Rack5ID, PodID = PodPID }, // Pod P, router 3
                new Device { DeviceID = "SW49", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack5ID, PodID = PodPID }, // Pod P, switch 1
                new Device { DeviceID = "SW50", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack5ID, PodID = PodPID }, // Pod P, switch 2
                new Device { DeviceID = "SW51", DeviceName = "Catalyst 2900 Plus Series Switch", Type = DeviceType.Switch, RackID = Rack5ID, PodID = PodPID } // Pod P, switch 3
                // End of Rack 5 devices
                );
        }
    }
}
