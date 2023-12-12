using FurnitureStore.API.Entities;
using FurnitureStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FurnitureStore.API.Services.Implementations
{
    public class DolarRepository : IDolarRepository
    {
        private readonly HttpClient _httpClient;

        public DolarRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<DolarResponse> GetDolar()
        {
            var response = await _httpClient.GetAsync("https://dolarapi.com/v1/dolares/blue");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dolarResponse = JsonSerializer.Deserialize<DolarResponse>(content);

                return dolarResponse;
            }
            else
            {
                return new DolarResponse();
            }
        }
    }
}
