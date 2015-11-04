using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    public class Fitness<T> where T : IData
    {
        public static double Evaluate(T ao_ind1, T ao_ind2)
        {
            int li_hord = ao_ind1.x() - ao_ind2.x();
            int li_verd = ao_ind1.y() - ao_ind2.y();

            return Math.Sqrt((li_hord * li_hord) + (li_verd * li_verd));
        }

        public static double EvaluateTotal(List<Gene<T>> ao_order)
        {
            double ld_totalfitness = 0;
            for(int i = 0; i< ao_order.Count - 1; i++)
            {
                ld_totalfitness += Evaluate(ao_order[i].data, ao_order[i + 1].data);
            }

            return ld_totalfitness;
        }
    }
}
