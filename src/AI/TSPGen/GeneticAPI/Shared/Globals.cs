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
    public class Globals<T> where T :IData
    {
        public static List<GeneticAPI.Gene<T>> DATA { get; set; }
        public static int POOLSIZE { get; set; }
        public static int GENERATIONS { get; set; }
        public static double MODIFYPROB { get; set; }

        public static double MODIFYBONUS { get; set; }
        public static double RECOMPROB { get; set; }
        public static GARandom RAND { get; set; }
        public static int ELITENUM { get; set; }

        public static Chromosome<T>[] ELITES { get; set; }

        public static bool ADAPTMUT { get; set; }

        public static bool ROG { get; set; }

        public static bool SROG { get; set; }

        public static ConcurrentPriorityQueue<Chromosome<T>> CPQ;
    }
}
