using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GeneticAPI
{
    /// <summary>
    /// Reads a JSON file into a list of T.
    /// </summary>
    /// <typeparam name="T">A Gene</typeparam>
    public class JsonFileReader<T>
    {
        /// <summary>
        /// Imports the JSON file.
        /// </summary>
        /// <param name="ao_filename">Full path of file.</param>
        /// <returns></returns>
        public List<T> Import(string ao_filename)
        {
            try {
                string ls_jsontxt = System.IO.File.ReadAllText(ao_filename);
                return JsonConvert.DeserializeObject<List<T>>(ls_jsontxt);
            } catch (Exception ex)
            {
                return null;
            }
        }
    }
}
