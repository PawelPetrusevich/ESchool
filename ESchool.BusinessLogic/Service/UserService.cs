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
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }
        public async Task<UserDTO> CreateUser(UserDTO userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException();
            }

            var user = _mapper.Map<AccauntDbModel>(userDto);
            var result = await _userRepository.AddAsync(user);

            return result is null ? throw new InvalidOperationException() : _mapper.Map<UserDTO>(result);

        }
    }
}