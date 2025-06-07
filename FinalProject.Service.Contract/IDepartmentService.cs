using FinalProject.Shared;
using System;
using System.Collections.Generic;

namespace FinalProject.Service.Contract
{
    public interface IDepartmentService
    {
        // Retrieves all departments, optionally tracking changes
        IEnumerable<DepartmentDto> GetAllDepartments(bool trackChanges);

        // Retrieves a department by its ID, optionally tracking changes
        DepartmentDto GetDepartmentById(int id, bool trackChanges);

        // Creates a new department
        void CreateDepartment(DepartmentDto deptDto);

        // Updates an existing department
        void UpdateDepartment(int id, DepartmentDto deptDto, bool trackChanges);

        // Deletes a department by its ID
        void DeleteDepartment(int id, bool trackChanges);
    }
}

