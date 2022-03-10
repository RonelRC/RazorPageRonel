using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Pages.Practica.Models;
using Razor.Pages.Practica.Pages;


namespace Razor.Pages.Practica.Pages.Territories
{
    public class EditModel : PageModel
    {
        private readonly ITerritoryDataService _territoryDataService;

        public EditModel(ITerritoryDataService territoryDataService)
        {
            this._territoryDataService = territoryDataService;
        }

        [BindProperty]
        public Territory Territory { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            int territoryId = int.Parse(Request.Query["id"].ToString());
            var territory = _territoryDataService.GetTerritoryById(territoryId);
            Territory = territory;
        }

        public IActionResult OnPost()
        {
            try
            {
                _territoryDataService.UpdateTerritory(this.Territory);

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
