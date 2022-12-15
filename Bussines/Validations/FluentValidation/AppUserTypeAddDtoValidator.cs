using Entities.Dtos.AppUserTypes;
using FluentValidation;

namespace Business.Validations.FluentValidation
{
    public class AppUserTypeAddDtoValidator : AbstractValidator<AppUserTypeAddDto>
    {
        public AppUserTypeAddDtoValidator()
        {
            RuleFor(x => x.AppUserTypeName).NotEmpty().
                WithErrorCode("VALIDATION_UserTypeNameFieldCannotBeEmpty");
        }
    }
}
