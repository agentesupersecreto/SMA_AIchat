using System;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x02000056 RID: 86
	public static class IEndableOnDateBuffExt
	{
		// Token: 0x060001D1 RID: 465 RVA: 0x00004568 File Offset: 0x00002768
		public static int DaysToBuffEndHour(this DateTime now, int daysToAdd)
		{
			return Convert.ToInt32((now.AddDays((double)daysToAdd) - DateTime.MinValue).TotalHours);
		}
	}
}
