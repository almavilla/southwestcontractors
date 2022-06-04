using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        //IReadOnlyList<T>
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetByIdAsync(Guid Id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        //needs entity
        Task DeleteAsync(T entity);
    }
}
