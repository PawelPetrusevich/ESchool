using System.Threading.Tasks;
using ESchool.Common.DTO;

namespace ESchool.Common.Interface.Service
{
    public interface IUserService
    {
        Task<CreatedUserDto> CreateUser(CreatedUserDto user);

        Task<ModifiUserSettingsDTO> AddUserSettings(ModifiUserSettingsDTO userSettings, int userId);
    }
}