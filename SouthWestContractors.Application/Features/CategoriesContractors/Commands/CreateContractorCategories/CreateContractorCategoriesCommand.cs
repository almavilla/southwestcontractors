using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.CategoriesContractors.Commands.CreateContractorCategories
{
    public class CreateContractorCategoriesCommand : IRequest<int>
    {
        public Guid ContractorId { get; set; }
        public List<Guid> Categories { get; set; }
    }
}
