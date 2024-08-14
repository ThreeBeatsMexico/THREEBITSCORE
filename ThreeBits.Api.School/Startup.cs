using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using RestSharp;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using ThreeBits.Business.Filters;
using ThreeBits.Business.Helpers;
using ThreeBits.Interfaces.Common;
using ThreeBits.Interfaces.School;
using ThreeBits.Interfaces.Security.Security;
using ThreeBits.Interfaces.Security.Users;
using ThreeBits.Services.School;
using ThreeBits.Services.Security;
using ThreeBits.Services.Security.Common;
using ThreeBits.Services.Security.Security;
using ThreeBits.Services.Security.User;

namespace ThreeBits.Api.School
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
			services.Configure(delegate (ApiBehaviorOptions options)
			{
				options.SuppressModelStateInvalidFilter = true;
			});
			services.AddCors(delegate (CorsOptions options)
			{
				options.AddPolicy("ThreeBitsPolicy", delegate (CorsPolicyBuilder builder)
				{
					builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
				});
			});
			services.AddControllers().AddJsonOptions(delegate (JsonOptions options)
			{
				options.JsonSerializerOptions.PropertyNamingPolicy = null;
			});
			services.AddSwaggerGen(delegate (SwaggerGenOptions c)
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "ThreeBits.Api.School",
					Version = "v1"
				});
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "Here Enter JWT Token with bearer format like bearer[space] token"
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement {
			{
				new OpenApiSecurityScheme
				{
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					}
				},
				new string[0]
			} });
				c.OperationFilter<xAppIdHeader>(Array.Empty<object>());
			});
			services.AddHttpContextAccessor();
			services.AddTransient<IRestClient, RestClient>();
			services.AddScoped<ISecurityServiceBR, SecurityServiceBR>();
			services.AddScoped<ISecurityServiceDA, SecurityServiceDA>();
			services.AddScoped<ICommonServiceBR, CommonServiceBR>();
			services.AddScoped<ICommonServiceDA, CommonServiceDA>();
			services.AddScoped<IUserServiceBR, UserServiceBR>();
			services.AddScoped<IUserServiceDA, UserServiceDA>();
			services.AddScoped<ISchoolServiceBR, SchoolServiceBR>();
			services.AddScoped<ISchoolServiceDA, SchoolServiceDA>();
			services.AddHttpContextAccessor();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(delegate (SwaggerUIOptions c)
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "ThreeBits.Api.School v1");
				});
			}
			app.UseRouting();
			app.UseCors();
			app.UseMiddleware<CustomHeaderValidatorMiddleware>(new object[1] { xAppIdHeader.HeaderName });
			app.UseMiddleware<JwtMiddleware>(Array.Empty<object>());
			app.UseAuthorization();
			app.UseEndpoints(delegate (IEndpointRouteBuilder endpoints)
			{
				endpoints.MapControllers();
			});
		}
	}

}