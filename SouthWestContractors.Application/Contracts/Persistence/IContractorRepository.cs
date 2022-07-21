using SouthWestContractors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Contracts.Persistence
{
    public interface IContractorRepository: IAsyncRepository<Contractor>
    {
        Task<Contractor> ContractorDetails(Guid contractorId);
    }
}
