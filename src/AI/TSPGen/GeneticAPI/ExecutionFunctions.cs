using GeneticAPI._4_Recombination;
using GeneticAPI._5_Modification;
using GeneticAPI._5_Modification.Mutation.PMX;
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
        public static void Initialize(ref double ad_fitness, List<Chromosome<T>> ao_population, NotableChromosomes<T> ao_notablechroms = null)
        {
            for (int i = 0; i < Globals<T>.POOLSIZE; i++)
            {
                Chromosome<T> temp = InitialChromosomeFactory<T>.GenerateChromosome();
                ao_population.Add(temp);
                if (ao_notablechroms != null)
                {
                    ao_notablechroms.UpdateInitialBest(temp);
                }
            }
            EvaluateFitness(ref ad_fitness, ao_population);
        }

        public static void Select(List<Chromosome<T>> ao_population, Selectors aen_selector, int ai_ts_contestants = 2)
        {
            Selector<T> lo_selector;

            if (aen_selector == Selectors.Roulette)
            {
               lo_selector = new Roulette<T>(ao_population);
            } else
            {
                lo_selector = new Tournament<T>(ao_population, ai_ts_contestants);
            }

            List<Chromosome<T>> lo_generation_population = new List<Chromosome<T>>();
            for (int i = 0; i < Globals<T>.POOLSIZE; i++)
            {
                Chromosome<T> temp = lo_selector.MakeSelection();
                lo_generation_population.Add(temp);
            }
            ao_population = lo_generation_population;
        }

        public static void Recombination(List<Chromosome<T>> ao_population)
        {
            Recombination<T> lo_recom = new CrossoverPMX<T>();
            for (int i = 0; i < Globals<T>.POOLSIZE; i += 2)
            {
                Chromosome<T>[] parents = { ao_population[i], ao_population[i + 1] };
                Chromosome<T>[] children = lo_recom.GenerateChildren(parents);
                ao_population[i] = children[0];
                ao_population[i + 1] = children[1];
            }
        }

        public static void Modification(List<Chromosome<T>> ao_population)
        {
            Modification<T> lo_modif = new MutationPMX<T>();
            for (int i = 0; i < Globals<T>.POOLSIZE; i++)
            {
                Chromosome<T>[] parents = { ao_population[i] };
                Chromosome<T> child = lo_modif.ModifyChildren(parents)[0];
                ao_population[i] = child;
            }
        }

        public static void EvaluateFitness(ref double ad_fitness, List<Chromosome<T>> ao_population, NotableChromosomes<T> ao_notablechroms = null)
        {
            double ld_tfitness = 0;
            for (int i = 0; i < Globals<T>.POOLSIZE; i++)
            {
                ld_tfitness += ao_population[i].fitness;
                if (ao_notablechroms != null)
                {
                    ao_notablechroms.UpdateFinalBest(ao_population[i]);
                }
            }

            ad_fitness = (ld_tfitness / ao_population.Count);
        }
    }
}
