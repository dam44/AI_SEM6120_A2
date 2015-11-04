using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    public class InitialChromosomeFactory<T> where T : IData
    {
        private static Random RAND = new Random();
        private static readonly object io_syncLock = new object();
        public static Chromosome<T> GenerateChromosome()
        {
            List<Gene<T>> lo_order = CreateOrder();
            return CreateChromosome(lo_order);

        }

        private static List<Gene<T>> CreateOrder()
        {
            List<Gene<T>> lo_order = new List<Gene<T>>();
            List<int> lo_datakeys = new List<int>();
            for (int i = 0; i < Globals<T>.DATA.Count; i++)
            {
                lo_datakeys.Add(i);
            }
            while (lo_datakeys.Count > 0)
            {
                lock (io_syncLock)
                {
                    int li_position = RAND.Next(0, lo_datakeys.Count);
                    int li_datakey = lo_datakeys[li_position];
                    lo_order.Add(Globals<T>.DATA[li_datakey]);
                    lo_datakeys.Remove(li_position);
                }
            }

            return lo_order;
        }

        private static Chromosome<T> CreateChromosome(List<Gene<T>> ao_order)
        {
            return new Chromosome<T>(ao_order, Fitness<T>.EvaluateTotal(ao_order));
        }

    }
}
