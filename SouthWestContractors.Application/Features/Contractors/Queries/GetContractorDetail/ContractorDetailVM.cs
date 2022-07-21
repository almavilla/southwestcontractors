using SouthWestContractors.Application.Features.Contractors.Queries.GetContractorDetail;
using System;
using System.Collections.Generic;

namespace SouthWestContractors.Application.Features.Contractors.Queries.GetContractor
{
    public class ContractorDetailVM
    {
        public Guid ContractorId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<GaleryDetailDto> Galery { get; set; }
        public ICollection<ContractorCategoryDetailDto> Categories { get; set; }
    }
}
