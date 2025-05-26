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
                Console.WriteLine("3. View all cities by population");
                Console.WriteLine("4. View top-N cities by population");
                Console.WriteLine("5. View capital cities by population");
                Console.WriteLine("6. View top-N capital cities by population");
                Console.WriteLine("7. View population breakdown by continent (city vs non-city)");
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

                    case "3":
                        CityReport report3 = new CityReport();
                        report3.GetCitiesByPopulation();
                        break;

                    case "4":
                        TopNCityReport report4 = new TopNCityReport();
                        report4.GetTopNCitiesByPopulation();
                        break;

                    case "5":
                        CapitalCityReport report5 = new CapitalCityReport();
                        report5.GetCapitalCitiesByPopulation();
                        break;

                    case "6":
                        TopNCapitalCityReport report6 = new TopNCapitalCityReport();
                        report6.GetTopNCapitalCitiesByPopulation();
                        break;

                    case "7":
                        PopulationReport report7 = new PopulationReport();
                        report7.GetPopulationBreakdownByContinent();
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
