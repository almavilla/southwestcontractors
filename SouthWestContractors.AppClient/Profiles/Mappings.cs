using AutoMapper;
using SouthWestContractors.AppClient.Services;
using SouthWestContractors.AppClient.ViewModels;

namespace SouthWestContractors.AppClient.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ContractorsListVm, ContractorListViewModel>();
        }
    }
}
