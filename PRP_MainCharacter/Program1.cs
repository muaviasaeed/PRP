using MySql.Data.MySqlClient;
using System;

namespace PopulationApp
{
    class Program
    {
        static void Main()
        {
            PopulationByCountry report = new PopulationByCountry();
            report.GetCountriesByPopulation();
            Console.ReadKey();
        }
    }
}