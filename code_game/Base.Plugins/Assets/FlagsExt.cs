using System;
using System.Collections.Generic;

namespace Assets
{
	// Token: 0x02000165 RID: 357
	public static class FlagsExt
	{
		// Token: 0x06000A8C RID: 2700 RVA: 0x00023AC4 File Offset: 0x00021CC4
		public static TEnum ToFlags<TEnum>(this IList<int> enumnVals) where TEnum : Enum
		{
			int num = 0;
			for (int i = 0; i < enumnVals.Count; i++)
			{
				num |= enumnVals[i];
			}
			return (TEnum)((object)num);
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x00023AF9 File Offset: 0x00021CF9
		public static bool IsAnyFlagSet(this int flags, int otherFalgs)
		{
			return (flags & otherFalgs) != 0;
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x00023B01 File Offset: 0x00021D01
		public static bool HasFlag(this int flags, int enumValue)
		{
			return flags < 0 || (enumValue != 0 && (flags & enumValue) == enumValue);
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x00023B14 File Offset: 0x00021D14
		public static bool HasFlag(this long flags, long enumValue)
		{
			return flags < 0L || (enumValue != 0L && (flags & enumValue) == enumValue);
		}
	}
}
