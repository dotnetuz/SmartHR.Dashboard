using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmartHR.Dashboard.Api.Extensions;
using SmartHR.Dashboard.Data.Contexts;
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

            services.AddTransient<IMailService, MailService>();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartHR.Dashboard.Api", Version = "v1" });
            });

            services.AddCustomServices();
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
