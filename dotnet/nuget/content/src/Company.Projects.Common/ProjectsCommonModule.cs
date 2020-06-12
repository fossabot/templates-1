namespace Company.Projects
{
    using Configurations;
    using Consts;
    using Localizations;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Options;
    using Volo.Abp.Authorization;
    using Volo.Abp.Localization;
    using Volo.Abp.Modularity;
    using Volo.Abp.VirtualFileSystem;

    [DependsOn(typeof(AbpLocalizationModule),
        typeof(AbpAuthorizationModule))]
    public class ProjectsCommonModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ProjectsCommonModule>(typeof(ProjectsCommonModule).Namespace);
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ProjectsLocalResource>(defaultCultureName: ModuleConsts.DefaultCultureName)
                    .AddVirtualJson("/Localizations/ProjectsResources");

                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("zh-CN", "zh-CN", "简体中文"));
            });

            RegisterRootConfiguration(context.Services);
        }

        private IRootConfiguration RegisterRootConfiguration(IServiceCollection services)
        {
            var options = services.ExecutePreConfiguredActions<ConfigOptions>();

            var configuration = services.GetConfiguration().GetSection(options.RootConfigurationPath);

            var root = new RootConfiguration();

            configuration.GetSection(options.AdminConfigurationPath).Bind(root.Admin);
            configuration.GetSection(options.AppConfigurationPath).Bind(root.App);

            services.AddSingleton(typeof(IRootConfiguration), root);

            return root;
        }
    }
}
