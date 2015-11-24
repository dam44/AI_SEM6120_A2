using GeneticAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    public abstract class Recombination<T> where T : IData
    {
        public Recombination()
        {

        }

        public abstract Chromosome<T>[] GenerateChildren(Chromosome<T>[] ao_parents);
    }
}
