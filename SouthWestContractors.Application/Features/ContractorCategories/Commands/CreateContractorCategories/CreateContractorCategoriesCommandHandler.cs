using MediatR;
using Microsoft.Extensions.Logging;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Application.Responses;
using SouthWestContractors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.ContractorCategories.Commands.CreateContractorCategories
{
    public class CreateContractorCategoriesCommandHandler : IRequestHandler<CreateContractorCategoriesCommand, BaseResponse>
    {
        private readonly IContractorCategoryRepository _contractorCategoryRepository;
        private readonly ILogger<CreateContractorCategoriesCommandHandler> _logger;

        public CreateContractorCategoriesCommandHandler(IContractorCategoryRepository contractorCategoryRepository,
            ILogger<CreateContractorCategoriesCommandHandler> logger)
        {
            _contractorCategoryRepository = contractorCategoryRepository;
            _logger = logger;
        }

        public async Task<BaseResponse> Handle(CreateContractorCategoriesCommand request, CancellationToken cancellationToken)
        {
            string errorMessage = string.Empty;
            var response = new BaseResponse();
            var validator = new CreateContractorCategoriesCommandValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Count > 0)
            {
                foreach (var item in validationResult.Errors)
                {
                    errorMessage = errorMessage + " " + item.ErrorMessage;
                }
                response.Success = false;
                response.Message = errorMessage;
                throw new Exceptions.ValidationException(validationResult);
            }
            List<ContractorCategory> contractorCategoriesList = new List<ContractorCategory>();
            try
            {
                foreach (var item in request.Categories)
                {
                    var contractorCategoryToCreate = new ContractorCategory();
                    contractorCategoryToCreate.ContractorId = request.ContractorId;
                    contractorCategoryToCreate.CategoryId = item;
                    contractorCategoriesList.Add(contractorCategoryToCreate);
                }
                if (response.Success)
                {
                    await _contractorCategoryRepository.AddContractorCategories(contractorCategoriesList);
                    response.Success = true;
                    response.Message = "Categories were added to contractor";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed creating ContractorCategory relationship: {ex.Message}");
            }
            return response;
        }
    }
}
