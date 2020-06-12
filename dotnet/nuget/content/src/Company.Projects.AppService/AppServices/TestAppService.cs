namespace Company.Projects.AppServices
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dtos;
    using Entities;
    using IAppServices;
    using IServices;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Authorization;

    public class TestAppService : ProjectsAppServiceBase, ITestAppService
    {
        private readonly ITestService _testService;

        public TestAppService(ITestService testService)
        {
            _testService = testService;
        }

        public async Task ChangeNameAsync([NotNull] TestDto dto)
        {
            var entity = await _testService.GetAsync(dto.Id);

            await _testService.ChangeNameAsync(entity, dto.Name);
        }

        [Authorize]
        public async Task<TestDto> CreateAsync([NotNull] TestCreateDto dto)
        {
            var entity = ObjectMapper.Map<TestCreateDto, TestEntity>(dto);

            var test = await _testService.CreateAsync(entity);

            return ObjectMapper.Map<TestEntity, TestDto>(test);
        }

        public async Task<IEnumerable<TestDto>> GetListAsync()
        {
            var list = await _testService.GetListAsync();

            return ObjectMapper.Map<IEnumerable<TestEntity>, IEnumerable<TestDto>>(list);
        }
        public async Task<TestDto> GetAsync([NotNull]Guid id)
        {
            var list = await _testService.GetAsync(id);

            return ObjectMapper.Map<TestEntity, TestDto>(list);
        }
    }
}
