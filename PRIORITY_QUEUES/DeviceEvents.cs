using System;

namespace PRIORITY_QUEUES
{
    public class DeviceEvents : IComparable<DeviceEvents>
    {
        public EventType eventType;
        public double priority;

        public DeviceEvents(EventType evenType, double priority)
        {
            this.eventType = evenType;
            this.priority = priority;
        }

        public override string ToString()
        {
            return "(" + eventType + ", " + priority.ToString("F1") + ")";
        }

        public int CompareTo(DeviceEvents other)
        {
            if (this.priority < other.priority)
            {
                return -1;
            }
            else if (this.priority > other.priority)
            {
                return 1;
            }
            return 0;
        }
    }
}
