using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    public class DataEncoder<T> where T : IData
    {
        public static List<Gene<T>> EncodeListFromData(List<T> ao_data)
        {
            List<Gene<T>> lo_individuals = new List<Gene<T>>();
            for (int i = 0; i< ao_data.Count; i++)
            {
                lo_individuals.Add(new Gene<T>(ao_data[i]));
            }
            return lo_individuals;
        }
    }
}
