namespace Company.Projects
{
    using EfCoreConfigurations;
    using EfCoreRepositories;
    using Entities;
    using Microsoft.Extensions.DependencyInjection;
    using Volo.Abp.EntityFrameworkCore;
    using Volo.Abp.Modularity;

    [DependsOn(typeof(ProjectsDomainModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class ProjectsEfCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ProjectsDbContext>(options =>
            {
                options.AddRepository<TestEntity, TestRepository>();
            });
        }
    }
}
