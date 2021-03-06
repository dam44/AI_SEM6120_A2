﻿using GeneticAPI._5_Modification;
using GeneticAPI.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI._5_Modification
{
    /// <summary>
    /// Mutation Abstract Super Class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Mutation<T> : Modification<T> where T : IData
    {
        private Chromosome<T>[] io_population;
        private int ii_iterationcount = 0;
        private int ii_iterationsreq;

        public Mutation() {
            ii_iterationsreq = 50;
        }

        /// <summary>
        /// Mutates the population.
        /// </summary>
        /// <param name="population"></param>
        /// <returns></returns>
        public override Chromosome<T>[] MutatePopulation(Chromosome<T>[] population)
        {
            io_population = population;
            for (int i = 0; i < Globals<T>.POOLSIZE; i++)
            {
                Chromosome<T>[] parents = { population[i] };
                Chromosome<T> child = ModifyChildren(parents)[0];
                population[i] = child;
            }
            return population;
        }

        /// <summary>
        /// Adaptive Mutation, calculate the bonus added to Mutation probability.
        /// Based on how much variance is in the population, calculted using the standard deviation.
        /// </summary>
        private void CalcMutationBonus()
        {
            Globals<T>.MODIFYBONUS = 0;
            double ld_avg = Util.CalcPopulationAverageFitness(io_population);
            double ld_sd = Util.StandardDeviationPopulation(io_population, ld_avg);
            double ld_change = ld_sd - (ld_avg / 20);
            if (ld_change < 0)
            {
                double ld_bonus = ld_change / 100;
                if (-ld_bonus > 0.3)
                {
                    Globals<T>.MODIFYBONUS = 0.3;
                } else
                {
                    Globals<T>.MODIFYBONUS = -ld_bonus;
                }
            }
        }
        //Check for a Chromosome whether it should be Muatated.
        public bool isMutation()
        {
            ii_iterationcount++;
            if (Globals<T>.ADAPTMUT && (ii_iterationcount > ii_iterationsreq))
            {
                CalcMutationBonus();
            }
            double ld_probwheel;
            do
            {
                ld_probwheel = ((double)Globals<T>.RAND.Next(10000000)) / 10000000;
            } while (ld_probwheel == 0);

            if ((Globals<T>.MODIFYPROB + Globals<T>.MODIFYBONUS) > ld_probwheel)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
