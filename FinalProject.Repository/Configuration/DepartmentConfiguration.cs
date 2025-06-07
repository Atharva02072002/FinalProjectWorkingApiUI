using FinalProject.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Repository.Configuration
{
    /// <summary>
    /// Configuration class for the Department entity.
    /// </summary>
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(r => r.DepartmentId)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn(seed: 1, increment: 1);
            builder.HasData(
                new Department
                {
                    DepartmentId = 1,
                    DeptName = "Cardiology",
                    HODName = "Dr. Anil Mehra",
                    PhoneExtensionNo = "111"
                },
                new Department
                {
                    DepartmentId = 2,
                    DeptName = "Neurology",
                    HODName = "Dr. Seema Verma",
                    PhoneExtensionNo = "222"
                },
                new Department
                {
                    DepartmentId = 3,
                    DeptName = "Orthopedics",
                    HODName = "Dr. Rajesh Khanna",
                    PhoneExtensionNo = "333"
                },
                new Department
                {
                    DepartmentId = 4,
                    DeptName = "Pediatrics",
                    HODName = "Dr. Neha Sharma",
                    PhoneExtensionNo = "444"
                },
                new Department
                {
                    DepartmentId = 5,
                    DeptName = "General Medicine",
                    HODName = "Dr. Vivek Gupta",
                    PhoneExtensionNo = "555"
                }
            );
        }
    }

}
