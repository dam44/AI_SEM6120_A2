﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Recombination
{
    /// <summary>
    /// Two Point PMX Crossover Operator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TwoPointCrossoverPMX<T> : Crossover<T> where T : IData
    {
        /// <summary>
        /// Takes 2 parents, Creates two children from them.
        /// </summary>
        /// <param name="ao_parents"></param>
        /// <returns></returns>
        public override Chromosome<T>[] GenerateChildPair(Chromosome<T>[] ao_parents)
        {
            //Check whether to crossover. (Crossover Probability)
            if (!isCrossover()) return ao_parents;

            int li_crosspoint_one = Globals<T>.RAND.Next(ao_parents[0].GetOrder().Count / 2);
            int li_crosspoint_two;

            //Create second crosspoint. Make sure it's not the same crosspoint as the first one.
            do
            {
                li_crosspoint_two = Globals<T>.RAND.Next(ao_parents[0].GetOrder().Count / 2);
            } while (li_crosspoint_two == li_crosspoint_one);

            //Crosspoint one is always the higher number.
            if (li_crosspoint_two > li_crosspoint_one)
            {
                int temp = li_crosspoint_one;
                li_crosspoint_one = li_crosspoint_two;
                li_crosspoint_two = temp;
            }

            Chromosome < T >[] lo_children = new Chromosome<T>[2];
            //Call create child twice, swapping position of parents to generate two different children from them.
            lo_children[0] = CreateChild(li_crosspoint_one, li_crosspoint_two, ao_parents[0], ao_parents[1]);
            lo_children[1] = CreateChild(li_crosspoint_one, li_crosspoint_two, ao_parents[1], ao_parents[0]);

            return lo_children;

        }

        /// <summary>
        /// Creates child using One Point PMX Crossover method.
        /// Select a random positions n1 and n2 in Chromosome gene list.
        /// Ensure: n1 > n2
        /// 
        /// 
        /// Find Gene g1 at n1 Parent 1 p1.
        /// Find Gene g2 at n1 Parent 2 p2.
        /// Find g2 in p1, swap g1 with g2.
        ///  n1 = n1 - 1
        /// Repeat, while (n1 gt n2)
        /// 
        /// Return p1 as Child c1
        /// </summary>
        /// <param name="ai_crosspoint"></param>
        /// <param name="ao_parent1"></param>
        /// <param name="ao_parent2"></param>
        /// <returns></returns>
        public Chromosome<T> CreateChild(int ai_crosspoint_one, int ai_crosspoint_two, Chromosome<T> ao_parent1, Chromosome<T> ao_parent2)
        {

            //Don't change anything if not mutating.

            int li_countdown = ai_crosspoint_one;
            //int li_countdown = 4;
            Dictionary<int, int> lo_newpositions_byid = new Dictionary<int, int>();
            Dictionary<int, int> lo_newpositions_bypos = new Dictionary<int, int>();
            Dictionary<int, Gene<T>> lo_idgenemap = new Dictionary<int, Gene<T>>();

            for (int i = 0; i < ao_parent1.GetOrder().Count; i++)
            {
                lo_newpositions_byid.Add(ao_parent1.GetOrder()[i].data.id(), i);
                lo_newpositions_bypos.Add(i, ao_parent1.GetOrder()[i].data.id());
                lo_idgenemap.Add(ao_parent1.GetOrder()[i].data.id(), ao_parent1.GetOrder()[i]);
            }

            while (li_countdown > ai_crosspoint_two)
            {

                //1. Find id at crossover point of data in parent 2.
                int li_p2id = ao_parent2.GetOrder()[li_countdown].data.id();

                //2. Find the position of this data in parent 1 chromosome gene list.
                int li_p1_p2id_pos = lo_newpositions_byid[li_p2id];

                //3. Set this position to be the crossover point.
                lo_newpositions_byid[li_p2id] = li_countdown;

                //4. Find the id at the crossover point of data in parent 1.
                //int li_p1id = ao_parent1.GetOrder()[li_countdown].data.id();
                int li_p1id = lo_newpositions_bypos[li_countdown];
                lo_newpositions_bypos[li_countdown] = li_p2id;

                //5. Set this position to be that of the position found in step 2.
                lo_newpositions_byid[li_p1id] = li_p1_p2id_pos;
                lo_newpositions_bypos[li_p1_p2id_pos] = li_p1id;

                li_countdown--;
            }

            Gene<T>[] childgenes = new Gene<T>[ao_parent1.GetOrder().Count];
            foreach (KeyValuePair<int, int> entry in lo_newpositions_byid)
            {
                childgenes[entry.Value] = lo_idgenemap[entry.Key];
            }

            return new Chromosome<T>(childgenes.ToList());
        }
    }
}
