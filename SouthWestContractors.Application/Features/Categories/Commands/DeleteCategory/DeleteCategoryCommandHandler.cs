using AutoMapper;
using MediatR;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Application.Exceptions;
using SouthWestContractors.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository=categoryRepository;
            _mapper=mapper;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (categoryToDelete == null)
            {
                throw new NotFoundException(typeof(Category).ToString(), request.CategoryId);
            }
            var validator = new DeleteCategoryCommandValidator();
            var validationResult = validator.Validate(request);
            if(validationResult.Errors.Count>0)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request, categoryToDelete, typeof(DeleteCategoryCommand), typeof(Category));
            await _categoryRepository.DeleteAsync(categoryToDelete);
            return Unit.Value;

        }
    }
}
