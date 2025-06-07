using FinalProject.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Repository.Configuration
{
    /// <summary>
    /// Configuration class for the Patient entity.
    /// </summary>
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>

    {

        public void Configure(EntityTypeBuilder<Patient> builder)

        {

            builder.HasData(

                new Patient

                {

                    PatientId = new Guid("C513F843-93EA-4761-9113-3EB19B910122"),

                    AadharId = "123456789012",

                    FirstName = "Amit",

                    LastName = "Sharma",

                    MobileNumber = "9876543210",

                    Gender = "Male",

                    Disease = "Diabetes",

                    Symptoms = "Fatigue, frequent urination",

                    AdmissionDateTime = new DateTime(2025, 5, 20, 10, 30, 0),

                    InitialDeposit = 5000m,

                    roomId = 115,

                    isDischarged = false

                }

               

            );

        }

    }

}

