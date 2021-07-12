using LoginRegister.DBO.Models;
using LoginRegister.Service.Contracts;
using LoginRegisterAPI.Extension;
using LoginRegisterAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegisterAPI
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
            services.AddDbContext<HospitalManagementContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("HMSConstr"));
            });
            services.AddScoped<IRegister, ServiceLayer>();
            services.AddScoped<IService<Login>, ServiceLayer>();
            services.AddSwaggerGen();
            services.ConfigureJWT();
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.AddControllers();

            //services.AddCors(o => o.AddPolicy("CorePolicy", builder =>
            //{
            //    builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials();
            //}));
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LoginRegisterAPI");
            });
            //app.UseForwardedHeaders(new ForwardedHeadersOptions
            //{
            //    ForwardedHeaders = ForwardedHeaders.All
            //});

            app.UseAuthorization();
            //app.UseCors("EnableCORS");
            //app.UseCors("CorePolicy");

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // allow credentials

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
