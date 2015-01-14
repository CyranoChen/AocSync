using System;

using AOCSync.Entity;

namespace AOCSync.Client
{
    class EventCallCenterDAY:Event
    {
        public EventCallCenterDAY()
        {
            ScheduleType = "AOCSync.Client.WorkCallCenterDAY";
            TimeOfDay = AOCConfig.INTERVALEVENTDAILY;
            UpdateTime();
        }

    }
}
