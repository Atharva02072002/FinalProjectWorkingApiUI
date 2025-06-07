using FinalProject.Entities.Models;

namespace FinalProject.Contracts
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAllPatients(bool trackChanges);  // Retrieve all patients
        Patient? GetPatientById(Guid id, bool trackChanges);     // Retrieve a patient by ID
        void CreatePatient(Patient patient);                     // Add a new patient
        void UpdatePatient(Patient patient);                     // Update an existing patient
        void DeletePatient(Patient patient);                     // Delete a patient

        // Check for existing patient by Aadhaar ID
        Patient? FindByAadhar(string aadharId);

        // Check for existing patient by Mobile number
        Patient? FindByMobile(string mobileNumber);

        // Check if a room is already occupied by any patient
        bool IsRoomOccupied(int roomId);
    }
}
