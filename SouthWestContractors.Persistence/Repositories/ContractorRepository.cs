using Microsoft.EntityFrameworkCore;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouthWestContractors.Persistence.Repositories
{
    public class ContractorRepository : BaseRepository<Contractor>, IContractorRepository
    {
       

        public ContractorRepository(SouthWestContractorsDbContext dbContext):base(dbContext)
        {
            
        }

        public async Task<Contractor> ContractorDetails(Guid contractorId)
        {
            var contractor = await _context.Contractors
                .Include(x => x.Galery)
                .Include(y=>y.ContractorCategories)
                .ThenInclude(y=>y.Category)
                .Where(x=>x.ContractorId==contractorId).FirstOrDefaultAsync();
            return contractor;
        }
    }
}
