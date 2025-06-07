using AutoMapper;
using FinalProject.Contracts;
using FinalProject.Service.Contract;
using FinalProject.Shared;
using FinalProject.Entities.Models;
using System;
using System.Collections.Generic;
using FinalProject.Entities.Exceptions;

namespace FinalProject.Services
{
    /// <summary>
    /// Service class for managing room-related operations.
    /// </summary>
    public class RoomService : IRoomService

    {

        private readonly IRepositoryManager _repository;

        private readonly IMapper _mapper;

        private readonly ILoggerManager _logger;

        public RoomService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)

        {

            _repository = repositoryManager;

            _mapper = mapper;

            _logger = logger;

        }

        public IEnumerable<RoomDto> GetAllRooms(bool trackChanges)

        {

            var rooms = _repository.Room.GetAllRooms(trackChanges);

            return _mapper.Map<IEnumerable<RoomDto>>(rooms);

        }

        public RoomDto GetRoomById(int id, bool trackChanges)

        {

            var room = _repository.Room.GetRoomById(id, trackChanges);

            if (room is null)

                throw new RoomNotFoundException(id);

            return _mapper.Map<RoomDto>(room);

        }

        public RoomDto CreateRoom(RoomDto roomDto)

        {

            if (_repository.Room.RoomNumberExists(roomDto.RoomNumber, false))

                throw new System.Exception("Room number already exists.");

            var room = _mapper.Map<Entities.Models.Room>(roomDto);

            _repository.Room.CreateRoom(room);

            _repository.Save();

            return _mapper.Map<RoomDto>(room);

        }

        public void UpdateRoom(int id, RoomDto roomDto, bool trackChanges)

        {

            var roomEntity = _repository.Room.GetRoomById(id, trackChanges);

            if (roomEntity == null) throw new RoomNotFoundException(id);

            _mapper.Map(roomDto, roomEntity);

            _repository.Save();

        }

        public void DeleteRoom(int id, bool trackChanges)

        {

            var room = _repository.Room.GetRoomById(id, trackChanges);

            if (room == null) throw new RoomNotFoundException(id);

            _repository.Room.DeleteRoom(room);

            _repository.Save();

        }

        public IEnumerable<RoomDto> GetAvailableRooms()

        {

            var rooms = _repository.Room.GetAvailableRooms(false);

            return _mapper.Map<IEnumerable<RoomDto>>(rooms);

        }

    }

}
