using Entities.Dtos.AppUserTypes;
using FluentValidation;

namespace Business.Validations.FluentValidation
{
    public class AppUserTypeUpdateDtoValidator : AbstractValidator<AppUserTypeUpdateDto>
    {
        public AppUserTypeUpdateDtoValidator()
        {
            RuleFor(x => x.AppUserTypeName).NotEmpty().
                WithErrorCode("VALIDATION_UserTypeNameFieldCannotBeEmpty");
        }
    }
}
