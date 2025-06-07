using FinalProject.Entities.Models;
using FinalProject.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalProject.Repository.Configuration
{
    public class AmbulanceConfiguration : IEntityTypeConfiguration<Ambulance>

    {

        public void Configure(EntityTypeBuilder<Ambulance> builder)

        {


            builder.HasData(

                new Ambulance

                {

                    AmbulanceId = new Guid("1F7FC946-AB0A-4C06-8571-3F022559B218"),

                    VehicleType = "Normal",

                    DriverName = "Ravi Kumar",

                    MobileNumber = "9876543210",

                    VehicleNumber = "UP21 AB 1234"

                },

                new Ambulance

                {

                    AmbulanceId = new Guid("4F4BA941-9355-4335-9CC5-A05226AEA4CD"),

                    VehicleType = "BasicLifeSupport",

                    DriverName = "Sunil Mehra",

                    MobileNumber = "9123456789",

                    VehicleNumber = "UP21 CD 5678"

                },

                new Ambulance

                {

                    AmbulanceId = new Guid("529CDD00-5D9E-475B-AF22-E8852EE599AE"),

                    VehicleType = "AdvancedLifeSupport",

                    DriverName = "Anil Sharma",

                    MobileNumber = "9012345678",

                    VehicleNumber = "UP21 EF 9012"

                },

                new Ambulance

                {

                    AmbulanceId = new Guid("6D7AF7DD-7B34-4019-8D25-C73217C0DA74"),

                    VehicleType = "Normal",

                    DriverName = "Vikram Singh",

                    MobileNumber = "9988776655",

                    VehicleNumber = "UP21 GH 3456"

                },

                new Ambulance

                {

                    AmbulanceId = new Guid("841383AF-86FF-45E7-AB96-D3B60B1E097F"),

                    VehicleType = "Neonatal",

                    DriverName = "Suresh Yadav",

                    MobileNumber = "9876501234",

                    VehicleNumber = "UP21 IJ 7890"

                },

                new Ambulance

                {

                    AmbulanceId = new Guid("4A105E1F-397D-465A-832C-8ECDD9D90BC2"),

                    VehicleType = "AdvancedLifeSupport",

                    DriverName = "Rajeev Ranjan",

                    MobileNumber = "9123409876",

                    VehicleNumber = "UP21 KL 2345"

                },

                new Ambulance

                {

                    AmbulanceId = new Guid("1CE30CCB-F4B4-473A-8222-233A3D27351E"),

                    VehicleType = "Normal",

                    DriverName = "Manoj Tiwari",

                    MobileNumber = "9001122334",

                    VehicleNumber = "UP21 MN 6789"

                },

                new Ambulance

                {

                    AmbulanceId = new Guid("9AE9403F-961D-4552-BC15-8F2273639640"),

                    VehicleType = "BasicLifeSupport",

                    DriverName = "Deepak Chauhan",

                    MobileNumber = "9112233445",

                    VehicleNumber = "UP21 OP 1122"

                },

                new Ambulance

                {

                    AmbulanceId = new Guid("57D695F7-4CC6-48C6-BD78-1A5BC96B3A53"),

                    VehicleType = "AdvancedLifeSupport",

                    DriverName = "Karan Verma",

                    MobileNumber = "9223344556",

                    VehicleNumber = "UP21 QR 3344"

                },

                new Ambulance

                {

                    AmbulanceId = new Guid("1B84996D-E7C2-4C96-AA39-F111EB5304A5"),

                    VehicleType = "Normal",

                    DriverName = "Amit Joshi",

                    MobileNumber = "9334455667",

                    VehicleNumber = "UP21 ST 5566"

                }

            );

        }

    }

}
