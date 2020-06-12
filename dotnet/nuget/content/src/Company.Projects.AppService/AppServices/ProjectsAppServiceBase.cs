namespace Company.Projects.AppServices
{
    using Localizations;
    using Volo.Abp.Application.Services;

    public abstract class ProjectsAppServiceBase : ApplicationService
    {
        protected ProjectsAppServiceBase()
        {
            ObjectMapperContext = typeof(ProjectsAppServiceModule);

            LocalizationResource = typeof(ProjectsLocalResource);
        }
    }
}
