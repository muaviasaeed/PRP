using MySql.Data.MySqlClient;

namespace PRP.Reports
{
    public static class CityReport  
    {
        public static void GenerateWorldReport(MySqlConnection connection)
        {
            const string query = @"SELECT city.Name, city.District, city.Population, country.Name AS Country 
                                 FROM city 
                                 JOIN country ON city.CountryCode = country.Code 
                                 ORDER BY city.Population DESC";

            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            Console.WriteLine("\n=== World Cities Report ===");
            while (reader.Read())
            {
                Console.WriteLine($"City: {reader["Name"]} | Country: {reader["Country"]} | Population: {reader["Population"]}");
            }
            reader.Close();
        }
    }
}