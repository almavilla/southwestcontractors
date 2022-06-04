using AutoMapper;
using MediatR;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Contractors.Commands.DeleteContractor
{
    public class DeleteContractorCommandHandler : IRequestHandler<DeleteContractorCommand>
    {
        private readonly IAsyncRepository<Contractor> _contractorRepository;
        private readonly IMapper _mapper;

        public DeleteContractorCommandHandler(IAsyncRepository<Contractor> contractorRepository, IMapper mapper)
        {
            _contractorRepository=contractorRepository;
            _mapper=mapper;
        }

        public async Task<Unit> Handle(DeleteContractorCommand request, CancellationToken cancellationToken)
        {
            var contractor = await _contractorRepository.GetByIdAsync(request.ContractorId);
            await _contractorRepository.DeleteAsync(contractor);
            return Unit.Value;
        }
    }
}
