using FinalProject.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Repository.Configuration
{
    /// <summary>
    /// Configuration class for the Employee entity.
    /// </summary>
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.HasData(
                new Employee
                {
                    EmployeeId = new Guid("AAD9F233-2C61-4DC3-9B45-C5DA6815AD7D"),
                    Name = "Dr. Ramesh Kumar",
                    Age = 45,
                    Gender = "Male",
                    DepartmentId = 1,
                    Position = "Senior Cardiologist",
                    MobileNumber = "9876543210",
                    AadharNo = "123456789012",
                    EmailId = "ramesh.kumar@hospital.com"
                },
                new Employee
                {
                    EmployeeId = new Guid("62989037-C514-420A-AAAD-0534383CFFA3"),
                    Name = "Dr. Priya Sharma",
                    Age = 38,
                    Gender = "Female",
                    DepartmentId = 2,
                    Position = "Neurologist",
                    MobileNumber = "9123456789",
                    AadharNo = "234567890123",
                    EmailId = "priya.sharma@hospital.com"
                },
                new Employee
                {
                    EmployeeId = new Guid("9D911F68-D7E1-40FB-8255-254F23105BC3"),
                    Name = "Dr. Arvind Patel",
                    Age = 50,
                    Gender = "Male",
                    DepartmentId = 3,
                    Position = "Orthopedic Surgeon",
                    MobileNumber = "9012345678",
                    AadharNo = "345678901234",
                    EmailId = "arvind.patel@hospital.com"
                },
                new Employee
                {
                    EmployeeId = new Guid("8A8AFFCC-C224-4F3B-A49E-6446C9E8329D"),
                    Name = "Dr. Sneha Verma",
                    Age = 42,
                    Gender = "Female",
                    DepartmentId = 4,
                    Position = "Pediatrician",
                    MobileNumber = "9988776655",
                    AadharNo = "456789012345",
                    EmailId = "sneha.verma@hospital.com"
                },
                new Employee
                {
                    EmployeeId = new Guid("D1C1C324-B11C-42B5-9DB0-EBEA2B566D89"),
                    Name = "Dr. Manish Gupta",
                    Age = 47,
                    Gender = "Male",
                    DepartmentId = 5,
                    Position = "General Physician",
                    MobileNumber = "9876501234",
                    AadharNo = "567890123456",
                    EmailId = "manish.gupta@hospital.com"
                },
                new Employee
                {
                    EmployeeId = new Guid("64537262-C51A-41C1-9994-06CB1D2D5D78"),
                    Name = "Dr. Kavita Nair",
                    Age = 40,
                    Gender = "Female",
                    DepartmentId = 1,
                    Position = "Cardiology Consultant",
                    MobileNumber = "9112233445",
                    AadharNo = "678901234567",
                    EmailId = "kavita.nair@hospital.com"
                },
            new Employee
            {
                EmployeeId = new Guid("D26F37A7-8FF1-45B5-84E0-61E032DE441F"),
                Name = "Dr. Rohit Sinha",
                Age = 36,
                Gender = "Male",
                DepartmentId = 2,
                Position = "Neurosurgeon",
                MobileNumber = "9223344556",
                AadharNo = "789012345678",
                EmailId = "rohit.sinha@hospital.com"
            },
            new Employee
            {
                EmployeeId = new Guid("8F647E4C-F09B-4AA5-90AE-2F16D883B65F"),
                Name = "Dr. Meena Joshi",
                Age = 44,
                Gender = "Female",
                DepartmentId = 3,
                Position = "Orthopedic Consultant",
                MobileNumber = "9334455667",
                AadharNo = "890123456789",
                EmailId = "meena.joshi@hospital.com"
            },
            new Employee
            {
                EmployeeId = new Guid("048A035C-ADC0-4EEE-A9C5-ED320CFA4C27"),
                Name = "Dr. Nikhil Bansal",
                Age = 39,
                Gender = "Male",
                DepartmentId = 4,
                Position = "Child Specialist",
                MobileNumber = "9445566778",
                AadharNo = "901234567890",
                EmailId = "nikhil.bansal@hospital.com"
            },
            new Employee
            {
                EmployeeId = new Guid("7C8ED9E7-0E96-4B45-91B5-CBA7B99A1D0F"),
                Name = "Dr. Anuja Desai",
                Age = 41,
                Gender = "Female",
                DepartmentId = 5,
                Position = "General Medicine Consultant",
                MobileNumber = "9556677889",
                AadharNo = "012345678901",
                EmailId = "anuja.desai@hospital.com"
            });
        }
    }
}