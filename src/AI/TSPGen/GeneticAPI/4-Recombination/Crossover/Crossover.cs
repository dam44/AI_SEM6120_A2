using GeneticAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Recombination
{
    /// <summary>
    /// Crossover Operator Abstract Superclass.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Crossover<T> : Recombination<T> where T : IData
    {
        /// <summary>
        /// Call ROG/SROG to get a Chromosome to use as one of the parents.
        /// </summary>
        /// <param name="ao_disappointingchild"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Generates new generation of children.
        /// </summary>
        /// <param name="ao_parents"></param>
        /// <returns></returns>
        public override Chromosome<T>[] GenerateChildren(Chromosome<T>[] ao_parents)
        {
            Array.Sort(ao_parents);
            int li_inc = 2;
            li_inc = 2;
            for (int i = 0; i < Globals<T>.POOLSIZE; i += li_inc)
            {
                //Compare parents, if they are the same then call ROG.
                if ((ao_parents[i].CompareTo(ao_parents[i + 1])) == 0)
                {
                    ao_parents[i + 1] = GetOrphanChild(ao_parents[i + 1]);
                }
                Copulate(ref ao_parents, i);
            }
            //If the poolsize is uneven then use ROG on the final parent who didn't get to have children.
            if ((Globals<T>.POOLSIZE % 2) != 0)
            {
                Chromosome<T>[] lo_parents = new Chromosome<T>[2];
                lo_parents[0] = ao_parents[ao_parents.Length - 1];
                lo_parents[1] = GetOrphanChild(ao_parents[1]);
                Copulate(ref lo_parents, 0);
                ao_parents[ao_parents.Length - 1] = lo_parents[0];
            }
            return ao_parents;
        }

        /// <summary>
        /// Generate two children from parents.
        /// </summary>
        /// <param name="ao_parents"></param>
        /// <param name="i"></param>
        private void Copulate(ref Chromosome<T>[] ao_parents, int i)
        {
            Chromosome<T>[] parents = { ao_parents[i], ao_parents[i + 1] };
            Chromosome<T>[] children = GenerateChildPair(parents);
            ao_parents[i] = children[0];
            ao_parents[i + 1] = children[1];
        }

        /// <summary>
        /// Check whether to use Crossover for two parents.
        /// </summary>
        /// <returns></returns>
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