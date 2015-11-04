using System;
using GeneticAPI;

namespace TSPModel
{
    public class City : IData
    {
        public int x { get; set; }
        public int y { get; set; }
        public int id { get; set; }

        public City()
        {

        }
        public City(int ai_id)
        {
            id = ai_id;
        }

        public City(int ai_id, int ai_x,int  ai_y)
        {
            id = ai_id;
            x = ai_x;
            y = ai_y;
        }

        int IData.x()
        {
            return this.x;
        }

        int IData.y()
        {
            return this.y;
        }

        int IData.id()
        {
            return this.id;
        }
    }
}