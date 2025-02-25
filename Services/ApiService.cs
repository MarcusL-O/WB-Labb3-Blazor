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
            return await _httpClient.GetFromJsonAsync<List<Technology>>("/api/technologies");
        }

        public async Task<Technology> AddTechnologyAsync(Technology tech)
        {
            //Skickar ett Post-anrop
            var response = await _httpClient.PostAsJsonAsync("apii/technologies", tech);

            //Om godkänt koden går vidare, annars kastas ett fel med statuskod
            response.EnsureSuccessStatusCode();

            //Läser och retunerar svar från api
            return await response.Content.ReadFromJsonAsync<Technology>();
        }

        // Hämta alla projekt
        public async Task<List<Projects>> GetProjectsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Projects>>("/api/projects");
        }

        // resten av crud för båda
        // be chatgpt generera dem bara
    }
}
