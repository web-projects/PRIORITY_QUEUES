using PRIORITY_QUEUES.Buffering;
using PRIORITY_QUEUES.tests;
using System;

namespace PRIORITY_QUEUES
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupPriorityQueue();

            PriorityQueueTests.TestPriorityQueue(50000);
        }

        static void SetupPriorityQueue()
        {
            Console.WriteLine("------ Creating priority queue of DeviceEvents items ------");
            PriorityQueue<DeviceEvents> pq = new PriorityQueue<DeviceEvents>();

            DeviceEvents e1 = new DeviceEvents(EventType.CommEvent, 1.0);
            DeviceEvents e2 = new DeviceEvents(EventType.CancelationRequest, 2.0);
            DeviceEvents e3 = new DeviceEvents(EventType.Timeout, 3.0);
            DeviceEvents e4 = new DeviceEvents(EventType.UserCancel, 4.0);

            Console.WriteLine($"Adding {e3} to priority queue");
            pq.Enqueue(e3);
            Console.WriteLine($"Adding {e4} to priority queue");
            pq.Enqueue(e4);
            Console.WriteLine($"Adding {e1} to priority queue");
            pq.Enqueue(e1);
            Console.WriteLine($"Adding {e2} to priority queue");
            pq.Enqueue(e2);

            Console.WriteLine($"\nPriory queue is: [{pq}]");

            while (pq.Count() > 0)
            {
                Console.WriteLine("\nRemoving device event from queue ------------");
                DeviceEvents e = pq.Dequeue();
                Console.WriteLine($"Removed device event is: {e}");
                Console.WriteLine($"Priory queue is now: [{pq}]");
            }
        }
    }
}
