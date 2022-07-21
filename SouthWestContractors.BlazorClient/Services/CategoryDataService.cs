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

        public async Task<ApiResponse<CreateCategoryDto>> AddCategory(Category category)
        {
           // await AddBearerToken();
            try
            {
                ApiResponse<CreateCategoryDto> apiResponse = new ApiResponse<CreateCategoryDto>();
                //The AddCategoryAsync is expecting CreateCategoryCommand which is defined in ServiceClient file
                //type so we mapp from CategoryAddViewModel to CreateCategoryCommand. 
                //Then the method is returning CreateCategoryCommandResponse which is defined in ServiceClient file
                //so we mimic CreateCategoryCommandResponse using ApiResponse<CreateCategoryDto>
                //in which CreateCategoryDto is in ServiceClient file and ApiResponse is in Base folder
                CreateCategoryCommand createCategoryCommand = _mapper.Map<CreateCategoryCommand>(category);
                var createCategoryCommandResponse = await _client.AddCategoryAsync(createCategoryCommand);
                if (createCategoryCommandResponse.Success)
                {
                    //apiResponse.Data = _mapper.Map<CreateCategoryDto>(createCategoryCommandResponse.Category);
                    _mapper.Map<ApiResponse<CreateCategoryDto>>(createCategoryCommandResponse);
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
        public async Task UpdateCategory(Category category)
        {
           // await AddBearerToken();
           
                //ApiResponse<CreateCategoryDto> apiResponse = new ApiResponse<CreateCategoryDto>();
                UpdateCategoryCommand updateCategoryCommand = _mapper.Map<UpdateCategoryCommand>(category);
                await _client.UpdateCategoryAsync(updateCategoryCommand);
               
                    //apiResponse.Data = _mapper.Map<CreateCategoryDto>(createCategoryCommandResponse.Category);
                    //_mapper.Map<ApiResponse<CreateCategoryDto>>(createCategoryCommandResponse);
                   // apiResponse.Data = _mapper.Map<CreateCategoryDto>(createCategoryCommandResponse.Category);
                   
            
        }

        public async Task<List<Category>> GetAllCategories()
        {
            //await AddBearerToken();
            var categories = await _client.GetAllCategoriesAsync();
            var categoriesList = _mapper.Map<ICollection<Category>>(categories);            
            return categoriesList.ToList();       
        }
        
        public async Task<Category> GetCategory(Guid id)
        {
            var category = await _client.GetCategoryAsync(id);
            var categoryVM = _mapper.Map<Category>(category);
            return categoryVM;
        }

        public async Task DeleteCategory(Category category)
        {
            //await AddBearerToken();
            var categoryToDelete = _mapper.Map<DeleteCategoryCommand>(category);
            await _client.DeleteCategoryAsync(categoryToDelete);


        }



    }
}
