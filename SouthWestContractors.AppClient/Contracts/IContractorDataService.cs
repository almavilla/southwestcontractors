using SouthWestContractors.AppClient.Services.Base;
using SouthWestContractors.AppClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SouthWestContractors.AppClient.Contracts
{
    public interface IContractorDataService
    {
        Task<List<ContractorListViewModel>> GetAllContractors();
        //Task<ContractorDetailViewModel> GetContractorById(Guid id);
        Task<ApiResponse<Guid>> CreateContractor(ContractorDetailViewModel eventDetailViewModel);
        Task<ApiResponse<Guid>> UpdateContractor(ContractorDetailViewModel eventDetailViewModel);
        Task<ApiResponse<Guid>> DeleteContractor(ContractorDeleteViewModel id);
    }
}
