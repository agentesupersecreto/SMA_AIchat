using System;

namespace com.ootii.Helpers
{
	// Token: 0x0200002E RID: 46
	public class FlagsHelper
	{
		// Token: 0x06000262 RID: 610 RVA: 0x0000BDB6 File Offset: 0x00009FB6
		public static bool ContainsValue(int rValues, int rTest)
		{
			return (rValues & rTest) != 0;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000BDBE File Offset: 0x00009FBE
		public static int AddValue(int rValues, int rValue)
		{
			return rValues | rValue;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000BDC3 File Offset: 0x00009FC3
		public static void AddValue(ref int rValues, int rValue)
		{
			rValues |= rValue;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000BDCB File Offset: 0x00009FCB
		public static int RemoveValue(int rValues, int rValue)
		{
			return rValues & ~rValue;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000BDD1 File Offset: 0x00009FD1
		public static void RemoveValue(ref int rValues, int rValue)
		{
			rValues &= ~rValue;
		}
	}
}
