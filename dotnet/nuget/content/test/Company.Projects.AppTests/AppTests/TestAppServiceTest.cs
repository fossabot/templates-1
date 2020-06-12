namespace Company.Projects.AppTests
{
    using System.Threading.Tasks;
    using Dtos;
    using IAppServices;
    using Shouldly;
    using Xunit;

    public class TestAppServiceTest : ProjectsAppTestBase
    {
        private readonly ITestAppService _testAppService;

        public TestAppServiceTest()
        {
            _testAppService = GetRequiredService<ITestAppService>();
        }

        [Fact]
        public async Task CreateAsync()
        {
            var test = new TestCreateDto("test3");

            var result = await _testAppService.CreateAsync(test);

            result.Name.ShouldNotBeNull();
        }
    }
}
