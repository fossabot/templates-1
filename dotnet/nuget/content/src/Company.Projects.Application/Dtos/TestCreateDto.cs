namespace Company.Projects.Dtos
{
    using System;
    using Volo.Abp.Application.Dtos;

    public class TestCreateDto : EntityDto<Guid?>
    {
        public TestCreateDto(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
