using FinalProject.Entities.Models;
using FinalProject.Service.Contract;
using FinalProject.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.UI.Pages.Rooms
{
    [Authorize(Roles = "Admin")]
    public class IndexModel(IRoomService roomService) : PageModel
    {
       
        private readonly IRoomService _roomService = roomService;

        public required IEnumerable<RoomDto> Rooms { get; set; }

        public void OnGet()
        {
            Rooms = _roomService.GetAllRooms(false);
        }
    }
}
