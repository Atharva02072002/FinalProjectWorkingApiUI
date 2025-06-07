using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.UI.Pages.DashBoard
{
    [Authorize(Roles = "Admin,Receptionist")]
    public class FrontDeskModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
