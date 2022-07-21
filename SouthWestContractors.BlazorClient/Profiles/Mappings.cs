using AutoMapper;
using SouthWestContractors.BlazorClient.Services;
using SouthWestContractors.BlazorClient.Services.Base;
using SouthWestContractors.BlazorClient.ViewModels;

namespace SouthWestContractors.AppClient.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ContractorsListVm, ContractorListViewModel>();
            CreateMap<CategoryDetailDto, Category>();
            CreateMap<ContractorCategoryDetailDto, ContractorCategory>();
            CreateMap<GaleryDetailDto, Galery>();
            CreateMap<ContractorDetailVM, ContractorDetailViewModel>();
            CreateMap<CategoryListVm, Category>();
            CreateMap<CategoryVM, Category>();
            CreateMap<Category, UpdateCategoryCommand>();
            CreateMap<Category, DeleteCategoryCommand>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<CreateCategoryCommandResponse, ApiResponse<CreateCategoryDto>>();
        }
    }
}
