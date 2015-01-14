using System;
using System.Collections.Generic;
using System.Text;

using AOCSync.Entity;

namespace AOCSync.Client
{
    class EventFlightQuerySystemIterval:Event
    {
        public EventFlightQuerySystemIterval()
        {
            ScheduleType = "AOCSync.Client.WorkFlightQuerySystemITV";
            Minutes = AOCConfig.INTERVALEVENT / 1000 / 60;
        }
    }
}
