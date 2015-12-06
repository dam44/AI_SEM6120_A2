
using GeneticAPI.Recombination;
using GeneticAPI._5_Modification;
using GeneticAPI._5_Modification.Mutation.PMX;
using GeneticAPI.Events;
using GeneticAPI.Recombination;
using GeneticAPI.Selection;
using GeneticAPI.Selection.Roulette;
using GeneticAPI.Shared;
using GeneticAPI.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAPI.SuperROG;
using System.Threading;

namespace GeneticAPI
{
    public delegate void ChangedEventHandler(object sender, APIEventArgs e);
    /// <summary>
    /// Initiates GA and iterates through population generations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Processor<T> where T : IData
    {
        public event ChangedEventHandler Changed;
        public static Thread io_thread = null;

        //Sends event to those subscribed.
        protected virtual void OnChanged(APIEventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e); 
            }
        }

        /// <summary>
        /// Starts the Genetic Algorithm.
        /// </summary>
        /// <param name="ao_data">List of IData to be converted into Genes and stored in Chromosome.</param>
        /// <param name="ai_poolsize">Size of population.</param>
        /// <param name="ai_generations">Number of generations to iterate algorithm.</param>
        /// <param name="ad_modifyprob">Probability of modification/mutation.</param>
        /// <param name="ad_recomprob">Probability of recombination/crossover.</param>
        /// <param name="aen_selector">Selector Operator.</param>
        /// <param name="aen_recomb">Recombination Operator.</param>
        /// <param name="aen_random">Random basic vs adv</param>
        /// <param name="ai_elites">Number of Elites.</param>
        /// <param name="ai_ts_contestants">Number of Contestants for Tournament Selector.</param>
        /// <param name="ab_adaptivemut">Adaptive Mutation Enabler.</param>
        /// <param name="ab_rog">ROG Enabler.</param>
        /// <param name="ab_srog">SROG Enabler.</param>
        public void Execute
            (
                List<T> ao_data, 
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
            //Initialize global variables.
            Globals<T>.DATA = DataEncoder<T>.EncodeListFromData(ao_data);
            Globals<T>.GENERATIONS = ai_generations;
            Globals<T>.POOLSIZE = ai_poolsize;
            Globals<T>.MODIFYPROB = ad_modifyprob;
            Globals<T>.MODIFYBONUS = 0;
            Globals<T>.RECOMPROB = ad_recomprob;
            Globals<T>.ELITENUM = ai_elites;
            Globals<T>.ADAPTMUT = ab_adaptivemut;
            Globals<T>.ROG = ab_rog;
            Globals<T>.SROG = ab_srog;

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

            //Start SROG thread if it's active.
            if (Globals<T>.SROG && io_thread == null)
            {
                Globals<T>.CPQ = new ConcurrentPriorityQueue<Chromosome<T>>(100);
                SuperROG<T> lo_seeder = new SuperROG<T>(ref Globals<T>.CPQ);
                io_thread = new Thread(new ThreadStart(lo_seeder.Run));
                io_thread.Start();
            }


            //Initialize population.
            ExecutionFunctions<T>.Initialize(ref ld_inifitness, ref ld_popbestfitness, lo_pop, lo_noteablechroms);

            Chromosome<T>[] lo_newpop = new Chromosome<T>[Globals<T>.POOLSIZE];
            //Iterate Genetic Algorithm.
            while (ContinueGA(ref li_generation)) {
                ExecutionFunctions<T>.EvaluateElite(lo_pop);
                ExecutionFunctions<T>.Select(lo_pop, lo_newpop, aen_selector, ai_ts_contestants);
                ExecutionFunctions<T>.Recombination(lo_newpop, aen_recomb);
                ExecutionFunctions<T>.Modification(lo_newpop);
                ExecutionFunctions<T>.EvaluateFitness(ref ld_fitness, ref ld_popbestfitness, lo_newpop, lo_noteablechroms);

                lo_pop = lo_newpop;
                //Send statistics to UI.
                OnChanged(new APIEventArgs("", false, ld_fitness, ld_popbestfitness, lo_noteablechroms.GetFinalBest().fitness, lo_noteablechroms.GetFinalBest().ToString()));
            }

            //Send final statistics to UI.
            OnChanged(new APIEventArgs("Initial avg fitness: ", false, ld_inifitness, ld_popbestfitness, lo_noteablechroms.GetFinalBest().fitness, lo_noteablechroms.GetFinalBest().ToString()));
            OnChanged(new APIEventArgs("Final avg fitness: ", false, ld_fitness, ld_popbestfitness, lo_noteablechroms.GetFinalBest().fitness, lo_noteablechroms.GetFinalBest().ToString()));
            OnChanged(new APIEventArgs("Initial best fitness: ", false,ld_fitness, ld_popbestfitness, lo_noteablechroms.GetFinalBest().fitness, lo_noteablechroms.GetFinalBest().ToString()));
            OnChanged(new APIEventArgs("Overall best fitness: ", false, ld_fitness, ld_popbestfitness, lo_noteablechroms.GetFinalBest().fitness, lo_noteablechroms.GetFinalBest().ToString(), true));
        }

        //Check whether to stop GA.
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
