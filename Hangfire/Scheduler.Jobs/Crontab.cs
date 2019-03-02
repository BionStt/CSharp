using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler.Jobs
{
	public static class Crontab
	{
		public static string Expression(IList<string> hours, IList<DayOfWeek> days)
		{
			var _hours = string.Join(",", hours.Select(x => Convert.ToInt16(x.Substring(0, 2))));
			var _days = string.Join(",", days.Select(x => ((int)x)));
			return $"0 {_hours} * * {_days}";
		}
	}
}