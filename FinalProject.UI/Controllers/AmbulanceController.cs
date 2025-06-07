using FinalProject.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace FinalProject.UI.Controllers
{
    public class AmbulanceController : Controller
    {
        private readonly HttpClient _httpClient;

        public AmbulanceController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/ambulances/");
        }

        // GET: Ambulance
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("");
            if (!response.IsSuccessStatusCode) return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var ambulances = JsonSerializer.Deserialize<List<AmbulanceDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(ambulances);
        }

        public async Task<IActionResult> Index1()
        {
            var response = await _httpClient.GetAsync("");
            if (!response.IsSuccessStatusCode) return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var ambulances = JsonSerializer.Deserialize<List<AmbulanceDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(ambulances);
        }

        // GET: Ambulance/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var ambulance = JsonSerializer.Deserialize<AmbulanceDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(ambulance);
        }

        // GET: Ambulance/Create
        public IActionResult Create() => View();

        // POST: Ambulance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AmbulanceDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            var error = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, error);
            return View(dto);
        }

        // GET: Ambulance/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var ambulance = JsonSerializer.Deserialize<AmbulanceDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(ambulance);
        }

        // POST: Ambulance/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AmbulanceDto dto)
        {
            if (id != dto.AmbulanceId)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(dto);

            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{id}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            var error = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, error);
            return View(dto);
        }

        // GET: Ambulance/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var ambulance = JsonSerializer.Deserialize<AmbulanceDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(ambulance);
        }

        // POST: Ambulance/DeleteConfirmed/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{id}");

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return NotFound();
        }
    }
}
