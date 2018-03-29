using System;
using System.Threading.Tasks;
using AutoMapper;
using ESchool.Common.DTO;
using ESchool.Common.Interface.Repository;
using ESchool.Common.Interface.Service;
using ESchool.Common.Model.Users;

namespace ESchool.BusinessLogic.Service
{
    using ESchool.BusinessLogic.Properties;

    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using Serilog;

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Create user in system.
        /// </summary>
        /// <param name="userDto">UserDto from front-end</param>
        /// <returns> new client</returns>
        /// <exception cref="InvalidOperationException">User not create</exception>
        public async Task<CreatedUserDto> CreateUser(CreatedUserDto userDto)
        {
            if (userDto == null)
            {
                Log.Error("UserDto for create user is empty");
                throw new ArgumentNullException();
            }

            if (this.userRepository.GetByEmail(userDto.Email) != null)
            {
                Log.Error("This email ==> {Email} <== is registered in the system ", userDto.Email);
                throw new ArgumentException(Resources.EmailExistent);
            }
            
            var user = this.mapper.Map<AccauntDbModel>(userDto);
            //user.AccauntSettings = new AccauntSettingsDbModel
            //{
            //    AccauntId = user.Id
            //};
            var result = await this.userRepository.AddAsync(user);

            if (result == null)
            {
                Log.Error("User not created");
                throw new InvalidOperationException();
            }

            Log.Information("{User} has be created", result.Loggin);
            return this.mapper.Map<CreatedUserDto>(result);
        }
    }
}