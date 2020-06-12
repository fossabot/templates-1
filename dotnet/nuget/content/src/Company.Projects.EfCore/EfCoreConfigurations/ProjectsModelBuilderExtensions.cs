namespace Company.Projects.EfCoreConfigurations
{
    using System;
    using Consts;
    using Entities;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using Options;
    using Volo.Abp;

    public static class ProjectsModelBuilderExtensions
    {
        public static void ConfigureProjects(
            [NotNull] this ModelBuilder builder,
            [CanBeNull] Action<ProjectsModelBuilderOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ProjectsModelBuilderOptions(
                DbOptions.Prefix,
                DbOptions.Schema
            );

            optionsAction?.Invoke(options);

            builder.Entity<TestEntity>(b =>
            {
                b.ToTable(options.TablePrefix + nameof(TestEntity), options.Schema);

                b.Property(m => m.Name).IsRequired().HasMaxLength(TestConsts.MaxNameLength);
            });
        }
    }
}
