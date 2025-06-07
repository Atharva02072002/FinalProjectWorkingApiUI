using FinalProject.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Repository.Configuration
{
    public class DischargedPatientConfiguration : IEntityTypeConfiguration<DischargedPatient>
    {
        public void Configure(EntityTypeBuilder<DischargedPatient> builder)
        {
            builder.ToTable("DischargedPatients");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.RoomNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(d => d.AdmissionDateTime)
                .IsRequired();

            builder.Property(d => d.DischargeDateTime)
                .IsRequired();

        }
    }
}
