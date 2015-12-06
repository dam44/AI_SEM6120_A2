using GeneticAPI;
using GeneticAPI.Shared;
using GeneticAPI.SuperROG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    /// <summary>
    /// Holds program Global static variables.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Globals<T> where T :IData
    {
        //Data read in from file.
        public static List<GeneticAPI.Gene<T>> DATA { get; set; }

        //Total population size.
        public static int POOLSIZE { get; set; }

        //Number of generations before stopping.
        public static int GENERATIONS { get; set; }

        //Probability of modification/mutation.
        public static double MODIFYPROB { get; set; }

        //Modification bonus created from Adaptive Mutation.
        public static double MODIFYBONUS { get; set; }

        //Probability to recombine/crossover.
        public static double RECOMPROB { get; set; }

        //Type of random to use (basic vs adv)
        public static GARandom RAND { get; set; }

        //Number of Elites.
        public static int ELITENUM { get; set; }

        //The current Elite Chromosomes.
        public static Chromosome<T>[] ELITES { get; set; }

        //Adaptive Mutation enabler.
        public static bool ADAPTMUT { get; set; }

        //Random Offspring enabler.
        public static bool ROG { get; set; }

        //SROG enabler.
        public static bool SROG { get; set; }

        //Concurrent Priority Queue instance used for SROG.
        public static ConcurrentPriorityQueue<Chromosome<T>> CPQ;
    }
}
