using System.Linq.Expressions;

namespace FinalProject.Contracts
{
    public interface IRepositoryBase<T>
    {

        IQueryable<T> FindAll(bool trackChanges); // Method to retrieve all records, optionally tracking changes
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges); 
                                                  // Method to retrieve records based on a condition, optionally tracking changes
        void Create(T entity);                    // Method to add a new record
        void Update(T entity);                    // Method to update an existing record
        void Delete(T entity);                    // Method to delete a record

    }
}
