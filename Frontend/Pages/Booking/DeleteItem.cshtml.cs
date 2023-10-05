using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Net;

namespace Frontend.Pages.Booking {

    public class DeleteItemPageModel : PageModel {
        private readonly ILogger<DeleteItemPageModel> _logger = null!;
        private readonly HttpClient _Client = null!;

        public DeleteItemPageModel(ILogger<DeleteItemPageModel> logger) {
            _logger = logger;

            Uri base_addr = new Uri("http://localhost:5000/");
            _Client = new HttpClient();
        }

        public async Task<IActionResult> OnGetAsync() {
            int id = -1;
            if (!RouteData.Values.TryGetValue("id", out object? obj) &&
                !int.TryParse((string?)obj, out id)) {
                    return RedirectToPage("./Index", (object?)"Could not get the id");
            }

            HttpResponseMessage response = await _Client.DeleteAsync($"Booking/{id}");

            if (response.StatusCode != HttpStatusCode.OK) {
                return RedirectToPage("./Index", (object?)"Could not find the item");
            }

            return RedirectToPage("./Index", (object?)"Item was deleted");
        }

    }

}
