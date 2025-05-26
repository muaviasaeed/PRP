using MySql.Data.MySqlClient;
using System;

namespace PopulationApp
{
    public class CityReport
    {
        private Database db = new Database();

        public void GetCitiesByPopulation()
        {
            using var conn = db.GetConnection();
            if (conn != null)
            {
                string sql = @"
                    SELECT city.Name AS Name, country.Name AS Country, city.District, city.Population
                    FROM city
                    JOIN country ON city.CountryCode = country.Code
                    ORDER BY city.Population DESC";

                using MySqlCommand cmd = new MySqlCommand(sql, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine($"{"Name",-25} {"Country",-25} {"District",-20} {"Population",-12}");
                Console.WriteLine(new string('-', 85));

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"],-25} {reader["Country"],-25} {reader["District"],-20} {reader["Population"],-12}");
                }

                conn.Close();
            }
        }
    }
}
