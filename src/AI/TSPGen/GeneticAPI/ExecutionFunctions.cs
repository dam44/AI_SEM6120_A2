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
using GeneticAPI.Selection.Rank;

namespace GeneticAPI
{
    /// <summary>
    /// Contains static functions that do work on the population.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class ExecutionFunctions<T> where T : IData
    {
        /// <summary>
        /// Initialize the population by calling the initialize chromosome factory until the population is full.
        /// </summary>
        /// <param name="ad_fitness"></param>
        /// <param name="ad_bestfitness"></param>
        /// <param name="ao_pop"></param>
        /// <param name="ao_notablechroms"></param>
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
            //Evaluate the fitness of the population.
            EvaluateFitness(ref ad_fitness, ref ad_bestfitness, ao_pop);
        }

        /// <summary>
        /// Pass the population to the Selection operator of choice to select a new generation.
        /// </summary>
        /// <param name="ao_pop"></param>
        /// <param name="ao_newpop"></param>
        /// <param name="aen_selector"></param>
        /// <param name="ai_ts_contestants"></param>
        public static void Select(Chromosome<T>[] ao_pop, Chromosome<T>[] ao_newpop, Selectors aen_selector, int ai_ts_contestants = 2)
        {
            Selector<T> lo_selector;

            if (aen_selector == Selectors.Roulette)
            {
               lo_selector = new Roulette<T>(ao_pop);
            } else if (aen_selector == Selectors.Rank)
            {
                lo_selector = new Rank<T>(ao_pop);
            } else
            {
                lo_selector = new Tournament<T>(ao_pop, ai_ts_contestants);
            }

            for (int i = 0; i < Globals<T>.POOLSIZE; i++)
            {
                Chromosome<T> temp = lo_selector.MakeSelection();
                ao_newpop[i] = temp;
            }
        }

        /// <summary>
        /// Pass the population to the Recombination operator of choice to create children for a new generation.
        /// </summary>
        /// <param name="ao_pop"></param>
        /// <param name="aen_recomtype"></param>
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

        /// <summary>
        /// Mutate population.
        /// </summary>
        /// <param name="ao_pop"></param>
        public static void Modification(Chromosome<T>[] ao_pop)
        {
            Modification<T> lo_modif = new MutationImpl<T>();
            lo_modif.MutatePopulation(ao_pop);
        }

        /// <summary>
        /// Evalutate the fitness of the population.
        /// </summary>
        /// <param name="ad_fitness"></param>
        /// <param name="ad_bestfitness"></param>
        /// <param name="ao_pop"></param>
        /// <param name="ao_notablechroms"></param>
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
            }

            ad_fitness = (ld_tfitness / ao_pop.Length);
            GeneticAPI.Fitness.Elitism<T>.MarkElite(ao_pop);
        }
        /// <summary>
        /// Adds Elites back into population if they have been lost.
        /// If the Elite is still in the population then we do not add it, this promotes variety.
        /// </summary>
        /// <param name="ao_pop"></param>
        public static void EvaluateElite(Chromosome<T>[] ao_pop) {
            if (Globals<T>.ELITES == null) return;

            List<int> li_alreadypresent = new List<int>();
            //Determine if the Elite is already present in the population.
            for (int i = 0; i < ao_pop.Length; i++)
            {
                for (int j = 0; j < Globals<T>.ELITES.Length; j++)
                {
                    if (ao_pop[i].fitness == Globals<T>.ELITES[j].fitness)
                    {
                        li_alreadypresent.Add(j);
                    }
                }
            }
            //Determines which members of the population to swap out in favour of the Elite. (The worst ones).
            for (int i = 0; i < Globals<T>.ELITES.Length; i++)
            {
                if (li_alreadypresent.Contains(i)) continue;
                int index = 0;
                for (int j = 0; j < ao_pop.Length; j++)
                {
                    for (int k = 0; k < ao_pop.Length; k++)
                    {
                        if (ao_pop[j].fitness < ao_pop[k].fitness)
                        {
                            index = j;
                        }
                    }
                }
                ao_pop[index] = Globals<T>.ELITES[i];
            }

        }
    }
}
