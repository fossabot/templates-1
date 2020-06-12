namespace Company.Projects
{
    using Microsoft.Extensions.DependencyInjection;
    using TestDatas;
    using Volo.Abp;
    using Volo.Abp.Autofac;
    using Volo.Abp.Modularity;
    using Volo.Abp.Threading;

    [DependsOn(typeof(ProjectsDomainModule),
        typeof(AbpTestBaseModule),
        typeof(AbpAutofacModule))]
    public class ProjectsTestBaseModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            SeedTestData(context);
        }

        private static void SeedTestData(ApplicationInitializationContext context)
        {
            using var scope = context.ServiceProvider.CreateScope();

            AsyncHelper.RunSync(async () =>
            {
                await scope.ServiceProvider.GetRequiredService<ProjectsTestDataBuilder>()
                .SeedAsync();
            });
        }
    }
}
