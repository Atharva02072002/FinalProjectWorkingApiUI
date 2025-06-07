using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Entities.Models
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        [Required, MaxLength(10)]
        public string Gender { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        [Required, MaxLength(100)]
        public string Position { get; set; } = null!;

        [Required, Phone]
        public string MobileNumber { get; set; } = null!;

        [Required, MaxLength(20)]
        public string AadharNo { get; set; } = null!;

        [Required, EmailAddress]
        public string EmailId { get; set; } = null!;
    }
}
