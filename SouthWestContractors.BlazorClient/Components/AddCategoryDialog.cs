using Microsoft.AspNetCore.Components;
using SouthWestContractors.BlazorClient.Contracts;
using SouthWestContractors.BlazorClient.ViewModels;
using System.Threading.Tasks;

namespace SouthWestContractors.BlazorClient.Components
{
    public partial class AddCategoryDialog
    {
        public Category Category { get; set; } =
           new Category();

        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

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
            Category = new Category();
        }

        protected async Task HandleValidSubmit()
        {
            await CategoryDataService.AddCategory(Category);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}
