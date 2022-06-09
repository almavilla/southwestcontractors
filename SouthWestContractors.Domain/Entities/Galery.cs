using SouthWestContractors.Domain.Common;
using System;

namespace SouthWestContractors.Domain.Entities
{
    public class Galery : AuditableEntity
    {
        public Guid GaleryId { get; set; }
        public Guid ContractorId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public Contractor Contractor { get; set; }
    }
}
