using System;
using System.Collections.Generic;

namespace SouthWestContractors.API.Models
{
    public class ContractorCategories
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public List<Guid> Categories { get; set; }
    }
}
