using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryQuery: IRequest<CategoryVM>
    {
        public Guid CategoryId { get; set; }
    }
}
