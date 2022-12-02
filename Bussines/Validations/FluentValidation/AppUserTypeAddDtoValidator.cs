using Entities.Dtos.AppUserTypes;
using FluentValidation;

namespace Business.Validations.FluentValidation
{
    public class AppUserTypeAddDtoValidator : AbstractValidator<AppUserTypeAddDto>
    {
        public AppUserTypeAddDtoValidator()
        {
            RuleFor(x => x.UserTypeName).NotEmpty().
                WithErrorCode("VALIDATION_UserTypeNameFieldCannotBeEmpty");
        }
    }
}
