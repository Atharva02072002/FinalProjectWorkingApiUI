using System.Linq.Expressions;
using FinalProject.Contracts;
using FinalProject.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RepositoryContext _context;

        public EmployeeRepository(RepositoryContext context) => _context = context;

        public IEnumerable<Employee> GetAllEmployees(bool trackChanges) =>
            trackChanges
                ? _context.Employees.Include(e => e.Department).ToList()
                : _context.Employees.Include(e => e.Department).AsNoTracking().ToList();

        public Employee? GetEmployeeById(Guid id, bool trackChanges) =>
            trackChanges
                ? _context.Employees.Include(e => e.Department).FirstOrDefault(e => e.EmployeeId == id)
                : _context.Employees.Include(e => e.Department).AsNoTracking().FirstOrDefault(e => e.EmployeeId == id);

        public void CreateEmployee(Employee emp) => _context.Employees.Add(emp);

        public void UpdateEmployee(Employee emp) { /* tracked by EF */ }

        public void DeleteEmployee(Employee emp) => _context.Employees.Remove(emp);

        public bool Exists(Expression<Func<Employee, bool>> condition)
        {
            return _context.Employees.Any(condition);
        }


    }
}
