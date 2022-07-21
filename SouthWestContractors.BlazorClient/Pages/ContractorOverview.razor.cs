using Microsoft.AspNetCore.Components;
using SouthWestContractors.BlazorClient.Components;
using SouthWestContractors.BlazorClient.Contracts;
using SouthWestContractors.BlazorClient.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouthWestContractors.BlazorClient.Pages
{
    public partial class ContractorOverview
    {
        [Inject]
        public IContractorDataService ContractorDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<ContractorListViewModel> Contractors { get; set; }
        protected AddContractorDialog AddContractorDialog { get; set; }

        //[Inject]
        //public IJSRuntime JSRuntime { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Contractors = await ContractorDataService.GetAllContractors();
        }

        protected void QuickAddContractor()
        {
            AddContractorDialog.Show();
        }

        public async void AddContractorDialog_OnDialogClose()
        {
            Contractors = (await ContractorDataService.GetAllContractors()).ToList();
            StateHasChanged();
        }
    }
}
