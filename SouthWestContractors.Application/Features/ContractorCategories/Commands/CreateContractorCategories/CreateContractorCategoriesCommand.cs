using MediatR;
using SouthWestContractors.Application.Responses;
using System;
using System.Collections.Generic;

namespace SouthWestContractors.Application.Features.ContractorCategories.Commands.CreateContractorCategories
{
    public class CreateContractorCategoriesCommand : IRequest<BaseResponse>
    {
        public Guid ContractorId { get; set; }
        public List<Guid> Categories { get; set; }
    }
}
