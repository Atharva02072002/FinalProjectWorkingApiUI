using FinalProject.Shared;

namespace FinalProject.Service.Contract
{
    public interface IRoomService

    {

        // Retrieves all rooms, optionally tracking changes

        IEnumerable<RoomDto> GetAllRooms(bool trackChanges);

        // Retrieves a room by its ID, optionally tracking changes

        RoomDto GetRoomById(int id, bool trackChanges);

        // Creates a new room

        RoomDto CreateRoom(RoomDto roomDto);

        // Updates an existing room

        void UpdateRoom(int id, RoomDto roomDto, bool trackChanges);

        // Deletes a room by its ID

        void DeleteRoom(int id, bool trackChanges);

        IEnumerable<RoomDto> GetAvailableRooms();

    }
}
