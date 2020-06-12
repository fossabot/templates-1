namespace Company.Projects.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Consts;
    using Dtos;
    using IAppServices;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Volo.Abp;
    using Volo.Abp.AspNetCore.Mvc;

    [RemoteService(Name = ModuleConsts.RemoteServiceName)]
    [Route("api/test")]
    public class TestController : AbpController, ITestAppService
    {
        protected readonly ITestAppService _testAppService;

        public TestController(ITestAppService testAppService)
        {
            _testAppService = testAppService;
        }

        [HttpPost]
        [Authorize]
        public Task<TestDto> CreateAsync(TestCreateDto dto)
        {
            return _testAppService.CreateAsync(dto);
        }

        [HttpPut]
        public Task ChangeNameAsync([NotNull] TestDto dto)
        {
            return _testAppService.ChangeNameAsync(dto);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<TestDto> GetAsync(Guid id)
        {
            return _testAppService.GetAsync(id);
        }

        [HttpGet]
        public Task<IEnumerable<TestDto>> GetListAsync()
        {
            return _testAppService.GetListAsync();
        }
    }
}
