using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Shared
{

    public class NotableChromosomes<T> where T : IData
    {
        public Dictionary<string, Chromosome<T>> io_noteablechromosomes { get; set; }

        public NotableChromosomes()
        {
            io_noteablechromosomes = new Dictionary<string, Chromosome<T>>();
            io_noteablechromosomes.Add("FINALBEST", null);
            io_noteablechromosomes.Add("INITIALBEST", null);
        }

        public void UpdateFinalBest(Chromosome<T> ao_chrom)
        {
            UpdateBest("FINALBEST", new Chromosome<T>(ao_chrom));
        }

        public void UpdateInitialBest(Chromosome<T> ao_chrom)
        {
            UpdateBest("INITIALBEST", new Chromosome<T>(ao_chrom));
        }

        public Chromosome<T> GetFinalBest()
        {
            return io_noteablechromosomes["FINALBEST"];
        }

        public Chromosome<T> GetInitialBest()
        {
            return io_noteablechromosomes["INITIALBEST"];
        }


        private void UpdateBest(string key, Chromosome<T> ao_chrom)
        {
                if ((io_noteablechromosomes[key] == null) || (io_noteablechromosomes[key].fitness > ao_chrom.fitness))
                {
                    io_noteablechromosomes[key] = new Chromosome<T>(ao_chrom);
                }

        }
    }
}
