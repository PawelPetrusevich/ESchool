using System.Reflection;
using AutoMapper;
using ESchool.BusinessLogic.Service;
using ESchool.Common;
using ESchool.Common.Interface.Repository;
using ESchool.Common.Interface.Service;
using ESchool.DataAccess.Context;
using ESchool.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NJsonSchema;
using NSwag.AspNetCore;

namespace ESchool
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
            services.AddMvc();
            services.AddAutoMapper();
            services.AddScoped<DbContext, ESchoolContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddDbContext<ESchoolContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ESchoolConnection")));
        }

        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, new SwaggerUiSettings()
            {
                DefaultPropertyNameHandling = PropertyNameHandling.Default
            });



            app.UseMvc();
        }

        
    }
}
