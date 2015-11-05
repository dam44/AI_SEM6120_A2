
using GeneticAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    public class Chromosome<T> where T : IData
    {
        private List<Gene<T>> order { get; set; }
        public double fitness { get; }

        public List<Gene<T>> GetOrder(bool changed = false)
        {
            if (changed)
            {
                Fitness<T>.EvaluateTotal(order);
            }
            return order;
        }

        public void SetOrder(List<Gene<T>> list)
        {
            Fitness<T>.EvaluateTotal(order);
            order = list;
        }

        public Chromosome (List<Gene<T>> ao_order)
        {
            this.order = ao_order;
            this.fitness = Fitness<T>.EvaluateTotal(order);
        }

    }
}
