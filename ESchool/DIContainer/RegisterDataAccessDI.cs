namespace ESchool.DIContainer
{
    using ESchool.Common.Interface.Repository;
    using ESchool.DataAccess.Context;
    using ESchool.DataAccess.Repositories;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class RegisterDataAccessDI
    {
        public static IServiceCollection DataAccessServiceCollection(this IServiceCollection services)
        {

            services.AddScoped<DbContext, ESchoolContext>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}