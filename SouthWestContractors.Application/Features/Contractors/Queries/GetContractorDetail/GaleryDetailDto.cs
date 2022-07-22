using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Contractors.Queries.GetContractorDetail
{
    public class GaleryDetailDto
    {
        public Guid GaleryId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
