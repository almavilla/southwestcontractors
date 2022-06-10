using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.CategoriesContractors.Commands.CreateContractorCategories
{
    public class CreateContractorCategoriesCommandHandler : IRequestHandler<CreateContractorCategoriesCommand, int>
    {
        private readonly IAsyncRepository<ContractorCategory> _contractorCategoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateContractorCategoriesCommandHandler> _logger;

        public CreateContractorCategoriesCommandHandler(IAsyncRepository<ContractorCategory> contractorCategoryRepository,
            IMapper mapper,
            ILogger<CreateContractorCategoriesCommandHandler> logger)
        {
            _contractorCategoryRepository=contractorCategoryRepository;
            _mapper=mapper;
            _logger=logger;
        }

        public async Task<int> Handle(CreateContractorCategoriesCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateContractorCategoriesCommandValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

           // var @contractorCategory = _mapper.Map<ContractorCategory>(request);

            try
            {
                foreach(var item in request.Categories)
                {
                    var contractorCategoryToCreate = new ContractorCategory();
                    contractorCategoryToCreate.ContractorId=request.ContractorId;
                    contractorCategoryToCreate.CategoryId=item;
                    var createdContractorCategory = await _contractorCategoryRepository.AddAsync(contractorCategoryToCreate);

                }

            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
                _logger.LogError($"Failed creating ContractorCategory relationship: {ex.Message}");
            }

            return request.Categories.Count;
        }
    }
}
