// --------------------------------------------------------------------------------------------------------------------
// <copyright company=" " file=" UserDeletedDtoValidator.cs">
//    
// </copyright>
// <summary>
//  Creator name: 
//  Solution: ESchool
//  Project: ESchool.Common
//  Filename: UserDeletedDtoValidator.cs
//  Created day: 09.04.2018    12:28
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace ESchool.Common.ModelVolidators
{
    using ESchool.Common.DTO;
    using FluentValidation;
    public class UserDeletedDtoValidator : AbstractValidator<UserDeletedDTO>
    {
        public UserDeletedDtoValidator()
        {
            this.RuleFor(x => x.Id).NotEmpty();
            this.RuleFor(x => x.IsDeleted).NotEmpty();
            this.RuleFor(x => x.UserName).NotEmpty();
        }
    }
}