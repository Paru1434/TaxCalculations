using TaxCalculation.Common.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaxCalculation.Repository.Interfaces
{

    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> AddOrUpdate(long Id, T inputRequest);
        Task<T> Update(long Id, T inputRequest);
        Task<bool> UpdateRange(IEnumerable<T> inputRequest);
        Task<T> GetById(long id);
        Task<bool> Delete(long id);
        Task<bool> DeleteRange(IList<long> ids);
        Task<List<T>> GetAll();
        Task<bool> AddRange(IEnumerable<T> inputRequest);
    }
}
