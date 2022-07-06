using Microsoft.EntityFrameworkCore;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SouthWestContractors.Persistence.Repositories
{
    public class ContractorCategoryRepository : BaseRepository<ContractorCategory>, IContractorCategoryRepository
    {
        public ContractorCategoryRepository(SouthWestContractorsDbContext context) : base(context)
        {
        }

        public async Task DeleteContractorCategories(Guid contractorId)
        {
            //foreach (var item in categoryContractors)
            //{
                // var category = await _context.ContractorCategories.FindAsync(item);
                var categories = _context.ContractorCategories.Where(x => x.ContractorId == contractorId).ToList();
                _context.ContractorCategories.RemoveRange(categories);
                await _context.SaveChangesAsync();
            //}
        }

        public async Task AddContractorCategories(List<ContractorCategory> categoryContractors)
        {
            foreach (var item in categoryContractors)
            {
                await _context.ContractorCategories.AddAsync(item);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IReadOnlyList<Guid>> GetContractorCategories(Guid contractorId)
        {
            var categoriesByContractor = await _context.ContractorCategories.Where(x => x.ContractorId == contractorId).Select(x => x.CategoryId).ToListAsync();
            return categoriesByContractor;
        }
    }
}
