namespace Company.Projects
{
    using Volo.Abp.Modularity;

    [DependsOn(typeof(ProjectsEfCoreTestModule))]
    public class ProjectsCommonTestModule : AbpModule
    {
    }
}
