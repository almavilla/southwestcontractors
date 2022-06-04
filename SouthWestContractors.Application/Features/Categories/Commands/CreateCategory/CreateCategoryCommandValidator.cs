using FluentValidation;

namespace SouthWestContractors.Application.Features.Categories.Commands.CreateCategory
{
    //install fluentValidation dependency injection
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must not exceed 50 characters");
        }
    }
}
