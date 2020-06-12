namespace Company.Projects
{
    using Consts;
    using Microsoft.Extensions.DependencyInjection;
    using Volo.Abp.Http.Client;
    using Volo.Abp.Modularity;

    [DependsOn(typeof(ProjectsAppModule),
        typeof(AbpHttpClientModule))]
    public class ProjectsWebClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ProjectsAppModule).Assembly,
                ModuleConsts.RemoteServiceName
            );
        }
    }
}
