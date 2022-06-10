using FluentValidation;

namespace SouthWestContractors.Application.Features.Galeries.Commands.CreateGalery
{
    public class CreateGaleryCommandValidator: AbstractValidator<CreateGaleryCommand>
    {
        public CreateGaleryCommandValidator()
        {
            RuleFor(x => x.ContractorId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
                
        }
    }
}
