using SouthWestContractors.Domain.Common;
using System;
using System.Collections.Generic;

namespace SouthWestContractors.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<ContractorCategory> ContractorCategories { get; set; }

    }
}
