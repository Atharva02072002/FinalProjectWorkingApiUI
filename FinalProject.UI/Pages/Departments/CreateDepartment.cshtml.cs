using FinalProject.Service.Contract;
using FinalProject.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.UI.Pages.Departments
{
    [Authorize(Roles = "Admin")]
    public class CreateModel(IDepartmentService departmentService) : PageModel
    {
        private readonly IDepartmentService _departmentService = departmentService;

        [BindProperty]
        public required DepartmentDto Department { get; set; }     
       
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _departmentService.CreateDepartment(Department);
            return RedirectToPage("Index");
        }
    }
}
