using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPGenGUI.JSONOutput
{
    public class Overall
    {

        public double best;
        public double averagebest;
        public double average;

        public Overall()
        {

        }


        public void init(List<Run> ao_runs)
        {
            best = ao_runs[0].best;
            average = 0;
            averagebest = 0;
            for (int i = 0; i < ao_runs.Count; i++)
            {
                average += ao_runs[i].average;
                averagebest += ao_runs[i].best;
                if (best > ao_runs[i].best)
                {
                    best = ao_runs[i].best;
                }
            }
            average = average / ao_runs.Count;
            averagebest = averagebest / ao_runs.Count;
        }
    }
}
