using FinalProject.Contracts;
using FinalProject.Entities.Models;
using FinalProject.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository
{
    public class RepositoryContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryContext"/> class.
        /// </summary>
        /// <param name="options">The options for configuring the context.</param>
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
        {
        }

        /// <summary>
        /// Configures the model using the specified model builder.
        /// </summary>
        /// <param name="modelBuilder">The model builder to configure.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AmbulanceConfiguration());  // Applying configuration for Ambulance entity
            modelBuilder.ApplyConfiguration(new PatientConfiguration());    // Applying configuration for Patient entity
            modelBuilder.ApplyConfiguration(new RoomConfiguration());       // Applying configuration for Room entity
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration()); // Applying configuration for Department entity
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());   // Applying configuration for Employee entity
            modelBuilder.ApplyConfiguration(new DischargedPatientConfiguration());
        }

        /// <summary>
        /// Gets or sets the DbSet for Ambulances.
        /// </summary>
        public DbSet<Ambulance> Ambulances { get; set; } // DbSet for Ambulance entities

        /// <summary>
        /// Gets or sets the DbSet for Patients.
        /// </summary>
        public DbSet<Patient> Patients { get; set; } // DbSet for Patient entities

        /// <summary>
        /// Gets or sets the DbSet for Rooms.
        /// </summary>
        public DbSet<Room> Rooms { get; set; } // DbSet for Room entities

        /// <summary>
        /// Gets or sets the DbSet for Employees.
        /// </summary>
        public DbSet<Employee> Employees { get; set; } // DbSet for Employee entities

        /// <summary>
        /// Gets or sets the DbSet for Departments.
        /// </summary>
        public DbSet<Department> Departments { get; set; } // DbSet for Department entities
        public DbSet<DischargedPatient> DischargedPatients { get; set; }
    }
}