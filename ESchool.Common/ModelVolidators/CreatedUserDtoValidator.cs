namespace ESchool.Common.ModelVolidators
{
    using ESchool.Common.DTO;

    using FluentValidation;

    public class CreatedUserDtoValidator: AbstractValidator<CreatedUserDto>
    {
        public CreatedUserDtoValidator()
        {
            this.RuleFor(x => x.Loggin).NotEmpty().MinimumLength(5);
            this.RuleFor(x => x.Password).NotEmpty().MinimumLength(5);
            this.RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}