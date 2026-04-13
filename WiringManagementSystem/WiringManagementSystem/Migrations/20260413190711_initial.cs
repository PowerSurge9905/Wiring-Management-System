using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WiringManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Racks",
                columns: table => new
                {
                    RackID = table.Column<string>(type: "TEXT", nullable: false),
                    RackName = table.Column<string>(type: "TEXT", nullable: false),
                    DevicesID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racks", x => x.RackID);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceID = table.Column<string>(type: "TEXT", nullable: false),
                    DeviceName = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    RackID = table.Column<string>(type: "TEXT", nullable: true),
                    PodID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceID);
                    table.ForeignKey(
                        name: "FK_Devices_Racks_RackID",
                        column: x => x.RackID,
                        principalTable: "Racks",
                        principalColumn: "RackID");
                });

            migrationBuilder.InsertData(
                table: "Racks",
                columns: new[] { "RackID", "DevicesID", "RackName" },
                values: new object[,]
                {
                    { "RK01", null, "Rack 1" },
                    { "RK02", null, "Rack 2" },
                    { "RK03", null, "Rack 3" },
                    { "RK04", null, "Rack 4" },
                    { "RK05", null, "Rack 5" },
                    { "RK06", null, "Rack 6" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "DeviceID", "DeviceName", "PodID", "RackID", "Type" },
                values: new object[,]
                {
                    { "FRWA", "ASA 5505 Series Firewall - Bloc A", null, "RK01", 3 },
                    { "FRWB", "ASA 5505 Series Firewall - Bloc B", null, "RK01", 3 },
                    { "FRWC", "ASA 5505 Series Firewall - Bloc C", null, "RK01", 3 },
                    { "FRWD", "ASA 5505 Series Firewall - Bloc D", null, "RK01", 3 },
                    { "FRWE", "ASA 5505 Series Firewall - Bloc E", null, "RK02", 3 },
                    { "FRWF", "ASA 5505 Series Firewall - Bloc F", null, "RK02", 3 },
                    { "FRWG", "ASA 5505 Series Firewall - Bloc G", null, "RK02", 3 },
                    { "FRWH", "ASA 5505 Series Firewall - Bloc H", null, "RK02", 3 },
                    { "FRWI", "ASA 5505 Series Firewall - Bloc I", null, "RK04", 3 },
                    { "FRWJ", "ASA 5505 Series Firewall - Bloc J", null, "RK04", 3 },
                    { "FRWK", "ASA 5505 Series Firewall - Bloc K", null, "RK04", 3 },
                    { "FRWL", "ASA 5505 Series Firewall - Bloc L", null, "RK04", 3 },
                    { "FRWM", "ASA 5505 Series Firewall - Bloc M", null, "RK05", 3 },
                    { "FRWN", "ASA 5505 Series Firewall - Bloc N", null, "RK05", 3 },
                    { "FRWO", "ASA 5505 Series Firewall - Bloc O", null, "RK05", 3 },
                    { "FRWP", "ASA 5505 Series Firewall - Bloc P", null, "RK05", 3 },
                    { "PODA", "Pod A", null, "RK01", 5 },
                    { "PODB", "Pod B", null, "RK01", 5 },
                    { "PODC", "Pod C", null, "RK01", 5 },
                    { "PODD", "Pod D", null, "RK01", 5 },
                    { "PODE", "Pod E", null, "RK02", 5 },
                    { "PODF", "Pod F", null, "RK02", 5 },
                    { "PODG", "Pod G", null, "RK02", 5 },
                    { "PODH", "Pod H", null, "RK02", 5 },
                    { "PODI", "Pod I", null, "RK04", 5 },
                    { "PODJ", "Pod J", null, "RK04", 5 },
                    { "PODK", "Pod K", null, "RK04", 5 },
                    { "PODL", "Pod L", null, "RK04", 5 },
                    { "PODM", "Pod M", null, "RK05", 5 },
                    { "PODN", "Pod N", null, "RK05", 5 },
                    { "PODO", "Pod O", null, "RK05", 5 },
                    { "PODP", "Pod P", null, "RK05", 5 },
                    { "RT00", "Cisco 1900 Series Router - Rack 1", null, "RK01", 2 },
                    { "RT01", "Cisco 1900 Series Router", "PODA", "RK01", 2 },
                    { "RT02", "Cisco 1900 Series Router", "PODA", "RK01", 2 },
                    { "RT03", "Cisco 1900 Series Router", "PODA", "RK01", 2 },
                    { "RT04", "Cisco 1900 Series Router", "PODB", "RK01", 2 },
                    { "RT05", "Cisco 1900 Series Router", "PODB", "RK01", 2 },
                    { "RT06", "Cisco 1900 Series Router", "PODB", "RK01", 2 },
                    { "RT07", "Cisco 1900 Series Router", "PODC", "RK01", 2 },
                    { "RT08", "Cisco 1900 Series Router", "PODC", "RK01", 2 },
                    { "RT09", "Cisco 1900 Series Router", "PODC", "RK01", 2 },
                    { "RT10", "Cisco 1900 Series Router", "PODD", "RK01", 2 },
                    { "RT11", "Cisco 1900 Series Router", "PODD", "RK01", 2 },
                    { "RT12", "Cisco 1900 Series Router", "PODD", "RK01", 2 },
                    { "RT13", "Cisco 1900 Series Router - Rack 2", null, "RK02", 2 },
                    { "RT14", "Cisco 1900 Series Router", "PODE", "RK02", 2 },
                    { "RT15", "Cisco 1900 Series Router", "PODE", "RK02", 2 },
                    { "RT16", "Cisco 1900 Series Router", "PODE", "RK02", 2 },
                    { "RT17", "Cisco 1900 Series Router", "PODF", "RK02", 2 },
                    { "RT18", "Cisco 1900 Series Router", "PODF", "RK02", 2 },
                    { "RT19", "Cisco 1900 Series Router", "PODF", "RK02", 2 },
                    { "RT20", "Cisco 1900 Series Router", "PODG", "RK02", 2 },
                    { "RT21", "Cisco 1900 Series Router", "PODG", "RK02", 2 },
                    { "RT22", "Cisco 1900 Series Router", "PODG", "RK02", 2 },
                    { "RT23", "Cisco 1900 Series Router", "PODH", "RK02", 2 },
                    { "RT24", "Cisco 1900 Series Router", "PODH", "RK02", 2 },
                    { "RT25", "Cisco 1900 Series Router", "PODH", "RK02", 2 },
                    { "RT26", "Cisco 1900 Series Router - Rack 4", null, "RK04", 2 },
                    { "RT27", "Cisco 1900 Series Router", "PODI", "RK04", 2 },
                    { "RT28", "Cisco 1900 Series Router", "PODI", "RK04", 2 },
                    { "RT29", "Cisco 1900 Series Router", "PODI", "RK04", 2 },
                    { "RT30", "Cisco 1900 Series Router", "PODJ", "RK04", 2 },
                    { "RT31", "Cisco 1900 Series Router", "PODJ", "RK04", 2 },
                    { "RT32", "Cisco 1900 Series Router", "PODJ", "RK04", 2 },
                    { "RT33", "Cisco 1900 Series Router", "PODK", "RK04", 2 },
                    { "RT34", "Cisco 1900 Series Router", "PODK", "RK04", 2 },
                    { "RT35", "Cisco 1900 Series Router", "PODK", "RK04", 2 },
                    { "RT36", "Cisco 1900 Series Router", "PODL", "RK04", 2 },
                    { "RT37", "Cisco 1900 Series Router", "PODL", "RK04", 2 },
                    { "RT38", "Cisco 1900 Series Router", "PODL", "RK04", 2 },
                    { "RT39", "Cisco 1900 Series Router - Rack 5", null, "RK05", 2 },
                    { "RT40", "Cisco 1900 Series Router", "PODM", "RK05", 2 },
                    { "RT41", "Cisco 1900 Series Router", "PODM", "RK05", 2 },
                    { "RT42", "Cisco 1900 Series Router", "PODM", "RK05", 2 },
                    { "RT43", "Cisco 1900 Series Router", "PODN", "RK05", 2 },
                    { "RT44", "Cisco 1900 Series Router", "PODN", "RK05", 2 },
                    { "RT45", "Cisco 1900 Series Router", "PODN", "RK05", 2 },
                    { "RT46", "Cisco 1900 Series Router", "PODO", "RK05", 2 },
                    { "RT47", "Cisco 1900 Series Router", "PODO", "RK05", 2 },
                    { "RT48", "Cisco 1900 Series Router", "PODO", "RK05", 2 },
                    { "RT49", "Cisco 1900 Series Router", "PODP", "RK05", 2 },
                    { "RT50", "Cisco 1900 Series Router", "PODP", "RK05", 2 },
                    { "RT51", "Cisco 1900 Series Router", "PODP", "RK05", 2 },
                    { "SRV01", "Host 1 Server", null, "RK03", 0 },
                    { "SRV02", "Host 2 Server", null, "RK03", 0 },
                    { "SRVBCK", "Backup Server", null, "RK03", 0 },
                    { "SRVMGMT", "Management Server", null, "RK03", 0 },
                    { "SW00", "Catalyst 2900 Plus Series Switch - Rack 1", null, "RK01", 1 },
                    { "SW01", "Catalyst 2900 Plus Series Switch", "PODA", "RK01", 1 },
                    { "SW02", "Catalyst 2900 Plus Series Switch", "PODA", "RK01", 1 },
                    { "SW03", "Catalyst 2900 Plus Series Switch", "PODA", "RK01", 1 },
                    { "SW04", "Catalyst 2900 Plus Series Switch", "PODB", "RK01", 1 },
                    { "SW05", "Catalyst 2900 Plus Series Switch", "PODB", "RK01", 1 },
                    { "SW06", "Catalyst 2900 Plus Series Switch", "PODB", "RK01", 1 },
                    { "SW07", "Catalyst 2900 Plus Series Switch", "PODC", "RK01", 1 },
                    { "SW08", "Catalyst 2900 Plus Series Switch", "PODC", "RK01", 1 },
                    { "SW09", "Catalyst 2900 Plus Series Switch", "PODC", "RK01", 1 },
                    { "SW10", "Catalyst 2900 Plus Series Switch", "PODD", "RK01", 1 },
                    { "SW11", "Catalyst 2900 Plus Series Switch", "PODD", "RK01", 1 },
                    { "SW12", "Catalyst 2900 Plus Series Switch", "PODD", "RK01", 1 },
                    { "SW13", "Catalyst 2900 Plus Series Switch - Rack 2", null, "RK02", 1 },
                    { "SW14", "Catalyst 2900 Plus Series Switch", "PODE", "RK02", 1 },
                    { "SW15", "Catalyst 2900 Plus Series Switch", "PODE", "RK02", 1 },
                    { "SW16", "Catalyst 2900 Plus Series Switch", "PODE", "RK02", 1 },
                    { "SW17", "Catalyst 2900 Plus Series Switch", "PODF", "RK02", 1 },
                    { "SW18", "Catalyst 2900 Plus Series Switch", "PODF", "RK02", 1 },
                    { "SW19", "Catalyst 2900 Plus Series Switch", "PODF", "RK02", 1 },
                    { "SW20", "Catalyst 2900 Plus Series Switch", "PODG", "RK02", 1 },
                    { "SW21", "Catalyst 2900 Plus Series Switch", "PODG", "RK02", 1 },
                    { "SW22", "Catalyst 2900 Plus Series Switch", "PODG", "RK02", 1 },
                    { "SW23", "Catalyst 2900 Plus Series Switch", "PODH", "RK02", 1 },
                    { "SW24", "Catalyst 2900 Plus Series Switch", "PODH", "RK02", 1 },
                    { "SW25", "Catalyst 2900 Plus Series Switch", "PODH", "RK02", 1 },
                    { "SW26", "Catalyst 2900 Plus Series Switch - Rack 4", null, "RK04", 1 },
                    { "SW27", "Catalyst 2900 Plus Series Switch", "PODI", "RK04", 1 },
                    { "SW28", "Catalyst 2900 Plus Series Switch", "PODI", "RK04", 1 },
                    { "SW29", "Catalyst 2900 Plus Series Switch", "PODI", "RK04", 1 },
                    { "SW30", "Catalyst 2900 Plus Series Switch", "PODJ", "RK04", 1 },
                    { "SW31", "Catalyst 2900 Plus Series Switch", "PODJ", "RK04", 1 },
                    { "SW32", "Catalyst 2900 Plus Series Switch", "PODJ", "RK04", 1 },
                    { "SW33", "Catalyst 2900 Plus Series Switch", "PODK", "RK04", 1 },
                    { "SW34", "Catalyst 2900 Plus Series Switch", "PODK", "RK04", 1 },
                    { "SW35", "Catalyst 2900 Plus Series Switch", "PODK", "RK04", 1 },
                    { "SW36", "Catalyst 2900 Plus Series Switch", "PODL", "RK04", 1 },
                    { "SW37", "Catalyst 2900 Plus Series Switch", "PODL", "RK04", 1 },
                    { "SW38", "Catalyst 2900 Plus Series Switch", "PODL", "RK04", 1 },
                    { "SW39", "Catalyst 2900 Plus Series Switch - Rack 5", null, "RK05", 1 },
                    { "SW40", "Catalyst 2900 Plus Series Switch", "PODM", "RK05", 1 },
                    { "SW41", "Catalyst 2900 Plus Series Switch", "PODM", "RK05", 1 },
                    { "SW42", "Catalyst 2900 Plus Series Switch", "PODM", "RK05", 1 },
                    { "SW43", "Catalyst 2900 Plus Series Switch", "PODN", "RK05", 1 },
                    { "SW44", "Catalyst 2900 Plus Series Switch", "PODN", "RK05", 1 },
                    { "SW45", "Catalyst 2900 Plus Series Switch", "PODN", "RK05", 1 },
                    { "SW46", "Catalyst 2900 Plus Series Switch", "PODO", "RK05", 1 },
                    { "SW47", "Catalyst 2900 Plus Series Switch", "PODO", "RK05", 1 },
                    { "SW48", "Catalyst 2900 Plus Series Switch", "PODO", "RK05", 1 },
                    { "SW49", "Catalyst 2900 Plus Series Switch", "PODP", "RK05", 1 },
                    { "SW50", "Catalyst 2900 Plus Series Switch", "PODP", "RK05", 1 },
                    { "SW51", "Catalyst 2900 Plus Series Switch", "PODP", "RK05", 1 },
                    { "SWCLST", "Cluster Switch", null, "RK03", 1 },
                    { "SWCTRL", "NL Control Switch", null, "RK03", 1 },
                    { "SWMGMT", "Management Switch", null, "RK03", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_RackID",
                table: "Devices",
                column: "RackID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Racks");
        }
    }
}
