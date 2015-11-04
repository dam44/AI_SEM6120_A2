using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    public class Gene<T>
    {
        public T data { get; set; }

        public Gene()
        {
        }

        public Gene(T ao_data)
        {
            this.data = ao_data;
        }
    }
}
