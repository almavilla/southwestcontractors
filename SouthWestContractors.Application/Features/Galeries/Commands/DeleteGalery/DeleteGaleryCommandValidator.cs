using FluentValidation;

namespace SouthWestContractors.Application.Features.Galeries.Commands.DeleteGalery
{
    public class DeleteGaleryCommandValidator : AbstractValidator<DeleteGaleryCommand>
    {
        public DeleteGaleryCommandValidator()
        {
            RuleFor(x => x.GaleryId)
                .NotEmpty().WithMessage("{PropertyName} is required" );
            RuleFor(x => x.ContractorId)
                .NotEmpty().WithMessage("{PropertyName} is requiered")
                .NotNull().WithMessage("{PropertyName} is requiered");
        }
    }
}
