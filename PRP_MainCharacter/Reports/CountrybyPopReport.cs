using MySql.Data.MySqlClient;
using System;

namespace PopulationApp
{
    public class Database
    {
        private string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") 
            ?? "server=localhost;user=root;password=123456789;database=";

        public MySqlConnection GetConnection()
        {
            try
            {
                var connection = new MySqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to the database: {ex.Message}");
                return null;
            }
        }
    }

    class PopulationByCountry
    {
        private Database db = new Database();

        public void GetCountriesByPopulation()
        {
            using var conn = db.GetConnection();
            if (conn == null) return;

            string sql = @"
                SELECT Code, Name, Continent, Region, Population, Capital
                FROM country
                ORDER BY Population DESC";

            try
            {
                using MySqlCommand cmd = new MySqlCommand(sql, conn);
                using MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine($"{"Code",-5} {"Name",-30} {"Continent",-15} {"Region",-20} {"Population",-12} {"Capital",-10}");
                Console.WriteLine(new string('-', 100));
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Code"],-5} {reader["Name"],-30} {reader["Continent"],-15} {reader["Region"],-20} {reader["Population"],-12} {reader["Capital"],-10}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing SQL query: {ex.Message}");
            }
        }
    }
}
