using FinalProject.Contracts;
using FinalProject.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly RepositoryContext _context; // Context for accessing the database

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public DepartmentRepository(RepositoryContext context) => _context = context;

        /// <summary>
        /// Retrieves all departments, optionally tracking changes.
        /// </summary>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>A list of all departments.</returns>
        public IEnumerable<Department> GetAllDepartments(bool trackChanges) =>
            trackChanges
                ? _context.Departments.Include(d => d.EmpaneledDoctorNames).ToList()
                : _context.Departments.Include(d => d.EmpaneledDoctorNames).AsNoTracking().ToList();

        /// <summary>
        /// Retrieves a department by its ID, optionally tracking changes.
        /// </summary>
        /// <param name="id">The ID of the department.</param>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>The department with the specified ID, or null if not found.</returns>
        public Department? GetDepartmentById(int id, bool trackChanges) =>
    trackChanges
        ? _context.Departments
            .Include(d => d.EmpaneledDoctorNames)
            .FirstOrDefault(d => d.DepartmentId == id)
        : _context.Departments
            .Include(d => d.EmpaneledDoctorNames)
            .AsNoTracking()
            .FirstOrDefault(d => d.DepartmentId == id);


        /// <summary>
        /// Adds a new department to the database.
        /// </summary>
        /// <param name="dept">The department to add.</param>
        public void CreateDepartment(Department dept) => _context.Departments.Add(dept);

        /// <summary>
        /// Updates an existing department in the database.
        /// </summary>
        /// <param name="dept">The department to update.</param>
        public void UpdateDepartment(Department dept) { /* EF tracks it */ }

        /// <summary>
        /// Removes a department from the database.
        /// </summary>
        /// <param name="dept">The department to remove.</param>
        public void DeleteDepartment(Department dept) => _context.Departments.Remove(dept);
    }
}
