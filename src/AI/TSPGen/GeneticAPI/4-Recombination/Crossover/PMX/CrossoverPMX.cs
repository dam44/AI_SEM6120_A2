using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI._4_Recombination
{
    public class CrossoverPMX<T> : Crossover<T> where T : IData
    {
        public override Chromosome<T>[] GenerateChildren(Chromosome<T>[] ao_parents)
        {
            int li_crosspoint = Globals<T>.RAND.Next(ao_parents[0].order.Count);

            Chromosome<T>[] lo_children = new Chromosome<T>[2];

            lo_children[0] = CreateChild(li_crosspoint, ao_parents[0], ao_parents[1]);
            lo_children[1] = CreateChild(li_crosspoint, ao_parents[1], ao_parents[0]);

            return lo_children;

        }

        public Chromosome<T> CreateChild(int ai_crosspoint, Chromosome<T> ao_parent1, Chromosome<T> ao_parent2)
        {
            int li_countdown = ai_crosspoint;
            Dictionary<int, int> lo_newpositions = new Dictionary<int, int>();
            Dictionary<int, int> lo_oldnew_map = new Dictionary<int, int>();
            Dictionary<int, int> lo_newold_map = new Dictionary<int, int>();

            for (int i = 0; i < ao_parent1.order.Count; i++)
            {
                lo_newpositions.Add(ao_parent1.order[i].data.id(), i);
                lo_oldnew_map.Add(i, i);
            }

            while (li_countdown > 0)
            {

                //1. Find id at crossover point of data in parent 2.
                int li_p2id = ao_parent2.order[li_countdown].data.id();

                //2. Find the position of this data in parent 1 chromosome gene list.
                int li_p1_p2id_pos = lo_newpositions[li_p2id];

                //3. Set this position to be the crossover point.
                lo_newpositions[li_p2id] = li_countdown;
                lo_oldnew_map[li_countdown] = li_p1_p2id_pos;

                //4. Find the id at the crossover point of data in parent 1.
                int li_p1id = ao_parent1.order[li_countdown].data.id();

                //5. Set this position to be that of the position found in step 2.
                lo_newpositions[li_p1id] = li_p1_p2id_pos;
                lo_oldnew_map[li_p1_p2id_pos] = li_countdown;

                li_countdown--;
            }

            foreach (KeyValuePair<int, int> entry in lo_oldnew_map)
            {
                lo_newold_map.Add(entry.Value, entry.Key);
            }

            List<Gene<T>> childgenes = new List<Gene<T>>();
            for (int i = 0; i < ao_parent1.order.Count; i++)
            {
                childgenes.Add(ao_parent1.order[lo_newold_map[i]]);
            }
            return new Chromosome<T>(childgenes, Fitness<T>.EvaluateTotal(childgenes));
        }
    }
}
