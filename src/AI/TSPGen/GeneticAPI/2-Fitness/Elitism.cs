using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Fitness
{
    public class Elitism<T> where T : IData
    {
        public static void MarkElite(Chromosome<T>[] ao_pop, Chromosome<T>[] ao_newpop)
        {
            Chromosome<T>[] lo_elites = new Chromosome<T>[Globals<T>.ELITENUM];
            bool lb_full = false;
            int li_count = 0;
            //Find best chromosomes.
            for (int i = 0; i < ao_pop.Length; i++)
            {
                int li_worstpos = -1;
                double ld_worstfitness = ao_pop[i].fitness;
                for (int j = 0; j < Globals<T>.ELITENUM; j++)
                {
                    if (!lb_full)
                    {
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
                        if ((ld_worstfitness < lo_elites[j].fitness))
                        {
                            ld_worstfitness = lo_elites[j].fitness;
                            li_worstpos = j;
                        }
                    }
                }
                if (li_worstpos != -1)
                {
                    lo_elites[li_worstpos] = ao_pop[i];
                }
            }
            //Mark the best chromosomes as elite.
            for (int i = 0; i < Globals<T>.ELITENUM; i++)
            {
                if (lo_elites[i] != null)
                {
                    ao_newpop[i] = (lo_elites[i]);
                }
            }
        }
    }
}