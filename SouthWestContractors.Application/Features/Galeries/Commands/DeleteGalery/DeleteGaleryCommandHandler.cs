using AutoMapper;
using MediatR;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Application.Exceptions;
using SouthWestContractors.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Galeries.Commands.DeleteGalery
{
    public class DeleteGaleryCommandHandler : IRequestHandler<DeleteGaleryCommand>
    {
        private readonly IAsyncRepository<Galery> _galeryRepository;
        private readonly IMapper _mapper;

        public DeleteGaleryCommandHandler(IAsyncRepository<Galery> galeryRepository, IMapper mapper)
        {
            _galeryRepository = galeryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteGaleryCommand request, CancellationToken cancellationToken)
        {
            var galeryToDelete = await _galeryRepository.GetByIdAsync(request.GaleryId);
            if(galeryToDelete == null)
            {
                throw new NotFoundException(nameof(Galery), request.GaleryId);
            }
            var validator = new DeleteGaleryCommandValidator();
            var validationResult = validator.Validate(request);
            if(validationResult.Errors.Count>0)
            {
                throw new ValidationException(validationResult);
            }
            _mapper.Map(request, galeryToDelete, typeof(DeleteGaleryCommand), typeof(Galery));
            await _galeryRepository.DeleteAsync(galeryToDelete);
            return Unit.Value;
        }
    }
}
