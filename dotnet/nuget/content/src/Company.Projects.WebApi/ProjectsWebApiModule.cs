namespace Company.Projects
{
    using Microsoft.Extensions.DependencyInjection;
    using Volo.Abp.AspNetCore.Mvc;
    using Volo.Abp.Modularity;

    [DependsOn(typeof(ProjectsAppModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class ProjectsWebApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ProjectsWebApiModule).Assembly);
            });
        }
    }
}
