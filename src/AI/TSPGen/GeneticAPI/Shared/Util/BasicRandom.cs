using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Shared
{
    public class BasicRandom : GARandom
    {

        private Random rand;

        public BasicRandom()
        {
            rand = new Random();
        }

        public int Next(int max)
        {
           return rand.Next(max);
        }

        public int Next(int min, int max)
        {
            return rand.Next(min, max);
        }
    }
}
