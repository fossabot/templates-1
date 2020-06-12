namespace Company.Projects.TestDatas
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;
    using IRepositories;
    using Volo.Abp.DependencyInjection;

    public class ProjectsTestDataBuilder : ITransientDependency
    {
        private readonly ITestRepository _testRepository;

        public ProjectsTestDataBuilder(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task SeedAsync()
        {
            var tests = new List<TestEntity>()
            {
                new TestEntity("test0"),

                new TestEntity("test1"),
            };

            foreach (var item in tests)
            {
                var test0 = await _testRepository.FindByNameAsync(item.Name);

                if (test0 == default)
                {
                    await _testRepository.InsertAsync(item, true);
                }
                else
                {
                    await _testRepository.UpdateAsync(test0);
                }
            }
        }
    }
}
