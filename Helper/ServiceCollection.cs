
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
                .AddScoped<IUserManagement,UserManagement>()
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
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter your token in the text input below.
                      ",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
          {
            {
              new OpenApiSecurityScheme
              {
                Reference = new OpenApiReference
                  {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                  },
                  Scheme = "oauth2",
                  Name = "Bearer",
                  In = ParameterLocation.Header,

                },
                new List<string>()
              }
            });

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
