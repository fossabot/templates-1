namespace Company.Projects.EfCoreConfigurations
{
    using Consts;
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Volo.Abp.Data;
    using Volo.Abp.EntityFrameworkCore;

    [ConnectionStringName(ModuleConsts.ConnectionStringName)]
    public class ProjectsDbContext : AbpDbContext<ProjectsDbContext>, IProjectsDbContext
    {
        public DbSet<TestEntity> Test { get; set; }

        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureProjects();
        }
    }
}
