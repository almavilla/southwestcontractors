using SouthWestContractors.BlazorClient.Services;
using SouthWestContractors.BlazorClient.Services.Base;
using SouthWestContractors.BlazorClient.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SouthWestContractors.BlazorClient.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryListViewModel>> GetAllCategories();
        Task<ApiResponse<CreateCategoryDto>> AddCategory(CategoryAddViewModel category);
    }
}
