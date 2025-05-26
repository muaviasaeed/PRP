using MySql.Data.MySqlClient;
using System;

namespace PopulationApp
{
    public class CityReport
    {
        private Database db = new Database();

        /// <summary>
        /// Displays all cities in the world ordered by population.
        /// </summary>
        public void GetCitiesByPopulation()
        {
            using var conn = db.GetConnection();
            if (conn != null)
            {
                string sql = @"
                SELECT city.Name AS CityName, country.Name AS CountryName, city.District, city.Population
                FROM city
                JOIN country ON city.CountryCode = country.Code
                ORDER BY city.Population DESC";

                using MySqlCommand cmd = new MySqlCommand(sql, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine($"{"City",-20} {"Country",-20} {"District",-20} {"Population",-12}");
                Console.WriteLine(new string('-', 75));

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["CityName"],-20} {reader["CountryName"],-20} {reader["District"],-20} {reader["Population"],-12}");
                }

                conn.Close();
            }
        }
    }
}
