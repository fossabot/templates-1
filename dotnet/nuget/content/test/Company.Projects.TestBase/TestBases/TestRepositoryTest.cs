namespace Company.Projects.TestBases
{
    using System.Threading.Tasks;
    using IRepositories;
    using Shouldly;
    using Volo.Abp.Modularity;
    using Xunit;

    public abstract class TestRepositoryTest<TStartupModule> : ProjectsTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        public ITestRepository TestRepository { get; }

        protected TestRepositoryTest()
        {
            TestRepository = GetRequiredService<ITestRepository>();
        }

        [Fact]
        public async Task FindByNameAsync()
        {
            var tenant = await TestRepository.FindByNameAsync("test1");
            tenant.ShouldNotBeNull();
        }

        [Fact]
        public async Task GetListAsync()
        {
            var tenants = await TestRepository.GetListAsync();

            tenants.ShouldContain(t => t.Name == "test1");
        }
    }
}
