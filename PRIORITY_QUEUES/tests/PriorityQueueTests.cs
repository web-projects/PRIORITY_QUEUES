using PRIORITY_QUEUES.Buffering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PRIORITY_QUEUES.tests
{
    public static class PriorityQueueTests
    {
        public static void TestPriorityQueue(int numOperations)
        {
            Console.WriteLine("\n------ Testing priority queue ------");

            Random rand = new Random(0);

            PriorityQueue<DeviceEvents> pq = new PriorityQueue<DeviceEvents>();

            for (int op = 0; op < numOperations; op++)
            {
                int opType = rand.Next((int)EventType.CommEvent, (int)EventType.UserCancel);

                if (opType == (int)EventType.CommEvent)
                {
                    double priority = (100.0 - 1.0) * rand.NextDouble() + 1.0;
                    pq.Enqueue(new DeviceEvents(EventType.CommEvent, priority));

                    if (pq.IsConsistent() == false)
                    {
                        Console.WriteLine($"Test fails after enqueue operation # {op}");
                    }
                }
                else
                {
                    if (pq.Count() > 0)
                    {
                        DeviceEvents e = pq.Dequeue();

                        if (pq.IsConsistent() == false)
                        {
                            Console.WriteLine($"Test fails after dequeue operation # {op}");
                        }
                    }
                }
            }
            Console.WriteLine("All tests passed");
        }
    }
}
