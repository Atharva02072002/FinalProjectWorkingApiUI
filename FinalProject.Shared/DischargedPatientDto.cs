using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Shared
{
    public class DischargedPatientDto
    {
        // Unique identifier for the discharged patient
        public Guid Id { get; set; }

        // Name of the discharged patient (required, max 100 characters)
        [Required(ErrorMessage = "Patient name is required")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        // Room number of the discharged patient (required)
        [Required(ErrorMessage = "Room number is required")]
        public int RoomNumber { get; set; }

        // Admission date and time (required)
        [Required(ErrorMessage = "Admission date and time is required")]
        public DateTime AdmissionDateTime { get; set; }

        // Discharge date and time (required)
        [Required(ErrorMessage = "Discharge date and time is required")]
        public DateTime DischargeDateTime { get; set; }
    }
}
