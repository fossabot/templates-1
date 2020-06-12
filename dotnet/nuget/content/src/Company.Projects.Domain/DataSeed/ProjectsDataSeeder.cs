namespace Company.Projects.DataSeed
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;
    using IRepositories;
    using Volo.Abp.DependencyInjection;
    using Volo.Abp.Uow;

    public class ProjectsDataSeeder : IProjectsDataSeeder, ITransientDependency
    {
        private readonly ITestRepository _testRepository;

        public ProjectsDataSeeder(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        [UnitOfWork]
        public async Task SeedAsync()
        {
            await CreateTestAsync();
        }

        private async Task CreateTestAsync()
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
