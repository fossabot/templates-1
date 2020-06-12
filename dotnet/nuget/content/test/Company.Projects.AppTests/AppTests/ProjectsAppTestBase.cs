namespace Company.Projects.AppTests
{
    using System;
    using TestBases;
    using EfCoreConfigurations;

    public abstract class ProjectsAppTestBase : ProjectsTestBase<ProjectsAppTestModule>
    {
        protected virtual void UsingDbContext(Action<IProjectsDbContext> action)
        {
            using var dbContext = GetRequiredService<IProjectsDbContext>();

            action.Invoke(dbContext);
        }

        protected virtual T UsingDbContext<T>(Func<IProjectsDbContext, T> action)
        {
            using var dbContext = GetRequiredService<IProjectsDbContext>();

            return action.Invoke(dbContext);
        }
    }
}
