using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPModel;

namespace TSPCityGenAPI.Output
{
    public abstract class AbstractOutput
    {
        protected List<City> io_cities;
        protected AbstractOutput(int num, int minX = 0, int maxX = 100, int minY = 0, int maxY = 100)
        {
            GenerateCities lo_gen = new GenerateCities();
            io_cities = lo_gen.Generate(num, minX, maxX, minY, maxY);
        }

        abstract public void Output();
    }
}
