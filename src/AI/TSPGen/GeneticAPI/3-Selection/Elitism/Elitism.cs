using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Selection
{
    public class Elitism<T> : Selection.Selector<T> where T : IData
    {
        public Elitism(Chromosome<T>[] ao_pop) : base(ao_pop)
        {

        }

        //public Chromosome<T>[] ChooseParents()
        //{
        //    List<Chromosome<T>> lo_parents = new List<Chromosome<T>>();
        //    for (int i = 0; i < Globals<T>.POOLSIZE; i++)
        //    {
        //        lo_parents.Add(io_pop[i]);
        //        for ()
        //    }
        //}

        public override Chromosome<T> MakeSelection()
        {
            return null;
        }
    }
}
