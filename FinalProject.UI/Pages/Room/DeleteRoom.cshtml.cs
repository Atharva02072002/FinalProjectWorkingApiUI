using FinalProject.Service.Contract;
using FinalProject.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.UI.Pages.Rooms
{
    [Authorize(Roles = "Admin")]
    public class DeleteRoomModel(IRoomService roomService) : PageModel
    {
        private readonly IRoomService _roomService = roomService;

        [BindProperty]
        public int RoomId { get; set; }

        public required RoomDto Room { get; set; }

        public Task<IActionResult> OnGetAsync(int roomId)
        {
            var room =  _roomService.GetRoomById(roomId, false);
            if (room == null)
            {
                return Task.FromResult<IActionResult>(NotFound());
            }

            Room = room;

            return Task.FromResult<IActionResult>(Page());
        }

        public IActionResult OnPostAsyn()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

             _roomService.DeleteRoom(RoomId, false);

            return RedirectToPage("./Index");
        }
    }
}
