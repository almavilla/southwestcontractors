using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Galeries.Commands.CreateGalery
{
    public class CreateGaleryDto
    {
        public Guid GaleryId { get; set; }
        public Guid ContractorId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
