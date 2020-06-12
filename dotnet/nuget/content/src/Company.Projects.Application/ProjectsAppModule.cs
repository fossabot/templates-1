namespace Company.Projects
{
    using Volo.Abp.Application;
    using Volo.Abp.Modularity;

    [DependsOn(typeof(AbpDddApplicationModule))]
    public class ProjectsAppModule : AbpModule
    {
    }
}
