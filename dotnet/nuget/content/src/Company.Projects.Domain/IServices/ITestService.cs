namespace Company.Projects.IServices
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;
    using JetBrains.Annotations;
    using Volo.Abp.Domain.Services;

    public interface ITestService : IDomainService
    {
        Task<TestEntity> CreateAsync([NotNull] TestEntity entity);

        Task ChangeNameAsync([NotNull] TestEntity tenant, [NotNull] string name);

        Task<TestEntity> GetAsync([NotNull]Guid id);

        Task<IEnumerable<TestEntity>> GetListAsync();
    }
}
