using FinalProject.Contracts;

namespace FinalProject.Contracts
{
    public interface IRepositoryManager
    {

        IPatientRepository Patient { get; }         // Property to access patient repository
        IRoomRepository Room { get; }               // Property to access room repository
        IAmbulanceRepository Ambulance { get; }     // Property to access ambulance repository (conditional use)
        IDepartmentRepository Department { get; }   // Property to access department repository
        IEmployeeRepository Employee { get; }       // Property to access employee repository
        IDischargedPatientRepository DischargedPatient { get; }

        void Save();                                // Method to save changes to the database
    }
}
