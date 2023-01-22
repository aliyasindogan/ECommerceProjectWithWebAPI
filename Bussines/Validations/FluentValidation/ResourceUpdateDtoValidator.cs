using Entities.Dtos.Resources;
using FluentValidation;

namespace Business.Validations.FluentValidation
{
    public class ResourceUpdateDtoValidator : AbstractValidator<ResourceUpdateDto>
    {
        public ResourceUpdateDtoValidator()
        {
            RuleFor(x => x.ResourceName).NotEmpty().
                WithErrorCode("VALIDATION_ResourceNameFieldCannotBeEmpty");

            RuleFor(x => x.ResourceValue).NotEmpty().
                WithErrorCode("VALIDATION_ResourceValueFieldCannotBeEmpty");

            RuleFor(x => x.ResourceGroupName).NotEmpty().
               WithErrorCode("VALIDATION_ResourceGroupNameFieldCannotBeEmpty");

            RuleFor(x => x.LanguageID).NotEmpty().
         WithErrorCode("VALIDATION_LanguageNameFieldCannotBeEmpty");
        }
    }
}
