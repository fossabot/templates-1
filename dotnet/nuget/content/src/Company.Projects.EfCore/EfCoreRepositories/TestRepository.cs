namespace Company.Projects.EfCoreRepositories
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using EfCoreConfigurations;
    using Entities;
    using IRepositories;
    using Microsoft.EntityFrameworkCore;
    using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
    using Volo.Abp.EntityFrameworkCore;

    public class TestRepository : EfCoreRepository<IProjectsDbContext, TestEntity, Guid>, ITestRepository
    {
        public TestRepository(IDbContextProvider<IProjectsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        // to do implement

        public async Task<TestEntity> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(m => m.Name == name, GetCancellationToken(cancellationToken));
        }
    }
}
