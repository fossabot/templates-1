namespace Company.Projects
{
    using Microsoft.Extensions.DependencyInjection;
    using Volo.Abp;
    using Volo.Abp.Modularity;

    [DependsOn(typeof(ProjectsEfCoreTestModule))]
    public class ProjectsDomainTestModule : AbpModule
    {
    }
}
