using GeneticAPI.Recombination;
using GeneticAPI._5_Modification;
using GeneticAPI._5_Modification.Mutation.PMX;
using GeneticAPI.Fitness;
using GeneticAPI.Recombination;
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
        public static void Initialize(ref double ad_fitness, ref double ad_bestfitness, Chromosome<T>[] ao_pop, NotableChromosomes<T> ao_notablechroms = null)
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
            EvaluateFitness(ref ad_fitness, ref ad_bestfitness, ao_pop);
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

        public static void Recombination(Chromosome<T>[] ao_pop, Recombinators aen_recomtype)
        {
            Recombination<T> lo_recom;
            if (aen_recomtype == Recombinators.OnePointCrossoverPMX)
            {
                lo_recom = new OnePointCrossoverPMX<T>();
            } else
            {
                lo_recom = new TwoPointCrossoverPMX<T>();
            }
            ao_pop = lo_recom.GenerateChildren(ao_pop);
        }

        public static void Modification(Chromosome<T>[] ao_pop)
        {
            Modification<T> lo_modif = new MutationPMX<T>();
            lo_modif.MutatePopulation(ao_pop);
        }

        public static void EvaluateFitness(ref double ad_fitness, ref double ad_bestfitness, Chromosome<T>[] ao_pop, NotableChromosomes<T> ao_notablechroms = null)
        {
            ad_bestfitness = 0;
            double ld_tfitness = 0;
            Globals<T>.MODIFYBONUS = 0;
            for (int i = 0; i < Globals<T>.POOLSIZE; i++)
            {
                ld_tfitness += ao_pop[i].fitness;
                if (ao_pop[i].fitness < ad_bestfitness || ad_bestfitness == 0)
                {
                    ad_bestfitness = ao_pop[i].fitness;
                }
                if (ao_notablechroms != null)
                {
                    ao_notablechroms.UpdateFinalBest(ao_pop[i]);
                }
                //if ((Globals<T>.MODIFYPROB + Globals<T>.MODIFYBONUS) < 1)
                //{
                //    for (int j = 0; j < Globals<T>.POOLSIZE; j++)
                //    {
                //        if (i == j) continue;

                //        if ((int)ao_pop[i].fitness == (int)ao_pop[j].fitness)
                //        {
                //            Globals<T>.MODIFYBONUS += 0.1/Globals<T>.POOLSIZE;
                //        }
                //    }
                //}
            }

            ad_fitness = (ld_tfitness / ao_pop.Length);
        }

        public static void EvaluateElite(Chromosome<T>[] ao_pop, Chromosome<T>[] ao_newpop) {
            GeneticAPI.Fitness.Elitism<T>.MarkElite(ao_pop, ao_newpop);
        }
    }
}
