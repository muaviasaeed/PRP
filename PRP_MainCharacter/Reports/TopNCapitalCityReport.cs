using MySql.Data.MySqlClient;
using System;

namespace PopulationApp
{
	class TopNCapitalCityReport
	{
		private Database db = new Database();
		/// <summary>
		/// Displays the top N capital cities in the world ordered by population.
		/// </summary>
		public void GetTopNCapitalCitiesByPopulation()
		{
			Console.Write("Enter the number of top capital cities to display (N): ");
			if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
			{
				Console.WriteLine("Invalid input. Please enter a positive number.");
				return;
			}

			using var conn = db.GetConnection();
			if (conn != null)
			{
				string sql = @"
        SELECT city.Name AS CapitalName, country.Name AS CountryName, city.Population
        FROM city
        JOIN country ON city.ID = country.Capital
        ORDER BY city.Population DESC
        LIMIT @limit";

				using MySqlCommand cmd = new MySqlCommand(sql, conn);
				cmd.Parameters.AddWithValue("@limit", n);

				using MySqlDataReader reader = cmd.ExecuteReader();

				Console.WriteLine($"\nTop {n} Capital Cities by Population:");
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
}
