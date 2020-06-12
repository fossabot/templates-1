namespace Company.Projects.DomainTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using IRepositories;
    using IServices;
    using Shouldly;
    using Volo.Abp;
    using Xunit;

    public class TestServiceTest : ProjectsDomainTestBase
    {
        private readonly ITestService _testService;
        private readonly ITestRepository _testRepository;

        public TestServiceTest()
        {
            _testService = GetRequiredService<ITestService>();
            _testRepository = GetRequiredService<ITestRepository>();
        }

        [Fact]
        public async Task Shoued_Name_Of_Data_Seed_Async()
        {
            var tenant = await _testService.GetListAsync();

            tenant.Select(m => m.Name).ShouldContain("test0");
        }

        [Fact]
        public async Task Create_Tenant_Name_Can_Not_Duplicate()
        {
            var test1 = new TestEntity("test1");

            await Assert.ThrowsAsync<UserFriendlyException>(async () => await _testService.CreateAsync(test1));
        }

        [Fact]
        public async Task ChangeNameAsync()
        {
            var tenant = await _testRepository.FindByNameAsync("test0");

            tenant.ShouldNotBeNull();

            await _testService.ChangeNameAsync(tenant, "test3");

            tenant.Name.ShouldBe("test3");
        }

        [Fact]
        public async Task ChangeName_Tenant_Name_Can_Not_Duplicate()
        {
            var tenant = await _testRepository.FindByNameAsync("test1");

            tenant.ShouldNotBeNull();

            await Assert.ThrowsAsync<UserFriendlyException>(async () => await _testService.ChangeNameAsync(tenant, "test1"));
        }
    }
}
