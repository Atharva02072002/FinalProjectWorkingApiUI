using FinalProject.Contracts;
using FinalProject.Repository;

namespace FinalProject.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;         // Context for accessing the database
        private IPatientRepository? _patientRepository;      // Lazy-loaded patient repository
        private IRoomRepository? _roomRepository;            // Lazy-loaded room repository
        private IAmbulanceRepository? _ambulanceRepository;  // Lazy-loaded ambulance repository
        private IDepartmentRepository? _deptRepo;            // Lazy-loaded department repository
        private IEmployeeRepository? _empRepo;               // Lazy-loaded employee repository
        private IDischargedPatientRepository _disPatient;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryManager"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public RepositoryManager(RepositoryContext context)
        {
            _context = context; // Initializing the context through dependency injection
        }

        /// <summary>
        /// Gets the patient repository.
        /// </summary>
        public IPatientRepository Patient => _patientRepository ??= new PatientRepository(_context);

        /// <summary>
        /// Gets the room repository.
        /// </summary>
        public IRoomRepository Room => _roomRepository ??= new RoomRepository(_context);

        /// <summary>
        /// Gets the ambulance repository.
        /// </summary>
        public IAmbulanceRepository Ambulance => _ambulanceRepository ??= new AmbulanceRepository(_context);

        /// <summary>
        /// Gets the department repository.
        /// </summary>
        public IDepartmentRepository Department => _deptRepo ??= new DepartmentRepository(_context);

        /// <summary>
        /// Gets the employee repository.
        /// </summary>
        public IEmployeeRepository Employee => _empRepo ??= new EmployeeRepository(_context);
        public IDischargedPatientRepository DischargedPatient => _disPatient ??= new DischargedPatientRepository(_context);

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        public void Save() => _context.SaveChanges();
    }
}
