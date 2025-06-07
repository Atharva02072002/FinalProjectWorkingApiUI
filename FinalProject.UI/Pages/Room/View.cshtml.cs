using FinalProject.Service.Contract;
using FinalProject.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.UI.Pages.Rooms
{
    [Authorize(Roles = "Admin,Receptionist")]
    public class ViewModel(IRoomService roomService) : PageModel
    {
        private readonly IRoomService _roomService = roomService;

        public required RoomDto Room { get; set; }

        public IActionResult OnGet(int id)
        {
            try
            {
                Room = _roomService.GetRoomById(id, trackChanges: false);
                return Page();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
