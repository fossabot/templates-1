namespace Company.Projects.EfCoreConfigurations
{
    using System.IO;
    using Consts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class WebHostDbContextFactory : IDesignTimeDbContextFactory<WebHostDbContext>
    {
        public WebHostDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<WebHostDbContext>()
                .UseSqlServer(configuration.GetConnectionString(ModuleConsts.ConnectionStringName));

            return new WebHostDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
