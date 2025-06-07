using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FinalProject.Entities.Models
{
    public class Patient
    {
        [Key]
        [Required]
        public Guid PatientId { get; set; }
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Aadhar ID must be exactly 12 digits.")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Aadhar ID must contain only digits.")]
        public string AadharId { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be 10 digits.")]
        public string MobileNumber { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string Disease { get; set; } = string.Empty;

        public string Symptoms { get; set; } = string.Empty;

        public DateTime AdmissionDateTime { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Initial deposit must be a positive number.")]
        public decimal InitialDeposit { get; set; }

        [ForeignKey(nameof(Room))]
        public int roomId { get; set; }
        public Room? Room { get; set; }
        public bool isDischarged { get; set; }
    }
}