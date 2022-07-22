using System;

namespace SouthWestContractors.Application.Features.Galeries.Commands.UpdateGalery
{
    public class UpdateGaleryDto
    {
        public Guid GaleryId { get; set; }
        public Guid ContractorId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
