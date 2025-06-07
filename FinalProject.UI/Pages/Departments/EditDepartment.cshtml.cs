using FinalProject.Service.Contract;
using FinalProject.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.UI.Pages.Departments
{
    [Authorize(Roles = "Admin")]
    public class EditModel(IDepartmentService departmentService) : PageModel
    {
        private readonly IDepartmentService _departmentService = departmentService;

        [BindProperty]
        public required DepartmentDto Department { get; set; }

        public IActionResult OnGet(int id)
        {
            try
            {
                Department = _departmentService.GetDepartmentById(id, trackChanges: false);
                return Page();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                _departmentService.UpdateDepartment(Department.DepartmentId, Department, trackChanges: true);
                return RedirectToPage("Index");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
