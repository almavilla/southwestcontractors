using FluentValidation;

namespace SouthWestContractors.Application.Features.ContractorCategories.Commands.CreateContractorCategories
{
    public class CreateContractorCategoriesCommandValidator : AbstractValidator<CreateContractorCategoriesCommand>
    {
        public CreateContractorCategoriesCommandValidator()
        {
            
            RuleFor(x => x.ContractorId)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();
        }
    }
}
