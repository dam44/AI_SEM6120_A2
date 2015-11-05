using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAPI._5_Modification;
using GeneticAPI.Shared;

namespace GeneticAPI._5_Modification.Mutation.PMX
{
    public class MutationPMX<T> : Mutation<T> where T : IData
    {
        public override Chromosome<T>[] ModifyChildren(Chromosome<T>[] individuals)
        {
            //Don't change anything if not mutating.
            if (!isMutation()) return individuals;


            Chromosome<T> individual = individuals[0];
            int li_swappos1 = Globals<T>.RAND.Next(individual.GetOrder().Count);

            int li_swappos2 = li_swappos1;

            //Make sure we select two different elements.
            while (li_swappos2 == li_swappos1)
            {
                li_swappos2 = Globals<T>.RAND.Next(individual.GetOrder().Count);
            }

            Util.SwapListElements<Gene<T>>(individual.GetOrder(), li_swappos1, li_swappos2);

            //Recalculate fitness now that mutation has taken place.
            individual.GetOrder(true);
            individuals[0] = individual;

            return individuals;
        }
    }
}
