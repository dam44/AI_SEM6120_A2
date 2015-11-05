using GeneticAPI._4_Recombination;
using GeneticAPI._5_Modification;
using GeneticAPI._5_Modification.Mutation.PMX;
using GeneticAPI.Events;
using GeneticAPI.Selection;
using GeneticAPI.Selection.Roulette;
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
        public void Execute(List<T> ao_data, int ai_poolsize, int ai_generations, double ad_modifyprob)
        {
            Globals<T>.DATA = DataEncoder<T>.EncodeListFromData(ao_data);
            Globals<T>.GENERATIONS = ai_generations;
            Globals<T>.POOLSIZE = ai_poolsize;
            Globals<T>.RAND = new Random();
            Globals<T>.MODIFYPROB = ad_modifyprob;


            List<Chromosome<T>> lo_initial_population = new List<Chromosome<T>>();
            double ld_totalfitness = 0;
            for (int i = 0; i< Globals<T>.POOLSIZE; i++)
            {
                Chromosome<T> temp = InitialChromosomeFactory<T>.GenerateChromosome();
                ld_totalfitness += temp.fitness;
                 lo_initial_population.Add(temp);
            }
            OnChanged(new APIEventArgs("Initialization procedure successful.", false, (ld_totalfitness / lo_initial_population.Count)));

            int li_generation = 0;
            Generation(li_generation, lo_initial_population);

        }

        public void Generation(int ai_gencount, List<Chromosome<T>> ao_generation)
        {
            Selector<T> lo_selector = new Roulette<T>(ao_generation);
            List<Chromosome<T>> lo_generation_population = new List<Chromosome<T>>();
            for (int i = 0; i < Globals<T>.POOLSIZE; i++)
            {
                lo_generation_population.Add(lo_selector.MakeSelection());
            }

            Recombination<T> lo_recom = new CrossoverPMX<T>();
            for (int i = 0; i < Globals<T>.POOLSIZE; i+=2)
            {
                Chromosome<T>[] parents = { lo_generation_population[i], lo_generation_population[i + 1] };
                Chromosome<T>[] children = lo_recom.GenerateChildren(parents);
                lo_generation_population[i] = children[0];
                lo_generation_population[i + 1] = children[1];
            }

            Modification<T> lo_modif = new MutationPMX<T>();
            for (int i = 0; i < Globals<T>.POOLSIZE; i += 2)
            {
                Chromosome<T>[] parents = { lo_generation_population[i] };
                Chromosome<T> child = lo_modif.ModifyChildren(parents)[0];
                lo_generation_population[i] = child;
            }

            double ld_totalfitness = 0;
            for (int i = 0; i < Globals<T>.POOLSIZE; i++)
            {
                ld_totalfitness += lo_generation_population[i].fitness;
            }

            OnChanged(new APIEventArgs("Initialization procedure successful.", false, (ld_totalfitness / lo_generation_population.Count)));
            if (ai_gencount < Globals<T>.GENERATIONS)
            {
                return;
            }
            else
            {
                OnChanged(new APIEventArgs("Fin.", false, (ld_totalfitness / lo_generation_population.Count)));
                //Recursive call.
                Generation(ai_gencount++, lo_generation_population);
            }
        }
    }
}
