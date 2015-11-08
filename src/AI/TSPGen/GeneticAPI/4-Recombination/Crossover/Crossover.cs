using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI._4_Recombination
{
    public abstract class Crossover<T> : Recombination<T> where T : IData
    {
        public bool isCrossover()
        {

            double ld_probwheel = ((double)Globals<T>.RAND.Next(100)) / 100;

            if (Globals<T>.RECOMPROB > ld_probwheel)
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
