using System;
using System.Threading.Tasks;
using AutoMapper;
using ESchool.Common.DTO;
using ESchool.Common.Interface.Repository;
using ESchool.Common.Interface.Service;
using ESchool.Common.Model.Users;

namespace ESchool.BusinessLogic.Service
{
    using Microsoft.Extensions.Logging;

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
                throw new ArgumentNullException();
            }
            
            var user = this.mapper.Map<AccauntDbModel>(userDto);
            var result = await this.userRepository.AddAsync(user);

            return result is null ? throw new InvalidOperationException() : this.mapper.Map<CreatedUserDto>(result);

        }
    }
}