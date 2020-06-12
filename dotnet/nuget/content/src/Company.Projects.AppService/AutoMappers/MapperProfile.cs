namespace Company.Projects.Mappings
{
    using AutoMapper;
    using Dtos;
    using Entities;
    using Volo.Abp.AutoMapper;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TestEntity, TestDto>();

            CreateMap<TestCreateDto, TestEntity>()
                .Ignore(m => m.TenantId);
        }
    }
}
