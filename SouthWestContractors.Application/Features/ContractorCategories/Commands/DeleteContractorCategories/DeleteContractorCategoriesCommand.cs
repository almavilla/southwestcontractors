using MediatR;
using SouthWestContractors.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.ContractorCategories.Commands.DeleteContractorCategories
{
    public class DeleteContractorCategoriesCommand: IRequest<BaseResponse>
    {
        public Guid ContractorId { get; set; }
    }
}
