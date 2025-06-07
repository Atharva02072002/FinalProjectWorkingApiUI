using FinalProject.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace FinalProject.UI.Controllers
{
    public class PatientController : Controller
    {
        private readonly HttpClient _httpClient;

        public PatientController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/patients/");
        }

        // GET: Patient
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("");
            if (!response.IsSuccessStatusCode) return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var patients = JsonSerializer.Deserialize<List<PatientDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(patients);
        }

        public async Task<IActionResult> Index1()
        {
            var response = await _httpClient.GetAsync("");
            if (!response.IsSuccessStatusCode) return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var patients = JsonSerializer.Deserialize<List<PatientDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(patients);
        }

        // GET: Patient/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var patient = JsonSerializer.Deserialize<PatientDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(patient);
        }

        // GET: Patient/Create
        public IActionResult Create() => View();

        // POST: Patient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientDto dto)
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

        // GET: Patient/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var patient = JsonSerializer.Deserialize<PatientDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(patient);
        }

        // POST: Patient/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PatientDto dto)
        {
            if (id != dto.PatientId) return BadRequest();

            if (!ModelState.IsValid) return View(dto);

            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{id}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            var error = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, error);
            return View(dto);
        }

        // GET: Patient/Delete/{id}
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var response = await _httpClient.GetAsync($"{id}");
        //    if (!response.IsSuccessStatusCode) return NotFound();

        //    var json = await response.Content.ReadAsStringAsync();
        //    var patient = JsonSerializer.Deserialize<PatientDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        //    return View(patient);
        //}

        //// POST: Patient/DeleteConfirmed/{id}
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var response = await _httpClient.DeleteAsync($"{id}");

        //    if (response.IsSuccessStatusCode)
        //        return RedirectToAction(nameof(Index));

        //    return NotFound();
        //}
    }
}
