using System;
using System.Collections.Generic;

namespace PRIORITY_QUEUES.Buffering
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data;

        public PriorityQueue()
        {
            this.data = new List<T>();
        }

        public void Enqueue(T item)
        {
            data.Add(item);
            int ci = data.Count - 1;

            while (ci > 0)
            {
                int pi = (ci - 1) / 2;
                if (data[ci].CompareTo(data[pi]) >= 0)
                {
                    break;
                }
                T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
                ci = pi;
            }
        }

        public T Dequeue()
        {
            // assumes pq is not empty; up to calling code
            int li = data.Count - 1;
            T head = data[0];
            data[0] = data[li];
            data.RemoveAt(li);

            li--; // last index (after removal)
            int pi = 0; // parent index. start at front of pq

            while (true)
            {
                int ci = pi * 2 + 1;
                if (ci > li)
                {
                    break;
                }
                int rc = ci + 1;
                if (rc <= li && data[rc].CompareTo(data[ci]) < 0)
                {
                    ci = rc;
                }
                if (data[pi].CompareTo(data[ci]) <= 0)
                {
                    break;
                }
                T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp;
                pi = ci;
            }
            return head;
        }

        public T Peek()
        {
            T head = data[0];
            return head;
        }

        public int Count()
        {
            return data.Count;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < data.Count; ++i)
            {
                str += data[i].ToString() + " ";
            }
            str += "count = " + data.Count;
            return str;
        }

        public bool IsConsistent()
        {
            // is the heap property true for all data?
            if (data.Count == 0)
            {
                return true;
            }
            int li = data.Count - 1;
            for (int pi = 0; pi < data.Count; ++pi)
            {
                int lci = 2 * pi + 1;
                int rci = 2 * pi + 2;

                if (lci <= li && data[pi].CompareTo(data[lci]) > 0)
                {
                    return false;
                }

                if (rci <= li && data[pi].CompareTo(data[rci]) > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
