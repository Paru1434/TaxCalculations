using Microsoft.EntityFrameworkCore;
using TaxCalculation.Common.Entities;
using TaxCalculation.Repository.DBContext;
using TaxCalculation.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using TaxCalculation.Common.Model;

namespace TaxCalculation.Repository.Impl
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<T> AddOrUpdate(long Id, T inputRequest)
        {
            _entities.Add(inputRequest);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return inputRequest;
        }
        public async Task<T> Update(long Id, T inputRequest)
        {
            var local = _entities.Local.FirstOrDefault(x => x.Id == Id);
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }

            _context.Entry(inputRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return await _entities.FindAsync(Id).ConfigureAwait(false);
        }

        public async Task<bool> UpdateRange(IEnumerable<T> inputRequest)
        {
            try
            {
                _entities.UpdateRange(inputRequest);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<T> GetById(long id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id).ConfigureAwait(false);
                if (entity != null)
                {
                    _context.Entry(entity).State = EntityState.Unchanged;
                }
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<T>> GetAll()
        {
            List<T> responseList = new List<T>();

            var results = await _entities.ToListAsync().ConfigureAwait(false);

            if (results != null)
            {
                responseList.AddRange(results);
            }
            return responseList;
        }

        public async Task<bool> Delete(long id)
        {
            T entity = await _entities.FindAsync(id).ConfigureAwait(false);
            _entities.Remove(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteRange(IList<long> ids)
        {
            List<T> entities = await _entities.Where(x => ids.Contains(x.Id)).ToListAsync().ConfigureAwait(false);
            _entities.RemoveRange(entities);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public Task<bool> AddRange(IEnumerable<T> inputRequest)
        {
            try
            {
                _entities.AddRange(inputRequest);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

    }
}
