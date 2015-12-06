
using GeneticAPI;
using GeneticAPI.Fitness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    /// <summary>
    /// Chromosome class representing a possible solution.
    /// </summary>
    /// <typeparam name="T">A gene class implementing IData.</typeparam>
    public class Chromosome<T> : IComparable<Chromosome<T>> where T : IData
    {
        private string is_tostring;
        private List<Gene<T>> order { get; set; }
        public double fitness { get; set; }

        /// <summary>
        /// Gets a list of the genes that this Chromosome consists of.
        /// </summary>
        /// <param name="changed">Whether to update the fitness of the Chromosome.</param>
        /// <returns>List of genes.</returns>
        public List<Gene<T>> GetOrder(bool changed = false)
        {
            if (changed)
            {
                this.fitness = Fitness<T>.EvaluateTotal(order);
            }
            return order;
        }

        /// <summary>
        /// Sets the list of genes.
        /// </summary>
        /// <param name="list">List of genes to be set.</param>
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

        public Chromosome (Chromosome<T> ao_chrom)
        {
            order = ao_chrom.order;
            fitness = Fitness<T>.EvaluateTotal(order);
        }

        /// <summary>
        /// Returns a string representing the list of genes.
        /// </summary>
        /// <returns></returns>
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
