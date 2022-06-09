using AutoMapper;
using SouthWestContractors.Application.Features.Categories.Commands.CreateCategory;
using SouthWestContractors.Application.Features.Categories.Queries.GetCategoriesList;
using SouthWestContractors.Application.Features.Contractors.Commands.CreateContractor;
using SouthWestContractors.Application.Features.Contractors.Commands.UpdateContractor;
using SouthWestContractors.Application.Features.Contractors.Queries.GetContractorsList;
using SouthWestContractors.Application.Features.Galeries.Queries.GetCategoriesList;
using SouthWestContractors.Domain.Entities;

namespace SouthWestContractors.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //source/destination
            CreateMap<CreateContractorCommand, Contractor>();
            CreateMap<UpdateContractorCommand, Contractor>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Contractor, CreateContractorDto>();
            CreateMap<Contractor, ContractorsListVm>();
            CreateMap<Galery, GaleriesListVm>();
            CreateMap<Category, CategoryListVm>();
        }
    }
}
