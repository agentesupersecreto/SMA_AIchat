using System;

namespace com.ootii.Helpers
{
	// Token: 0x02000037 RID: 55
	public static class StringExtensions
	{
		// Token: 0x060002A9 RID: 681 RVA: 0x0000CB02 File Offset: 0x0000AD02
		public static bool Contains(this string rSource, string rValue, StringComparison rComparison)
		{
			return rSource.IndexOf(rValue, rComparison) >= 0;
		}
	}
}
