using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Application.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.ContractorCategories.Commands.DeleteContractorCategories
{
    public class DeleteContractorCategoriesCommandHandler : IRequestHandler<DeleteContractorCategoriesCommand, BaseResponse>
    {
        private readonly IContractorCategoryRepository _contractorCategoryRepository;
        private readonly ILogger<DeleteContractorCategoriesCommandHandler> _logger;

        public DeleteContractorCategoriesCommandHandler(IContractorCategoryRepository contractorCategoryRepository, 
            IMapper mapper, ILogger<DeleteContractorCategoriesCommandHandler> logger)
        {
            _contractorCategoryRepository = contractorCategoryRepository;
            _logger = logger;
        }

        public async Task<BaseResponse> Handle(DeleteContractorCategoriesCommand request, CancellationToken cancellationToken)
        {
            string errorMessage = string.Empty;
            var response = new BaseResponse();
            var validator = new DeleteContractorCategoriesCommandValidator();
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
            try
            {               
                if (response.Success)
                {
                    await _contractorCategoryRepository.DeleteContractorCategories(request.ContractorId);
                    response.Success = true;
                    response.Message = "Categories were deleted from contractor";
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
