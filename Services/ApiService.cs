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
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //--------------------------- GET-metoder ---------------------------

        // Hämta alla teknologier
        public async Task<List<Technology>> GetTechnologiesAsync()
        {
            var techs = await _httpClient.GetFromJsonAsync<List<Technology>>("/api/technologies");
            return techs ?? new List<Technology>();
        }

        // Hämta alla certifikat
        public async Task<List<Certificate>> GetCertificatesAsync()
        {
            var certs = await _httpClient.GetFromJsonAsync<List<Certificate>>("/api/certificates");
            return certs ?? new List<Certificate>();
        }

        // Hämta alla erfarenheter
        public async Task<List<Experience>> GetExperiencesAsync()
        {
            var exps = await _httpClient.GetFromJsonAsync<List<Experience>>("/api/experiences");
            return exps ?? new List<Experience>();
        }

        //--------------------------- POST-metoder ---------------------------

        // Skapa en ny teknologi
        public async Task<Technology?> AddTechnologyAsync(Technology tech)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/technologies", tech);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<Technology>();
        }

        // Skapa ett nytt certifikat
        public async Task<Certificate?> AddCertificateAsync(Certificate cert)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/certificates", cert);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<Certificate>();
        }

        // Skapa en ny erfarenhet
        public async Task<Experience?> AddExperienceAsync(Experience exp)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/experiences", exp);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadFromJsonAsync<Experience>();
        }
    }
}
