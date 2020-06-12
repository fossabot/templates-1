namespace Company.Projects.TestBases
{
    using Volo.Abp;
    using Volo.Abp.Modularity;
    using Volo.Abp.Testing;

    public abstract class ProjectsTestBase<TStartupModule> : AbpIntegratedTest<TStartupModule>
        where TStartupModule : IAbpModule
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
