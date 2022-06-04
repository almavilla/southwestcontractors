using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Contractors.Commands.DeleteContractor
{
    //It does not return anything and Has one parameter contractorId
    public class DeleteContractorCommand : IRequest
    {
        public Guid ContractorId { get; set; }
    }
}
