
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    public class Chromosome<T> where T : IData
    {
        public List<Gene<T>> order { get; }
        public double fitness { get; }

        public Chromosome (List<Gene<T>> ao_order, double ai_fitness)
        {
            this.order = ao_order;
            this.fitness = ai_fitness;
        }

    }
}
