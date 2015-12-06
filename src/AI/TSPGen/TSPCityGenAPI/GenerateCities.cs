using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPModel;

namespace TSPCityGenAPI
{
    /// <summary>
    /// Generates a list of cities.
    /// </summary>
    public class GenerateCities
    {
        private Random io_rand;
        private static readonly object io_syncLock = new object();

        public GenerateCities()
        {
            io_rand = new Random();
        }
        /// <summary>
        /// Generates a list of cities.
        /// </summary>
        /// <param name="num">Number of cities to generate.</param>
        /// <param name="minX"></param>
        /// <param name="maxX"></param>
        /// <param name="minY"></param>
        /// <param name="maxY"></param>
        /// <returns></returns>
        public List<City> Generate(int num, int minX = 0, int maxX = 100, int minY = 0, int maxY = 100)
        {
            List<City> lo_cities = new List<City>();
            for (int i = 0; i < num; i++)
            {
                City lo_city = new City(i+1);
                lo_city.x = randInt(minX, maxX);
                lo_city.y = randInt(minY, maxY);
                lo_cities.Add(lo_city);
            }
            return lo_cities;
        }

        private int randInt(int min, int max)
        {
            lock(io_syncLock)
            {
                return io_rand.Next(min, max);
            }
        }
    }
}
