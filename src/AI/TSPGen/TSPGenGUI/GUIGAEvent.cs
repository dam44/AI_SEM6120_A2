using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPGenGUI
{
    public class GUIGAEvent : GeneticAPI.Events.APIEventArgs
    {
        public int ii_generations { get;set;}

        public GUIGAEvent(GeneticAPI.Events.APIEventArgs e, int ai_generations) : base(e.message, e.error, e.avgfitness, e.popbestfitness, e.bestfitness, e.bestchrom, e.finished)
        {
            ii_generations = ai_generations;
        }
        public GUIGAEvent
            (
            string as_message, 
            bool ab_error, 
            double ad_avgfitness, 
            double ad_popbestfitness, 
            double ad_bestfitness,
            int ai_generations, 
            string as_bestchrom,
            bool ab_finished = false
            )
            : base
            (
            as_message,
            ab_error,
            ad_avgfitness,
            ad_popbestfitness,
            ad_bestfitness,
            as_bestchrom,
            ab_finished      
            )
        {
            ii_generations = ai_generations;
        }
    }
}
