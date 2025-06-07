using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Shared
{
    // Data transfer object for Patient


    public class PatientDto

    {

        // Unique identifier for the patient

        public Guid PatientId { get; set; }

        // Aadhar ID (must be exactly 12 digits)

        [StringLength(12, MinimumLength = 12, ErrorMessage = "Aadhar ID must be exactly 12 digits.")]

        [RegularExpression(@"^\d{12}$", ErrorMessage = "Aadhar ID must contain only digits.")]

        public string AadharId { get; set; } = string.Empty;

        // First name of the patient

        [Required(ErrorMessage = "First name is required")]

        public string FirstName { get; set; } = string.Empty;

        // Last name of the patient

        [Required(ErrorMessage = "Last name is required")]

        public string LastName { get; set; } = string.Empty;

        // Mobile number (must be 10 digits)

        [Required(ErrorMessage = "Mobile number is required")]

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be 10 digits.")]

        public string MobileNumber { get; set; } = string.Empty;

        // Gender of the patient

        [Required(ErrorMessage = "Gender is required")]

        public string Gender { get; set; } = string.Empty;

        // Disease name (optional)

        public string? Disease { get; set; }

        // Symptoms (optional)

        public string? Symptoms { get; set; }

        // Admission date and time

        public DateTime AdmissionDateTime { get; set; }

        // Initial deposit amount

        public decimal InitialDeposit { get; set; }

        [Required(ErrorMessage = "Room ID is required")]

        public int RoomId { get; set; }

        // Room number (optional, for display purposes)

        public bool isDischarged { get; set; }

    }


}