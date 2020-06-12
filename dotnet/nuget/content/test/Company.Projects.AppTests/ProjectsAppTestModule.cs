namespace Company.Projects
{
    using Microsoft.Extensions.DependencyInjection;
    using Volo.Abp.Modularity;

    [DependsOn(typeof(ProjectsAppServiceModule),
        typeof(ProjectsEfCoreTestModule))]
    public class ProjectsAppTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}
