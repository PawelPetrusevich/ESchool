namespace ESchool.DIContainer
{
    using AutoMapper;

    using ESchool.BusinessLogic.Service;
    using ESchool.Common.Interface.Service;

    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Conteiner for injections in business logic
    /// </summary>
    public static class RegisterBusinessLogicDI
    {
        public static IServiceCollection BusinessLogicServiceCollection(this IServiceCollection services)
        {

            services.AddAutoMapper();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAdminService, AdminService>();
            return services;
        }
    }
}