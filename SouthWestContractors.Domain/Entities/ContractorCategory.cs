using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SouthWestContractors.Domain.Entities
{
    [Table("ContractorCategory", Schema = "dbo")]
    public class ContractorCategory
    {
        public Guid ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
