using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using SouthWestContractors.BlazorClient.Contracts;
using SouthWestContractors.BlazorClient.ViewModels;
using SouthWestContractors.BlazorClient.Services.Base;
using SouthWestContractors.BlazorClient.Services;

namespace SouthWestContractors.BlazorClient.Pages
{
    public class CategoryAddModel: ComponentBase
    {
        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CategoryAddViewModel CategoryViewModel { get; set; }
        public string Message { get; set; }

        protected override void OnInitialized()
        {
            CategoryViewModel = new CategoryAddViewModel();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await CategoryDataService.AddCategory(CategoryViewModel);
            
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<CreateCategoryDto> response)
        {
            if (response.Success)
            {
                Message = "Category added";
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
