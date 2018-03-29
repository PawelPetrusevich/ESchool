namespace ESchool.DIContainer
{
    using AutoMapper;

    using ESchool.BusinessLogic.Service;
    using ESchool.Common.Interface.Service;

    using Microsoft.Extensions.DependencyInjection;

    public static class RegisterBusinessLogicDI
    {
        public static IServiceCollection BusinessLogicServiceCollection(this IServiceCollection services)
        {

            services.AddAutoMapper();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}