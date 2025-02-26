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


        //-------Teknologier---------


        //Hämta alla tekonoliger
        public async Task<List<Technology>> GetTechnologiesAsync()
        {
            var tech = await _httpClient.GetFromJsonAsync<List<Technology>>("/api/technologies");

            if (tech == null)
            {
                //Hanterar null 
                return new List<Technology>();
            }
            return tech;
        }

        //Skapa
        public async Task<Technology> AddTechnologyAsync(Technology tech)
        {
            //Skickar ett Post-anrop
            var response = await _httpClient.PostAsJsonAsync("api/technologies", tech);

            //Om godkänt koden går vidare, annars kastas ett fel med statuskod
            response.EnsureSuccessStatusCode();

            //Läser och retunerar svar från api
            var createdTech =  await response.Content.ReadFromJsonAsync<Technology>();

            if (createdTech == null)
            {
                throw new Exception("The Technology could not be created ");
            }
            return createdTech;
        }

        //Get by id 
        public async Task<Technology> GetTechnologyByIdAsync(int id)
        {
            var tech = await _httpClient.GetFromJsonAsync<Technology>($"/api/technologies/{id}");
            if ( tech == null)
            {
                throw new Exception($"Technology with id {id} was not found");
            }
            return tech;
        }

        //Update
        public async Task<Technology> UpdateTechnologyAsync (Technology tech)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/technologies/{tech.Id}", tech);
            response.EnsureSuccessStatusCode();

            var updatedTech =  await response.Content.ReadFromJsonAsync<Technology>();

            if ( updatedTech == null)
            {
                throw new Exception("Technology could not be updated");
            }
            return updatedTech;
        }

        //Delete
        public async Task DeleteTechnologyAsync(int Id)
        {
            var response = await _httpClient.DeleteAsync($"api/technologies/{Id}");
            response.EnsureSuccessStatusCode();
        }

        //-------Projekt---------

        // Hämta alla projekt
        public async Task<List<Projects>> GetProjectsAsync()
        {
            var tech = await _httpClient.GetFromJsonAsync<List<Projects>>("/api/projects");

            if (tech == null )
            {
                return new List<Projects>();
            }
            return tech;
        }

        //Skapa
        public async Task<Projects> AddProjectAsync (Projects newProject)
        {
            var response = await _httpClient.PostAsJsonAsync<Projects>("/api/projects", newProject);

            response.EnsureSuccessStatusCode();

            var createdProject = await response.Content.ReadFromJsonAsync<Projects>();

            if (createdProject == null)
            {
                throw new Exception("The Project could not be created");
            }

            return createdProject;
        }

        //Get by id
        public async Task<Projects> GetProjectByIdAsync(int id)
        {
            var project = await _httpClient.GetFromJsonAsync<Projects>($"/api/projects/{id}");
            if (project == null )
            {
                throw new Exception($"The project with id {id} was not found");
            }
            return project;
        }

        //Update
        public async Task<Projects> UpdateProjectAsync(Projects project)
        {
            var response = await _httpClient.PutAsJsonAsync<Projects>($"/api/projects/{project.Id}", project);
            var updatedProject = await response.Content.ReadFromJsonAsync<Projects>();

            if(updatedProject == null)
            {
                throw new Exception("The project could not be updated");
            }
            return updatedProject;
        }

        //Delete
        public async Task DeleteProjectsAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/projects/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
