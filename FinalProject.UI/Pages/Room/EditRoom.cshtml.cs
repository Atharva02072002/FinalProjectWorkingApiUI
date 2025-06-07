using FinalProject.Entities.Models;
using FinalProject.Service.Contract;
using FinalProject.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.UI.Pages.Rooms
{
    [Authorize(Roles = "Admin")]
    public class EditRoomModel(IRoomService roomService) : PageModel
    {
        private readonly IRoomService _roomService = roomService;

        [BindProperty]
        public int RoomId { get; set; }
        [BindProperty]
        public required string RoomNumber { get; set; }
        [BindProperty]
        public decimal Price { get; set; }
        [BindProperty]
        public BedType BedType { get; set; }

        public  IActionResult OnGetAsync(int roomId)
        {
            var room =  _roomService.GetRoomById(roomId, false);
            if (room == null)
            {
                return NotFound();
            }

            RoomId = room.RoomId;
            RoomNumber = room.RoomNumber;
            Price = room.Price;
            BedType = (BedType)Enum.Parse(typeof(BedType), room.BedType.ToString()); ;

            return Page();
        }

        public  IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var roomDto = new RoomDto(
            RoomId,                   
            RoomNumber,              
            Price,                   
            BedType.ToString()       
        );
            _roomService.UpdateRoom(RoomId, roomDto, false);

            return RedirectToPage("./Index");
        }
    }
}
