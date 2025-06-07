using FinalProject.Entities.Models;
using FinalProject.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalProject.Repository.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>

    {

        public void Configure(EntityTypeBuilder<Room> builder)

        {

            // Identity column starting from 101

            builder.Property(r => r.RoomId)

                   .ValueGeneratedOnAdd()

                   .UseIdentityColumn(seed: 101, increment: 1);

            // Required RoomNumber

            builder.Property(r => r.RoomNumber)

                   .IsRequired();

            // Required Price

            builder.Property(r => r.Price)

                   .IsRequired();

            // Required BedType as string

            builder.Property(r => r.BedType)

                   .IsRequired();

            // Unique index on RoomNumber

            builder.HasIndex(r => r.RoomNumber).IsUnique();

            // Seed data

            builder.HasData(

                new Room { RoomId = 101, RoomNumber = "A101", Price = 1000m, BedType = "Single", IsAvailable = false },

                new Room { RoomId = 102, RoomNumber = "A102", Price = 2000m, BedType = "Double", IsAvailable = true },

                new Room { RoomId = 103, RoomNumber = "A103", Price = 1500m, BedType = "Single", IsAvailable = true },

                new Room { RoomId = 104, RoomNumber = "A104", Price = 1800m, BedType = "Double", IsAvailable = true },

                new Room { RoomId = 105, RoomNumber = "A105", Price = 1200m, BedType = "Single", IsAvailable = true },

                new Room { RoomId = 106, RoomNumber = "B101", Price = 2100m, BedType = "Double", IsAvailable = true },

                new Room { RoomId = 107, RoomNumber = "B102", Price = 2200m, BedType = "Double", IsAvailable = true },

                new Room { RoomId = 108, RoomNumber = "B103", Price = 1300m, BedType = "Single", IsAvailable = true },

                new Room { RoomId = 109, RoomNumber = "B104", Price = 1700m, BedType = "Single", IsAvailable = true },

                new Room { RoomId = 110, RoomNumber = "B105", Price = 1600m, BedType = "Double", IsAvailable = true },

                new Room { RoomId = 111, RoomNumber = "C101", Price = 1900m, BedType = "Single", IsAvailable = true },

                new Room { RoomId = 112, RoomNumber = "C102", Price = 2000m, BedType = "Double", IsAvailable = true },

                new Room { RoomId = 113, RoomNumber = "C103", Price = 1400m, BedType = "Single", IsAvailable = true },

                new Room { RoomId = 114, RoomNumber = "C104", Price = 2300m, BedType = "Double", IsAvailable = true },

                new Room { RoomId = 115, RoomNumber = "C105", Price = 2500m, BedType = "Double", IsAvailable = true }

            );

        }

    }
}
