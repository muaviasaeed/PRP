using MySql.Data.MySqlClient;
using System;

namespace PopulatioApp
{
    class Database
    {
        private string ConnectionString = "server=localhost;user=root;password=123456789;database=world";

        public MySqlConnection? GetConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(ConnectionString);
                connection.Open();
                Console.WriteLine("Database connection successful!");
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection failed: {ex.Message}");
                return null;
            }
        }
    }
}