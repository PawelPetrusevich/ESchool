namespace ESchool.DIContainer
{
    using ESchool.Common.Interface.Repository;
    using ESchool.DataAccess.Context;
    using ESchool.DataAccess.Repositories;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class RegisterDataAccessDI
    {
        public static IServiceCollection DataAccessServiceCollection(this IServiceCollection services, IConfiguration cfg)
        {
            services.AddScoped<DbContext, ESchoolContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserSettingsRepository,UserSettingsRepository>();
            services.AddDbContext<ESchoolContext>(options => options.UseSqlServer(cfg.GetConnectionString("ESchoolConnection")));
            return services;
        }
    }
}