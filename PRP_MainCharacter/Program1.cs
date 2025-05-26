using System;

namespace PopulationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PopulatioByCountry report = new PopulatioByCountry();
            report.GetCountriesByPopulation();
        }
    }
}