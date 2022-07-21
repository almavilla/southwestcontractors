using SouthWestContractors.BlazorClient.Services.Base;
using SouthWestContractors.BlazorClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SouthWestContractors.BlazorClient.Contracts
{
    public interface IContractorDataService
    {
        Task<List<ContractorListViewModel>> GetAllContractors();
        //Task<ContractorDetailViewModel> GetContractorById(Guid id);
        Task<ApiResponse<Guid>> CreateContractor(ContractorDetailViewModel eventDetailViewModel);
        Task<ApiResponse<Guid>> UpdateContractor(ContractorDetailViewModel eventDetailViewModel);
        Task<ApiResponse<Guid>> DeleteContractor(ContractorDeleteViewModel id);
        Task<ContractorDetailViewModel> GetContractorDetail(Guid id);
    }
}
