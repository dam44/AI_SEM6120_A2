using GeneticAPI.Selection;
using GeneticAPI.Selection.Roulette;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI
{
    public class Processor<T> where T : IData
    {
        public void Execute(List<T> ao_data, int ai_poolsize)
        {
            Globals<T>.DATA = DataEncoder<T>.EncodeListFromData(ao_data);
            List<Individual<T>> lo_individuals = new List<Individual<T>>();
            for (int i = 0; i< ai_poolsize; i++)
            {
                 lo_individuals.Add(InitialIndividualFactory<T>.GenerateIndividual());
            }

            Selector<T> lo_selector = new Roulette<T>(lo_individuals);
            List<Individual<T>> lo_individuals_gen2 = new List<Individual<T>>();
            for (int i = 0; i < ai_poolsize; i++)
            {
                lo_individuals_gen2.Add(lo_selector.MakeSelection());
            }



        }
    }
}
