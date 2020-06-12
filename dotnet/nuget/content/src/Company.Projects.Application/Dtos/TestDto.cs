namespace Company.Projects.Dtos
{
    using System;
    using Volo.Abp.Application.Dtos;

    public class TestDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public Guid? TenantId { get; set; }
    }
}
