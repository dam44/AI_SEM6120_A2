using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAPI.SuperSeeder
{
    public class ConcurrentPriorityQueue<T> where T : IComparable<T>
    {
        private readonly List<T> io_cpq;
        private readonly int ii_size;
        public ConcurrentPriorityQueue(int ai_size)
        {
            io_cpq = new List<T>();
            ii_size = ai_size;
        }

        public void Enqueue(T item)
        {
            lock (io_cpq)
            {
                for (int i = 0; i < io_cpq.Count - 1; i++)
                {
                    if (io_cpq[i].CompareTo(item) > 0)
                    {
                        io_cpq.Insert(i, item);
                        if (io_cpq.Count >= ii_size)
                        {
                            io_cpq.RemoveAt(io_cpq.Count - 1);
                        }
                        return;
                    }
                }
                if (io_cpq.Count < ii_size)
                {
                    io_cpq.Add(item);
                    return;
                }
            }

        }

        public T Dequeue()
        {
            lock (io_cpq)
            {
                T lo_ret = io_cpq[0];
                io_cpq.RemoveAt(0);
                return lo_ret;
            }
        }

    }
}
