using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPCityGenAPI.Output;

namespace TSPCityGenAPI
{
    public class OutputFile : AbstractOutput
    {
        private string filename { get; set; }
        public OutputFile(int num, string filename, int minX = 0, int maxX = 100, int minY = 0, int maxY = 100) : base(num, minX, maxX, minY, maxY)
        {
            this.filename = filename;
        }
        /// <summary>
        /// Outputs list of cities to JSON file.
        /// </summary>
        public override void Output()
        {
           String ls_output = JsonConvert.SerializeObject(this.io_cities);
            System.IO.File.WriteAllText(@filename, ls_output);
        }
    }
}
