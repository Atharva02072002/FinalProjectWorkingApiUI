using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.UI
{
    // Data transfer object for Employee
    public class EmployeeDto
    {
        // Unique identifier for the employee
        public Guid Id { get; set; }

        // Name of the employee (required, max length 100)
        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;

        // Age of the employee (required)
        [Required]
        public int Age { get; set; }

        // Gender of the employee (required, max length 10)
        [Required, MaxLength(10)]
        public string Gender { get; set; } = null!;

        // Department ID the employee belongs to (required)
        [Required]
        public int DepartmentId { get; set; }
        public DepartmentDto? Department { get; set; }

        // Position of the employee (required, max length 100)
        [Required, MaxLength(100)]
        public string Position { get; set; } = null!;

        // Mobile number of the employee (required, must be a valid phone number)
        [Required, Phone]
        public string MobileNumber { get; set; } = null!;

        // Aadhar number of the employee (required, max length 20)
        [Required, MaxLength(20)]
        public string AadharNo { get; set; } = null!;

        // Email ID of the employee (required, must be a valid email address)
        [Required, EmailAddress]
        public string EmailId { get; set; } = null!;
    }
}
