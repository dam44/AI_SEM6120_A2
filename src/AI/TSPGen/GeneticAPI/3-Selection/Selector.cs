using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Selection
{
    public abstract class Selector<T> where T : IData
    {
        protected List<Chromosome<T>> io_individuals;
        protected double id_totalfitness;
        public Selector(List<Chromosome<T>> ao_individuals)
        {
            this.io_individuals = ao_individuals;
            this.id_totalfitness = FindTotalFitness();
        }

        protected double FindTotalFitness()
        {
            double ld_totalfitness = 0;
            for (int i = 0; i < this.io_individuals.Count; i++)
            {
                ld_totalfitness += this.io_individuals[i].fitness;
            }
            return ld_totalfitness;
        }

        public abstract Chromosome<T> MakeSelection();
    }
}
