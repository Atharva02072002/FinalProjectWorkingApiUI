using AutoMapper;
using FinalProject.Contracts;
using FinalProject.Entities.Models;
using FinalProject.Service.Contract;
using FinalProject.Shared;
using System;
using System.Collections.Generic;

namespace FinalProject.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public EmployeeService(IRepositoryManager repoManager, ILoggerManager logger, IMapper mapper)
        {
            _repo = repoManager;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges) =>
            _mapper.Map<IEnumerable<EmployeeDto>>(_repo.Employee.GetAllEmployees(trackChanges));

        public EmployeeDto GetEmployeeById(Guid id, bool trackChanges)
        {
            var emp = _repo.Employee.GetEmployeeById(id, trackChanges)
                     ?? throw new KeyNotFoundException($"Employee {id} not found");
            return _mapper.Map<EmployeeDto>(emp);
        }

        public EmployeeDto CreateEmployee(EmployeeDto dto)
        {
            // Check for duplicates by mobile, aadhar, or email
            var exists = _repo.Employee.Exists(e =>
               e.MobileNumber == dto.MobileNumber ||
               e.AadharNo == dto.AadharNo ||
               e.EmailId == dto.EmailId);

            if (exists)
            {
                throw new ArgumentException("Employee with the same Mobile Number, Aadhar No, or Email ID already exists.");
            }


            var entity = _mapper.Map<Employee>(dto);
            _repo.Employee.CreateEmployee(entity);
            _repo.Save();

            return _mapper.Map<EmployeeDto>(entity);
        }


        public void UpdateEmployee(Guid id, EmployeeDto dto, bool trackChanges)
        {
            var entity = _repo.Employee.GetEmployeeById(id, trackChanges)
                         ?? throw new KeyNotFoundException($"Employee {id} not found");
            _mapper.Map(dto, entity);
            _repo.Save();
        }

        public void DeleteEmployee(Guid id, bool trackChanges)
        {
            var entity = _repo.Employee.GetEmployeeById(id, trackChanges)
                         ?? throw new KeyNotFoundException($"Employee {id} not found");
            _repo.Employee.DeleteEmployee(entity);
            _repo.Save();
        }
    }
}
