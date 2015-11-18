
using GeneticAPI._4_Recombination;
using GeneticAPI._5_Modification;
using GeneticAPI._5_Modification.Mutation.PMX;
using GeneticAPI.Events;
using GeneticAPI.Selection;
using GeneticAPI.Selection.Roulette;
using GeneticAPI.Shared;
using GeneticAPI.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    public delegate void ChangedEventHandler(object sender, APIEventArgs e);
    public class Processor<T> where T : IData
    {
        public event ChangedEventHandler Changed;

        protected virtual void OnChanged(APIEventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e); 
            }
        }
        public void Execute
            (
                List<T> ao_data, 
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
            //Initialize global variables.
            Globals<T>.DATA = DataEncoder<T>.EncodeListFromData(ao_data);
            Globals<T>.GENERATIONS = ai_generations;
            Globals<T>.POOLSIZE = ai_poolsize;
            Globals<T>.MODIFYPROB = ad_modifyprob;
            Globals<T>.RECOMPROB = ad_recomprob;
            Globals<T>.ELITENUM = ai_elites;

            if (aen_random == Randoms.Basic)
            {
                Globals<T>.RAND = new BasicRandom();
            }
            else
            {
                Globals<T>.RAND = new AdvRandom();
            }


            //Initialize local variables.
            NotableChromosomes<T> lo_noteablechroms = new NotableChromosomes<T>();
            Chromosome<T>[] lo_pop = new Chromosome<T>[Globals<T>.POOLSIZE];
            double ld_fitness = 0;
            double ld_popbestfitness = 0;
            double ld_inifitness = 0;
            int li_generation = 0;


            //Initialize population.
            ExecutionFunctions<T>.Initialize(ref ld_inifitness, ref ld_popbestfitness, lo_pop, lo_noteablechroms);

            Chromosome<T>[] lo_newpop = new Chromosome<T>[Globals<T>.POOLSIZE];
            //Start Genetic Algorithm.
            while (ContinueGA(ref li_generation)) {
                ExecutionFunctions<T>.EvaluateElite(lo_pop, lo_newpop);
                ExecutionFunctions<T>.Select(lo_pop, lo_newpop, aen_selector, ai_ts_contestants);
                ExecutionFunctions<T>.Recombination(lo_newpop);
                ExecutionFunctions<T>.Modification(lo_newpop);
                ExecutionFunctions<T>.EvaluateFitness(ref ld_fitness, ref ld_popbestfitness, lo_newpop, lo_noteablechroms);

                lo_pop = lo_newpop;
                //Send statistics to UI.
                OnChanged(new APIEventArgs("", false, ld_fitness, ld_popbestfitness, lo_noteablechroms.GetFinalBest().fitness));
            }

            //Send final statistics to UI.
            OnChanged(new APIEventArgs("Initial avg fitness: ", false, ld_inifitness, ld_popbestfitness, lo_noteablechroms.GetFinalBest().fitness));
            OnChanged(new APIEventArgs("Final avg fitness: ", false, ld_fitness, ld_popbestfitness, lo_noteablechroms.GetFinalBest().fitness));
            OnChanged(new APIEventArgs("Initial best fitness: ", false,ld_fitness, ld_popbestfitness, lo_noteablechroms.GetFinalBest().fitness));
            OnChanged(new APIEventArgs("Overall best fitness: ", false, ld_fitness, ld_popbestfitness, lo_noteablechroms.GetFinalBest().fitness));

        }

        private bool ContinueGA(ref int ai_generation)
        {
            bool lb_ret = true;
            if (ai_generation > Globals<T>.GENERATIONS) {
                lb_ret = false;
            }
            ai_generation++;
            return lb_ret;
        }
    }
}
