using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.ContractorCategories.Queries.GetContractorCategories
{
    public class GetContractorCategoriesListQuery: IRequest<IReadOnlyList<Guid>>
    {
        public Guid ContractorId { get; set; }
    }
}
