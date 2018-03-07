using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ESchool.Common.Interface.Repository;
using ESchool.Common.Model;
using ESchool.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace ESchool.DataAccess.Repositories
{
    public class Repository<TModel> : IRepository<TModel> 
        where TModel : Entity
    {
        private bool _disposedFlag = false;
        protected readonly DbContext _context;
        protected readonly DbSet<TModel> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TModel>();
        }

        ~Repository()
        {
            Dispose(false);
        }

        public virtual async Task<TModel> AddAsync(TModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            _dbSet.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public virtual async Task<TModel> DeleteAsync(int id)
        {
            if (id<=0)
            {
                throw new ArgumentException();
            }

            var model = _dbSet.FirstOrDefault(x => x.Id == id);

            if (model==null)
            {
                throw new ArgumentNullException();
            }

            _dbSet.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public virtual async Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> filterExpression)
        {
            if (filterExpression == null)
            {
                throw new ArgumentNullException();
            }

            return await _dbSet.Where(filterExpression).ToListAsync();
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TModel> GetAsync(int id)
        {
            if (id<=0)
            {
                throw new ArgumentException();
            }

            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<TModel> UpdateAsync(TModel model)
        {
            if (model==null)
            {
                throw new ArgumentNullException();
            }

            _dbSet.Update(model);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return model;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                return;
            }

            _disposedFlag = true;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}