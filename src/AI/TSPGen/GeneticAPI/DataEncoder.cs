using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    public class DataEncoder<T> where T : IData
    {
        public static List<DataWrapper<T>> EncodeListFromData(List<T> ao_data)
        {
            List<DataWrapper<T>> lo_individuals = new List<DataWrapper<T>>();
            for (int i = 0; i< ao_data.Count; i++)
            {
                lo_individuals.Add(new DataWrapper<T>(ao_data[i]));
            }
            return lo_individuals;
        }
    }
}
