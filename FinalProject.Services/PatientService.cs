using AutoMapper;
using FinalProject.Contracts;
using FinalProject.Entities.Exceptions;
using FinalProject.Entities.Models;
using FinalProject.Service.Contract;
using FinalProject.Shared;

namespace FinalProject.Services
{
    /// <summary>
    /// Service class for managing patient-related operations.
    /// </summary>
    public class PatientService : IPatientService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public PatientService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _repository = repositoryManager;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<PatientDto> GetAllPatients(bool trackChanges)
        {
            var patients = _repository.Patient.GetAllPatients(trackChanges);
            return _mapper.Map<IEnumerable<PatientDto>>(patients);
        }

        public PatientDto GetPatientById(Guid id, bool trackChanges)
        {
            var patient = _repository.Patient.GetPatientById(id, trackChanges);
            if (patient is null)
                throw new PatientNotFoundException(id);
            return _mapper.Map<PatientDto>(patient);
        }

        public PatientDto CreatePatient(PatientDto patientDto)
        {
            if (patientDto == null)
                throw new ArgumentNullException(nameof(patientDto));

            // Check for existing Aadhar ID
            if (_repository.Patient.FindByAadhar(patientDto.AadharId) != null)
                throw new Exception("Aadhar ID already exists.");

            // Check for existing Mobile Number
            if (_repository.Patient.FindByMobile(patientDto.MobileNumber) != null)
                throw new Exception("Mobile number already exists.");

            // Get the room with tracking enabled to ensure EF Core tracks changes
            var room = _repository.Room.GetRoomById(patientDto.RoomId, trackChanges: true);

            if (room == null)
                throw new Exception($"Room with ID {patientDto.RoomId} does not exist.");

            // Check if the room is available
            if (!room.IsAvailable)
                throw new Exception($"Room {room.RoomNumber} (ID = {room.RoomId}) is not available.");

            // Map DTO to Patient entity
            var patientEntity = _mapper.Map<Patient>(patientDto);

            // Create patient entity
            _repository.Patient.CreatePatient(patientEntity);

            // Mark the room as not available now that it's occupied
            room.IsAvailable = false;
            _repository.Room.UpdateRoom(room);

            // Save all changes in one transaction
            _repository.Save();

            // Return the created patient as DTO
            return _mapper.Map<PatientDto>(patientEntity);
        }


        public void UpdatePatient(Guid id, PatientDto patientDto, bool trackChanges)
        {
            var patientEntity = _repository.Patient.GetPatientById(id, trackChanges);
            if (patientEntity == null)
                throw new PatientNotFoundException(id);

            bool wasDischarged = patientEntity.isDischarged;

            _mapper.Map(patientDto, patientEntity);

            if (!wasDischarged && patientEntity.isDischarged)
            {
                var dischargedPatient = new DischargedPatient
                {
                    Id = patientEntity.PatientId,
                    Name = patientEntity.FirstName + patientEntity.LastName,
                    RoomNumber = patientEntity.roomId,
                    AdmissionDateTime = patientEntity.AdmissionDateTime,
                    DischargeDateTime = DateTime.Now,
                };

                _repository.DischargedPatient.CreateDischargedPatient(dischargedPatient);

                var room = _repository.Room.GetRoomById(patientEntity.roomId, true);
                if (room != null)
                {
                    room.IsAvailable = true;
                    _repository.Room.UpdateRoom(room);
                }
            }

            _repository.Save();
        }

        public void DeletePatient(Guid id, bool trackChanges)
        {
            var patient = _repository.Patient.GetPatientById(id, trackChanges);
            if (patient == null) throw new PatientNotFoundException(id);

            _repository.Patient.DeletePatient(patient);
            _repository.Save();
        }
    }
}