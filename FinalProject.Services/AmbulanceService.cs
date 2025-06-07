using System;
using System.Collections.Generic;
using AutoMapper;
using FinalProject.Contracts;
using FinalProject.Service.Contract;
using FinalProject.Shared;
using FinalProject.Entities.Models;
using FinalProject.Entities.Exceptions;

namespace FinalProject.Services
{
    /// <summary>
    /// Service class for managing ambulance-related operations.
    /// </summary>
    public class AmbulanceService : IAmbulanceService

    {

        private readonly IRepositoryManager _repositoryManager;

        private readonly IMapper _mapper;

        private readonly ILoggerManager _logger;

        /// <summary>

        /// Initializes a new instance of the <see cref="AmbulanceService"/> class.

        /// </summary>

        public AmbulanceService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)

        {

            _repositoryManager = repositoryManager;

            _mapper = mapper;

            _logger = logger;

        }

        /// <summary>

        /// Retrieves all ambulances, optionally tracking changes.

        /// </summary>

        public IEnumerable<AmbulanceDto> GetAllAmbulances(bool trackChanges)

        {

            var ambulances = _repositoryManager.Ambulance.GetAllAmbulances(trackChanges);

            return _mapper.Map<IEnumerable<AmbulanceDto>>(ambulances);

        }

        /// <summary>

        /// Retrieves an ambulance by its ID.

        /// </summary>

        public AmbulanceDto GetAmbulanceById(Guid id, bool trackChanges)

        {

            var ambulance = _repositoryManager.Ambulance.GetAmbulanceById(id, trackChanges);

            if (ambulance is null)

                throw new AmbulanceNotFoundException(id);

            return _mapper.Map<AmbulanceDto>(ambulance);

        }

        /// <summary>

        /// Creates a new ambulance.

        /// </summary>

        public AmbulanceDto CreateAmbulance(AmbulanceDto dto)

        {

            var exists = _repositoryManager.Ambulance.Exists(a =>

                a.VehicleNumber == dto.VehicleNumber || a.MobileNumber == dto.MobileNumber);

            if (exists)

                throw new ArgumentException("Ambulance with same Vehicle Number or Mobile Number already exists.");

            var entity = _mapper.Map<Ambulance>(dto);

            _repositoryManager.Ambulance.CreateAmbulance(entity);

            _repositoryManager.Save();

            return _mapper.Map<AmbulanceDto>(entity);

        }

        /// <summary>

        /// Updates an existing ambulance.

        /// </summary>

        public void UpdateAmbulance(Guid id, AmbulanceDto ambulanceDto, bool trackChanges)

        {

            var ambulanceEntity = _repositoryManager.Ambulance.GetAmbulanceById(id, trackChanges);

            if (ambulanceEntity == null)

                throw new AmbulanceNotFoundException(id);

            ambulanceEntity.DriverName = ambulanceDto.DriverName;

            ambulanceEntity.MobileNumber = ambulanceDto.MobileNumber;

            ambulanceEntity.VehicleType = ambulanceDto.VehicleType; // Direct assignment since it's a string now

            _repositoryManager.Ambulance.UpdateAmbulance(ambulanceEntity);

            _repositoryManager.Save();

        }

        /// <summary>

        /// Deletes an ambulance by its ID.

        /// </summary>

        public void DeleteAmbulance(Guid id, bool trackChanges)

        {

            var ambulanceEntity = _repositoryManager.Ambulance.GetAmbulanceById(id, trackChanges);

            if (ambulanceEntity == null)

                throw new AmbulanceNotFoundException(id);

            _repositoryManager.Ambulance.DeleteAmbulance(ambulanceEntity);

            _repositoryManager.Save();

        }

    }
}

