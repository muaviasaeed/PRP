using PRP.Data;
using PRP.Reports;
using MySql.Data.MySqlClient;

namespace PRP
{
    class Program
    {
        static void Main()
        {
            var db = new DatabaseConnection();

            try
            {
                using var connection = db.GetConnection();
                connection.Open();
                Console.WriteLine("✅ Database connection successful!");

                while (true)
                {
                    Console.WriteLine("\n===== MAIN MENU =====");
                    Console.WriteLine("1. World Countries Report");
                    Console.WriteLine("2. World Cities Report");
                    Console.WriteLine("3. Exit");
                    Console.Write("Select option: ");

                    var input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            CountryReport.GenerateWorldReport(connection);
                            break;
                        case "2":
                            CityReport.GenerateWorldReport(connection);
                            break;
                        case "3":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid option!");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }
    }
}