using Abstraction.Models;
using Abstraction.Enumerators;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookingFrontend.Services
{
    public class APICaller
    {

        private HttpClient APIContext = null!;

        public APICaller() {
            APIContext = new HttpClient();
            APIContext.BaseAddress = new Uri("http://localhost:7002/");
        }

        public async Task<ActionResult> AddResources(string name, int type, double price) {
            ResourceDTO data = new ResourceDTO(name, (Specification)type, price);
            StringContent send_content = new StringContent(JsonSerializer.Serialize(data));

            HttpResponseMessage response = await APIContext.PostAsync("Ressource", send_content);

            if (!response.IsSuccessStatusCode) {
                return new NoContentResult();
            }

            return new OkResult();
        }

        public async Task<ActionResult<ResourceDTO>> GetRessources(int id) {
            HttpResponseMessage response = await APIContext.GetAsync($"Ressource/{id}");

            if (!response.IsSuccessStatusCode) {
                return new NoContentResult();
            }

            ResourceDTO? json_ressource = await response.Content.ReadFromJsonAsync<ResourceDTO>();

            if (json_ressource == null) {
                return new NoContentResult();
            }

            return json_ressource;
        }

        public async Task<ActionResult> UpdateRessources(int id, string desc, string type, string s_price) {
            Specification spec = (Specification)int.Parse(type);
            double price = double.Parse(s_price);
            ResourceDTO ressource = new ResourceDTO(desc, spec, price);

            StringContent send_content = new StringContent(JsonSerializer.Serialize(ressource));

            HttpResponseMessage response = await APIContext.PutAsync($"Ressource/{id}", send_content);

            if (!response.IsSuccessStatusCode) {
                return new NotFoundResult();
            }

            return new OkResult();
        }

        public async Task<ActionResult> DeleteRessource(int id) {
            HttpResponseMessage response = await APIContext.DeleteAsync($"Ressource/{id}");

            if (!response.IsSuccessStatusCode) {
                return new NotFoundResult();
            }

            return new OkResult();
        }
    }
}
