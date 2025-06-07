using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Shared
{
    public class AmbulanceDto
    {
        // Unique identifier for the ambulance
        public Guid AmbulanceId { get; set; }

        // Vehicle number (required, max 20 characters)
        [Required(ErrorMessage = "Vehicle number is required")]
        [MaxLength(20)]
        public string VehicleNumber { get; set; } = null!;

        // Vehicle type (required)
        [Required(ErrorMessage = "Vehicle type is required")]
        public string VehicleType { get; set; } = null!;

        // Driver name (required, max 100 characters)
        [Required(ErrorMessage = "Driver name is required")]
        [MaxLength(100)]
        public string DriverName { get; set; } = null!;

        // Mobile number (required, must be a valid phone number, max 15 characters)
        [Required(ErrorMessage = "Mobile number is required")]
        [Phone]
        [MaxLength(15)]
        public string MobileNumber { get; set; } = null!;
    }



}

