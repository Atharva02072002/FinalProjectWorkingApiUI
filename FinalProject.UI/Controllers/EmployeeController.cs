using FinalProject.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FinalProject.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient _employeeClient;
        private readonly HttpClient _departmentClient;

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _employeeClient = httpClientFactory.CreateClient();
            _employeeClient.BaseAddress = new Uri("https://localhost:5001/api/employees/");

            _departmentClient = httpClientFactory.CreateClient();
            _departmentClient.BaseAddress = new Uri("https://localhost:5001/api/departments/");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _employeeClient.GetAsync("");
            if (!response.IsSuccessStatusCode) return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var employees = JsonSerializer.Deserialize<List<EmployeeDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(employees);
        }

        public async Task<IActionResult> Index1()
        {
            var response = await _employeeClient.GetAsync("");
            if (!response.IsSuccessStatusCode) return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var employees = JsonSerializer.Deserialize<List<EmployeeDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(employees);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _employeeClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var employee = JsonSerializer.Deserialize<EmployeeDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(employee);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["Departments"] = await LoadDepartments();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(employeeDto), Encoding.UTF8, "application/json");
                var response = await _employeeClient.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));

                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, error);
            }

            ViewData["Departments"] = await LoadDepartments();
            return View(employeeDto);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _employeeClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var employee = JsonSerializer.Deserialize<EmployeeDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            ViewData["Departments"] = await LoadDepartments();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EmployeeDto employeeDto)
        {
            if (id != employeeDto.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonSerializer.Serialize(employeeDto), Encoding.UTF8, "application/json");
                var response = await _employeeClient.PutAsync($"{id}", content);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));

                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, error);
            }

            ViewData["Departments"] = await LoadDepartments();
            return View(employeeDto);
        }

        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var response = await _employeeClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var employee = JsonSerializer.Deserialize<EmployeeDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(employee);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await _employeeClient.DeleteAsync($"{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return NotFound();
        }

        private async Task<List<DepartmentDto>> LoadDepartments()
        {
            var response = await _departmentClient.GetAsync("");
            if (!response.IsSuccessStatusCode) return new List<DepartmentDto>();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<DepartmentDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
