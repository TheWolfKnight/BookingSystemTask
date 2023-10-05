using Abstraction.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Booking
{
    public class IndexPageModel : PageModel {
        public string Mesasge { get; set; } = "";
        public IEnumerable<BookingDTO> Bookings = null!;

        private readonly ILogger<IndexPageModel> _logger = null!;
        private readonly HttpClient _Client = null!;

        public IndexPageModel(ILogger<IndexPageModel> logger) {
            _logger = logger;

            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

            #if DEBUG
            string addr_str = config.GetValue<string>("APIHttpUri:Debug")!;
            #else
            string addr_str = config.GetValue<string>("APIHttpUri:Release");
            #endif

            Uri base_addr = new Uri(addr_str);
            _Client = new HttpClient();
            _Client.BaseAddress = base_addr;
        }

        private async Task GetAllBookings() {
            DateTime t = DateTime.Now;
        }

        public async Task<IActionResult> OnGetAsync() {

            await GetAllBookings();

            if (RouteData.Values.TryGetValue("message", out object? obj) &&
                !string.IsNullOrEmpty((string?)obj))
            {
                    Mesasge = (string)obj;
            }

            return Page();
        }

    }

}
