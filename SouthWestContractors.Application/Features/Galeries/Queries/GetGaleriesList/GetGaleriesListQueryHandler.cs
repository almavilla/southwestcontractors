using AutoMapper;
using MediatR;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Galeries.Queries.GetCategoriesList
{
    public class GetGaleriesListQueryHandler : IRequestHandler<GetGaleriesListQuery, List<GaleriesListVm>>
    {
        private readonly IAsyncRepository<Galery> _galeryRepository;
        private readonly IMapper _mapper;

        public GetGaleriesListQueryHandler(IAsyncRepository<Galery> galeryRepository, IMapper mapper)
        {
            _galeryRepository=galeryRepository;
            _mapper=mapper;
        }

        public async Task<List<GaleriesListVm>> Handle(GetGaleriesListQuery request, CancellationToken cancellationToken)
        {
            var galeries = (await _galeryRepository.ListAllAsync()).OrderBy(x=>x.CreatedDate);
            return _mapper.Map<List<GaleriesListVm>>(galeries);
        }
    }
}
