using System;

namespace SouthWestContractors.Application.Features.Galeries.Queries.GetCategoriesList
{
    public class GaleriesListVm
    {
        public Guid GaleryId { get; set; }
        public Guid ContractorId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
