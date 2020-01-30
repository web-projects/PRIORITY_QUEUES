using System;
using System.Collections.Generic;
using System.Text;

namespace PRIORITY_QUEUES
{
    public enum EventType
    {
        CommEvent = 0,
        CancelationRequest,
        Timeout,
        UserCancel
    }
}
