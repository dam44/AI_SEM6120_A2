using GeneticAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Selection.Roulette
{
    public class Roulette<T> : Selector<T> where T : IData
    {
        NotableChromosomes<T> io_notablechroms;
        public Roulette(List<Chromosome<T>> ao_individuals, NotableChromosomes<T> ao_notablechroms = null) : base(ao_individuals)
        {
            io_notablechroms = ao_notablechroms;
        }

        public double FindIndividualPercentage(Chromosome<T> ao_individual)
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

        public override Chromosome<T> MakeSelection()
        {
            List<double> ld_percentages = GeneratePercentageList();
            int li_arrow = Globals<T>.RAND.Next(0, 100);
            bool lb_stop = false;
            int li_count = 0;
            double ld_percsofar = 0;
            while(!lb_stop)
            {
                ld_percsofar += ld_percentages[li_count];
                    if (li_arrow < ld_percsofar)
                    {
                        lb_stop = true;
                    } else
                    {
                        li_count++;
                    }

            }
            return io_individuals[li_count];
        }
    }
}
