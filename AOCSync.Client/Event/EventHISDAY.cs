using System;

using AOCSync.Entity;

namespace AOCSync.Client
{
    class EventHISDAY:Event
    {
         public EventHISDAY()
        {
            ScheduleType = "AOCSync.Client.WorkHISDAY";
            TimeOfDay = AOCConfig.INTERVALEVENTHISTORY;
            UpdateTime();
        }
        
    }
}
