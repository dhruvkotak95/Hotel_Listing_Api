using Hotel_Listing_Api.Configurations;
using Hotel_Listing_Api.DataModel;
using Hotel_Listing_Api.IdentityConfigurations;
using Hotel_Listing_Api.IRepository;
using Hotel_Listing_Api.JwtServices;
using Hotel_Listing_Api.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace Hotel_Listing_Api
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
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString"))
            );

            services.AddAuthentication();
            services.ConfigureIdentity(); // set up identity and identity roles
            services.ConfigureJwt(Configuration); // set up jwt configuration from service extension

            services.AddCors(o =>
            {
                o.AddPolicy("AllowAllRequests", builder =>
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddAutoMapper(typeof(MapperInitializer));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtAuthManager, JwtAuthManager>();

            AddSwaggerDoc(services);

            services.AddControllers().AddNewtonsoftJson(j =>
            j.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        private void AddSwaggerDoc(IServiceCollection services)
        {
            const string Bearer = "Bearer";
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition(Bearer, new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme.
                        Enter 'Bearer' [SPACE] and then your token in the text input below.
                        Example:- 'Bearer ABCddf1234GHYff'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = Bearer
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = Bearer
                            },
                            Scheme = "0auth2",
                            Name = Bearer,
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotel_Listing_Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseCors("AllowAllRequests");
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel_Listing_Api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); // this line is required as we call [Authorize] annotation before method
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
