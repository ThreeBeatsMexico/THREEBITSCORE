using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using RestSharp;
using ThreeBits.Business.Filters;
using ThreeBits.Business.Helpers;
using ThreeBits.Interfaces.Security.Common;
using ThreeBits.Interfaces.Security.Security;
using ThreeBits.Interfaces.Security.Users;
using ThreeBits.Services.Security;
using ThreeBits.Services.Security.Common;
using ThreeBits.Services.Security.Security;
using ThreeBits.Services.Security.User;

namespace ThreeBits.Api.Security
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
                
            });

            



            services.AddCors(options =>
            {
                options.AddPolicy("ThreeBitsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();

                    });
            });
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                                  });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ThreeBits.Api.Core", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Here Enter JWT Token with bearer format like bearer[space] token"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                            }
                        },
                        new string [] {}
                    }
                });
                c.OperationFilter<xAppIdHeader>();
            });
            services.AddHttpContextAccessor();            
            services.AddTransient<IRestClient, RestClient>();
            services.AddScoped<ISecurityServiceBR, SecurityServiceBR>();
            services.AddScoped<ISecurityServiceDA, SecurityServiceDA>();
            services.AddScoped<ICommonServiceBR, CommonServiceBR>();
            services.AddScoped<ICommonServiceDA, CommonServiceDA>();
            services.AddScoped<IUserServiceBR, UserServiceBR>();
            services.AddScoped<IUserServiceDA, UserServiceDA>();


            // services.AddScoped<JwtAuthenticationAttribute>();
            // config.Filters.Add(new AuthorizeAttribute());


            services.AddHttpContextAccessor();



        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ThreeBits.Api.Core v1"));
            }
            app.UseRouting();
           
            app.UseCors();
            app.UseMiddleware<CustomHeaderValidatorMiddleware>(xAppIdHeader.HeaderName);
            app.UseMiddleware<JwtMiddleware>();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



    }
}
