using Microsoft.AspNetCore.Components;
using SouthWestContractors.BlazorClient.Contracts;
using SouthWestContractors.BlazorClient.ViewModels;
using System;
using System.Threading.Tasks;

namespace SouthWestContractors.BlazorClient.Pages
{
    public partial class ContractorDetail
    {
        [Parameter]
        public string ContractorId { get; set; }
        public ContractorDetailViewModel Contractor { get; set; } = new ContractorDetailViewModel();

        [Inject]
        public IContractorDataService ContractorDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Contractor = await ContractorDataService.GetContractorDetail(Guid.Parse(ContractorId));

        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/ContractorOverview");
        }
    }
}
