using GeneticAPI.Selection;
using GeneticAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Selection.Rank
{
    public class Rank<T> : Selector<T> where T : IData
    {
        public Rank(Chromosome<T>[] ao_pop) : base(ao_pop)
        {
        }

        public double FindIndividualPercentage(Chromosome<T> ao_individual)
        {
            return (100 / id_totalinversefitness) * (1 / (ao_individual.fitness));
        }

        public List<double> GeneratePercentageList()
        {
            Array.Sort(io_pop);
            double ld_n = 10;
            List<double> ld_percentages = new List<double>();
            for (int i = 0; i < io_pop.Length; i++)
            {
                ld_percentages.Add(ld_n);
                ld_n = ld_n / 2;
            }

            return ld_percentages;
        }

        public override Chromosome<T> MakeSelection()
        {
            List<double> ld_percentages = GeneratePercentageList();
            double ld_totalpercent = 0;
            for (int i = 0; i < ld_percentages.Count; i++)
            {
                ld_totalpercent += ld_percentages[i];
            }

            double ld_arrow = Globals<T>.RAND.Next(0, (int)ld_totalpercent);
            bool lb_stop = false;
            int li_count = 0;
            double ld_percsofar = 0;

            while (!lb_stop)
            {
                ld_percsofar += ld_percentages[li_count];
                if (ld_arrow < ld_percsofar)
                {
                    lb_stop = true;
                }
                else
                {
                    li_count++;
                }

            }
            return io_pop[li_count];
        }
    }
}
