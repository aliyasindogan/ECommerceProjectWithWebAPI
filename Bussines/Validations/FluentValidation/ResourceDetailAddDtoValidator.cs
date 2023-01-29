using Entities.Dtos.ResourceDetails;
using FluentValidation;

namespace Business.Validations.FluentValidation
{
    public class ResourceDetailAddDtoValidator : AbstractValidator<ResourceDetailAddDto>
    {
        public ResourceDetailAddDtoValidator()
        {
            RuleFor(x => x.ResourceID).NotEmpty().
                WithErrorCode("VALIDATION_ResourceNameFieldCannotBeEmpty");

            RuleFor(x => x.ResourceValue).NotEmpty().
                WithErrorCode("VALIDATION_ResourceValueFieldCannotBeEmpty");

            RuleFor(x => x.LanguageID).NotEmpty().
         WithErrorCode("VALIDATION_LanguageNameFieldCannotBeEmpty");
        }
    }
}
