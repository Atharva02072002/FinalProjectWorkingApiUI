using FinalProject.Service.Contract;

namespace FinalProject.Service.Contract
{
    /// <summary>
    /// Interface for managing various services.
    /// </summary>
    public interface IServiceManager
    {
        // Service for managing ambulance-related operations
        IAmbulanceService AmbulanceService { get; }

        // Service for managing patient-related operations
        IPatientService PatientService { get; }

        // Service for managing room-related operations
        IRoomService RoomService { get; }

        // Service for managing department-related operations
        IDepartmentService DepartmentService { get; }

        // Service for managing employee-related operations
        IEmployeeService EmployeeService { get; }
        IDischargedPatientService DischargedPatientService { get; }
    }
}
