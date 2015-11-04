using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Selection.Roulette
{
    public class Roulette<T> : Selector<T> where T : IData
    {
        private double id_totalfitness;
        private Random rand;
        public Roulette(List<Individual<T>> ao_individuals) : base(ao_individuals)
        {
            this.id_totalfitness = FindTotalFitness();
            this.rand = new Random();
        }
        public double FindTotalFitness()
        {
            double ld_totalfitness = 0;
            for (int i = 0; i< this.io_individuals.Count; i++)
            {
                ld_totalfitness += this.io_individuals[i].fitness;
            }
            return ld_totalfitness;
        }

        public double FindIndividualPercentage(Individual<T> ao_individual)
        {
            return (100 / id_totalfitness) * ao_individual.fitness;
        }

        public List<double> GeneratePercentageList()
        {
            List<double> ld_percentages = new List<double>();
            for (int i = 0; i< io_individuals.Count; i++)
            {
                ld_percentages.Add(FindIndividualPercentage(io_individuals[i]));
            }

            return ld_percentages;
        }

        public override Individual<T> MakeSelection()
        {
            List<double> ld_percentages = GeneratePercentageList();
            int li_arrow = rand.Next(0, 100);
            bool stop = false;
            int count = 0;

            while(!stop)
            {
                if (count == 0)
                {
                    if (li_arrow < ld_percentages[count])
                    {
                        stop = true;
                    }
                } else
                {
                    if (li_arrow > ld_percentages[count-1] && li_arrow < ld_percentages[count])
                    {
                        stop = true;
                    }
                }

            }
            return io_individuals[count];
        }
    }
}
