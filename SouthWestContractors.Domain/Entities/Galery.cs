using SouthWestContractors.Domain.Common;
using System;

namespace SouthWestContractors.Domain.Entities
{
    public class Galery : AuditableEntity
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
