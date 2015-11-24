using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI._4_Recombination
{
    public abstract class Crossover<T> : Recombination<T> where T : IData
    {

        public override Chromosome<T>[] GenerateChildren(Chromosome<T>[] ao_parents)
        {
            Array.Sort(ao_parents);
            int li_inc = 2;
            int li_child1 = 0;
            int li_child2 = 0;
            for (int i = 0; i < Globals<T>.POOLSIZE; i += li_inc)
            {
                if (i >= Globals<T>.POOLSIZE)
                {
                    break;
                }
                else if (i + 1 >= Globals<T>.POOLSIZE)
                {
                    break;
                }

                li_child1 = i;
                int j = li_child1;
                do
                {
                    if (j < Globals<T>.POOLSIZE - 1)
                    {
                        j++;
                        li_child2 = j;
                    } else
                    {
                        break;
                    }
                } while
                (
                li_child1 < ao_parents.Length &&
                li_child2 < ao_parents.Length &&
                (ao_parents[li_child2].fitness == ao_parents[li_child1].fitness)
                );

                //li_child2 = i + 1;
                li_inc = 2;
                Chromosome<T>[] parents = { ao_parents[li_child1], ao_parents[li_child2] };
                Chromosome<T>[] children = GenerateChildPair(parents);
                ao_parents[i] = children[0];
                ao_parents[i + 1] = children[1];
            }
            return ao_parents;
        }
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

        public abstract Chromosome<T>[] GenerateChildPair(Chromosome<T>[] ao_parentpair);

    }

}
