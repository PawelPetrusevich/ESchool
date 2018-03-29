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
        private bool disposedFlag = false;
        protected readonly DbContext Context;
        protected readonly DbSet<TModel> DbSet;

        public Repository(DbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<TModel>();
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

            this.DbSet.Add(model);
            await this.Context.SaveChangesAsync();
            return model;
        }

        public virtual async Task<TModel> DeleteAsync(int id)
        {
            if (id<=0)
            {
                throw new ArgumentException();
            }

            var model = this.DbSet.FirstOrDefault(x => x.Id == id);

            if (model==null)
            {
                throw new ArgumentNullException();
            }

            this.DbSet.Remove(model);
            await this.Context.SaveChangesAsync();
            return model;
        }

        public virtual async Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> filterExpression)
        {
            if (filterExpression == null)
            {
                throw new ArgumentNullException();
            }

            return await this.DbSet.Where(filterExpression).ToListAsync();
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await this.DbSet.ToListAsync();
        }

        public virtual async Task<TModel> GetAsync(int id)
        {
            if (id<=0)
            {
                throw new ArgumentException();
            }

            return await this.DbSet.FindAsync(id);
        }

        public virtual async Task<TModel> UpdateAsync(TModel model)
        {
            if (model==null)
            {
                throw new ArgumentNullException();
            }

            this.DbSet.Update(model);
            await this.Context.SaveChangesAsync().ConfigureAwait(false);
            return model;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                return;
            }

            this.disposedFlag = true;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}