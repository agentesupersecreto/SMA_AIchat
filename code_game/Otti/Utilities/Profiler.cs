using System;
using System.Collections.Generic;
using System.Diagnostics;
using com.ootii.Utilities.Debug;

namespace com.ootii.Utilities
{
	// Token: 0x02000009 RID: 9
	public class Profiler
	{
		// Token: 0x0600008B RID: 139 RVA: 0x0000599C File Offset: 0x00003B9C
		public Profiler(string rTag)
		{
			this.Tag = rTag;
			this.mTicksPerMillisecond = 10000f;
			this.mMinTime = 2.1474836E+09f;
			this.mMaxTime = -2.1474836E+09f;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000059F8 File Offset: 0x00003BF8
		public Profiler(string rTag, string rSpacing)
		{
			this.Tag = rTag;
			this.mSpacing = rSpacing;
			this.mTicksPerMillisecond = 10000f;
			this.mMinTime = 2.1474836E+09f;
			this.mMaxTime = -2.1474836E+09f;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00005A5B File Offset: 0x00003C5B
		public void Reset()
		{
			this.mCount = 0;
			this.mRunTime = 0f;
			this.mTotalTime = 0f;
			this.mMinTime = 0f;
			this.mMaxTime = 0f;
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00005A90 File Offset: 0x00003C90
		public float AverageTime
		{
			get
			{
				if (this.mCount == 0)
				{
					return 0f;
				}
				return this.mTotalTime / (float)this.mCount;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00005AAE File Offset: 0x00003CAE
		public float MinTime
		{
			get
			{
				return this.mMinTime;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00005AB6 File Offset: 0x00003CB6
		public float MaxTime
		{
			get
			{
				return this.mMaxTime;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00005ABE File Offset: 0x00003CBE
		public float TotalTime
		{
			get
			{
				return this.mTotalTime;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00005AC6 File Offset: 0x00003CC6
		public float Time
		{
			get
			{
				return this.mRunTime;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00005ACE File Offset: 0x00003CCE
		public float ElapsedTime
		{
			get
			{
				if (this.mTimer.IsRunning)
				{
					return (float)this.mTimer.ElapsedTicks / this.mTicksPerMillisecond;
				}
				return this.mRunTime;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00005AF7 File Offset: 0x00003CF7
		public int Count
		{
			get
			{
				return this.mCount;
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00005AFF File Offset: 0x00003CFF
		public void Start()
		{
			this.mTimer.Reset();
			this.mTimer.Start();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00005B18 File Offset: 0x00003D18
		public float Stop()
		{
			this.mTimer.Stop();
			this.mRunTime = (float)this.mTimer.ElapsedTicks / this.mTicksPerMillisecond;
			this.mTotalTime += this.mRunTime;
			if (this.mMinTime == 0f || this.mRunTime < this.mMinTime)
			{
				this.mMinTime = this.mRunTime;
			}
			if (this.mMaxTime == 0f || this.mRunTime > this.mMaxTime)
			{
				this.mMaxTime = this.mRunTime;
			}
			this.mCount++;
			return this.mRunTime;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00005BC0 File Offset: 0x00003DC0
		public override string ToString()
		{
			return string.Format("{0} {1} - time:{2:f4}ms cnt:{3} avg:{4:f4}ms min:{5:f4}ms max:{6:f4}ms", new object[] { this.mSpacing, this.Tag, this.mRunTime, this.mCount, this.AverageTime, this.mMinTime, this.mMaxTime });
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00005C35 File Offset: 0x00003E35
		public static Profiler Start(string rProfiler)
		{
			if (!Profiler.sProfilers.ContainsKey(rProfiler))
			{
				Profiler.sProfilers.Add(rProfiler, new Profiler(rProfiler, ""));
			}
			Profiler.sProfilers[rProfiler].Start();
			return Profiler.sProfilers[rProfiler];
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00005C75 File Offset: 0x00003E75
		public static Profiler Start(string rProfiler, string rSpacing)
		{
			if (!Profiler.sProfilers.ContainsKey(rProfiler))
			{
				Profiler.sProfilers.Add(rProfiler, new Profiler(rProfiler, rSpacing));
			}
			Profiler.sProfilers[rProfiler].Start();
			return Profiler.sProfilers[rProfiler];
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00005CB1 File Offset: 0x00003EB1
		public static float Stop(string rProfiler)
		{
			if (!Profiler.sProfilers.ContainsKey(rProfiler))
			{
				return 0f;
			}
			return Profiler.sProfilers[rProfiler].Stop();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00005CD6 File Offset: 0x00003ED6
		public static float ProfilerTime(string rProfiler)
		{
			if (!Profiler.sProfilers.ContainsKey(rProfiler))
			{
				return 0f;
			}
			return Profiler.sProfilers[rProfiler].ElapsedTime;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00005CFC File Offset: 0x00003EFC
		public static string ToString(string rProfiler)
		{
			if (rProfiler.Length == 0)
			{
				float num = 0f;
				float num2 = 0f;
				foreach (Profiler profiler in Profiler.sProfilers.Values)
				{
					num += profiler.Time;
					num2 += profiler.AverageTime;
				}
				string text = string.Format("Profiles - Time:{0:f4}ms Avg:{1:f4}ms\r\n", num, num2);
				foreach (Profiler profiler2 in Profiler.sProfilers.Values)
				{
					text += string.Format("{0} Prc:{1:f3} AvgPrc:{2:f3}\r\n", profiler2.ToString(), profiler2.Time / num, profiler2.AverageTime / num2);
				}
				return text;
			}
			if (!Profiler.sProfilers.ContainsKey(rProfiler))
			{
				return "";
			}
			return Profiler.sProfilers[rProfiler].ToString();
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00005E28 File Offset: 0x00004028
		public static void ScreenWrite(string rProfiler, int rLine)
		{
			if (rProfiler.Length == 0)
			{
				float num = 0f;
				float num2 = 0f;
				foreach (Profiler profiler in Profiler.sProfilers.Values)
				{
					num += profiler.Time;
					num2 += profiler.AverageTime;
				}
				int num3 = 0;
				using (Dictionary<string, Profiler>.ValueCollection.Enumerator enumerator = Profiler.sProfilers.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Profiler profiler2 = enumerator.Current;
						Log.ScreenWrite(string.Format("{0} Prc:{1:f3} AvgPrc:{2:f3}\r\n", profiler2.ToString(), profiler2.Time / num, profiler2.AverageTime / num2), rLine + num3);
						num3++;
					}
					return;
				}
			}
			if (!Profiler.sProfilers.ContainsKey(rProfiler))
			{
				return;
			}
			Log.ScreenWrite(Profiler.sProfilers[rProfiler].ToString(), rLine);
		}

		// Token: 0x040000A3 RID: 163
		public string Tag = "";

		// Token: 0x040000A4 RID: 164
		private string mSpacing = "";

		// Token: 0x040000A5 RID: 165
		private int mCount;

		// Token: 0x040000A6 RID: 166
		private float mRunTime;

		// Token: 0x040000A7 RID: 167
		private float mTotalTime;

		// Token: 0x040000A8 RID: 168
		private float mMinTime;

		// Token: 0x040000A9 RID: 169
		private float mMaxTime;

		// Token: 0x040000AA RID: 170
		private Stopwatch mTimer = new Stopwatch();

		// Token: 0x040000AB RID: 171
		private float mTicksPerMillisecond;

		// Token: 0x040000AC RID: 172
		private static Dictionary<string, Profiler> sProfilers = new Dictionary<string, Profiler>();
	}
}
