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

namespace SouthWestContractors.Application.Features.Contractors.Queries.GetContractorsList
{
    //This class is the handler
    //GetContractListQuery is the request and
    //List<ContractorsListVm is the response
    public class GetContractorsListQueryHandler : IRequestHandler<GetContractorsListQuery, List<ContractorsListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Contractor> _contractorRepository;

        public GetContractorsListQueryHandler(IMapper mapper, IAsyncRepository<Contractor> contractorRepository)
        {
            _mapper=mapper;
            _contractorRepository=contractorRepository;
        }

        public async Task<List<ContractorsListVm>> Handle(GetContractorsListQuery request, CancellationToken cancellationToken)
        {
            //parentesis for await
            var contractorsList = (await _contractorRepository.ListAllAsync()).OrderBy(x => x.LastName);
            return _mapper.Map<List<ContractorsListVm>>(contractorsList);
        }
    }
}
