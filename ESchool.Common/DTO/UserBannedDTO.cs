// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" UserBannedDTO.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: ESchool
//  Project: ESchool.Common
//  Filename: UserBannedDTO.cs
//  Created day: 08.04.2018    22:21
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace ESchool.Common.DTO
{

    /// <summary>
    /// Dto for banned user.
    /// </summary>
    public class UserBannedDTO
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public bool IsBanned { get; set; }
        
    }
}