using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Contractors.Queries.GetContractor
{
    public class GetContractorDetailQuery: IRequest<ContractorDetailVM>
    {
        public Guid ContractorId { get; set; }
    }
}
