using System;
using System.Collections.Generic;
using System.Text;

using AOCSync.Entity;

namespace AOCSync.Client
{
    class EventCallCenterIterval:Event
    {
        public EventCallCenterIterval()
        {
            ScheduleType = "AOCSync.Client.WorkCallCenterITV";
            Minutes = AOCConfig.INTERVALEVENT / 1000 / 60;
        }
    }
}
