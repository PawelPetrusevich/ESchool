using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESchool.DIContainer
{
    using ESchool.Common.DTO;
    using ESchool.Common.ModelVolidators;

    using FluentValidation;

    using Microsoft.Extensions.DependencyInjection;

    public static class RegisterValidatorDI
    {
        public static IServiceCollection ValidatorServiceCollection(this IServiceCollection services)
        {

            services.AddTransient<IValidator<CreatedUserDto>, CreatedUserDtoValidator>();
            return services;
        }
    }
}
