using System;

namespace SouthWestContractors.Application.Features.Contractors.Commands.UpdateContractor
{
    public class GaleryDto
    {
        public Guid GaleryId { get; set; }
        public Guid ContractorId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
