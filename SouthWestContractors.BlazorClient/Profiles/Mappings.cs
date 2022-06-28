using AutoMapper;
using SouthWestContractors.BlazorClient.Services;
using SouthWestContractors.BlazorClient.ViewModels;

namespace SouthWestContractors.AppClient.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ContractorsListVm, ContractorListViewModel>();
            CreateMap<CategoryListVm, CategoryListViewModel>();
            CreateMap<CategoryAddViewModel, CreateCategoryCommand>();
        }
    }
}
