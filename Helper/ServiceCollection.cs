
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Policy.Data.Repo;
using Policy.Data.Services;
using Policy.Logger;
using Policy.Repo;

namespace Policy.Helper
{
    internal static class ServiceCollection
    {


        internal static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IPolicyRepo,PolicyRepo>()
                .AddScoped<IBenefitRepo,BenefitRepo>()
                .AddScoped<IPlanRepo,PlanRepo>()
                .AddScoped<ICategoryRepo,CategoryRepo>()

               


            ;//end of repositories
        }
        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IPolicyService, PolicyService>()
                .AddScoped<IPlanBenefitService, PlanBenefitService>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
            ;//end of services
        }



        internal static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                string[] methodsOrder = new string[] { "get", "post", "put", "patch", "delete", "options", "trace" };
                options.OrderActionsBy(apiDesc => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{Array.IndexOf(methodsOrder, apiDesc.HttpMethod.ToLower())}");
                options.CustomSchemaIds(type => type.ToString());
                

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Policy Api",

                });
                

            });
        }

        internal static ILoggingBuilder AddDbLogger(this ILoggingBuilder builder,Action<DbLoggerOptions> configure)
        {
            builder.Services.AddSingleton<ILoggerProvider, DbLoggerProvider>();
            builder.Services.Configure(configure);
            return builder;
        }


    }
}
