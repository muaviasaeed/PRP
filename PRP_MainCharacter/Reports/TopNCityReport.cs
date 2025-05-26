using MySql.Data.MySqlClient;
using System;

namespace PopulationApp
{
    class TopNCityReport
    {
        private Database db = new Database();
      
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
                    SELECT city.Name AS Name, country.Name AS Country, city.District, city.Population
                    FROM city
                    JOIN country ON city.CountryCode = country.Code
                    ORDER BY city.Population DESC
                    LIMIT @n";

                using MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@n", n);

                using MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine($"\nTop {n} Cities by Population:");
                Console.WriteLine($"{"Name",-25} {"Country",-25} {"District",-20} {"Population",-12}");
                Console.WriteLine(new string('-', 85));

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"],-25} {reader["Country"],-25} {reader["District"],-20} {reader["Population"],-12}");
                }
            }
        }
    }
}