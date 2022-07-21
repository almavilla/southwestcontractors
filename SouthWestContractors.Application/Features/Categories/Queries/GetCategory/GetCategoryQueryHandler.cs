using AutoMapper;
using MediatR;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Application.Exceptions;
using SouthWestContractors.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryVM>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryVM> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var @category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            var categoryDto = _mapper.Map<CategoryVM>(@category);           

            if (category == null)
            {
                throw new NotFoundException(nameof(Category), request.CategoryId);
            }            
            return categoryDto;
        }
    }
}
