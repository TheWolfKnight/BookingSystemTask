using Abstraction.Enumerators;
using Abstraction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Frontend.Pages.Ressource
{
    public class EditItemModel : PageModel
    {
        private readonly ILogger<EditItemModel> _logger;
        private readonly HttpClient _Client = null!;
        private static int Id;

        public string ErrMessage = "";


        public EditItemModel(ILogger<EditItemModel> logger) {
            _logger = logger;

            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

#if DEBUG
            string addr_str = config.GetValue<string>("APIHttpUri:Debug")!;
#else
            string addr_str = config.GetValue<string>("APIHttpUri:Release")!;
#endif

            Uri base_addr = new Uri(addr_str);

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

            HttpResponseMessage response = await _Client.PutAsync($"Ressource/{Id}", content);

            if (!response.IsSuccessStatusCode) {
                return RedirectToPage("./Index", (object?)"Could not finde the Ressource you are trying to update");
            }

            return RedirectToPage("./Index", (object?)"Ressource was updated");
        }

        public IActionResult OnGet()
        {
            if (RouteData.Values.TryGetValue("id", out object? obj) &&
                int.TryParse((string?)obj, out int id)) {
                Id = id;
                return Page();
            }

            return RedirectToPage("./Index", (object?)"Unknown id input, please check");
        }
    }
}
