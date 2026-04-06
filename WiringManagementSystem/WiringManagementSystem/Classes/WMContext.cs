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
        }
    }
}
