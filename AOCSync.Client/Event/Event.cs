using System;
using System.Xml.Serialization;

using AOCSync.Entity;

namespace AOCSync.Client
{
	/// <summary>
	/// Event is the configuration of an IEvent. 
	/// </summary>
	public class Event
	{
		public Event()
		{

		}

		private IWork _ievent = null;

		/// <summary>
		/// The current implementation of IEvent
		/// </summary>
		public IWork IEventInstance
		{
			get
			{
				LoadIEvent();
				return _ievent;
			}
		}

		/// <summary>
		/// Private method for loading an instance of IEvent
		/// </summary>
		private void LoadIEvent()
		{
			if(_ievent == null)
			{
				if(this.ScheduleType == null)
				{
                    AOCLog.logErro("计划任务没有定义其 type 属性");
				}

                Type type = Type.GetType(this.ScheduleType);
                if (type == null)
                {
                    AOCLog.logErro(string.Format("计划任务 {0} 无法被正确识别", this.ScheduleType));
                }
                else
                {
                    _ievent = (IWork)Activator.CreateInstance(type);
                    if (_ievent == null)
                    {
                        AOCLog.logErro(string.Format("计划任务 {0} 未能正确加载", this.ScheduleType));
                    }
                    else
                    {
                        _ievent.UserID = UserID;
                    }
                }
			}
		}
        private int _userid;
        public int UserID
        {
            get { return this._userid; }
            set { this._userid= value; }
        }

		private string _key;
		
		/// <summary>
		/// A unique key used to query the database. The name of the Server will also be used to ensure the "Key" is 
		/// unique in a cluster
		/// </summary>
		public string Key
		{
			get {return this._key;}
			set {this._key = value;}
		}

		private int _timeOfDay = -1;
		
		/// <summary>
		/// Absolute time in mintues from midnight. Can be used to assure event is only 
		/// executed once per-day and as close to the specified
		/// time as possible. Example times: 0 = midnight, 27 = 12:27 am, 720 = Noon
		/// </summary>
		public int TimeOfDay
		{
			get {return this._timeOfDay;}
			set {this._timeOfDay = value;}
		}

		private int _minutes = 60;
		
		/// <summary>
		/// The scheduled event interval time in minutes. If TimeOfDay has a value >= 0, Minutes will be ignored. 
		/// This values should not be less than the Timer interval.
		/// </summary>
		public int Minutes
		{
			get 
			{
				if(this._minutes < EventManager.TimerMinutesInterval)
				{
					return EventManager.TimerMinutesInterval;
				}
				return this._minutes;
			}
			set {this._minutes = value;	}
		}

		private string _scheduleType;
		
		/// <summary>
		/// The Type of class which implements IEvent
		/// </summary>
		[XmlAttribute("type")]
		public string ScheduleType
		{
			get {return this._scheduleType;}
			set {this._scheduleType = value;}
		}

		private DateTime _lastCompleted;
		
		/// <summary>
		/// Last Date and Time this event was processed/completed.
		/// </summary>
		[XmlIgnoreAttribute]
		public DateTime LastCompleted
		{
			get {return this._lastCompleted;}
			set 
			{
				dateWasSet = true;
				this._lastCompleted = value;
			}
		}

		//internal testing variable
		bool dateWasSet = true;

		[XmlIgnoreAttribute]
		public bool ShouldExecute
		{
			get
			{
                //TO CHECK!
                if (dateWasSet == false)
                {
                    return false;
                }

                //if(!dateWasSet) //if the date was not set (and it can not be configured), check the data store
                //{
                //    LastCompleted = DatabaseProvider.GetInstance().GetLastExecuteScheduledEventDateTime(this.Key,Environment.MachineName);
                //}

				//If we have a TimeOfDay value, use it and ignore the Minutes interval
                bool temp=true;
                if (ScheduleType.Equals("AOCSync.Client.WorkCallCenterDAY") || ScheduleType.Equals("AOCSync.Client.WorkCallCenterITV"))
                {
                    temp =  Lock.CC;                   
                }
                else if (ScheduleType.Equals("AOCSync.Client.WorkFlightQuerySystemDAY") || ScheduleType.Equals("AOCSync.Client.WorkFlightQuerySystemITV"))
                {
                    temp = Lock.FQS;                   
                }
                else if (ScheduleType.Equals("AOCSync.Client.WorkFTPDAY"))
                {
                    temp = Lock.CanDayFtpCC && Lock.CanDayFtpFQS;
                }
               
				if(this.TimeOfDay > -1)
				{
					//Now
					DateTime dtNow = DateTime.Now;  //now
					//We are looking for the current day @ 12:00 am
					DateTime dtCompare = dtNow.Date;
					//Check to see if the LastCompleted date is less than the 12:00 am + TimeOfDay minutes
                    //return LastCompleted < dtCompare.AddMinutes(this.TimeOfDay) && dtCompare.AddMinutes(this.TimeOfDay) <= dtNow;
                   return LastCompleted < dtCompare.AddMinutes(this.TimeOfDay) && dtCompare.AddMinutes(this.TimeOfDay) <= dtNow && temp;
				}
				else
				{
					//Is the LastCompleted date + the Minutes interval less than now?
					//return LastCompleted.AddMinutes(this.Minutes) < DateTime.Now;
                    return LastCompleted.AddMinutes(this.Minutes) < DateTime.Now && temp;                   
				}
			}
		}

		/// <summary>
		/// Call this method BEFORE processing the ScheduledEvent. This will help protect against long running events 
		/// being fired multiple times. Note, it is not absolute protection. App restarts will cause events to look like
		/// they were completed, even if they were not. Again, ScheduledEvents are helpful...but not 100% reliable
		/// </summary>
		public void UpdateTime()
		{
			this.LastCompleted = DateTime.Now;
		}

        public void SetLastExecuteScheduledEventDateTime(DateTime lastexecuted)
        {
            LastCompleted = lastexecuted;
        }

        public DateTime GetLastExecuteScheduledEventDateTime(string key, string servername)
        {
            return LastCompleted;
        }

        public virtual void Excute(object state)
        {
            dateWasSet = false;
            IEventInstance.Execute(state);
            dateWasSet = true;
        }
	}
}
