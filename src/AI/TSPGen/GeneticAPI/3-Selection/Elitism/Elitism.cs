using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Selection
{
    public class Elitism<T> where T : IData
    {
        private Chromosome<T>[] io_elites;

        public Elitism()
        {
            io_elites = new Chromosome<T>[Globals<T>.ELITENUM];
        }

        public void AddElite(int ai_num, Chromosome<T> ao_chrom)
        {
            io_elites[ai_num] = new Chromosome<T>(ao_chrom);
        }

        public Chromosome<T> GetElite(int ai_num)
        {
            return io_elites[ai_num];
        }
    }
}
