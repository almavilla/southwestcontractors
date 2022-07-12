using FluentValidation;

namespace SouthWestContractors.Application.Features.Galeries.Commands.UpdateGalery
{
    public class UpdateGaleryCommandValidator : AbstractValidator<UpdateGaleryCommand>
    {
        public UpdateGaleryCommandValidator()
        {
            RuleFor(x => x.GaleryId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.ContractorId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");   
        }
    }
}
