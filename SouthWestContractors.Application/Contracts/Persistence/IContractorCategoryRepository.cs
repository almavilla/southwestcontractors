using SouthWestContractors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Contracts.Persistence
{
    public interface IContractorCategoryRepository: IAsyncRepository<ContractorCategory>
    {
        Task AddContractorCategories(List<ContractorCategory> categoryContractors);
        Task DeleteContractorCategories(Guid contractorId);
        Task<IReadOnlyList<Guid>> GetContractorCategories(Guid contractorId);
    }
}
