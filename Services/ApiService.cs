using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using labb3_Blazor.Models;
using Microsoft.Extensions.Logging;

namespace labb3_Blazor.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ApiService> _logger;

        public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        //--------------------------- GET-metoder ---------------------------
        public async Task<List<Technology>> GetTechnologiesAsync()
        {
            try
            {
                var techs = await _httpClient.GetFromJsonAsync<List<Technology>>("/api/technologies");
                return techs ?? new List<Technology>();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Fel vid hämtning av teknologier");
                return new List<Technology>();
            }
        }

        public async Task<List<Certificate>> GetCertificatesAsync()
        {
            try
            {
                var certs = await _httpClient.GetFromJsonAsync<List<Certificate>>("/api/certificates");
                return certs ?? new List<Certificate>();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Fel vid hämtning av certifikat");
                return new List<Certificate>();
            }
        }

        public async Task<List<Experience>> GetExperiencesAsync()
        {
            try
            {
                var exps = await _httpClient.GetFromJsonAsync<List<Experience>>("/api/experiences");
                return exps ?? new List<Experience>();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Fel vid hämtning av erfarenheter");
                return new List<Experience>();
            }
        }

        //--------------------------- POST-metoder ---------------------------
        public async Task<Technology?> AddTechnologyAsync(Technology tech)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/technologies", tech);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Fel vid POST av teknologi: {StatusCode}", response.StatusCode);
                    return null;
                }
                return await response.Content.ReadFromJsonAsync<Technology>();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Undantag vid POST av teknologi");
                return null;
            }
        }

        public async Task<Certificate?> AddCertificateAsync(Certificate cert)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/certificates", cert);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Fel vid POST av certifikat: {StatusCode}", response.StatusCode);
                    return null;
                }
                return await response.Content.ReadFromJsonAsync<Certificate>();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Undantag vid POST av certifikat");
                return null;
            }
        }

        public async Task<Experience?> AddExperienceAsync(Experience exp)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/experiences", exp);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Fel vid POST av erfarenhet: {StatusCode}", response.StatusCode);
                    return null;
                }
                return await response.Content.ReadFromJsonAsync<Experience>();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Undantag vid POST av erfarenhet");
                return null;
            }
        }
    }
}
