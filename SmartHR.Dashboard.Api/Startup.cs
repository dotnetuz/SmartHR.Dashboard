using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmartHR.Dashboard.Api.Extensions;
using SmartHR.Dashboard.Data.Contexts;
using SmartHR.Dashboard.Service.Customs;
using SmartHR.Dashboard.Service.Helpers;
using SmartHR.Dashboard.Service.Interfaces;
using SmartHR.Dashboard.Service.Services;
using SmartHR.Dashboard.Service.ViewModels;

namespace SmartHR.Dashboard.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // setup dbcontexts
            services.AddDbContext<SmartHRDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("SmartHR"));
            });

            // Add JWT settings
            services.AddJwtService(Configuration);

            services.AddHttpContextAccessor();

            // Setup CORS
            services.AddCorsService();

            // Swagger part and others
            services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            }).AddNewtonsoftJson();

            services.AddSignalR();
            services.AddSwaggerService();

            // Custom services
            services.AddCustomServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartHR.Dashboard.Api v1"));
            }

            if (app.ApplicationServices.GetService<IHttpContextAccessor>() != null)
            {
                HttpContextHelper.Accessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            }

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
