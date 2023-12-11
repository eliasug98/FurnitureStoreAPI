using FurnitureStore.API.Entities;
using FurnitureStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FurnitureStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DolarController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IDolarRepository _dolarRepository;

        public DolarController(HttpClient httpClient, IDolarRepository dolarRepository)
        {
            _httpClient = httpClient;
            _dolarRepository = dolarRepository;
        }

        [HttpGet]
        public async Task<ActionResult<DolarResponse>> GetDolar()
        {
            var dolarResponse = await _dolarRepository.GetDolar();
            return Ok(dolarResponse);
        }
    }
}
