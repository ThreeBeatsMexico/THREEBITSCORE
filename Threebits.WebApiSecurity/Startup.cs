using Microsoft.OpenApi.Models;
using RestSharp;
using ThreeBits.Business.Security;
using ThreeBits.Data.Security;
using ThreeBits.Interfaces.Security;
using ThreeBits.Services.Security;

namespace Threebits.WebApiSecurity
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("TBCorsPolicy",
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ThreeBits.WebApiSecurity", Version = "v1" });
            });

            //services.AddHttpClient<INotificaService, NotificaService>();
            //services.AddHttpClient<IFirmaElectronicaService, FirmaElectronicaService>();
            //services.AddHttpClient<ILatinoService, LatinoService>();

            //services.AddTransient<IRestClient, RestClient>();

            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<ISecurityDA, SecurityDA>();
            services.AddScoped<ISecurityBR, SecurityBR>();
            //services.AddScoped<IAdminService, AdminService>();
            //services.AddScoped<ICatalogoService, CatalogoService>();
            //services.AddScoped<IGestionService, GestionService>();
            //services.AddScoped<IUsuarioService, UsuarioService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IES.Formularios.WebApi v1"));
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



    }
}
