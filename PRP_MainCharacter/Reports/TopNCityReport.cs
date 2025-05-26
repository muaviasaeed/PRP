using MySql.Data.MySqlClient;
using System;

namespace PopulationApp
{
    class TopNCityReport
    {
        private Database db = new Database();
        /// <summary>
        /// Displays top N cities in the world by population.
        /// </summary>
        public void GetTopNCitiesByPopulation()
        {
            Console.Write("Enter the number of top cities to display (N): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                return;
            }

            using var conn = db.GetConnection();
            if (conn != null)
            {
                string sql = @"
        SELECT city.Name AS CityName, country.Name AS CountryName, city.District, city.Population
        FROM city
        JOIN country ON city.CountryCode = country.Code
        ORDER BY city.Population DESC
        LIMIT @limit";

                using MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@limit", n);

                using MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine($"\nTop {n} Cities by Population:");
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