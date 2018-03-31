namespace ESchool.BusinessLogic.Service
{
    using System;
    using System.Threading.Tasks;

    using AutoMapper;

    using ESchool.BusinessLogic.Properties;
    using ESchool.Common.DTO;
    using ESchool.Common.Interface.Repository;
    using ESchool.Common.Interface.Service;
    using ESchool.Common.Model.Users;

    using Serilog;

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        private readonly IUserSettingsRepository userSettingsRepository;

        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper, IUserSettingsRepository userSettingsRepository)
        {
            this.mapper = mapper;
            this.userSettingsRepository = userSettingsRepository;
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
                Log.Error(LogResources.EmptyArgument, nameof(userDto));
                throw new ArgumentNullException();
            }

            if (this.userRepository.GetByEmail(userDto.Email) != null)
            {
                Log.Error("This email ==> {Email} <== is registered in the system ", userDto.Email);
                throw new ArgumentException(Resources.EmailExistent);
            }

            var user = this.mapper.Map<AccauntDbModel>(userDto);
            var result = await this.userRepository.AddAsync(user);

            if (result == null)
            {
                Log.Error("User not created");
                throw new InvalidOperationException();
            }

            Log.Information("{User} has be created", result.Loggin);
            return this.mapper.Map<CreatedUserDto>(result);
        }


        public async Task<ModifiUserSettingsDTO> AddUserSettings(ModifiUserSettingsDTO userSettings, int userId)
        {
            if (userSettings == null)
            {
                Log.Error(LogResources.EmptyArgument, nameof(userSettings));
                throw new ArgumentNullException();
            }

            if (await this.userRepository.GetAsync(userId) == null)
            {
                Log.Error(LogResources.IncorectArgument, nameof(userId));
                throw new ArgumentException();
            }

            var settings = this.mapper.Map<AccauntSettingsDbModel>(userSettings);
            settings.AccauntId = userId;
            var result = await this.userSettingsRepository.AddAsync(settings);

            if (result == null)
            {
                Log.Error("User settings not create");
                throw new InvalidOperationException("User setting not create");
            }

            Log.Information("User settings is created");
            return this.mapper.Map<ModifiUserSettingsDTO>(result);
        }
    }
}