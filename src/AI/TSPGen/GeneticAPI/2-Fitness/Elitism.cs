using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Fitness
{
    /// <summary>
    /// Determines which Chromosomes are Elite.
    /// These Chromosomes are added to a seperate list so that they can still participate in Crossover and Mutation
    /// and then be added back in afterwards.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Elitism<T> where T : IData
    {
        /// <summary>
        /// Marks best Chromosomes as Elite.
        /// </summary>
        /// <param name="ao_pop"></param>
        public static void MarkElite(Chromosome<T>[] ao_pop)
        {
            Chromosome<T>[] lo_elites = new Chromosome<T>[Globals<T>.ELITENUM];
            bool lb_full = false;
            int li_count = 0;
            //Find best chromosomes.
            for (int i = 0; i < ao_pop.Length; i++)
            {
                int li_worstpos = -1;
                double ld_worstfitness = ao_pop[i].fitness;
                //Loop through the number of Elites required..
                for (int j = 0; j < Globals<T>.ELITENUM; j++)
                {
                    if (!lb_full)
                    {
                        //If Elite list is not full then we add the candidate to it.
                        if ((lo_elites[j] == null))
                        {
                            li_count++;
                            if (li_count >= Globals<T>.ELITENUM)
                            {
                                lb_full = true;
                            }
                            lo_elites[j] = ao_pop[i];
                            break;
                        }
                    }
                    else
                    {
                        //If the Elite list is full then we compare the candidate against the elites and find the worst Elite that it is better than.
                        if ((ld_worstfitness < lo_elites[j].fitness))
                        {
                            ld_worstfitness = lo_elites[j].fitness;
                            li_worstpos = j;
                        }
                    }
                }
                //Switch it with the worst Elite it is better than. If it's worse than all then discard.
                if (li_worstpos != -1)
                {
                    lo_elites[li_worstpos] = ao_pop[i];
                }
            }
            //Mark the best chromosomes as elite.
            Globals<T>.ELITES = lo_elites;
        }
    }
}