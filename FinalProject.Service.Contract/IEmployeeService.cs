using FinalProject.Shared;
using System;
using System.Collections.Generic;

namespace FinalProject.Service.Contract
{
    public interface IEmployeeService
    {
        // Retrieves all employees, optionally tracking changes
        IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges);

        // Retrieves an employee by their ID, optionally tracking changes
        EmployeeDto GetEmployeeById(Guid id, bool trackChanges);

        // Creates a new employee
        EmployeeDto CreateEmployee(EmployeeDto empDto);

        // Updates an existing employee
        void UpdateEmployee(Guid id, EmployeeDto empDto, bool trackChanges);

        // Deletes an employee by their ID
        void DeleteEmployee(Guid id, bool trackChanges);
    }
}
