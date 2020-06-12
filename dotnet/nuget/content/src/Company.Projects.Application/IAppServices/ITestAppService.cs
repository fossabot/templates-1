namespace Company.Projects.IAppServices
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dtos;
    using JetBrains.Annotations;
    using Volo.Abp.Application.Services;

    public interface ITestAppService : IApplicationService
    {
        Task<TestDto> CreateAsync([NotNull]TestCreateDto dto);

        Task ChangeNameAsync([NotNull]TestDto dto);

        Task<TestDto> GetAsync([NotNull]Guid id);

        Task<IEnumerable<TestDto>> GetListAsync();
    }
}
