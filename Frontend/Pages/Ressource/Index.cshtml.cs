using Abstraction.Interfaces;
using Abstraction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Ressource
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly HttpClient _Client;
        public string Message = null!;

        private bool _IsSecond = false;

        [BindProperty]
        public IEnumerable<ResourceDTO> Ressources { get; set; } = null!;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

            Uri base_addr = new Uri("http://localhost:5000/");

            _Client = new HttpClient();
            _Client.BaseAddress = base_addr;
        }

        public string GetColor()
        {
            _IsSecond = !_IsSecond;
            return _IsSecond ? "#f83e35" : "#db0a00";
        }

        public async Task GetRessources()
        {
            HttpResponseMessage response = null!;
            try
            {
                response = await _Client.GetAsync("Ressource/all");
            }
            catch (Exception)
            {
                Message = "Could not get an connection to the server";
                Ressources = new List<ResourceDTO>();
                return;
            }

            if (!response.IsSuccessStatusCode)
                return;

            IEnumerable<ResourceDTO>? content = await response.Content.ReadFromJsonAsync<IEnumerable<ResourceDTO>>();

            Ressources = content!;
            Message = "Ressources Loaded: \n";
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await GetRessources();

            if (RouteData.Values.TryGetValue("message", out object? msg) &&
                !string.IsNullOrEmpty((string)msg!))
            {
                Message = (string)msg!;
            }

            return Page();
        }
    }
}