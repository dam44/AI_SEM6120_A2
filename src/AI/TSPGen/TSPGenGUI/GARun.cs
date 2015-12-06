using GeneticAPI.Recombination;
using GeneticAPI.Selection;
using GeneticAPI.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPGenGUI
{
    public class GARun
    {
        private static int id = 0;
        private int myid = 0;

        public int ii_recpergen { get; }
        public string ii_path { get; }
        public int ii_poolsize { get; }
        public int ii_generations { get; }
        public double id_modifyprob { get; }
        public double id_recomprob { get; }
        public Selectors ien_selector { get; }
        public Recombinators ien_recomb { get; }
        public Randoms ien_random { get; }
        public int ii_elites { get; }
        public int ii_ts_contestants { get; }

        public bool ib_adaptivemut { get; }
        public bool ib_rog {get;}
        public bool ib_lrog { get; }

        public GARun(
                int ai_recpergen,
                string as_path,
                int ai_poolsize,
                int ai_generations,
                double ad_modifyprob,
                double ad_recomprob,
                Selectors aen_selector,
                Recombinators aen_recomb,
                Randoms aen_random,
                int ai_elites = 1,
                int ai_ts_contestants = 2,
                bool ab_adaptivemut = true,
                bool ab_rog = false,
                bool ab_lrog = true
            )
        {
            ii_recpergen = ai_recpergen;
            ii_path = as_path;
            ii_poolsize = ai_poolsize;
            ii_generations = ai_generations;
            id_modifyprob = ad_modifyprob;
            id_recomprob = ad_recomprob;
            ien_selector = aen_selector;
            ien_recomb = aen_recomb;
            ien_random = aen_random;
            ii_elites = ai_elites;
            ii_ts_contestants = ai_ts_contestants;
            ib_adaptivemut = ab_adaptivemut;
            ib_rog = ab_rog;
            ib_lrog = ab_lrog;
            id = id + 1;
            myid = id;
        }

        public string FileName()
        {
            return "run" + myid + ".png";
        }

        public override string ToString()
        {
            return "Run: " + myid;
        }
    }
}
