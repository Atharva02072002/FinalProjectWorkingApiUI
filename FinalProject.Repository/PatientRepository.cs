using FinalProject.Contracts;
using FinalProject.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository
{
    public class PatientRepository : IPatientRepository

    {

        private readonly RepositoryContext _context;

        public PatientRepository(RepositoryContext context)

        {

            _context = context;

        }

        public IEnumerable<Patient> GetAllPatients(bool trackChanges) =>

            !trackChanges

                ? _context.Patients.AsNoTracking().ToList()

                : _context.Patients.ToList();

        public Patient? GetPatientById(Guid id, bool trackChanges) =>

            !trackChanges

                ? _context.Patients.AsNoTracking().FirstOrDefault(p => p.PatientId == id)

                : _context.Patients.FirstOrDefault(p => p.PatientId == id);

        public void CreatePatient(Patient patient)

        {

            if (FindByAadhar(patient.AadharId) != null)

                throw new InvalidOperationException($"A patient with Aadhar {patient.AadharId} already exists.");

            if (FindByMobile(patient.MobileNumber) != null)

                throw new InvalidOperationException($"A patient with mobile {patient.MobileNumber} already exists.");

            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == patient.roomId);

            if (room == null)

                throw new InvalidOperationException($"Requested room (ID = {patient.roomId}) does not exist.");

            if (!room.IsAvailable)

                throw new InvalidOperationException($"Room {room.RoomNumber} (ID = {room.RoomId}) is not available.");

            room.IsAvailable = false;

            _context.Patients.Add(patient);

        }

        public void UpdatePatient(Patient patient)

        {

            var existingByAadhar = _context.Patients

                .FirstOrDefault(p => p.AadharId == patient.AadharId && p.PatientId != patient.PatientId);

            if (existingByAadhar != null)

                throw new InvalidOperationException($"Aadhar {patient.AadharId} is already assigned to another patient.");

            var existingByMobile = _context.Patients

                .FirstOrDefault(p => p.MobileNumber == patient.MobileNumber && p.PatientId != patient.PatientId);

            if (existingByMobile != null)

                throw new InvalidOperationException($"Mobile {patient.MobileNumber} is already assigned to another patient.");

            var original = _context.Patients.AsNoTracking().FirstOrDefault(p => p.PatientId == patient.PatientId);

            if (original == null)

                throw new InvalidOperationException($"Cannot update: patient with ID {patient.PatientId} not found.");

            if (original.roomId != patient.roomId)

            {

                var oldRoom = _context.Rooms.FirstOrDefault(r => r.RoomId == original.roomId);

                if (oldRoom != null && !original.isDischarged)

                    oldRoom.IsAvailable = true;

                var newRoom = _context.Rooms.FirstOrDefault(r => r.RoomId == patient.roomId);

                if (newRoom == null)

                    throw new InvalidOperationException($"Requested room (ID = {patient.roomId}) does not exist.");

                if (!newRoom.IsAvailable)

                    throw new InvalidOperationException($"Room {newRoom.RoomNumber} (ID = {newRoom.RoomId}) is not available.");

                newRoom.IsAvailable = false;

            }

            _context.Patients.Update(patient);

        }

        public void DischargePatient(Guid patientId)

        {

            var patient = _context.Patients.FirstOrDefault(p => p.PatientId == patientId);

            if (patient == null)

                throw new InvalidOperationException($"Cannot discharge: patient ID {patientId} not found.");

            if (patient.isDischarged)

                throw new InvalidOperationException($"Patient ID {patientId} is already discharged.");

            patient.isDischarged = true;

            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == patient.roomId);

            if (room != null)

                room.IsAvailable = true;

            var dischargeEntry = new DischargedPatient

            {

                Id = patient.PatientId,

                Name = $"{patient.FirstName} {patient.LastName}",

                RoomNumber = patient.roomId,

                AdmissionDateTime = patient.AdmissionDateTime,

                DischargeDateTime = DateTime.Now

            };

            _context.Set<DischargedPatient>().Add(dischargeEntry);

        }

        public void DeletePatient(Patient patient)

        {

            if (!patient.isDischarged)

            {

                var room = _context.Rooms.FirstOrDefault(r => r.RoomId == patient.roomId);

                if (room != null)

                    room.IsAvailable = true;

            }

            _context.Patients.Remove(patient);

        }

        public Patient? FindByAadhar(string aadharId) =>

            _context.Patients.FirstOrDefault(p => p.AadharId == aadharId && !p.isDischarged);

        public Patient? FindByMobile(string mobileNumber) =>

            _context.Patients.FirstOrDefault(p => p.MobileNumber == mobileNumber && !p.isDischarged);

        public bool IsRoomOccupied(int roomId) =>

            _context.Patients.Any(p => p.roomId == roomId && !p.isDischarged);

    }
}