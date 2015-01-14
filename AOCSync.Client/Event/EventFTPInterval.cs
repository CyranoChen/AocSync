using System;
using System.Collections.Generic;
using System.Text;

using AOCSync.Entity;

namespace AOCSync.Client
{
    class EventFTPIterval:Event
    {
        public EventFTPIterval()
        {
            ScheduleType = "AOCSync.Client.WorkFTPITV";
            Minutes = AOCConfig.INTERVALEVENT / 1000 / 60;
        }

        public EventFTPIterval(AOCUserData user)
        {
            ScheduleType = "AOCSync.Client.WorkFTPITV";
            UserID = user.UserID;
            Minutes = user.ITVTime;
        }
    }
}
