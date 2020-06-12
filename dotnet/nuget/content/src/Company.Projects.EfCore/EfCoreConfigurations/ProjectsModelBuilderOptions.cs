namespace Company.Projects.EfCoreConfigurations
{
    using JetBrains.Annotations;
    using Volo.Abp.EntityFrameworkCore.Modeling;

    public class ProjectsModelBuilderOptions : AbpModelBuilderConfigurationOptions
    {
        public ProjectsModelBuilderOptions(
            [NotNull] string tablePrefix,
            [CanBeNull] string schema)
            : base(
                tablePrefix,
                schema)
        {
        }
    }
}
