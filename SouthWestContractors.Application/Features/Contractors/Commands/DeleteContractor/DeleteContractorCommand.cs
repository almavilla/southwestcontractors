using MediatR;
using System;

namespace SouthWestContractors.Application.Features.Contractors.Commands.DeleteContractor
{
    //It does not return anything and has one parameter contractorId
    public class DeleteContractorCommand : IRequest
    {
        public Guid ContractorId { get; set; }
    }
}
