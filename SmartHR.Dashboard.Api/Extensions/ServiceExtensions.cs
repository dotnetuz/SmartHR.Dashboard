using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SmartHR.Dashboard.Data.IRepositories;
using SmartHR.Dashboard.Data.Repositories;
using SmartHR.Dashboard.Service.Interfaces;
using SmartHR.Dashboard.Service.Services;
using System.Text;

namespace SmartHR.Dashboard.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Taqsim.Services.Admin.Api", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
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
                        new string[] { }
                    }
                });

            });
        }

        /// <summary>
        /// Setup CORs
        /// </summary>
        /// <param name="services"></param>
        public static void AddCorsService(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }

        /// <summary>
        /// Setup JWT service for security using token
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void AddJwtService(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication();

            // Jwt bearer configuration
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
                };
            });
        }
    }
}
