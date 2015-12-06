
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.SuperROG
{
    /// <summary>
    /// Continually add new Chromosomes to the Concurrent Priority Queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LessROG<T> where T : IData
    {
        private ConcurrentPriorityQueue<Chromosome<T>> io_cpq;
        public LessROG(ref ConcurrentPriorityQueue<Chromosome<T>> ao_cpq)
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
