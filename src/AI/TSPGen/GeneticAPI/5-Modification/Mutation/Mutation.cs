using GeneticAPI._5_Modification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI._5_Modification
{
    public abstract class Mutation<T> : Modification<T> where T : IData
    {
        public bool isMutation()
        {
            double ld_probwheel;
            do
            {
                ld_probwheel = ((double)Globals<T>.RAND.Next(10000000)) / 10000000;
            } while (ld_probwheel == 0);
           
            if (Globals<T>.MODIFYPROB > ld_probwheel)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
