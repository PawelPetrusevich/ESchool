// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" UserDeletedDTO.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: ESchool
//  Project: ESchool.Common
//  Filename: UserDeletedDTO.cs
//  Created day: 08.04.2018    22:37
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace ESchool.Common.DTO
{
    /// <summary>
    /// The user deleted dto.
    /// </summary>
    public class UserDeletedDTO
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public bool IsDeleted { get; set; }
    }
}