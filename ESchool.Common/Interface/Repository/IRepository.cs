using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ESchool.Common.Model;

namespace ESchool.Common.Interface.Repository
{
    public interface IRepository<TModel>: IDisposable 
        where TModel : Entity
    {
        Task<TModel> GetAsync(int id);
        Task<TModel> AddAsync(TModel model);
        Task<TModel> UpdateAsync(TModel model);
        Task<TModel> DeleteAsync(int id);
        Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> filterExpression);
        Task<IEnumerable<TModel>> GetAllAsync();
    }
}
