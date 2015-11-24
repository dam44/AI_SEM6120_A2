
using GeneticAPI;
using GeneticAPI.Fitness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    public class Chromosome<T> : IComparable<Chromosome<T>> where T : IData
    {
        private string is_tostring;
        private List<Gene<T>> order { get; set; }
        public double fitness { get; set; }

        public List<Gene<T>> GetOrder(bool changed = false)
        {
            if (changed)
            {
                this.fitness = Fitness<T>.EvaluateTotal(order);
            }
            return order;
        }

        public void SetOrder(List<Gene<T>> list)
        {
            order = list;
            this.fitness = Fitness<T>.EvaluateTotal(order);
        }

        public int CompareTo(Chromosome<T> other)
        {
            return this.fitness.CompareTo(other.fitness);
        }

        public Chromosome (List<Gene<T>> ao_order)
        {
            this.order = ao_order;
            this.fitness = Fitness<T>.EvaluateTotal(order);
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(is_tostring))
            {
                for (int i = 0; i < order.Count; i++)
                {
                    is_tostring += order[i].data.ToString();
                }
            }
            return is_tostring;
        }


    }
}
