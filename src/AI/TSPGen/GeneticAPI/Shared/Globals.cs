using GeneticAPI;
using GeneticAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    public class Globals<T>
    {
        public static List<GeneticAPI.Gene<T>> DATA { get; set; }
        public static int POOLSIZE { get; set; }
        public static int GENERATIONS { get; set; }
        public static double MODIFYPROB { get; set; }
        public static double RECOMPROB { get; set; }
        public static GARandom RAND { get; set; }
    }
}
