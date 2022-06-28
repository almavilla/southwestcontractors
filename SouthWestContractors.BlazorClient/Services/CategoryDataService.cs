using AutoMapper;
using Blazored.LocalStorage;
using SouthWestContractors.BlazorClient.Contracts;
using SouthWestContractors.BlazorClient.Services.Base;
using SouthWestContractors.BlazorClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouthWestContractors.BlazorClient.Services
{
    public class CategoryDataService : BaseDataService, ICategoryDataService
    {
        private readonly IMapper _mapper;
        public CategoryDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) 
            : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<CreateCategoryDto>> AddCategory(CategoryAddViewModel category)
        {
            await AddBearerToken();
            try
            {
                ApiResponse<CreateCategoryDto> apiResponse = new ApiResponse<CreateCategoryDto>();
                CreateCategoryCommand createCategoryCommand = _mapper.Map<CreateCategoryCommand>(category);
                var createCategoryCommandResponse = await _client.AddCategoryAsync(createCategoryCommand);
                if (createCategoryCommandResponse.Success)
                {
                    apiResponse.Data = _mapper.Map<CreateCategoryDto>(createCategoryCommandResponse.Category);
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Data = null;
                    foreach (var error in createCategoryCommandResponse.ValidationErrors)
                    {
                        apiResponse.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<CreateCategoryDto>(ex);
            }
        }

        public async Task<List<CategoryListViewModel>> GetAllCategories()
        {
            await AddBearerToken();
            var categories = await _client.GetAllCategoriesAsync();
            var categoriesList = _mapper.Map<ICollection<CategoryListViewModel>>(categories);            
            return categoriesList.ToList();       
        }

        //public async Task DeleteCategory(CategoryDeleteViewModel deleteCategory)
        //{
        //    await AddBearerToken();
        //    await _client.d

        //}

      

    }
}
