using AutoMapper;
using SouthWestContractors.API.Models;
using SouthWestContractors.Application.Features.Contractors.Commands.CreateContractor;

namespace SouthWestContractors.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContractorCategories, CreateContractorCommand>();
        }
    }
}
