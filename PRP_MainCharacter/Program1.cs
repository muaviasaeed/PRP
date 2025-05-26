using MySql.Data.MySqlClient;
using System;

namespace PopulationApp
{
    class Program
    {
        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("===== Population Reporting System =====");
                Console.WriteLine("1. View all countries by population");
                Console.WriteLine("2. View top-N countries by population");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PopulationByCountry report1 = new PopulationByCountry();
                        report1.GetCountriesByPopulation();
                        break;

                    case "2":
                        TopNCountryReport report2 = new TopNCountryReport();
                        report2.GetTopNCountriesByPopulation();
                        break;

                    case "0":
                        Console.WriteLine("Exiting... 👋");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("❌ Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}
