using InfrastructureLayer.ContextClass;
using InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly StudentManagementContext _studentRepositoryContext;
        public GenericRepository(StudentManagementContext context)
        {
            _studentRepositoryContext = context;
        }

        /// <summary>
        /// This async method is used to get the list of all the 
        /// entity related data where T represents an entity
        /// </summary>
        /// <returns>Returns a list containing all the objects of an entity</returns>
        public IEnumerable<T> GetAll()
        {
            return _studentRepositoryContext.Set<T>().ToList();
        }

        /// <summary>
        /// This async method is used to add an object related
        /// to an entity
        /// </summary>
        /// <param name="entity">Provides the object of an entity to be added</param>
        /// <returns>Added object</returns>
        public async Task<T> Add(T entity)
        {
            _studentRepositoryContext.Set<T>().Add(entity);
            return entity;
        }


        /// <summary>
        /// This async method is used to update an object
        /// </summary>
        /// <param name="entity">Provides the object of an entity to be updated</param>        
        public async Task Edit(T entity)
        {
            this._studentRepositoryContext.Set<T>().Update(entity);
        }

        /// <summary>
        /// This async method is used to delete an object
        /// </summary>
        /// <param name="entity">Provides the object of an entity to be deleted</param> 
        public async Task Delete(T entity)
        {
            _studentRepositoryContext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// This method is used to find an object according to the given expression
        /// </summary>
        /// <param name="predicate">Expression</param>
        /// <returns>IEnumerable of objects</returns>
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _studentRepositoryContext.Set<T>().Where(predicate)
                                      .AsEnumerable();
        }
    }
}
