namespace Company.Projects
{
    using Mappings;
    using Microsoft.Extensions.DependencyInjection;
    using Volo.Abp.AutoMapper;
    using Volo.Abp.Modularity;

    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(ProjectsDomainModule),
        typeof(ProjectsAppModule))]
    public class ProjectsAppServiceModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<ProjectsAppServiceModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MapperProfile>(validate: true);
            });
        }
    }
}
