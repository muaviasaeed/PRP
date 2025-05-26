using MySql.Data.MySqlClient;
using System;

namespace PopulationApp
{
    public class CapitalCityReport
    {
        private Database db = new Database();

        public CapitalCityReport()
        {
        }

        public void GetCapitalCitiesByPopulation()
        {
            using var conn = db.GetConnection();
            if (conn == null) return;

            string sql = @"
                SELECT city.Name AS Name, country.Name AS Country, city.Population
                FROM city
                JOIN country ON city.ID = country.Capital
                ORDER BY city.Population DESC";

            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            using MySqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine($"{"Name",-25} {"Country",-25} {"Population",-12}");
            Console.WriteLine(new string('-', 65));

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"],-25} {reader["Country"],-25} {reader["Population"],-12}");
            }
        }

        public void GetCapitalCitiesByContinent(string continent)
        {
            using var conn = db.GetConnection();
            if (conn == null) return;

            string sql = @"
                SELECT city.Name AS Name, country.Name AS Country, city.Population
                FROM city
                JOIN country ON city.ID = country.Capital
                WHERE country.Continent = @continent
                ORDER BY city.Population DESC";

            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@continent", continent);
            using MySqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine($"{"Name",-25} {"Country",-25} {"Population",-12}");
            Console.WriteLine(new string('-', 65));

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"],-25} {reader["Country"],-25} {reader["Population"],-12}");
            }
        }

        public void GetCapitalCitiesByRegion(string region)
        {
            using var conn = db.GetConnection();
            if (conn == null) return;

            string sql = @"
                SELECT city.Name AS Name, country.Name AS Country, city.Population
                FROM city
                JOIN country ON city.ID = country.Capital
                WHERE country.Region = @region
                ORDER BY city.Population DESC";

            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@region", region);
            using MySqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine($"{"Name",-25} {"Country",-25} {"Population",-12}");
            Console.WriteLine(new string('-', 65));

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"],-25} {reader["Country"],-25} {reader["Population"],-12}");
            }
        }

        public void GetTopNCapitalCitiesByPopulation(int n)
        {
            using var conn = db.GetConnection();
            if (conn == null) return;

            string sql = @"
                SELECT city.Name AS Name, country.Name AS Country, city.Population
                FROM city
                JOIN country ON city.ID = country.Capital
                ORDER BY city.Population DESC
                LIMIT @n";

            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@n", n);
            using MySqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine($"\nTop {n} Capital Cities by Population:");
            Console.WriteLine($"{"Name",-25} {"Country",-25} {"Population",-12}");
            Console.WriteLine(new string('-', 65));

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"],-25} {reader["Country"],-25} {reader["Population"],-12}");
            }
        }
    }
}