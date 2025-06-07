using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace FinalProject.UI.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            // Sign out the authentication cookie
            await HttpContext.SignOutAsync();

            // Clear session if used
            HttpContext.Session.Clear();

            // Redirect to login or home page after logout
            return RedirectToPage("/Account/Login");
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Optional: allow logout via GET if you want
            return await OnPostAsync();
        }
    }
}
