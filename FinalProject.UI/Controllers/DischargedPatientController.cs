using FinalProject.UI.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FinalProject.UI.Controllers
{
    public class DischargedPatientController : Controller
    {
        private readonly HttpClient _httpClient;
        public DischargedPatientController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/discharged/");
        }
        public async Task<IActionResult> Index()
        {
            //return View();
            var response = await _httpClient.GetAsync("");
            if (!response.IsSuccessStatusCode) return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var dischargedPatients = JsonSerializer.Deserialize<List<DischargedPatientDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(dischargedPatients);
        }
    }
}
