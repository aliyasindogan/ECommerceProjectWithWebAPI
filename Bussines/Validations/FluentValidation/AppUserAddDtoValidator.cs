using Entities.Dtos.AppUsers;
using FluentValidation;

namespace Business.Validations.FluentValidation
{
    public class AppUserAddDtoValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().
                WithErrorCode("VALIDATION_UserNameFieldCannotBeEmpty");

            RuleFor(x => x.Password).NotEmpty().
                WithErrorCode("VALIDATION_PasswordFieldCannotBeEmpty");

            RuleFor(x => x.Email).NotEmpty().
                WithErrorCode("VALIDATION_EmailFieldCannotBeEmpty");

            RuleFor(x => x.FirstName).NotEmpty().
                WithErrorCode("VALIDATION_FirstNameFieldCannotBeEmpty");

            RuleFor(x => x.LastName).NotEmpty().
                  WithErrorCode("VALIDATION_LastNameFieldCannotBeEmpty");

            RuleFor(x => x.GsmNumber).NotEmpty().
               WithErrorCode("VALIDATION_GsmNumberFieldCannotBeEmpty");

            RuleFor(x => x.RefreshToken).NotEmpty().
               WithErrorCode("VALIDATION_RefreshTokenFieldCannotBeEmpty");

            RuleFor(x => x.UserTypeID).NotEmpty().
                WithErrorCode("VALIDATION_AppUserTypeFieldCannotBeEmpty");
        }
    }
}
