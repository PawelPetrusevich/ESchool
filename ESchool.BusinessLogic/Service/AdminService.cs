// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" AdminService.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: ESchool
//  Project: ESchool.BusinessLogic
//  Filename: AdminService.cs
//  Created day: 09.04.2018    11:41
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace ESchool.BusinessLogic.Service
{
    using System;
    using System.Threading.Tasks;

    using AutoMapper;

    using ESchool.Common.DTO;
    using ESchool.Common.Interface.Repository;
    using ESchool.Common.Interface.Service;
    using ESchool.Common.Model.Users;

    using Serilog;

    public class AdminService : IAdminService
    {
        private readonly IUserRepository userRepository;

        public AdminService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserBannedDTO> UserBanned(int userId)
        {
            var user = await this.userRepository.GetAsync(userId);

            if (user == null)
            {
                throw new ArgumentException();
            }

            user.IsBanned = true;

            var result = await this.userRepository.UpdateAsync(user);

            return Mapper.Map<UserBannedDTO>(user);
        }

        public async Task<UserDeletedDTO> UserDeleted(int userId)
        {
            var user = await this.userRepository.GetAsync(userId);

            if (user == null)
            {
                throw new ArgumentException();
            }

            user.IsDeleted = true;

            var result = await this.userRepository.UpdateAsync(user);

            return Mapper.Map<UserDeletedDTO>(result);
        }
    }
}