using FluentValidation;

namespace SouthWestContractors.Application.Features.ContractorCategories.Commands.DeleteContractorCategories
{
    public class DeleteContractorCategoriesCommandValidator : AbstractValidator<DeleteContractorCategoriesCommand>
    {
        public DeleteContractorCategoriesCommandValidator()
        {
            RuleFor(x => x.ContractorId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();           
        }
    }
}
