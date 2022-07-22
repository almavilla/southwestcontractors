using AutoMapper;
using Blazored.LocalStorage;
using SouthWestContractors.BlazorClient.Contracts;
using SouthWestContractors.BlazorClient.Services.Base;
using SouthWestContractors.BlazorClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouthWestContractors.BlazorClient.Services
{
    public class ContractorDataService : BaseDataService, IContractorDataService
    {
        private readonly IMapper _mapper;

        public ContractorDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) 
            : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<ContractorListViewModel>> GetAllContractors()
        {
            await AddBearerToken();
            var allEvents = await _client.GetAllContractorsAsync();
            var mappedEvents = _mapper.Map<ICollection<ContractorListViewModel>>(allEvents);
            return mappedEvents.ToList();
        }

        public async Task<ContractorDetailViewModel> GetContractorDetail(Guid id)
        {
            var selectedContractor = await _client.GetContractorDetailAsync(id);
            var mappedContractor = _mapper.Map<ContractorDetailViewModel>(selectedContractor);
            return mappedContractor;
        }

        public async Task<ApiResponse<Guid>> CreateContractor(ContractorDetailViewModel contractorDetailViewModel)
        {
            try
            {
                CreateContractorCommand createEventCommand = _mapper.Map<CreateContractorCommand>(contractorDetailViewModel);
                var newId = await _client.CreateContractorAsync (createEventCommand);
                return new ApiResponse<Guid>() { Data = newId.Contractor.ContractorId, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> UpdateContractor(ContractorDetailViewModel eventDetailViewModel)
        {
            try
            {
                UpdateContractorCommand updateEventCommand = _mapper.Map<UpdateContractorCommand>(eventDetailViewModel);
                await _client.UpdateContractorAsync(updateEventCommand);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> DeleteContractor(ContractorDeleteViewModel id)
        {
            try
            {
                //Mapping from ContractorDeleteViewModel to DeleteContractorCommand which is defined in ServiceClient
                DeleteContractorCommand deleteContractor = _mapper.Map<DeleteContractorCommand>(id);
                await _client.DeleteContractorAsync(deleteContractor);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
