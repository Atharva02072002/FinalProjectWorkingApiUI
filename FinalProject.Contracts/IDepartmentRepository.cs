using FinalProject.Entities.Models;
using System;
using System.Collections.Generic;

namespace FinalProject.Contracts
{
    public interface IDepartmentRepository

    {
        IEnumerable<Department> GetAllDepartments(bool trackChanges); // Method to retrieve all departments, optionally tracking changes
        Department? GetDepartmentById(int id, bool trackChanges);   // Method to retrieve a department by its ID, optionally tracking changes
        void CreateDepartment(Department dept); // Method to add a new department
        void UpdateDepartment(Department dept); // Method to update an existing department
        void DeleteDepartment(Department dept); // Method to delete a department
    }

}
