using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Razor.Pages.Practica.Models;
using Razor.Pages.Practica.Pages;

namespace Razor.Pages.Practica.Pages.Territories
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<Pages.IndexModel> _logger;
        private readonly ITerritoryDataService _territoyDataService;

        public IndexModel(ILogger<Pages.IndexModel> logger,
            ITerritoryDataService territoryDataService)
        {
            _logger = logger;
            _territoyDataService = territoryDataService;
        }

        [BindProperty]
        public Territory Territory { get; set; }

        public string ErrorMessage { get; set; }

        public IEnumerable<Territory> Territories { get; set; }
        public void OnGet()
        {
            Territories = _territoyDataService.GetTerritories();
        }


        public IActionResult OnPost()
        {

            try
            {
                int territoryId = int.Parse(Request.Query["id"].ToString());
                var territory = _territoyDataService.GetTerritoryById(territoryId);
                Territory = territory;
                _territoyDataService.DeleteTerritory(this.Territory);

                return RedirectToPage("Index");
            }
            catch (Exception Ex)
            {

                ErrorMessage = Ex.Message;
                return Page();
            }
        }
    }

}
