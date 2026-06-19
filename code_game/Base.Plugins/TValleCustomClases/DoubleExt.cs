using System;

namespace TValleCustomClases
{
	// Token: 0x0200007C RID: 124
	public static class DoubleExt
	{
		// Token: 0x060003A0 RID: 928 RVA: 0x0000F974 File Offset: 0x0000DB74
		public static double OutPow(this double x, double p)
		{
			if (x <= 0.0)
			{
				return 0.0;
			}
			if (x >= 1.0)
			{
				return 1.0;
			}
			int num = ((p % 2.0 == 0.0) ? (-1) : 1);
			return (double)num * (Math.Pow(x - 1.0, p) + (double)num);
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x0000F9DF File Offset: 0x0000DBDF
		public static double inPow(this double x, double p)
		{
			if (x <= 0.0)
			{
				return 0.0;
			}
			if (x >= 1.0)
			{
				return 1.0;
			}
			return Math.Pow(x, p);
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x0000FA14 File Offset: 0x0000DC14
		public static double inOutPow(this double x, double p)
		{
			if (x <= 0.0)
			{
				return 0.0;
			}
			if (x >= 1.0)
			{
				return 1.0;
			}
			x *= 2.0;
			if (x < 1.0)
			{
				return x.inPow(p) / 2.0;
			}
			int num = ((p % 2.0 == 0.0) ? (-1) : 1);
			return (double)num / 2.0 * (Math.Pow(x - 2.0, p) + (double)(num * 2));
		}
	}
}
