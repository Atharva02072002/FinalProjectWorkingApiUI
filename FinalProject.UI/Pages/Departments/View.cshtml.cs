using FinalProject.Service.Contract;
using FinalProject.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.UI.Pages.Departments
{
    [Authorize(Roles = "Admin,Receptionist")]
    public class ViewModel(IDepartmentService departmentService) : PageModel
    {
        private readonly IDepartmentService _departmentService = departmentService;

        public required DepartmentDto Department { get; set; }

        public IActionResult OnGet(int id)
        {
            Department = _departmentService.GetDepartmentById(id, trackChanges: false);
            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }
    }

}
