using Microsoft.AspNetCore.Components;
using SouthWestContractors.BlazorClient.Contracts;
using SouthWestContractors.BlazorClient.ViewModels;
using System;
using System.Threading.Tasks;

namespace SouthWestContractors.BlazorClient.Pages
{
    public partial class CategoryUpdate: ComponentBase
    {
        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }
       

        [Parameter]
        public string CategoryId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Category Category { get; set; } = new Category();


        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            //Guid.TryParse(CategoryId, out var categoryId);

            if (string.IsNullOrEmpty(CategoryId)) //new employee is being created
            {
                //add some defaults
                Category = new Category();
            }
            else
            {
                Category = await CategoryDataService.GetCategory(Guid.Parse(CategoryId));
            }

        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (string.IsNullOrEmpty(Category.CategoryId.ToString())) //new
            {
                var addedCategory = await CategoryDataService.AddCategory(Category);
                if (addedCategory != null)
                {
                    StatusClass = "alert-success";
                    Message = "New category added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new category. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await CategoryDataService.UpdateCategory(Category);
                StatusClass = "alert-success";
                Message = "Category updated successfully.";
                Saved = true;
            }
        }
        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteEmployee()
        {
            await CategoryDataService.DeleteCategory(Category);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/CategoryList");
        }
    }
}
