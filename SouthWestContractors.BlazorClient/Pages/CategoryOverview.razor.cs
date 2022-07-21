using Microsoft.AspNetCore.Components;
using SouthWestContractors.BlazorClient.Components;
using SouthWestContractors.BlazorClient.Contracts;
using SouthWestContractors.BlazorClient.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SouthWestContractors.BlazorClient.Pages
{
    public partial class CategoryOverview: ComponentBase
    {
        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        public ICollection<Category> Categories { get; set; }

        protected AddCategoryDialog AddCategoryDialog { get; set; }

        protected override async  Task OnInitializedAsync()
        {
            Categories = (await CategoryDataService.GetAllCategories()).ToList();
        }

        protected void QuickAddCategory()
        {
            AddCategoryDialog.Show();
        }

        public async void AddCategoryDialog_OnDialogClose()
        {
            Categories = (await CategoryDataService.GetAllCategories()).ToList();
            StateHasChanged();
        }
    }
}
