using SouthWestContractors.Client.Services.Base;
using SouthWestContractors.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SouthWestContractors.Client.Contracts
{
    public interface IContractorDataService
    {
        Task<List<ContractorListViewModel>> GetAllContractors();
        //Task<ContractorDetailViewModel> GetContractorById(Guid id);
        //Task<ApiResponse<Guid>> CreateContractor(ContractorDetailViewModel eventDetailViewModel);
        //Task<ApiResponse<Guid>> UpdateContractor(ContractorDetailViewModel eventDetailViewModel);
        //Task<ApiResponse<Guid>> DeleteContractor(ContractorDeleteViewModel id);
    }
}
