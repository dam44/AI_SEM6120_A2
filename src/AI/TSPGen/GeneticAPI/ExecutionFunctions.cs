using GeneticAPI._4_Recombination;
using GeneticAPI._5_Modification;
using GeneticAPI._5_Modification.Mutation.PMX;
using GeneticAPI.Fitness;
using GeneticAPI.Selection;
using GeneticAPI.Selection.Roulette;
using GeneticAPI.Selection.Tournament;
using GeneticAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    public static class ExecutionFunctions<T> where T : IData
    {
        public static void Initialize(ref double ad_fitness, Chromosome<T>[] ao_pop, NotableChromosomes<T> ao_notablechroms = null)
        {
            for (int i = 0; i < Globals<T>.POOLSIZE; i++)
            {
                Chromosome<T> temp = InitialChromosomeFactory<T>.GenerateChromosome();
                ao_pop[i] = temp;
                if (ao_notablechroms != null)
                {
                    ao_notablechroms.UpdateInitialBest(temp);
                }
            }
            EvaluateFitness(ref ad_fitness, ao_pop);
        }

        public static void Select(Chromosome<T>[] ao_pop, Chromosome<T>[] ao_newpop, Selectors aen_selector, int ai_ts_contestants = 2)
        {
            Selector<T> lo_selector;

            if (aen_selector == Selectors.Roulette)
            {
               lo_selector = new Roulette<T>(ao_pop);
            } else
            {
                lo_selector = new Tournament<T>(ao_pop, ai_ts_contestants);
            }

            for (int i = Globals<T>.ELITENUM; i < Globals<T>.POOLSIZE; i++)
            {
                Chromosome<T> temp = lo_selector.MakeSelection();
                ao_newpop[i] = temp;
            }
        }

        public static void Recombination(Chromosome<T>[] ao_pop)
        {
            Recombination<T> lo_recom = new CrossoverPMX<T>();
            int li_inc = 2;
            int li_child1 = 0;
            int li_child2 = 0;
            for (int i = Globals<T>.ELITENUM; i < Globals<T>.POOLSIZE; i += li_inc)
            {
                if (i >= Globals<T>.POOLSIZE)
                {
                    break;
                }
                else if (i+1 >= Globals<T>.POOLSIZE)
                {
                    break;
                }
                li_child1 = i;
                li_child2 = i + 1;
                li_inc = 2;
                Chromosome<T>[] parents = { ao_pop[li_child1], ao_pop[li_child2] };
                Chromosome<T>[] children = lo_recom.GenerateChildren(parents);
                ao_pop[i] = children[0];
                ao_pop[i + 1] = children[1];
            }
        }

        public static void Modification(Chromosome<T>[] ao_pop)
        {
            Modification<T> lo_modif = new MutationPMX<T>();
            for (int i = Globals<T>.ELITENUM; i < Globals<T>.POOLSIZE; i++)
            {
                    Chromosome<T>[] parents = { ao_pop[i] };
                    Chromosome<T> child = lo_modif.ModifyChildren(parents)[0];
                    ao_pop[i] = child;
            }
        }

        public static void EvaluateFitness(ref double ad_fitness, Chromosome<T>[] ao_pop, NotableChromosomes<T> ao_notablechroms = null)
        {
            double ld_tfitness = 0;
            for (int i = 0; i < Globals<T>.POOLSIZE; i++)
            {
                ld_tfitness += ao_pop[i].fitness;
                if (ao_notablechroms != null)
                {
                    ao_notablechroms.UpdateFinalBest(ao_pop[i]);
                }
            }

            ad_fitness = (ld_tfitness / ao_pop.Length);
        }

        public static void EvaluateElite(Chromosome<T>[] ao_pop, Chromosome<T>[] ao_newpop) {
            Elitism<T>.MarkElite(ao_pop, ao_newpop);
        }
    }
}
