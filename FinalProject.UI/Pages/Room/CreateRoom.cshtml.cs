using FinalProject.Entities.Models;
using FinalProject.Service.Contract;
using FinalProject.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace FinalProject.UI.Pages.Rooms
{
    [Authorize(Roles = "Admin")]
    public class CreateRoomModel(IRoomService roomService) : PageModel
    {
        private readonly IRoomService _roomService = roomService;

       
        [BindProperty]
        public required string RoomNumber { get; set; }
        [BindProperty]
        public decimal Price { get; set; }
        [BindProperty]
        public BedType BedType { get; set; }

        public  IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var roomDto = new RoomDto
            (    0,       
             RoomNumber,
             Price,
              BedType.ToString()
             );
            

            _roomService.CreateRoom(roomDto);

            return RedirectToPage("./Index"); // Redirect to room listing page
        }
    }
}
