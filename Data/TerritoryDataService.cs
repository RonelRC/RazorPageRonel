using Dapper;
using Microsoft.Extensions.Configuration;
using Razor.Pages.Practica.Models;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Razor.Pages.Practica.Pages
{
    public class TerritoryDataService : ITerritoryDataService
    {
        private readonly IConfiguration _configuration;

        public TerritoryDataService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IEnumerable<Territory> GetTerritories()
        {
            var connectionString = _configuration.GetConnectionString("Northwind");
            var connection = new SqlConnection(connectionString);
            var resultSet = connection.Query<Territory>("select Territoryid,  TerritoryDescription " +
                "from territories");

            return resultSet;
        }

        public Territory GetTerritoryById(int territoryId)
        {
            var connectionString = _configuration.GetConnectionString("Northwind");
            var connection = new SqlConnection(connectionString);
            var resultSet = connection.QuerySingle<Territory>(
                "select Territoryid,  TerritoryDescription " +
                "from territories where TerritoryId = @territoryId", new
                {
                    territoryId
                }
                );

            return resultSet;
        }

        public void UpdateTerritory(Territory territory)
        {
            var connectionString = _configuration.GetConnectionString("Northwind");
            var connection = new SqlConnection(connectionString);
            var resultSet = connection.Execute(
                "update Territories " +
                "set TerritoryDescription = @TerritoryDescription " +
                "where TerritoryId = @territoryId", new
                {
                    territoryId = territory.Territoryid,
                    TerritoryDescription = territory.TerritoryDescription
                }
                );
        }

        public void DeleteTerritory(Territory territory)
        {
            var connectionString = _configuration.GetConnectionString("Northwind");
            var connection = new SqlConnection(connectionString);
            var resultSet = connection.Execute(

                "delete from territories where TerritoryID = @territoryId", new
                {
                    territoryId = territory.Territoryid
                }
                );
        }
        public void AddTerritory(Territory territory)
        {
            var connectionString = _configuration.GetConnectionString("Northwind");
            var connection = new SqlConnection(connectionString);
            var resultSet = connection.Execute(

                "insert into  " +
                "territories (Territoryid, TerritoryDescription, RegionID) values (@Territoryid, @TerritoryDescription, 1)", new
                {
                    territoryId = territory.Territoryid,
                    TerritoryDescription = territory.TerritoryDescription
                }
                );
        }
    }
}