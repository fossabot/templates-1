namespace Company.Projects.EfCoreConfigurations
{
    using Consts;
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Volo.Abp.Data;
    using Volo.Abp.EntityFrameworkCore;

    [ConnectionStringName(ModuleConsts.ConnectionStringName)]
    public interface IProjectsDbContext : IEfCoreDbContext
    {
        DbSet<TestEntity> Test { get; set; }
    }
}
