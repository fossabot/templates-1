namespace Company.Projects.CommonTests
{
    using Localizations;
    using Microsoft.Extensions.Localization;
    using Shouldly;
    using TestBases;
    using Volo.Abp.Localization;
    using Xunit;

    public class LocalizatinTest : ProjectsTestBase<ProjectsCommonTestModule>
    {
        private readonly IStringLocalizer<ProjectsLocalResource> _stringLocalizer;

        public LocalizatinTest()
        {
            _stringLocalizer = GetRequiredService<IStringLocalizer<ProjectsLocalResource>>();
        }

        [Fact]
        public void Should_Localize_Messages()
        {
            // en
            using (CultureHelper.Use("en"))
            {
                _stringLocalizer["Projects:Name"].Value.ShouldBe("Projects-en");
            }

            // zh-CN
            using (CultureHelper.Use("zh-CN"))
            {
                _stringLocalizer["Projects:Name"].Value.ShouldBe("Projects-zh-CN");
            }
        }
    }
}
