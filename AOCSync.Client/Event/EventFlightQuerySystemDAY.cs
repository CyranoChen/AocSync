using System;

using AOCSync.Entity;

namespace AOCSync.Client
{
    class EventFlightQuerySystemDAY:Event
    {
        public EventFlightQuerySystemDAY()
        {
            ScheduleType = "AOCSync.Client.WorkFlightQuerySystemDAY";
            TimeOfDay = AOCConfig.INTERVALEVENTDAILY;
            UpdateTime();
        }

    }
}
