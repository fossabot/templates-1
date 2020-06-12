namespace Company.Projects.DataSeed
{
    using System.Threading.Tasks;
    using Volo.Abp.Data;
    using Volo.Abp.DependencyInjection;

    public class ProjectsDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IProjectsDataSeeder _dataSeeder;

        public ProjectsDataSeedContributor(IProjectsDataSeeder dataSeeder)
        {
            _dataSeeder = dataSeeder;
        }

        public Task SeedAsync(DataSeedContext context)
        {
            return _dataSeeder.SeedAsync();
        }
    }
}
