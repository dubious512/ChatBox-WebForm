using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class ManageAppDbContextFactory : IDesignTimeDbContextFactory<ManageAppDbContext>
    {
        public ManageAppDbContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json")
                .Build();


            var buider = new DbContextOptionsBuilder<ManageAppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            buider.UseSqlServer(connectionString);
            return new ManageAppDbContext(buider.Options);

        }
    }
}
