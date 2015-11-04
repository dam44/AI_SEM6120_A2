using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI._5_Modification
{
    public abstract class Modification<T> where T : IData
    {

        public abstract Chromosome<T>[] ModifyChildren(Chromosome<T>[] parents);
    }
}
