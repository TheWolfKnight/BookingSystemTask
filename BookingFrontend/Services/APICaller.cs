using Abstraction.Models;
using Abstraction.Enumerators;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BookingFrontend.Services
{
    public class APICaller
    {

        private HttpClient APIContext = null!;

        public APICaller() {
            APIContext = new HttpClient();
            APIContext.BaseAddress = new Uri("https://localhost:6580/");
        }


        public async Task<ActionResult> AddResouce(string name, int type, double price) {

            ResourceDTO data = new ResourceDTO(name, (Specification)type, price);
            StringContent content = new StringContent(JsonSerializer.Serialize(data));

            HttpResponseMessage repsonse = await APIContext.PostAsync("Ressource", content);

            repsonse.EnsureSuccessStatusCode();

            return new OkResult();
        }

        public async Task<ActionResult<string>> GetResource(int id) {


            return "not";
        }

    }
}
