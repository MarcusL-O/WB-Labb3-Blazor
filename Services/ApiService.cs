using System;
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

        private async Task<T> ExecuteSafeAsync<T>(Func<Task<T>> func, T defaultValue = default)
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return defaultValue;
            }
        }

        //---------------------------teknologier---------------------

        // Hämta alla teknologier
        public async Task<List<Technology>> GetTechnologiesAsync() =>
            await ExecuteSafeAsync(async () =>
            {
                var tech = await _httpClient.GetFromJsonAsync<List<Technology>>("/api/technologies");
                return tech ?? new List<Technology>();
            }, new List<Technology>());

        // Skapa en ny teknologi
        public async Task<Technology?> AddTechnologyAsync(Technology tech) =>
            await ExecuteSafeAsync(async () =>
            {
                var response = await _httpClient.PostAsJsonAsync("api/technologies", tech);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error in AddTechnologyAsync: HTTP {(int)response.StatusCode}");
                    return null;
                }
                var createdTech = await response.Content.ReadFromJsonAsync<Technology>();
                if (createdTech == null)
                {
                    Console.WriteLine("Error in AddTechnologyAsync: The Technology could not be created (null returned)");
                }
                return createdTech;
            });

        // Hämta teknologi via id
        public async Task<Technology?> GetTechnologyByIdAsync(int id) =>
            await ExecuteSafeAsync(async () =>
            {
                var tech = await _httpClient.GetFromJsonAsync<Technology>($"/api/technologies/{id}");
                if (tech == null)
                {
                    Console.WriteLine($"Technology with id {id} was not found");
                }
                return tech;
            });

        // Uppdatera en teknologi
        public async Task<Technology?> UpdateTechnologyAsync(Technology tech) =>
            await ExecuteSafeAsync(async () =>
            {
                var response = await _httpClient.PutAsJsonAsync($"api/technologies/{tech.Id}", tech);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error in UpdateTechnologyAsync: HTTP {(int)response.StatusCode}");
                    return null;
                }
                var updatedTech = await response.Content.ReadFromJsonAsync<Technology>();
                if (updatedTech == null)
                {
                    Console.WriteLine("Error in UpdateTechnologyAsync: Technology could not be updated (null returned)");
                }
                return updatedTech;
            });

        // Ta bort en teknologi
        public async Task DeleteTechnologyAsync(int id) =>
            await ExecuteSafeAsync(async () =>
            {
                var response = await _httpClient.DeleteAsync($"api/technologies/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error in DeleteTechnologyAsync: HTTP {(int)response.StatusCode}");
                }
                return true;
            }, false);

        //---------------------------certifikat---------------------

        // Hämta alla certifikat
        public async Task<List<Certificate>> GetCertificatesAsync() =>
            await ExecuteSafeAsync(async () =>
            {
                var certs = await _httpClient.GetFromJsonAsync<List<Certificate>>("/api/certificates");
                return certs ?? new List<Certificate>();
            }, new List<Certificate>());

        // Skapa ett nytt certifikat
        public async Task<Certificate?> AddCertificateAsync(Certificate cert) =>
            await ExecuteSafeAsync(async () =>
            {
                var response = await _httpClient.PostAsJsonAsync("/api/certificates", cert);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error in AddCertificateAsync: HTTP {(int)response.StatusCode}");
                    return null;
                }
                var createdCert = await response.Content.ReadFromJsonAsync<Certificate>();
                if (createdCert == null)
                {
                    Console.WriteLine("Error in AddCertificateAsync: The Certificate could not be created (null returned)");
                }
                return createdCert;
            });

        // Hämta ett certifikat via id
        public async Task<Certificate?> GetCertificateByIdAsync(int id) =>
            await ExecuteSafeAsync(async () =>
            {
                var cert = await _httpClient.GetFromJsonAsync<Certificate>($"/api/certificates/{id}");
                if (cert == null)
                {
                    Console.WriteLine($"Certificate with id {id} was not found");
                }
                return cert;
            });

        // Uppdatera ett certifikat
        public async Task<Certificate?> UpdateCertificateAsync(Certificate cert) =>
            await ExecuteSafeAsync(async () =>
            {
                var response = await _httpClient.PutAsJsonAsync($"/api/certificates/{cert.Id}", cert);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error in UpdateCertificateAsync: HTTP {(int)response.StatusCode}");
                    return null;
                }
                var updatedCert = await response.Content.ReadFromJsonAsync<Certificate>();
                if (updatedCert == null)
                {
                    Console.WriteLine("Error in UpdateCertificateAsync: Certificate could not be updated (null returned)");
                }
                return updatedCert;
            });

        // Ta bort ett certifikat
        public async Task DeleteCertificateAsync(int id) =>
            await ExecuteSafeAsync(async () =>
            {
                var response = await _httpClient.DeleteAsync($"/api/certificates/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error in DeleteCertificateAsync: HTTP {(int)response.StatusCode}");
                }
                return true;
            }, false);

        //---------------------------Erfarenhet---------------------

        // Hämta alla erfarenheter
        public async Task<List<Experience>> GetExperiencesAsync() =>
            await ExecuteSafeAsync(async () =>
            {
                var exps = await _httpClient.GetFromJsonAsync<List<Experience>>("/api/experiences");
                return exps ?? new List<Experience>();
            }, new List<Experience>());

        // Skapa en ny erfarenhet
        public async Task<Experience?> AddExperienceAsync(Experience exp) =>
            await ExecuteSafeAsync(async () =>
            {
                var response = await _httpClient.PostAsJsonAsync("/api/experiences", exp);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error in AddExperienceAsync: HTTP {(int)response.StatusCode}");
                    return null;
                }
                var createdExp = await response.Content.ReadFromJsonAsync<Experience>();
                if (createdExp == null)
                {
                    Console.WriteLine("Error in AddExperienceAsync: The Experience could not be created (null returned)");
                }
                return createdExp;
            });

        // Hämta en erfarenhet via id
        public async Task<Experience?> GetExperienceByIdAsync(int id) =>
            await ExecuteSafeAsync(async () =>
            {
                var exp = await _httpClient.GetFromJsonAsync<Experience>($"/api/experiences/{id}");
                if (exp == null)
                {
                    Console.WriteLine($"Experience with id {id} was not found");
                }
                return exp;
            });

        // Uppdatera en erfarenhet
        public async Task<Experience?> UpdateExperienceAsync(Experience exp) =>
            await ExecuteSafeAsync(async () =>
            {
                var response = await _httpClient.PutAsJsonAsync($"/api/experiences/{exp.Id}", exp);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error in UpdateExperienceAsync: HTTP {(int)response.StatusCode}");
                    return null;
                }
                var updatedExp = await response.Content.ReadFromJsonAsync<Experience>();
                if (updatedExp == null)
                {
                    Console.WriteLine("Error in UpdateExperienceAsync: Experience could not be updated (null returned)");
                }
                return updatedExp;
            });

        // Ta bort en erfarenhet
        public async Task DeleteExperienceAsync(int id) =>
            await ExecuteSafeAsync(async () =>
            {
                var response = await _httpClient.DeleteAsync($"/api/experiences/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error in DeleteExperienceAsync: HTTP {(int)response.StatusCode}");
                }
                return true;
            }, false);
    }
}
