namespace ESchool.Common.ModelVolidators
{
    using ESchool.Common.DTO;

    using FluentValidation;

    public class UserSettingsDtoValidator : AbstractValidator<ModifiUserSettingsDTO>
    {
        public UserSettingsDtoValidator()
        {
            this.RuleFor(x => x.FirstName).NotEmpty().MinimumLength(5);
            this.RuleFor(x => x.LastName).NotEmpty().MinimumLength(5);
            this.RuleFor(x => x.DateOfBirth).NotEmpty();
        }
    }
}