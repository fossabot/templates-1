namespace Company.Projects
{
    using EfCoreConfigurations;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Storage;
    using Volo.Abp.EntityFrameworkCore;
    using Volo.Abp.Modularity;

    [DependsOn(typeof(ProjectsTestBaseModule),
        typeof(ProjectsEfCoreModule))]
    public class ProjectsEfCoreTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var sqliteConnection = CreateDatabaseAndGetConnection();

            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(abpDbContextConfigurationContext =>
                {
                    abpDbContextConfigurationContext.DbContextOptions.UseSqlite(sqliteConnection);
                });
            });
        }

        private static SqliteConnection CreateDatabaseAndGetConnection()
        {
            // memory connection
            var connection = new SqliteConnection("Data Source=:memory:");

            connection.Open();

            new ProjectsDbContext(
                new DbContextOptionsBuilder<ProjectsDbContext>().UseSqlite(connection).Options
            ).GetService<IRelationalDatabaseCreator>().CreateTables();

            return connection;
        }
    }
}
