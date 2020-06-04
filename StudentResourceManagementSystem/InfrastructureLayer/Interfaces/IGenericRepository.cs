using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Interfaces
{
    /// <summary>
    /// This interface declares the generic methods that can be used by all 
    /// the entity repositories
    /// </summary>
    /// <typeparam name="T">Entity class</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> Add(T entity);
        Task Edit(T entity);
        Task Delete(T entity);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
