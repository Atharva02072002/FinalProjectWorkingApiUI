using System.Linq.Expressions;
using FinalProject.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class

    {

        protected RepositoryContext repositoryContext;

        public RepositoryBase(RepositoryContext repository)

        {

            repositoryContext = repository;

        }

        public IQueryable<T> FindAll(bool trackChanges)

        {

            return !trackChanges ? repositoryContext.Set<T>().AsNoTracking() : repositoryContext.Set<T>();

        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)

        {

            return !trackChanges

                ? repositoryContext.Set<T>().Where(expression).AsNoTracking()

                : repositoryContext.Set<T>().Where(expression);

        }

        public void Create(T entity)

        {

            repositoryContext.Set<T>().Add(entity);

        }

        public void Update(T entity)

        {

            repositoryContext.Set<T>().Update(entity);

        }

        public void Delete(T entity)

        {

            repositoryContext.Set<T>().Remove(entity);

        }

    }
}
