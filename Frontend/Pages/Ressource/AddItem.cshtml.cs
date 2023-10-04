using Abstraction.Enumerators;
using Abstraction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Text.Json;
using System.Net.Http.Headers;

namespace Frontend.Pages.Ressource
{
    public class AddItemModel : PageModel
    {

        public string ErrMessage = "";

        private readonly ILogger<AddItemModel> _logger;

        private readonly HttpClient _Client = null!;

        public AddItemModel(ILogger<AddItemModel> logger) {
            _logger = logger;

            Uri base_addr = new Uri("http://localhost:5000/");

            _Client = new HttpClient();
            _Client.BaseAddress = base_addr;
        }

        public async Task<IActionResult> OnPostAsync() {
            ErrMessage = "";

            string? desc = Request.Form["DescriptionInput"];
            string? s_spec = Request.Form["TypeInput"];
            string? s_price = Request.Form["PriceInput"];


            if (desc == null || desc.Length < 1) {
                ErrMessage += "Please input a Description\n";
            }

            if (!int.TryParse(s_spec, out int spec)) {
                ErrMessage += "Please input a valid specification\n";
            }

            s_price = s_price?.Replace('.', ',');
            if (!double.TryParse(s_price, out double price)) {
                ErrMessage += "Please input a valid price\n";
            }

            if (!string.IsNullOrEmpty(ErrMessage)) {
                return Page();
            }

            ResourceDTO dto = new ResourceDTO(desc!, (Specification)spec, price);

            StringContent content = new StringContent(JsonSerializer.Serialize(dto));
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            HttpResponseMessage response = await _Client.PostAsync("Ressource", content);

            if (!response.IsSuccessStatusCode) {
                return RedirectToPage("./Index", (object?)"Could not send data to the server, please try again");
            }

            return RedirectToPage("./Index", (object?)"Ressource Created");
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
