using FinalProject.Entities.Models;
using System;
using System.Collections.Generic;

namespace FinalProject.Contracts
{
    public interface IRoomRepository

    {
        IEnumerable<Room> GetAllRooms(bool trackChanges);            // Method to retrieve all rooms, optionally tracking changes
        Room? GetRoomById(int id, bool trackChanges);               // Method to retrieve a room by its ID, optionally tracking changes
        Room? GetRoomByNumber(string roomNumber, bool trackChanges); // Method to retrieve a room by its number, optionally tracking changes
        void CreateRoom(Room room); // Method to add a new room
        void UpdateRoom(Room room); // Method to update an existing room
        void DeleteRoom(Room room); // Method to delete a room

        bool RoomNumberExists(string roomNumber, bool trackChanges);
        IEnumerable<Room> GetAvailableRooms(bool trackChanges);
        //// Optional - for advanced queries/search
        //IEnumerable<Room> GetRoomsByBedType(string bedType, bool trackChanges);
        //IEnumerable<Room> GetAvailableRooms(bool trackChanges);
    }
}

