namespace Company.Projects
{
    using Consts;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.Filters;
    using Swashbuckle.AspNetCore.SwaggerUI;
    using Volo.Abp;
    using Volo.Abp.AspNetCore.MultiTenancy;
    using Volo.Abp.Autofac;
    using Volo.Abp.Data;
    using Volo.Abp.EntityFrameworkCore;
    using Volo.Abp.EntityFrameworkCore.SqlServer;
    using Volo.Abp.Modularity;
    using Volo.Abp.MultiTenancy;
    using Volo.Abp.Threading;

    [DependsOn(typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMultiTenancyModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(ProjectsEfCoreModule),
        typeof(ProjectsAppServiceModule),
        typeof(ProjectsWebApiModule))]
    public class ProjectsWebHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            var hostingEnvironment = context.Services.GetHostingEnvironment();

            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = ModuleConsts.IsMultiTenancyEnabled;
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            // swagger
            context.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Company.Projects.Web.Host",
                    Version = "v1",
                });

                options.CustomSchemaIds(type => type.FullName);

                options.DocInclusionPredicate((docName, description) => true);

                options.OperationFilter<AddResponseHeadersFilter>();

                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            if (ModuleConsts.IsMultiTenancyEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Company Projects API");

                options.DocExpansion(DocExpansion.None);
            });

            app.UseConfiguredEndpoints();

            AsyncHelper.RunSync(async () =>
            {
                using var scope = context.ServiceProvider.CreateScope();

                await scope.ServiceProvider
                .GetRequiredService<IDataSeeder>()
                .SeedAsync();
            });
        }
    }
}
