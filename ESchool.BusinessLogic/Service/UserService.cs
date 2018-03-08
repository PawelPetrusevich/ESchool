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
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<UserDTO> CreateUser(UserDTO userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException();
            }

            var user = Mapper.Map<AccauntDbModel>(userDto);
            var result = await _userRepository.AddAsync(user);

            return result is null ? throw new InvalidOperationException() : Mapper.Map<UserDTO>(result);

        }
    }
}