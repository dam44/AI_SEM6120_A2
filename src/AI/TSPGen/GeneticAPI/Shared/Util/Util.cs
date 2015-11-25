using GeneticAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Shared.Util
{
    public static class Util
    {

        public static double CalcPopulationAverageFitness<T>(Chromosome<T>[] ao_pop) where T : IData
        {
            double ld_avg = 0;

            for (int i = 0; i < ao_pop.Length; i++)
            {
                ld_avg += ao_pop[i].fitness;
            }
            ld_avg = ld_avg / ao_pop.Length;
            return ld_avg;
        }
        public static double StandardDeviationPopulation<T>(Chromosome<T>[] ao_pop, double ad_avg = -1) where T : IData
        {
            if (ad_avg == -1)
            {
                ad_avg = CalcPopulationAverageFitness(ao_pop);
            }
            double ld_total = 0;
            for (int i =0; i < ao_pop.Length; i++)
            {
                ld_total += Math.Pow(ao_pop[i].fitness - ad_avg, 2);
            }
            double ld_variance = (ld_total / ao_pop.Length);
            double ld_sd = Math.Sqrt(ld_variance);
            return ld_sd;

        }
        public static void SwapArrayElements<U>(U[] ao_array, int e1, int e2)
        {
            U temp = ao_array[e1];
            ao_array[e1] = ao_array[e2];
            ao_array[e2] = temp;

        }

        public static void SwapListElements<U>(List<U> ao_list, int e1, int e2)
        {
            U temp = ao_list[e1];
            ao_list[e1] = ao_list[e2];
            ao_list[e2] = temp;

        }

    }
}
