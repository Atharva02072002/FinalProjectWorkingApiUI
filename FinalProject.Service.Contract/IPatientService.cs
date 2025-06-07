using FinalProject.Shared;

namespace FinalProject.Service.Contract
{
    public interface IPatientService

    {

        /// <summary>

        /// Retrieves all patients, optionally tracking changes.

        /// </summary>

        IEnumerable<PatientDto> GetAllPatients(bool trackChanges);

        /// <summary>

        /// Retrieves a patient by their ID, optionally tracking changes.

        /// </summary>

        PatientDto GetPatientById(Guid id, bool trackChanges);

        /// <summary>

        /// Creates a new patient.

        /// </summary>

        PatientDto CreatePatient(PatientDto patientDto);

        /// <summary>

        /// Updates an existing patient.

        /// </summary>

        void UpdatePatient(Guid id, PatientDto patientDto, bool trackChanges);

        /// <summary>

        /// Deletes a patient by their ID.

        /// </summary>

        void DeletePatient(Guid id, bool trackChanges);

    }
}
