namespace WiringManagementSystem.Classes
{
    public class Rack
    {
        public required string RackID { get; set; }
        public required string RackName { get; set; }
        public List<string>? Notes { get; set; }
    }
}
