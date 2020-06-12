namespace Company.Projects
{
    using Volo.Abp.Domain;
    using Volo.Abp.Modularity;

    [DependsOn(typeof(AbpDddDomainModule),
        typeof(ProjectsCommonModule))]
    public class ProjectsDomainModule : AbpModule
    {
    }
}
