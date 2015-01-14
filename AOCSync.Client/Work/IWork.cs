using System;

namespace AOCSync.Client
{
	public interface IWork
	{
        int UserID { set; get; }
		void Execute(object state);
	}
}
