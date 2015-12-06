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
    /// <summary>
    /// JSON Run class. Stores information about a GA run.
    /// </summary>
    public class Run
    {
        public string route { get; }

        public string name { get; }
        public double average { get; }
        public double best { get; }
        public int recpergen { get; }
        public string path { get; }
        public int poolsize { get; }
        public int generations { get; }
        public double modifyprob { get; }
        public double recomprob { get; }
        public Selectors selector { get; }
        public Recombinators recomb { get; }
        public Randoms random { get; }
        public int elites { get; }
        public int contestants { get; }
        public bool adaptivemut { get; }
        public bool rog { get; }
        public bool srog { get; }

        public string runtime { get; }

        public Run()
        {

        }
        public Run(GARun ao_run, double ad_average, double ad_best, string as_route, TimeSpan ats_runtime)
        {
            route = as_route;
            name = ao_run.FileName();
            average = ad_average;
            best = ad_best;
            recpergen = ao_run.ii_recpergen;
            path = ao_run.ii_path;
            poolsize = ao_run.ii_poolsize;
            generations = ao_run.ii_generations;
            modifyprob = ao_run.id_modifyprob;
            recomprob = ao_run.id_recomprob;
            selector = ao_run.ien_selector;
            recomb = ao_run.ien_recomb;
            random = ao_run.ien_random;
            elites = ao_run.ii_elites;
            contestants = ao_run.ii_ts_contestants;
            adaptivemut = ao_run.ib_adaptivemut;
            rog = ao_run.ib_rog;
            srog = ao_run.ib_lrog;
            runtime = ats_runtime.ToString();

        }
    }
}
