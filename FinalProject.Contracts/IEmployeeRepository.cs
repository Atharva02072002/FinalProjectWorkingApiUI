using FinalProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FinalProject.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees(bool trackChanges); // Method to retrieve all employees, optionally tracking changes
        Employee? GetEmployeeById(Guid id, bool trackChanges);   // Method to retrieve an employee by their ID, optionally tracking changes
        void CreateEmployee(Employee emp); // Method to add a new employee
        void UpdateEmployee(Employee emp); // Method to update an existing employee
        void DeleteEmployee(Employee emp); // Method to delete an employee
        bool Exists(Expression<Func<Employee, bool>> predicate);

    }
}
