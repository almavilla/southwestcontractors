using Microsoft.AspNetCore.Components;
using SouthWestContractors.BlazorClient.Contracts;
using SouthWestContractors.BlazorClient.ViewModels;
using System;
using System.Threading.Tasks;

namespace SouthWestContractors.BlazorClient.Pages
{
    public partial class CategoryDetail : ComponentBase
    {
        [Parameter]
        public string CategoryId { get; set; }
        public Category Category {get;set;} = new Category();

        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
       
        protected async override Task OnInitializedAsync()
        {
            Category = await CategoryDataService.GetCategory(Guid.Parse(CategoryId));
        
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/CategoryList");
        }
    }
}
