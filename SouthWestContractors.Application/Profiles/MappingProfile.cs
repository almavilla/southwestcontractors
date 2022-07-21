using AutoMapper;
using SouthWestContractors.Application.Features.Categories.Commands.CreateCategory;
using SouthWestContractors.Application.Features.Categories.Commands.DeleteCategory;
using SouthWestContractors.Application.Features.Categories.Commands.UpdateCategory;
using SouthWestContractors.Application.Features.Categories.Queries.GetCategoriesList;
using SouthWestContractors.Application.Features.Categories.Queries.GetCategory;
using SouthWestContractors.Application.Features.ContractorCategories.Queries.GetContractorCategories;
using SouthWestContractors.Application.Features.Contractors.Commands.CreateContractor;
using SouthWestContractors.Application.Features.Contractors.Commands.DeleteContractor;
using SouthWestContractors.Application.Features.Contractors.Commands.UpdateContractor;
using SouthWestContractors.Application.Features.Contractors.Queries.GetContractor;
using SouthWestContractors.Application.Features.Contractors.Queries.GetContractorDetail;
using SouthWestContractors.Application.Features.Contractors.Queries.GetContractorsList;
using SouthWestContractors.Application.Features.Galeries.Commands.CreateGalery;
using SouthWestContractors.Application.Features.Galeries.Commands.DeleteGalery;
using SouthWestContractors.Application.Features.Galeries.Commands.UpdateGalery;
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
            CreateMap<DeleteContractorCommand, Contractor>();
            CreateMap<Contractor, CreateContractorDto>();
            CreateMap<Contractor, ContractorsListVm>();
            CreateMap<ContractorCategory, ContractorCategoryDetailDto>();
            CreateMap<Category, CategoryDetailDto>();
            CreateMap<Galery, GaleryDetailDto>();
            CreateMap<Contractor, ContractorDetailVM>()
                .ForMember(dest => dest.Categories, opt => opt
                .MapFrom(src => src.ContractorCategories));         

            CreateMap<ContractorCategory, ContractorCategoriesListVM>();

           
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, CategoryVM>();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            //CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<DeleteCategoryCommand, Category>();

           
            CreateMap<Galery, GaleriesListVm>();
            CreateMap<Galery, CreateGaleryDto>();
            CreateMap<Galery, UpdateGaleryDto>();
            CreateMap<DeleteGaleryCommand, Galery>();

            //CreateMap<Galery, UpdateGaleryDto>()
            //    .ForMember(dest => dest.GaleryId, opts => opts.MapFrom(src => src.GaleryId))
            //.ForMember(dest => dest.ContractorId, opts => opts.MapFrom(src => src.ContractorId))
            //.ForMember(dest => dest.ImageUrl, opts => opts.MapFrom(src => src.ImageUrl))
            //.ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description));



            //        Mapper.Mapper.CreateMap<BookViewModel, Book>()
            //.ForMember(dest => dest.Author.Name,
            //           opts => opts.MapFrom(src => src.Author));
            //CreateMap<Foo, Bar>().ForMember(x => x.Blarg, opt => opt.Ignore());

            CreateMap<Category, CategoryListVm>();
            
        }
    }
}
