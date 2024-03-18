using BusinessObject;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.Impl;
using Services;
using Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BirthdayPartyBooking
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
            services.AddCors(options =>
            {
                options.AddPolicy("_myAllowSpecificOrigins",
                    policy =>
                    {
                        policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();

                    });
            });

            var secretKey = Configuration["ConnectionStrings:SecretKey"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BirthdayPartyBooking", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            services.AddDbContext<BirthdayPartyBookingContext>();

            services.AddScoped<IRepoWrapper, RepoWrapper>();
            services.AddScoped<IAccountRepo, AccountRepo>();
            services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IPlaceRepo, PlaceRepo>();
            services.AddScoped<IServiceRepo, ServiceRepo>();
            services.AddScoped<IServiceTypeRepo, ServiceTypeRepo>();

            services.AddScoped<IServiceWrapper, ServiceWrapper>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IServiceTypeService, ServiceTypeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BirthdayPartyBooking v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("_myAllowSpecificOrigins");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
