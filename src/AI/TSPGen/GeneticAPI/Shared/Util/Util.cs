using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Shared.Util
{
    public static class Util
    {
        public static void SwapArrayElements<U>(U[] ao_array, int e1, int e2)
        {
            U temp = ao_array[e1];
            ao_array[e1] = ao_array[e2];
            ao_array[e2] = temp;

        }

        public static void SwapListElements<U>(List<U> ao_list, int e1, int e2)
        {
            U temp = ao_list[e1];
            ao_list[e1] = ao_list[e2];
            ao_list[e2] = temp;

        }

    }
}
