using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private ILogger<CreateCategoryCommandHandler> _logger;

        public CreateCategoryCommandHandler(IMapper mapper, 
            IAsyncRepository<Category> categoryRepository,
            ILogger<CreateCategoryCommandHandler> logger)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateCategoryCommandResponse();

            var validator = new CreateCategoryCommandValidator();
            var validatorResult = validator.Validate(request);
            if (validatorResult.Errors.Count > 0)
            {
                response.ValidationErrors = new List<string>();
                response.Success = false;
                foreach (var error in validatorResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                    _logger.LogError(error.ErrorMessage);

                }

            }
            if (response.Success)
            {
                _logger.LogInformation("Category created successfully");
                var category = new Category() { Name = request.Name };
                category = await _categoryRepository.AddAsync(category);
                response.Category = _mapper.Map<CreateCategoryDto>(category);
            }
            return response;

        }
    }
}
