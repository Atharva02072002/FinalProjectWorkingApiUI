using FinalProject.UI.Models; // adjust this to your actual namespace
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FinalProject.UI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly HttpClient _httpClient;

        public DepartmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/departments/");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("");
            if (!response.IsSuccessStatusCode) return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var departments = JsonSerializer.Deserialize<List<DepartmentDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(departments);
        }

        public async Task<IActionResult> Index1()
        {
            var response = await _httpClient.GetAsync("");
            if (!response.IsSuccessStatusCode) return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var departments = JsonSerializer.Deserialize<List<DepartmentDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(departments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var department = JsonSerializer.Deserialize<DepartmentDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(department);
        }

        public IActionResult CreateDepartment() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDepartment(DepartmentDto departmentDto)
        {
            if (!ModelState.IsValid) return View(departmentDto);

            var content = new StringContent(JsonSerializer.Serialize(departmentDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(departmentDto);
        }

        public async Task<IActionResult> EditDepartment(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var department = JsonSerializer.Deserialize<DepartmentDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDepartment(DepartmentDto departmentDto)
        {
            if (!ModelState.IsValid) return View(departmentDto);

            var content = new StringContent(JsonSerializer.Serialize(departmentDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{departmentDto.DepartmentId}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(departmentDto);
        }

        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var department = JsonSerializer.Deserialize<DepartmentDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(department);
        }

        [HttpPost, ActionName("DeleteDepartment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"{id}");

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return NotFound();
        }
    }
}
