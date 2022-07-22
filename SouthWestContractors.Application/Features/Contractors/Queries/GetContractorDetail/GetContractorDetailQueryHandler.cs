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

namespace SouthWestContractors.Application.Features.Contractors.Queries.GetContractor
{
    public class GetContractorDetailQueryHandler : IRequestHandler<GetContractorDetailQuery, ContractorDetailVM>
    {
        private readonly IContractorRepository _contractorRepository;
        private readonly IMapper _mapper;

        public GetContractorDetailQueryHandler(IContractorRepository contractorRepository, IMapper mapper)
        {
            _contractorRepository = contractorRepository;
            _mapper = mapper;
        }

        public async Task<ContractorDetailVM> Handle(GetContractorDetailQuery request, CancellationToken cancellationToken)
        {
            var contractor = await _contractorRepository.ContractorDetails(request.ContractorId);
            var contractorDetailVM = _mapper.Map<ContractorDetailVM>(contractor);
            return contractorDetailVM;
            
        }
    }
}
