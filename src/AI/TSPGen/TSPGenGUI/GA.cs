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
using TSPModel;

namespace TSPGenGUI
{
    public delegate void ChartEventHandler(object sender, GUIGAEvent e);
    public class GA
    {
        private Recombinators ien_recomtype;
        public event ChartEventHandler ChartUpdate;
        private int ii_recpergen;
        private string ii_path;
        private int ii_poolsize;
        private int ii_generations;
        private double id_modifyprob;
        private double id_recomprob;
        private Selectors ien_selector;
        private Randoms ien_random;
        private int ii_elites = 1;
        private int ii_ts_contestants = 2;

        private double id_avgavg;
        private double id_avgbest;
        private int ii_reccount;
        private int ii_gencount;
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
            lo_processor.Execute(ien_recomtype, lo_data, ii_poolsize, ii_generations, id_modifyprob, id_recomprob, ien_selector, ien_random, ii_elites, ii_ts_contestants);
        }

        public void init
            (
                Recombinators aen_recomtype,
                int ai_recpergen,
                string as_path,
                int ai_poolsize,
                int ai_generations,
                double ad_modifyprob,
                double ad_recomprob,
                Selectors aen_selector,
                Randoms aen_random,
                int ai_elites = 1,
                int ai_ts_contestants = 2
            )
        {
            ien_recomtype = aen_recomtype;
            ii_recpergen = ai_recpergen;
            ii_path = as_path;
            ii_poolsize = ai_poolsize;
            ii_generations = ai_generations;
            id_modifyprob = ad_modifyprob;
            id_recomprob = ad_recomprob;
            ien_selector = aen_selector;
            ien_random = aen_random;
            ii_elites = ai_elites;
            ii_ts_contestants = ai_ts_contestants;
        }

        public void init
        (
            GARun ao_run
        )
        {
            ien_recomtype = ao_run.ien_recomtype;
            ii_recpergen = ao_run.ii_recpergen;
            ii_path = ao_run.ii_path;
            ii_poolsize = ao_run.ii_poolsize;
            ii_generations = ao_run.ii_generations;
            id_modifyprob = ao_run.id_modifyprob;
            id_recomprob = ao_run.id_recomprob;
            ien_selector = ao_run.ien_selector;
            ien_random = ao_run.ien_random;
            ii_elites = ao_run.ii_elites;
            ii_ts_contestants = ao_run.ii_ts_contestants;
        }

        private void Changed(object sender, GeneticAPI.Events.APIEventArgs e)
        {
            ii_reccount++;
            id_avgavg += e.avgfitness;
            id_avgbest += e.bestfitness;
            ii_gencount++;
            if (ii_reccount >= ii_recpergen)
            {
                e.avgfitness = (id_avgavg / ii_reccount);
                e.bestfitness = (id_avgbest / ii_reccount);
                ii_reccount = 0;
                id_avgavg = 0;
                id_avgbest = 0;
                GUIGAEvent gui_e = new GUIGAEvent(e, ii_gencount);
                OnChartUpdate(gui_e);
            }
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
