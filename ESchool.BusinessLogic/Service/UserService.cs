using System;
using System.Threading.Tasks;
using AutoMapper;
using ESchool.Common.DTO;
using ESchool.Common.Interface.Repository;
using ESchool.Common.Interface.Service;
using ESchool.Common.Model.Users;

namespace ESchool.BusinessLogic.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
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