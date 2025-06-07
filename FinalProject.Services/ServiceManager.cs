using AutoMapper;
using FinalProject.Contracts;
using FinalProject.Service.Contract;

namespace FinalProject.Services
{
    /// <summary>
    /// Service manager class for managing various services.
    /// </summary>
    public class ServiceManager : IServiceManager

    {

        private readonly Lazy<IAmbulanceService> _ambulanceService;

        private readonly Lazy<IPatientService> _patientService;

        private readonly Lazy<IRoomService> _roomService;

        private readonly Lazy<IDepartmentService> _deptSvc;

        private readonly Lazy<IEmployeeService> _empSvc;

        private readonly Lazy<IDischargedPatientService> _dischargedPatientService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)

        {

            _ambulanceService = new Lazy<IAmbulanceService>(() => new AmbulanceService(repositoryManager, logger, mapper));

            _patientService = new Lazy<IPatientService>(() => new PatientService(repositoryManager, logger, mapper));

            _roomService = new Lazy<IRoomService>(() => new RoomService(repositoryManager, logger, mapper));

            _deptSvc = new Lazy<IDepartmentService>(() => new DepartmentService(repositoryManager, logger, mapper));

            _empSvc = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper));

            _dischargedPatientService = new Lazy<IDischargedPatientService>(() => new DischargedPatientService(repositoryManager, logger, mapper));

        }

        public IAmbulanceService AmbulanceService => _ambulanceService.Value;

        public IPatientService PatientService => _patientService.Value;

        public IRoomService RoomService => _roomService.Value;

        public IDepartmentService DepartmentService => _deptSvc.Value;

        public IEmployeeService EmployeeService => _empSvc.Value;

        public IDischargedPatientService DischargedPatientService => _dischargedPatientService.Value;
    }
}
