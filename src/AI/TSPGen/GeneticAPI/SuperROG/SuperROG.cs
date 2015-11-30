
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.SuperROG
{
    public class SuperROG<T> where T : IData
    {
        private ConcurrentPriorityQueue<Chromosome<T>> io_cpq;
        public SuperROG(ref ConcurrentPriorityQueue<Chromosome<T>> ao_cpq)
        {
            this.io_cpq = ao_cpq;
        }
        public void Run()
        {
            while (true)
            {
                io_cpq.Enqueue(InitialChromosomeFactory<T>.GenerateChromosome());
            }
        }
    }
}
