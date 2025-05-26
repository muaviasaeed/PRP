using MySql.Data.MySqlClient;
using System;

namespace PopulationApp
{
   class TopNCountryReport
   {
        private Database db = new Database();
        /// <summary>
        ///  Display Country Report for Top N Countries by Population
        ///  </summary>
        public void GetTopNCountriesByPopulation()
        {
            Console.Write("Enter the number of top countries to display (N): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                return;
            }

            using var conn = db.GetConnection();
            if (conn != null)
            {
                string sql = @"
        SELECT Code, Name, Continent, Region, Population, Capital
        FROM country
        ORDER BY Population DESC
        LIMIT @limit";

                using MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@limit", n);

                using MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine($"\nTop {n} Countries by Population:");
                Console.WriteLine($"{"Code",-5} {"Name",-20} {"Continent",-15} {"Region",-20} {"Population",-12} {"Capital",-10}");
                Console.WriteLine(new string('-', 90));

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Code"],-5} {reader["Name"],-20} {reader["Continent"],-15} {reader["Region"],-20} {reader["Population"],-12} {reader["Capital"],-10}");
                }

                conn.Close();
            }
        }

   }
}