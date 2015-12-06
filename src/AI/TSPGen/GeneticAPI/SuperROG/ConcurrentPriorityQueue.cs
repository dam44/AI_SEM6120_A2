using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneticAPI.SuperROG
{
    /// <summary>
    /// Concurrent Priority Queue Implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConcurrentPriorityQueue<T> where T : IComparable<T>
    {
        private readonly List<T> io_cpq;
        private readonly int ii_size;
        public ConcurrentPriorityQueue(int ai_size)
        {
            io_cpq = new List<T>();
            ii_size = ai_size;
        }

        /// <summary>
        /// Adds an item to the CPQ.
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            //Locks the queue whilst adding to it so another thread doesn't try at the same time.
            lock (io_cpq)
            {
                //Finds where the item should be added to in the queue.
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
                //If the item has not been added and the queue is less than maximum size then add it to the end.
                if (io_cpq.Count < ii_size)
                {
                    io_cpq.Add(item);
                    return;
                }
                //When the queue has one element in it wake other threads that were waiting for an element to be added to the empty queue.
                if (io_cpq.Count == 1)
                {
                    Monitor.PulseAll(io_cpq);
                }
            }

        }

        /// <summary>
        /// Takes an item from the front of the queue.
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            //Lock queue whilst taking from it.
            lock (io_cpq)
            {
                //If the queue is empty wait for an item to be added to it.
                if (io_cpq.Count == 0)
                {
                    Monitor.Wait(io_cpq);
                }
                //Get the item and then remove it from the queue.
                T lo_ret = io_cpq[0];
                io_cpq.RemoveAt(0);
                return lo_ret;
            }
        }

    }
}
