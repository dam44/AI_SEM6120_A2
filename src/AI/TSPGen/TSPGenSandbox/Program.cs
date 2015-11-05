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
            Program lo_program = new Program();
            lo_program.doWork(args);
        }

        public void doWork(string[] args)
        {
            GeneticAPI.JsonFileReader<City> importer = new GeneticAPI.JsonFileReader<City>();
            List<City> lo_data = importer.Import(args[0]);

            for (int i = 0; i < lo_data.Count; i++)
            {
                Console.WriteLine(lo_data[i].id);
            }

            Processor<City> lo_processor = new Processor<City>();
            lo_processor.Changed += new ChangedEventHandler(Changed);
            lo_processor.Execute(lo_data, 4, 100, 0.1);
            Console.ReadLine();
        }

        private void Changed(object sender, GeneticAPI.Events.APIEventArgs e)
        {
            Console.WriteLine(e.message);
            Console.WriteLine("Average fitness: " + e.avgfitness);
        }
    }
}
