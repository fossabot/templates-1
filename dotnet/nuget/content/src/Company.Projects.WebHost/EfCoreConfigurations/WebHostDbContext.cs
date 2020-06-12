namespace Company.Projects.EfCoreConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Volo.Abp.EntityFrameworkCore;

    public class WebHostDbContext : AbpDbContext<WebHostDbContext>
    {
        public WebHostDbContext(DbContextOptions<WebHostDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureProjects();
        }
    }
}
