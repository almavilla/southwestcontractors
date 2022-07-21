using SouthWestContractors.BlazorClient.Services;
using SouthWestContractors.BlazorClient.Services.Base;
using SouthWestContractors.BlazorClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SouthWestContractors.BlazorClient.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<Category>> GetAllCategories();
        Task<ApiResponse<CreateCategoryDto>> AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task<Category> GetCategory(Guid id);
        Task DeleteCategory(Category deleteCategory);
    }
}
