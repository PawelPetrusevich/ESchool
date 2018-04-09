// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" IAdminService.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: ESchool
//  Project: ESchool.Common
//  Filename: IAdminService.cs
//  Created day: 09.04.2018    11:36
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace ESchool.Common.Interface.Service
{
    using System.Threading.Tasks;

    using ESchool.Common.DTO;

    public interface IAdminService
    {
        Task<UserBannedDTO> UserBanned(int userId);

        Task<UserDeletedDTO> UserDeleted(int userId);
    } 
}