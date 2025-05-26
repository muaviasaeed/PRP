using MySql.Data.MySqlClient;
using System;

namespace PopulationApp
{
    public class CapitalCityReport
    {
        private Database db = new Database();

        
        public class Database
        {
            public MySqlConnection GetConnection()
            {
                try
                {
                    string connectionString = "your_connection_string_here";
                    var connection = new MySqlConnection(connectionString);
                    connection.Open();
                    return connection;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Database connection error: {ex.Message}");
                    return null;
                }
            }
        }

        
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

            
        }

        public void GetCapitalCitiesByContinent(string continent)
        {
            using var conn = db.GetConnection();
            if (conn == null) return;

            string sql = @"
                SELECT city.Name AS CapitalName, country.Name AS CountryName, city.Population
                FROM city
                JOIN country ON city.ID = country.Capital
                WHERE country.Continent = @continent
                ORDER BY city.Population DESC";

            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@continent", continent);
            using MySqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine($"{"Capital",-20} {"Country",-25} {"Population",-12}");
            Console.WriteLine(new string('-', 60));

            while (reader.Read())
            {
                Console.WriteLine($"{reader["CapitalName"],-20} {reader["CountryName"],-25} {reader["Population"],-12}");
            }
        }

        public void GetCapitalCitiesByRegion(string region)
        {
            using var conn = db.GetConnection();
            if (conn == null) return;

            string sql = @"
                SELECT city.Name AS CapitalName, country.Name AS CountryName, city.Population
                FROM city
                JOIN country ON city.ID = country.Capital
                WHERE country.Region = @region
                ORDER BY city.Population DESC";

            using MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@region", region);
            using MySqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine($"{"Capital",-20} {"Country",-25} {"Population",-12}");
            Console.WriteLine(new string('-', 60));

            while (reader.Read())
            {
                Console.WriteLine($"{reader["CapitalName"],-20} {reader["CountryName"],-25} {reader["Population"],-12}");
            }
        }
    }
}
