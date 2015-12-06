using GeneticAPI.Selection;
using GeneticAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Selection.Rank
{
    /// <summary>
    /// Rank Selector Operator.
    /// Assigns candidate probabilities based on fitness and then picks members using a probability wheel.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Rank<T> : Selector<T> where T : IData
    {
        public Rank(Chromosome<T>[] ao_pop) : base(ao_pop)
        {
        }

        /// <summary>
        /// Finds an individuals pick probability. 
        /// As TSP is searching for a minimum solution the fitnesses are inversed before probability assigned.
        /// </summary>
        /// <param name="ao_individual"></param>
        /// <returns></returns>
        public double FindIndividualPercentage(Chromosome<T> ao_individual)
        {
            return (100 / id_totalinversefitness) * (1 / (ao_individual.fitness));
        }

        /// <summary>
        /// Generates a list of fixed probabilities.
        /// </summary>
        /// <returns></returns>
        public List<double> GeneratePercentageList()
        {
            //Sorts the population based on their fitness.
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

        /// <summary>
        /// Selects a candidate using Rank selection.
        /// </summary>
        /// <returns></returns>
        public override Chromosome<T> MakeSelection()
        {
            List<double> ld_percentages = GeneratePercentageList();
            double ld_totalpercent = 0;
            //Find the total percent in the generated percent list. It should add to 100 but rounding errors can mean it's slightly off.
            for (int i = 0; i < ld_percentages.Count; i++)
            {
                ld_totalpercent += ld_percentages[i];
            }

            //Point an arrow somewhere between 0 and the total percentage.
            double ld_arrow = Globals<T>.RAND.Next(0, (int)ld_totalpercent);
            bool lb_stop = false;
            int li_count = 0;
            double ld_percsofar = 0;

            //Find where the error stops and the candidate it has landed on.
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
