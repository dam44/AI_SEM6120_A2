using GeneticAPI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Selection.Tournament
{
    public class Tournament<T> : Selector<T> where T : IData
    {
        int ii_contestantsperevent;
        public Tournament(List<Chromosome<T>> ao_individuals, int ai_contsperevent = 2) : base(ao_individuals)
        {
            this.ii_contestantsperevent = ai_contsperevent;
        }
        public override Chromosome<T> MakeSelection()
        {
            List<Chromosome<T>> lo_contestants = new List<Chromosome<T>>();
            for (int i = 0; i < ii_contestantsperevent; i++)
            {
                int li_contestantnumber = Globals<T>.RAND.Next(io_individuals.Count - 1);
                lo_contestants.Add(io_individuals[li_contestantnumber]);
            }

            Chromosome<T> lo_winner = lo_contestants[0];
            for (int i = 1; i < lo_contestants.Count; i++)
            {
                if (lo_contestants[i].fitness < lo_winner.fitness)
                {
                    lo_winner = lo_contestants[i];
                }
            }
            return lo_winner;
        }
    }
}
