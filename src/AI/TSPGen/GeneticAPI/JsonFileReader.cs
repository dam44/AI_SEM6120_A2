using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GeneticAPI
{
    public class JsonFileReader<T>
    {
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
