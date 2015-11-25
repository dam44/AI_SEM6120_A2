using GeneticAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Recombination
{
    public abstract class Crossover<T> : Recombination<T> where T : IData
    {

        private Chromosome<T> GetOrphanChild(Chromosome<T> ao_disappointingchild)
        {
            //Filing paper work...
            Chromosome<T> lo_orphanchild = null;
            if (Globals<T>.SROG)
            {
                lo_orphanchild = Globals<T>.CPQ.Dequeue();
            } else if (Globals<T>.ROG)
            {
                lo_orphanchild = InitialChromosomeFactory<T>.GenerateChromosome();
            } else
            {
                //Decided against trading away that disgrace of a child.
                lo_orphanchild = ao_disappointingchild;
            }
            //Take it home.
            return lo_orphanchild;

        }
        public override Chromosome<T>[] GenerateChildren(Chromosome<T>[] ao_parents)
        {
            Array.Sort(ao_parents);
            int li_inc = 2;
            li_inc = 2;
            for (int i = 0; i < Globals<T>.POOLSIZE; i += li_inc)
            {
                if ((ao_parents[i].CompareTo(ao_parents[i + 1])) == 0)
                {
                    ao_parents[i + 1] = GetOrphanChild(ao_parents[i + 1]);
                }
                Copulate(ref ao_parents, i);
            }

            if ((Globals<T>.POOLSIZE % 2) != 0)
            {
                Chromosome<T>[] lo_parents = new Chromosome<T>[2];
                lo_parents[0] = ao_parents[ao_parents.Length - 1];
                //lo_parents[1] = InitialChromosomeFactory<T>.GenerateChromosome();
                lo_parents[1] = GetOrphanChild(ao_parents[1]);
                Copulate(ref lo_parents, 0);
                ao_parents[ao_parents.Length - 1] = lo_parents[0];
            }
            return ao_parents;
        }

        private void Copulate(ref Chromosome<T>[] ao_parents, int i)
        {
            Chromosome<T>[] parents = { ao_parents[i], ao_parents[i + 1] };
            Chromosome<T>[] children = GenerateChildPair(parents);
            ao_parents[i] = children[0];
            ao_parents[i + 1] = children[1];
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


//if (i >= Globals<T>.POOLSIZE)
//{
//    break;
//}
//else if (i + 1 >= Globals<T>.POOLSIZE)
//{
//    break;
//}

//li_child1 = i;
//int j = li_child1;
//do
//{
//    if (j < Globals<T>.POOLSIZE - 1)
//    {
//        j++;
//        li_child2 = j;
//    } else
//    {
//        break;
//    }
//} while
//(
//li_child1 < ao_parents.Length &&
//li_child2 < ao_parents.Length &&
//(ao_parents[li_child2].fitness == ao_parents[li_child1].fitness)
//);

//li_child2 = i + 1;