using System.Threading.Tasks;
using ESchool.Common.DTO;

namespace ESchool.Common.Interface.Service
{
    public interface IUserService
    {
        Task<UserDTO> CreateUser(UserDTO user);
    }
}