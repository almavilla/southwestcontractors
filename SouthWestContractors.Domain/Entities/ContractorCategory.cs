using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWestContractors.Domain.Entities
{
    public class ContractorCategory
    {
        public Guid ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
