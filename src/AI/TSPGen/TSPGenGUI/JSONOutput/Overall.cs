using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPGenGUI.JSONOutput
{
    /// <summary>
    /// JSON overall results class.
    /// </summary>
    public class Overall
    {

        public double best;
        public double averagebest;
        public double average;
        public string averageruntime;

        public Overall()
        {

        }

        /// <summary>
        /// Calculates statistics based on runs.
        /// </summary>
        /// <param name="ao_runs"></param>
        public void init(List<Run> ao_runs)
        {
            List<TimeSpan> lts_timespans = new List<TimeSpan>();
            best = ao_runs[0].best;
            average = 0;
            averagebest = 0;
            for (int i = 0; i < ao_runs.Count; i++)
            {
                lts_timespans.Add(TimeSpan.Parse(ao_runs[i].runtime));
                average += ao_runs[i].average;
                averagebest += ao_runs[i].best;
                if (best > ao_runs[i].best)
                {
                    best = ao_runs[i].best;
                }
            }
            double ld_avgticks = lts_timespans.Average(timeSpan => timeSpan.Ticks);
            long ll_avgticks = Convert.ToInt64(ld_avgticks);
            TimeSpan lts_timetaken = new TimeSpan(ll_avgticks);
            averageruntime = lts_timetaken.ToString();
            average = average / ao_runs.Count;
            averagebest = averagebest / ao_runs.Count;
        }
    }
}
