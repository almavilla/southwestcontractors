using System;

namespace SouthWestContractors.BlazorClient.ViewModels
{
    public class ContractorListViewModel
    {
        public Guid ContractorId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
       

    }
}
