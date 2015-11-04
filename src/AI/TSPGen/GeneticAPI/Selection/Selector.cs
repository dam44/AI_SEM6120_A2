using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Selection
{
    public abstract class Selector<T> where T : IData
    {
        protected List<Individual<T>> io_individuals;
        public Selector(List<Individual<T>> ao_individuals)
        {
            this.io_individuals = ao_individuals;
        }

        public abstract Individual<T> MakeSelection();
    }
}
