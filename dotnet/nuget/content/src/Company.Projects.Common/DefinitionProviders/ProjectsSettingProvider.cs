namespace Company.Projects.DefinitionProviders
{
    using Consts;
    using Localizations;
    using Volo.Abp.Localization;
    using Volo.Abp.Settings;

    public class ProjectsSettingProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            // set default language
            var languageSetting = context.GetOrNull(LocalizationSettingNames.DefaultLanguage);

            if (languageSetting != null)
            {
                languageSetting.DefaultValue = ModuleConsts.DefaultCultureName;
            }

            // Define your own settings here. Example:
            context.Add(new SettingDefinition(
                name: ProjectsSettingNames.ModuleName,
                defaultValue: "Projects",
                displayName: L("Setting:MySetting1")
                ));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProjectsLocalResource>(name);
        }
    }
}
