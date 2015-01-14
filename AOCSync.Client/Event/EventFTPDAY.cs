using System;

using AOCSync.Entity;

namespace AOCSync.Client
{
    class EventFTPDAY:Event
    {
        public EventFTPDAY()
        {
            ScheduleType = "AOCSync.Client.WorkFTPDAY";
            //TimeOfDay = AOCConfig.INTERVALEVENTDAILY;
            TimeOfDay = AOCConfig.INTERVALEVENTDAILY;
            UpdateTime();
        }

    }
}
