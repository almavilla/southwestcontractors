using AutoMapper;
using MediatR;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Application.Exceptions;
using SouthWestContractors.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Contractors.Commands.UpdateContractor
{
    public class UpdateContractorCommandHandler : IRequestHandler<UpdateContractorCommand, Guid>
    {
        private readonly IAsyncRepository<Contractor> _contractorRepository;
        private readonly IMapper _mapper;

        public UpdateContractorCommandHandler(IAsyncRepository<Contractor> contractorRepository, IMapper mapper)
        {
            _contractorRepository=contractorRepository;
            _mapper=mapper;
        }

        public async Task<Guid> Handle(UpdateContractorCommand request, CancellationToken cancellationToken)
        {
            var contractorToUpdate = await _contractorRepository.GetByIdAsync(request.ContractorId);
            if (contractorToUpdate == null)
            {
                throw new NotFoundException(nameof(Contractor), request.ContractorId);
            }
            var validator = new UpdateContractorCommandValidator();
            var validationResult = validator.Validate(request);
            if(validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request,contractorToUpdate, typeof(UpdateContractorCommand), typeof(Contractor));
            var updatedContractor = await _contractorRepository.UpdateAsync(contractorToUpdate);
            return updatedContractor.ContractorId;
        }
    }
}
