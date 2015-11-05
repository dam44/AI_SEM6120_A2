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

        public APIEventArgs(string as_message, bool ab_error, double ad_avgfitness)
        {
            this.message = as_message;
            this.error = ab_error;
            this.avgfitness = ad_avgfitness;
        }
    }
}
