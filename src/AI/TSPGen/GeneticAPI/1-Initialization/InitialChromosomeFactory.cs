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
            IList<int> lo_datakeys = new List<int>();
            for (int i = 0; i < Globals<T>.DATA.Count; i++)
            {
                lo_datakeys.Add(i);
            }
            Stack<int> lo_datakeystack = new Stack<int>(Shuffle(lo_datakeys));
            while (lo_datakeystack.Count > 0)
            {
                lock (io_syncLock)
                {
                    lo_order.Add(Globals<T>.DATA[lo_datakeystack.Pop()]);
                }
            }

            return lo_order;
        }

        private static IList<int> Shuffle(IList<int> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Globals<T>.RAND.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        private static Chromosome<T> CreateChromosome(List<Gene<T>> ao_order)
        {
            return new Chromosome<T>(ao_order);
        }

    }
}
