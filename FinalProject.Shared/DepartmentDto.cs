using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Shared
{
    // Data transfer object for Department
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DepartmentDto
    {
        // Unique identifier for the department
        public int DepartmentId { get; set; }

        // Name of the department (required, max 100 characters)
        [Required(ErrorMessage = "Department name is required")]
        [MaxLength(100)]
        public string DeptName { get; set; } = null!;

        // Name of the Head of Department (required, max 100 characters)
        [Required(ErrorMessage = "HOD name is required")]
        [MaxLength(100)]
        public string HODName { get; set; } = null!;

        // Optional phone extension number (max 20 characters)
        [MaxLength(20)]
        public string? PhoneExtensionNo { get; set; }

        // Optional list of empaneled doctor names
        public List<string>? EmpaneledDoctorNames { get; set; }
    }

}