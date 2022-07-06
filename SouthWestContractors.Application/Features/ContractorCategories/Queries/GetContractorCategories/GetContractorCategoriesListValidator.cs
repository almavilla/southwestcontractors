using FluentValidation;

namespace SouthWestContractors.Application.Features.ContractorCategories.Queries.GetContractorCategories
{
    public class GetContractorCategoriesListValidator : AbstractValidator<GetContractorCategoriesListQuery>
    {
        public GetContractorCategoriesListValidator()
        {
            RuleFor(x => x.ContractorId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");
        }
    }
}
