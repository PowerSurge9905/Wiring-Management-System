using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WiringManagementSystem.Classes
{
    public class WMContextFactory : IDesignTimeDbContextFactory<WMContext>
    {
        public WMContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WMContext>();
            optionsBuilder.UseSqlite("Data Source=WMDB.sqlite");

            return new WMContext(optionsBuilder.Options);
        }
    }
}
