using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Application.Exceptions;
using SouthWestContractors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.ContractorCategories.Queries.GetContractorCategories
{
    public class GetContractorCategoriesListQueryHandler : IRequestHandler<GetContractorCategoriesListQuery, IReadOnlyList<Guid>>
    {
        private readonly IContractorCategoryRepository _contractorCategories;
        private readonly ILogger<GetContractorCategoriesListQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetContractorCategoriesListQueryHandler(IContractorCategoryRepository contractorCategories,
            ILogger<GetContractorCategoriesListQueryHandler> logger, IMapper mapper)
        {
            _contractorCategories = contractorCategories;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<Guid>> Handle(GetContractorCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetContractorCategoriesListValidator();
            var validationResult = validator.Validate(request);
            if (validationResult == null)
            {
                throw new NotFoundException(nameof(ContractorCategory),request.ContractorId);
            }

            var contractorCategories = await _contractorCategories.GetContractorCategories(request.ContractorId);
            return contractorCategories;
        }
    }
}
