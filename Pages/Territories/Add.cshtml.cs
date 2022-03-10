using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Pages.Practica.Models;

namespace Razor.Pages.Practica.Pages.Territories
{
    public class AddModel : PageModel
    {
        private readonly ITerritoryDataService _territoryDataService;

        public AddModel(ITerritoryDataService territoryDataService)
        {
            this._territoryDataService = territoryDataService;
        }

        [BindProperty]
        public Territory Territory { get; set; }

        public string ErrorMessage { get; set; }

       
        public IActionResult OnPost()
        {
            try
            {
                _territoryDataService.AddTerritory(this.Territory);

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
