using AutoMapper;
using FinalProject.Contracts;
using FinalProject.Entities.Models;
using FinalProject.Service.Contract;
using FinalProject.Shared;
using System;
using System.Collections.Generic;

namespace FinalProject.Services
{
    /// <summary>
    /// Service class for managing department-related operations.
    /// </summary>
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentService"/> class.
        /// </summary>
        /// <param name="repoManager">The repository manager.</param>
        /// <param name="mapper">The mapper.</param>
        public DepartmentService(IRepositoryManager repoManager, ILoggerManager logger , IMapper mapper)
        {
            _repo = repoManager;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all departments, optionally tracking changes.
        /// </summary>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>A collection of DepartmentDto objects.</returns>
        public IEnumerable<DepartmentDto> GetAllDepartments(bool trackChanges) =>
            _mapper.Map<IEnumerable<DepartmentDto>>(_repo.Department.GetAllDepartments(trackChanges));

        /// <summary>
        /// Retrieves a department by its ID, optionally tracking changes.
        /// </summary>
        /// <param name="id">The ID of the department.</param>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>A DepartmentDto object.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the department with the specified ID is not found.</exception>
        public DepartmentDto GetDepartmentById(int id, bool trackChanges)
        {
            var dept = _repo.Department.GetDepartmentById(id, trackChanges)
                       ?? throw new KeyNotFoundException($"Dept {id} not found");
            return _mapper.Map<DepartmentDto>(dept);
        }

        /// <summary>
        /// Creates a new department.
        /// </summary>
        /// <param name="dto">The department data transfer object.</param>
        public void CreateDepartment(DepartmentDto dto)
        {
            var entity = _mapper.Map<Department>(dto);
            _repo.Department.CreateDepartment(entity);
            _repo.Save();
        }

        /// <summary>
        /// Updates an existing department.
        /// </summary>
        /// <param name="id">The ID of the department.</param>
        /// <param name="dto">The department data transfer object.</param>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the department with the specified ID is not found.</exception>
        public void UpdateDepartment(int id, DepartmentDto dto, bool trackChanges)
        {
            var entity = _repo.Department.GetDepartmentById(id, trackChanges)
                         ?? throw new KeyNotFoundException($"Dept {id} not found");
            _mapper.Map(dto, entity);
            _repo.Save();
        }

        /// <summary>
        /// Deletes a department by its ID.
        /// </summary>
        /// <param name="id">The ID of the department.</param>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the department with the specified ID is not found.</exception>
        public void DeleteDepartment(int id, bool trackChanges)
        {
            var entity = _repo.Department.GetDepartmentById(id, trackChanges)
                         ?? throw new KeyNotFoundException($"Dept {id} not found");
            _repo.Department.DeleteDepartment(entity);
            _repo.Save();
        }
    }
}
