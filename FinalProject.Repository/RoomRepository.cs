using FinalProject.Contracts;
using FinalProject.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository

    {

        public RoomRepository(RepositoryContext context) : base(context) { }

        public IEnumerable<Room> GetAllRooms(bool trackChanges) =>

            FindAll(trackChanges).ToList();

        public Room? GetRoomById(int id, bool trackChanges) =>

            FindByCondition(r => r.RoomId == id, trackChanges).FirstOrDefault();

        public Room? GetRoomByNumber(string roomNumber, bool trackChanges) =>

            FindByCondition(r => r.RoomNumber == roomNumber, trackChanges).FirstOrDefault();

        public void CreateRoom(Room room) => Create(room);

        public void UpdateRoom(Room room) => Update(room);

        public void DeleteRoom(Room room) => Delete(room);

        public bool RoomNumberExists(string roomNumber, bool trackChanges) =>

            FindByCondition(r => r.RoomNumber == roomNumber, trackChanges).Any();

        public IEnumerable<Room> GetAvailableRooms(bool trackChanges) =>

            FindByCondition(r => r.IsAvailable, trackChanges).ToList();

    }
}