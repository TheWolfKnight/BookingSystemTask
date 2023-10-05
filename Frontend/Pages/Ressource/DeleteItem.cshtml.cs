using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Ressource
{
    public class DeleteItemModel : PageModel
    {

        public int Id;
        private readonly HttpClient _Client = null!;

        public DeleteItemModel()
        {

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

        public async Task<IActionResult> OnGetAsync()
        {
            if (RouteData.Values.TryGetValue("id", out object? obj) &&
                int.TryParse((string?)obj, out int id))
            {
                Id = id;
            }
            else
            {
                return RedirectToPage("./Index", (object?)"Corrupted Id");
            }

            HttpResponseMessage response;
            try
            {
                response = await _Client.DeleteAsync($"Ressource/{Id}");
            }
            catch (Exception)
            {
                return RedirectToPage("./Index", (object?)"Could not get an connection to the server");
            }

            if (!response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index", (object?)"Could not delete the item");
            }

            return RedirectToPage("./Index", (object?)"Ressource was deleted");
        }
    }
}
