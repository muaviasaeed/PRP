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
                Console.WriteLine("5. View all capital cities by population");
                Console.WriteLine("6. View all capital cities in a continent by population");
                Console.WriteLine("7. View all capital cities in a region by population");
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
                        Console.Write("Enter continent: ");
                        string continent = Console.ReadLine();
                        CapitalCityReport report6 = new CapitalCityReport();
                        report6.GetCapitalCitiesByContinent(continent);
                        break;

                    case "7":
                        Console.Write("Enter region: ");
                        string region = Console.ReadLine();
                        CapitalCityReport report7 = new CapitalCityReport();
                        report7.GetCapitalCitiesByRegion(region);
                        break;

                    case "0":
                        Console.WriteLine("Exiting... ");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
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
