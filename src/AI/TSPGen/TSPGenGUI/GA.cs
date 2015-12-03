using GeneticAPI;
using GeneticAPI.Events;
using GeneticAPI.Recombination;
using GeneticAPI.Selection;
using GeneticAPI.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPGenGUI.JSONOutput;
using TSPModel;

namespace TSPGenGUI
{
    public delegate void ChartEventHandler(object sender, GUIGAEvent e);
    public class GA
    {
        public event ChartEventHandler ChartUpdate;
        private int ii_recpergen;
        private string ii_path;
        private int ii_poolsize;
        private int ii_generations;
        private double id_modifyprob;
        private double id_recomprob;
        private Selectors ien_selector;
        private Recombinators ien_recomb;
        private Randoms ien_random;
        private int ii_elites = 1;
        private int ii_ts_contestants = 2;
        private bool ib_adaptivemut = true;
        private bool ib_rog = false;
        private bool ib_srog = true;
        private GARun io_run = null;

        private double id_avgavg;
        private double id_avgavgavg;
        private double id_best;
        private int ii_reccount;
        private int ii_gencount;
        private Wrapper io_wrapper;
        private long il_msgcount = 0;
        private string is_bestchrom;
        private DateTime ida_starttime;
        private TimeSpan its_runtime;
        public void StartGA()
        {

            string[] args = new string[1];
            args[0] = ii_path;
            GeneticAPI.JsonFileReader<City> importer = new GeneticAPI.JsonFileReader<City>();
            List<City> lo_data = importer.Import(args[0]);

            for (int i = 0; i < lo_data.Count; i++)
            {
                Console.WriteLine(lo_data[i].id);
            }

            Processor<City> lo_processor = new Processor<City>();
            lo_processor.Changed += new ChangedEventHandler(Changed);
            lo_processor.Execute(lo_data, ii_poolsize, ii_generations, id_modifyprob, id_recomprob, ien_selector, ien_recomb, ien_random, ii_elites, ii_ts_contestants, ib_adaptivemut, ib_rog, ib_srog);
        }

        public void SetJSONWrapper(ref Wrapper ao_wrapper)
        {
            io_wrapper = ao_wrapper;
        }

        public void init
            (   
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
                bool ab_srog = true
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
            ib_srog = ab_srog;
            ida_starttime = new DateTime();
        }

        public void init
        (
            GARun ao_run,
            ref Wrapper ao_wrapper
        )
        {
            io_wrapper = ao_wrapper;
            io_run = ao_run;
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
            ida_starttime = new DateTime();
        }

        private void Changed(object sender, GeneticAPI.Events.APIEventArgs e)
        {
            if (ida_starttime == DateTime.MinValue)
            {
                ida_starttime = DateTime.Now;
            }
            ii_reccount++;
            id_avgavg += e.avgfitness;
            id_avgavgavg += e.avgfitness;
            il_msgcount++;
            //id_avgbest += e.bestfitness;
            ii_gencount++;
            if (e.finished)
            {
                Complete();
            }
            if (ii_reccount >= ii_recpergen)
            {
                e.avgfitness = (id_avgavg / ii_reccount);
                
                //e.bestfitness = (id_best / ii_reccount);
                id_best = e.bestfitness;
                is_bestchrom = e.bestchrom;
                ii_reccount = 0;
                id_avgavg = 0;
                GUIGAEvent gui_e = new GUIGAEvent(e, ii_gencount);
                OnChartUpdate(gui_e);
            }
        }

        public void Complete()
        {
            if (io_run == null) return;
            its_runtime = DateTime.Now - ida_starttime;
            io_wrapper.runs.Add(new Run(io_run, id_avgavgavg/il_msgcount, id_best, is_bestchrom, its_runtime));
        }

        protected virtual void OnChartUpdate(GUIGAEvent e)
        {
            if (ChartUpdate != null)
            {
                ChartUpdate(this, e);
            }
        }

    }
}
