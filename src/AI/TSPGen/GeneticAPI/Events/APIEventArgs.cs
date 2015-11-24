using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.Events
{
    public class APIEventArgs : EventArgs
    {
        public string message { get; set; }
        public bool error { get; set; }
        public double avgfitness { get; set; }

        public double bestfitness { get; set; }

        public string bestchrom { get; set; }

        public double popbestfitness { get; set; }

        public bool finished { get; set; }

        public APIEventArgs(string as_message, bool ab_error, double ad_avgfitness, double ad_popbestfitness, double ad_bestfitness, string as_bestchrom, bool ab_finished = false)
        {
            this.message = as_message;
            this.error = ab_error;
            this.avgfitness = ad_avgfitness;
            this.bestfitness = ad_bestfitness;
            this.bestchrom = as_bestchrom;
            this.popbestfitness = ad_popbestfitness;
            this.finished = ab_finished;
        }
    }
}
