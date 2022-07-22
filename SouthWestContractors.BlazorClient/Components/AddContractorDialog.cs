using Microsoft.AspNetCore.Components;
using SouthWestContractors.BlazorClient.Contracts;
using SouthWestContractors.BlazorClient.ViewModels;
using System.Threading.Tasks;

namespace SouthWestContractors.BlazorClient.Components
{
    public partial class AddContractorDialog
    {
        public ContractorDetailViewModel Contractor { get; set; } =
         new ContractorDetailViewModel();

        [Inject]
        public IContractorDataService ContractorDataService { get; set; }

        public bool ShowDialog { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            Contractor = new ContractorDetailViewModel();
        }

        protected async Task HandleValidSubmit()
        {
            await ContractorDataService.CreateContractor(Contractor);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}
