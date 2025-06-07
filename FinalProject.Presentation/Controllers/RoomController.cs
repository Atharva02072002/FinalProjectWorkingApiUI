using FinalProject.Service.Contract;
using FinalProject.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Presentation.Controllers
{
    [ApiController]

    [Route("api/rooms")]

    public class RoomController : ControllerBase

    {

        private readonly IServiceManager _service;

        public RoomController(IServiceManager service) =>

            _service = service;

        [HttpGet]

        public IActionResult GetAllRooms()

        {

            var rooms = _service.RoomService.GetAllRooms(trackChanges: false);

            return Ok(rooms);

        }

        [HttpGet("{id:int}", Name = "GetRoomById")]

        public IActionResult GetRoomById(int id)

        {

            var room = _service.RoomService.GetRoomById(id, trackChanges: false);

            if (room == null) return NotFound();

            return Ok(room);

        }

        [HttpGet("available")]

        public IActionResult GetAvailableRooms()

        {

            var availableRooms = _service.RoomService.GetAvailableRooms();

            return Ok(availableRooms);

        }

        [HttpPost]

        public IActionResult CreateRoom([FromBody] RoomDto roomDto)

        {

            if (roomDto == null)

                return BadRequest("Room object is null");

            var createdRoom = _service.RoomService.CreateRoom(roomDto);

            return CreatedAtRoute("GetRoomById", new { id = createdRoom.RoomId }, createdRoom);

        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateRoom(int id, [FromBody] RoomDto roomDto)

        {

            if (roomDto == null)

                return BadRequest("Room object is null");

            _service.RoomService.UpdateRoom(id, roomDto, trackChanges: true);

            return NoContent();

        }

        [HttpDelete("{id:int}")]

        public IActionResult DeleteRoom(int id)

        {

            _service.RoomService.DeleteRoom(id, trackChanges: false);

            return NoContent();

        }

    }
}
