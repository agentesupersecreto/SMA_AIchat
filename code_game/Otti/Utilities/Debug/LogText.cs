using System;
using com.ootii.Collections;

namespace com.ootii.Utilities.Debug
{
	// Token: 0x0200001B RID: 27
	public class LogText
	{
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000183 RID: 387 RVA: 0x0000A195 File Offset: 0x00008395
		public static int Length
		{
			get
			{
				return LogText.sPool.Length;
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000A1A1 File Offset: 0x000083A1
		public static LogText Allocate()
		{
			LogText logText = LogText.sPool.Allocate();
			logText.Text = "";
			logText.X = 0;
			logText.Y = 0;
			return logText;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000A1C6 File Offset: 0x000083C6
		public static LogText Allocate(string rText, int rX, int rY)
		{
			LogText logText = LogText.sPool.Allocate();
			logText.Text = rText;
			logText.X = rX;
			logText.Y = rY;
			return logText;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000A1E7 File Offset: 0x000083E7
		public static void Release(LogText rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			LogText.sPool.Release(rInstance);
		}

		// Token: 0x040000F3 RID: 243
		public string Text;

		// Token: 0x040000F4 RID: 244
		public int X;

		// Token: 0x040000F5 RID: 245
		public int Y;

		// Token: 0x040000F6 RID: 246
		private static ObjectPool<LogText> sPool = new ObjectPool<LogText>(20, 5);
	}
}
