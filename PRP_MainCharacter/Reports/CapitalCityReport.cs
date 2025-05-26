using MySql.Data.MySqlClient;
using System;

namespace PopulationApp
{
    public class CapitalCityReport
    {
        private Database db = new Database();

        /// <summary>
        /// Displays all capital cities in the world ordered by population.
        /// </summary>
        public void GetCapitalCitiesByPopulation()
        {
            using var conn = db.GetConnection();
            if (conn == null) return;

            string sql = @"
                SELECT city.Name AS CapitalName, country.Name AS CountryName, city.Population
                FROM city
                JOIN country ON city.ID = country.Capital
                ORDER BY city.Population DESC";

            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            using MySqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine($"{"Capital",-20} {"Country",-25} {"Population",-12}");
            Console.WriteLine(new string('-', 60));

            while (reader.Read())
            {
                Console.WriteLine($"{reader["CapitalName"],-20} {reader["CountryName"],-25} {reader["Population"],-12}");
            }

            conn.Close();
        }
    }
}
