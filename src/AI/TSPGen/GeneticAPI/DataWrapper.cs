using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    public class DataWrapper<T>
    {
        public T data { get; set; }

        public DataWrapper()
        {
        }

        public DataWrapper(T ao_data)
        {
            this.data = ao_data;
        }
    }
}
