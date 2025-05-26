using MySql.Data.MySqlClient;
using System;

namespace PopulationApp
{
    public class PopulationReport
    {
        private Database db = new Database();

        /// <summary>
        /// Displays population breakdown (city vs non-city) by continent.
        /// </summary>
        public void GetPopulationBreakdownByContinent()
        {
            using var conn = db.GetConnection();
            if (conn == null) return;

            string sql = @"
                SELECT country.Continent,
                       SUM(country.Population) AS TotalPopulation,
                       SUM(city.Population) AS CityPopulation,
                       (SUM(country.Population) - SUM(city.Population)) AS NonCityPopulation,
                       ROUND(SUM(city.Population) / SUM(country.Population) * 100, 2) AS CityPercentage
                FROM country
                JOIN city ON country.Code = city.CountryCode
                GROUP BY country.Continent
                ORDER BY TotalPopulation DESC;";

            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            using MySqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine($"{"Continent",-15} {"Total",-15} {"City",-15} {"Non-City",-15} {"City %",-8}");
            Console.WriteLine(new string('-', 70));

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Continent"],-15} {reader["TotalPopulation"],-15} {reader["CityPopulation"],-15} {reader["NonCityPopulation"],-15} {reader["CityPercentage"],-8}%");
            }

            conn.Close();
        }
    }
}
