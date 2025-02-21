using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using labb3_Blazor.Models;

namespace labb3_Blazor.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //Hämta alla tekonoliger
        public async Task<List<Technology>> GetTechnologiesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Technology>>("api/technologies");
        }

        // Hämta alla projekt
        public async Task<List<Projectcs>> GetProjectsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Projectcs>>("api/projects");
        }

        // resten av crud för båda
        // be chatgpt generera dem bara
    }
}
