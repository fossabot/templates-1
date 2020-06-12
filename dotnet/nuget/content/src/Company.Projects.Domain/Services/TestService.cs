namespace Company.Projects.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;
    using IRepositories;
    using IServices;
    using JetBrains.Annotations;
    using Volo.Abp;
    using Volo.Abp.Domain.Services;

    public class TestService : DomainService, ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task ChangeNameAsync([NotNull] TestEntity tenant, [NotNull] string name)
        {
            Check.NotNull(tenant, nameof(tenant));

            Check.NotNull(name, nameof(name));

            await ValidateNameAsync(name);

            tenant.SetName(name);
        }

        public async Task<TestEntity> CreateAsync([NotNull] TestEntity entity)
        {
            Check.NotNull(entity, nameof(entity));

            await ValidateNameAsync(entity.Name);

            await _testRepository.InsertAsync(entity);

            return entity;
        }

        public async Task<TestEntity> GetAsync([NotNull] Guid id)
        {
            return await _testRepository.GetAsync(id);
        }

        public async Task<IEnumerable<TestEntity>> GetListAsync()
        {
            return await _testRepository.GetListAsync();
        }

        protected virtual async Task ValidateNameAsync(string name, Guid? expectedId = null)
        {
            var test = await _testRepository.FindByNameAsync(name);

            if (test != null && test.Id != expectedId)
            {
                throw new UserFriendlyException("Duplicate tenancy name: " + name); //TODO: A domain exception would be better..?
            }
        }
    }
}
