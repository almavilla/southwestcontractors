using SouthWestContractors.Domain.Common;
using System;

namespace SouthWestContractors.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
