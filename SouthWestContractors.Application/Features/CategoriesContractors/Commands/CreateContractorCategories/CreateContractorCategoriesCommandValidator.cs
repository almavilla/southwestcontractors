using FluentValidation;

namespace SouthWestContractors.Application.Features.CategoriesContractors.Commands.CreateContractorCategories
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
