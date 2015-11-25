using GeneticAPI.Recombination;
using GeneticAPI.Selection;
using GeneticAPI.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPGenGUI.JSONOutput
{
    public class Run
    {
        public double average { get; }
        public double best { get; }
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
        public bool ib_rog { get; }
        public bool ib_srog { get; }

        public Run()
        {

        }
        public Run(GARun ao_run, double ad_average, double ad_best)
        {
            average = ad_average;
            best = ad_best;
            ii_recpergen = ao_run.ii_recpergen;
            ii_path = ao_run.ii_path;
            ii_poolsize = ao_run.ii_poolsize;
            ii_generations = ao_run.ii_generations;
            id_modifyprob = ao_run.id_modifyprob;
            id_recomprob = ao_run.id_recomprob;
            ien_selector = ao_run.ien_selector;
            ien_recomb = ao_run.ien_recomb;
            ien_random = ao_run.ien_random;
            ii_elites = ao_run.ii_elites;
            ii_ts_contestants = ao_run.ii_ts_contestants;
            ib_adaptivemut = ao_run.ib_adaptivemut;
            ib_rog = ao_run.ib_rog;
            ib_srog = ao_run.ib_srog;

        }
    }
}
