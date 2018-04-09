// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" UserBannedDtoValidator.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: ESchool
//  Project: ESchool.Common
//  Filename: UserBannedDtoValidator.cs
//  Created day: 09.04.2018    12:31
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace ESchool.Common.ModelVolidators
{
    using ESchool.Common.DTO;

    using FluentValidation;
    public class UserBannedDtoValidator: AbstractValidator<UserBannedDTO>
    {
        public UserBannedDtoValidator()
        {
            this.RuleFor(x => x.Id).NotEmpty();
            this.RuleFor(x => x.IsBanned).NotEmpty();
            this.RuleFor(x => x.UserName).NotEmpty();
        }
    }
}