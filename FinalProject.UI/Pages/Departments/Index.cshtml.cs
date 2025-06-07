using FinalProject.Service.Contract;
using FinalProject.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.UI.Pages.Departments
{
    [Authorize(Roles = "Admin")]
    public class IndexModel(IDepartmentService service) : PageModel
    {
        private readonly IDepartmentService _service = service;

        public required IEnumerable<DepartmentDto> Departments { get; set; }

        public void OnGet()
        {
            Departments = _service.GetAllDepartments(trackChanges: false);
        }
    }

}
