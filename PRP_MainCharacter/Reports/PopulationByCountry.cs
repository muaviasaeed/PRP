using MySql.Data.MySqlClient;
using System;

namespace PopulationApp
{
    class PopulatioByCountry
    {
        private Database db = new Database();

        /// <summary>
        /// Displays all countries in the world ordered by population.
        /// </summary>
        public void GetCountriesByPopulation()
        {
            using var conn = db.GetConnection();
            if (conn != null)

            string sql = @"
                SELECT Code, Name, Continent, Region, Population, Capital
                FROM country
                ORDER BY Population DESC";

            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            using MySqlDataReader reader = cmd.ExecuteReader();

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