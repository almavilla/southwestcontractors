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
            var allEvents = await _client.ContractorAllAsync();
            var mappedEvents = _mapper.Map<ICollection<ContractorListViewModel>>(allEvents);
            return mappedEvents.ToList();
        }

        //public async Task<ContractorDetailViewModel> GetContractorById(Guid id)
        //{
        //    var selectedEvent = await _client.contra(id);
        //    var mappedEvent = _mapper.Map<ContractorDetailViewModel>(selectedEvent);
        //    return mappedEvent;
        //}

        public async Task<ApiResponse<Guid>> CreateContractor(ContractorDetailViewModel eventDetailViewModel)
        {
            try
            {
                ContractorCategories createEventCommand = _mapper.Map<ContractorCategories>(eventDetailViewModel);
                var newId = await _client.ContractorPOSTAsync (createEventCommand);
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
                await _client.ContractorPUTAsync(updateEventCommand);
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
