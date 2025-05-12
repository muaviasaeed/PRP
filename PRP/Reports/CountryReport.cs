using MySql.Data.MySqlClient;

namespace PRP.Reports
{
    public static class CountryReport
    {
        public static void GenerateWorldReport(MySqlConnection connection)
        {
            const string query = @"SELECT Code, Name, Continent, Region, Population, Capital 
                                 FROM country 
                                 ORDER BY Population DESC";

            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            Console.WriteLine("\n=== World Countries Report ===");
            while (reader.Read())
            {
                Console.WriteLine($"Code: {reader["Code"]} | Name: {reader["Name"]} | Population: {reader["Population"]}");
            }
            reader.Close();
        }
    }
}