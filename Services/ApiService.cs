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

        //------- Teknologier ---------
        // Hämta alla teknologier
        public async Task<List<Technology>> GetTechnologiesAsync()
        {
            var tech = await _httpClient.GetFromJsonAsync<List<Technology>>("/api/technologies");
            if (tech == null)
            {
                return new List<Technology>();
            }
            return tech;
        }

        // Skapa en ny teknologi
        public async Task<Technology> AddTechnologyAsync(Technology tech)
        {
            var response = await _httpClient.PostAsJsonAsync("api/technologies", tech);
            response.EnsureSuccessStatusCode();
            var createdTech = await response.Content.ReadFromJsonAsync<Technology>();
            if (createdTech == null)
            {
                throw new Exception("The Technology could not be created");
            }
            return createdTech;
        }

        // Hämta teknologi via id
        public async Task<Technology> GetTechnologyByIdAsync(int id)
        {
            var tech = await _httpClient.GetFromJsonAsync<Technology>($"/api/technologies/{id}");
            if (tech == null)
            {
                throw new Exception($"Technology with id {id} was not found");
            }
            return tech;
        }

        // Uppdatera en teknologi
        public async Task<Technology> UpdateTechnologyAsync(Technology tech)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/technologies/{tech.Id}", tech);
            response.EnsureSuccessStatusCode();
            var updatedTech = await response.Content.ReadFromJsonAsync<Technology>();
            if (updatedTech == null)
            {
                throw new Exception("Technology could not be updated");
            }
            return updatedTech;
        }

        // Ta bort en teknologi
        public async Task DeleteTechnologyAsync(int Id)
        {
            var response = await _httpClient.DeleteAsync($"api/technologies/{Id}");
            response.EnsureSuccessStatusCode();
        }

        //------- Certificates ---------

        // Hämta alla certifikat
        public async Task<List<Certificate>> GetCertificatesAsync()
        {
            var certs = await _httpClient.GetFromJsonAsync<List<Certificate>>("/api/certificates");
            if (certs == null)
            {
                return new List<Certificate>();
            }
            return certs;
        }

        // Skapa ett nytt certifikat
        public async Task<Certificate> AddCertificateAsync(Certificate cert)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/certificates", cert);
            response.EnsureSuccessStatusCode();
            var createdCert = await response.Content.ReadFromJsonAsync<Certificate>();
            if (createdCert == null)
            {
                throw new Exception("The Certificate could not be created");
            }
            return createdCert;
        }

        // Hämta ett certifikat via id
        public async Task<Certificate> GetCertificateByIdAsync(int id)
        {
            var cert = await _httpClient.GetFromJsonAsync<Certificate>($"/api/certificates/{id}");
            if (cert == null)
            {
                throw new Exception($"Certificate with id {id} was not found");
            }
            return cert;
        }

        // Uppdatera ett certifikat
        public async Task<Certificate> UpdateCertificateAsync(Certificate cert)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/certificates/{cert.Id}", cert);
            response.EnsureSuccessStatusCode();
            var updatedCert = await response.Content.ReadFromJsonAsync<Certificate>();
            if (updatedCert == null)
            {
                throw new Exception("Certificate could not be updated");
            }
            return updatedCert;
        }

        // Ta bort ett certifikat
        public async Task DeleteCertificateAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/certificates/{id}");
            response.EnsureSuccessStatusCode();
        }

        //------- Experiences ---------

        // Hämta alla erfarenheter
        public async Task<List<Experience>> GetExperiencesAsync()
        {
            var exps = await _httpClient.GetFromJsonAsync<List<Experience>>("/api/experiences");
            if (exps == null)
            {
                return new List<Experience>();
            }
            return exps;
        }

        // Skapa en ny erfarenhet
        public async Task<Experience> AddExperienceAsync(Experience exp)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/experiences", exp);
            response.EnsureSuccessStatusCode();
            var createdExp = await response.Content.ReadFromJsonAsync<Experience>();
            if (createdExp == null)
            {
                throw new Exception("The Experience could not be created");
            }
            return createdExp;
        }

        // Hämta en erfarenhet via id
        public async Task<Experience> GetExperienceByIdAsync(int id)
        {
            var exp = await _httpClient.GetFromJsonAsync<Experience>($"/api/experiences/{id}");
            if (exp == null)
            {
                throw new Exception($"Experience with id {id} was not found");
            }
            return exp;
        }

        // Uppdatera en erfarenhet
        public async Task<Experience> UpdateExperienceAsync(Experience exp)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/experiences/{exp.Id}", exp);
            response.EnsureSuccessStatusCode();
            var updatedExp = await response.Content.ReadFromJsonAsync<Experience>();
            if (updatedExp == null)
            {
                throw new Exception("Experience could not be updated");
            }
            return updatedExp;
        }

        // Ta bort en erfarenhet
        public async Task DeleteExperienceAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/experiences/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
