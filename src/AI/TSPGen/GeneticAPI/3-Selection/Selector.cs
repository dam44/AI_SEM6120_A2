using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Selection
{
    public abstract class Selector<T> where T : IData
    {
        protected Chromosome<T>[] io_pop;
        protected double id_totalfitness;
        public Selector(Chromosome<T>[] ao_pop)
        {
            this.io_pop = ao_pop;
            this.id_totalfitness = FindTotalFitness();
        }

        protected double FindTotalFitness()
        {
            double ld_totalfitness = 0;
            for (int i = 0; i < this.io_pop.Length; i++)
            {
                ld_totalfitness += this.io_pop[i].fitness;
            }
            return ld_totalfitness;
        }

        public abstract Chromosome<T> MakeSelection();
    }
}
