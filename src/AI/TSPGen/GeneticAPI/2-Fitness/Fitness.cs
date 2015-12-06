using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Fitness
{
    /// <summary>
    /// Evaluates the fitness of a solution.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Fitness<T> where T : IData
    {
        /// <summary>
        /// Evaluates a route between two cities using pythagoras.
        /// </summary>
        /// <param name="ao_ind1"></param>
        /// <param name="ao_ind2"></param>
        /// <returns></returns>
        public static double Evaluate(T ao_ind1, T ao_ind2)
        {
            int li_hord = ao_ind2.x() - ao_ind1.x();
            int li_verd = ao_ind2.y() - ao_ind1.y();

            return Math.Sqrt((li_hord * li_hord) + (li_verd * li_verd));
        }

        /// <summary>
        /// Evalues the total route.
        /// </summary>
        /// <param name="ao_order">List of genes.</param>
        /// <returns></returns>
        public static double EvaluateTotal(List<Gene<T>> ao_order)
        {
            double ld_totalfitness = 0;
            //Find the distance between all cities and add them together.
            for (int i = 0; i < ao_order.Count - 1; i++)
            {
                ld_totalfitness += Evaluate(ao_order[i].data, ao_order[i + 1].data);
            }
            //Add the fitness between the final city and the starting city.
            ld_totalfitness += Evaluate(ao_order[ao_order.Count - 1].data, ao_order[0].data);

            return ld_totalfitness;
        }
    }
}