namespace Company.Projects.DefinitionProviders
{
    using Consts;
    using Localizations;
    using Volo.Abp.Authorization.Permissions;
    using Volo.Abp.Localization;

    public class ProjectsPermissionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var group = context.AddGroup(ProjectsPermissionNames.GroupName);

            //Define your own permissions here. Example:
            group.AddPermission(ProjectsPermissionNames.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ProjectsLocalResource>(name);
        }
    }
}
