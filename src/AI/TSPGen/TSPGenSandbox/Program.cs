using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAPI;
using TSPModel;

namespace TSPGenSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneticAPI.JsonFileReader<City> importer = new GeneticAPI.JsonFileReader<City>();
            List<City> lo_data = importer.Import(args[0]);

            for (int i = 0; i< lo_data.Count; i++)
            {
                Console.WriteLine(lo_data[i].id);
            }
            Console.ReadLine();
        }
    }
}
