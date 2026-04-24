using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using WiringManagementSystem.Classes;

namespace WiringManagementSystem
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //using (var db = new WMContext())
            //{
            //    db.Database.EnsureCreated();
            //}

            Application.Run(new WMForm());
        }
    }
}