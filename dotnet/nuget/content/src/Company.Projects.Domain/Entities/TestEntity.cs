namespace Company.Projects.Entities
{
    using System;
    using Consts;
    using JetBrains.Annotations;
    using Volo.Abp;
    using Volo.Abp.Domain.Entities;
    using Volo.Abp.MultiTenancy;

    public class TestEntity : Entity<Guid>, IMultiTenant
    {
        public TestEntity([NotNull]string name)
        {
            SetName(name);
        }

        public string Name { get; set; }

        public Guid? TenantId { get; set; }

        internal void SetName([NotNull]string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), TestConsts.MaxNameLength);
        }
    }
}
