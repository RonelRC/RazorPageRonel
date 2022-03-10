using Razor.Pages.Practica.Models;
using System.Collections.Generic;

namespace Razor.Pages.Practica
{
    public interface ITerritoryDataService
    {
        IEnumerable<Territory> GetTerritories();

        Territory GetTerritoryById(int territoryId);

        public void UpdateTerritory(Territory territory);

        public void DeleteTerritory(Territory territory);

        public void AddTerritory(Territory territory);
    }
}