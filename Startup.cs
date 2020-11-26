using AutoMapper;
using DrHelperBack.Data;
using DrHelperBack.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;

namespace DrHelperBack
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
            services.AddDbContext<DrHelperContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("DrHelperDBConnection")));

            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IDrHelperRepo<UserType>, SqlUserTypeRepo>();

            services.AddScoped<IDrHelperRepo<Disease>, SqlDiseaseRepo>();

            services.AddScoped<IDrHelperRepo<User>, SqlUserRepo>();

            services.AddScoped<IDrHelperRepo<Medicine>, SqlMedicineRepo>();

            services.AddScoped<IDrHelperRepo<Timeblock>, SqlTimeblockRepo>();

            services.AddScoped<IUsersDiseases, SqlUsersDiseasesRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
