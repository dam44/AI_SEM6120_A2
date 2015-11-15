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
        public Tournament(Chromosome<T>[] ao_pop, int ai_contsperevent = 2) : base(ao_pop)
        {
            this.ii_contestantsperevent = ai_contsperevent;
        }
        public override Chromosome<T> MakeSelection()
        {
            Chromosome<T>[] lo_contestants = new Chromosome<T>[ii_contestantsperevent];
            for (int i = 0; i < ii_contestantsperevent; i++)
            {
                int li_contestantnumber = Globals<T>.RAND.Next(io_pop.Length - 1);
                lo_contestants[i] = io_pop[li_contestantnumber];
            }

            Chromosome<T> lo_winner = lo_contestants[0];
            for (int i = 1; i < lo_contestants.Length; i++)
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
