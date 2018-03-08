using ESchool.BusinessLogic.Service;
using ESchool.Common.Interface.Repository;
using ESchool.Common.Interface.Service;
using ESchool.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ESchool
{
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Dependency service and repository for this interface.
        /// </summary>
        /// <param name="service"></param>
        public static void DIContainer(this IServiceCollection service)
        {
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IUserService, UserService>();
        }
    }
}
