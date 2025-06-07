using Microsoft.AspNetCore.Mvc;

namespace FinalProject.UI.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult FrontDesk()
        {
            return View();
        }
    }
}
