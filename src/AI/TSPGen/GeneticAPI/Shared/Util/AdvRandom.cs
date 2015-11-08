using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Shared
{
    public class AdvRandom : GARandom
    {
        public int Next(int max)
        {
            return NextRand(0, max);
        }

        public int Next(int min, int max)
        {
            return NextRand(min, max);
        }


        private readonly RNGCryptoServiceProvider lo_rng = new RNGCryptoServiceProvider();

        /// <summary>
        /// http://scottlilly.com/create-better-random-numbers-in-c/
        /// Method adapted from tutorial code.
        /// </summary>

        private int NextRand(int ai_minimumValue, int ai_maximumValue)
        {
            int li_maxexcval = ai_maximumValue - 1;
            byte[] ib_rand = new byte[1];

            lo_rng.GetBytes(ib_rand);

            double ld_asciiValOfRandChar = Convert.ToDouble(ib_rand[0]);

            double ld_multiplier = Math.Max(0, (ld_asciiValOfRandChar / 255d) - 0.00000000001d);

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            int li_range = li_maxexcval - ai_minimumValue + 1;

            double ld_randValInRange = Math.Floor(ld_multiplier * li_range);

            return (int)(ai_minimumValue + ld_randValInRange);
        }
    }
}
