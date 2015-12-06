using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Selection
{
    /// <summary>
    /// Selector Abstract Super Class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Selector<T> where T : IData
    {
        protected Chromosome<T>[] io_pop;
        protected double id_totalfitness;
        protected double id_totalinversefitness;
        public Selector(Chromosome<T>[] ao_pop)
        {
            this.io_pop = ao_pop;
            this.id_totalfitness = FindTotalFitness();
            this.id_totalinversefitness = FindTotalInverseFitness();
        }

        //Findsw total fitness of population.
        protected double FindTotalFitness()
        {
            double ld_totalfitness = 0;
            for (int i = 0; i < this.io_pop.Length; i++)
            {
                ld_totalfitness += this.io_pop[i].fitness;

            }
            return ld_totalfitness;
        }

        //Finds total inverse fitness of population.
        protected double FindTotalInverseFitness()
        {
            double ld_totalinversefitness = 0;
            for (int i = 0; i < this.io_pop.Length; i++)
            {
                ld_totalinversefitness += (1/(this.io_pop[i].fitness));

            }
            return ld_totalinversefitness;
        }

        /// <summary>
        /// Select candidate from population.
        /// </summary>
        /// <returns></returns>
        public abstract Chromosome<T> MakeSelection();
    }
}
