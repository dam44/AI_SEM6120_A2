using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Shared
{
    public interface GARandom
    {
        int Next(int min, int max);
        int Next(int max);
    }
}
