using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using LandlordBackendAPI.Data;
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        //// Build configuration from appsettings.json
        //IConfigurationRoot configuration = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //    .Build();

        //// Get the connection string
        //var connectionString = configuration.GetConnectionString("DefaultConnection");

        //// Configure DbContext options
        //var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        //optionsBuilder.UseSqlServer(connectionString);

        //return new AppDbContext(optionsBuilder.Options);

       
            var configPath = Directory.GetCurrentDirectory();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(configPath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);   

    }
}
