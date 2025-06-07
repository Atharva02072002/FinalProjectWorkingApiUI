using FinalProject.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FinalProject.UI.Controllers
{
    public class RoomController : Controller
    {
        private readonly HttpClient _httpClient;

        public RoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/rooms/");
        }


        // GET: Room
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("");
            if (!response.IsSuccessStatusCode) return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var rooms = JsonSerializer.Deserialize<List<RoomDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(rooms);
        }

        // GET: Room/Available
        public async Task<IActionResult> Available()
        {
            var response = await _httpClient.GetAsync("available");
            if (!response.IsSuccessStatusCode) return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var availableRooms = JsonSerializer.Deserialize<List<FinalProject.Shared.RoomDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(availableRooms);
        }

        public async Task<IActionResult> Index1()
        {
            var response = await _httpClient.GetAsync("");
            if (!response.IsSuccessStatusCode) return View("Error");

            var json = await response.Content.ReadAsStringAsync();
            var rooms = JsonSerializer.Deserialize<List<RoomDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(rooms);
        }

        // GET: Room/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var room = JsonSerializer.Deserialize<RoomDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(room);
        }

        // GET: Room/Create
        public IActionResult Create() => View();

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomDto dto)
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

        // GET: Room/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var room = JsonSerializer.Deserialize<RoomDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(room);
        }

        // POST: Room/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RoomDto dto)
        {
            if (id != dto.RoomId) return BadRequest();

            if (!ModelState.IsValid) return View(dto);

            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{id}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            var error = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, error);
            return View(dto);
        }

        // GET: Room/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var room = JsonSerializer.Deserialize<RoomDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(room);
        }

        // POST: Room/DeleteConfirmed/{id}
        [HttpPost, ActionName("Delete")]
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
