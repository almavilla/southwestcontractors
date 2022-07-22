using System;
using System.Collections.Generic;

namespace SouthWestContractors.API.ViewModels
{
    public class ContractorCategoriesVM
    {
        public Guid ContractorId { get; set; }
        public List<Guid> Categories { get; set; }
    }
}
