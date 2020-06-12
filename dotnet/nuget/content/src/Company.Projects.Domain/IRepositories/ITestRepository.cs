namespace Company.Projects.IRepositories
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Volo.Abp.Domain.Repositories;

    public interface ITestRepository : IBasicRepository<TestEntity, Guid>
    {
        Task<TestEntity> FindByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}
