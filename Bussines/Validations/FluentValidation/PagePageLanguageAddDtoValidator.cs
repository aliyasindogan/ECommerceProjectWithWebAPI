using Entities.Dtos.PagePageLanguages;
using Entities.Dtos.Pages;
using FluentValidation;

namespace Business.Validations.FluentValidation
{
    public class PagePageLanguageAddDtoValidator : AbstractValidator<PagePageLanguageAddDto>
    {
        public PagePageLanguageAddDtoValidator()
        {
            RuleFor(x => x.PageName).NotEmpty().
                WithErrorCode("VALIDATION_PageNameFieldCannotBeEmpty");

            RuleFor(x => x.PageURL).NotEmpty().
               WithErrorCode("VALIDATION_PageURLFieldCannotBeEmpty");

            RuleFor(x => x.PageTypeID).NotEmpty().
               WithErrorCode("VALIDATION_PageTypeIDFieldCannotBeEmpty");

            RuleFor(x => x.DisplayOrder).NotEmpty().
               WithErrorCode("VALIDATION_DisplayOrderFieldCannotBeEmpty");
        }
    }
}
