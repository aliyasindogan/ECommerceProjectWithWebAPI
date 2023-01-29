using Entities.Dtos.ResourceDetails;
using FluentValidation;

namespace Business.Validations.FluentValidation
{
    public class ResourceDetailUpdateDtoValidator : AbstractValidator<ResourceDetailUpdateDto>
    {
        public ResourceDetailUpdateDtoValidator()
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
