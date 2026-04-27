namespace WiringManagementSystem.Classes
{
    public class Globals
    {
        public static string connectionString = $"Data Source={Path.Combine(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\")), "WMDB.sqlite")}";
    }
}
