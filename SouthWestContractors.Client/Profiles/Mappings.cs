using AutoMapper;
using SouthWestContractors.Client.Services;
using SouthWestContractors.Client.ViewModels;

namespace SouthWestContractors.Client.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ContractorsListVm, ContractorListViewModel>();
        }
    }
}
