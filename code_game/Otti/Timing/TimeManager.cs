using System;
using UnityEngine;

namespace com.ootii.Timing
{
	// Token: 0x0200001D RID: 29
	public class TimeManager
	{
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000196 RID: 406 RVA: 0x0000A348 File Offset: 0x00008548
		public static int SampleCount
		{
			get
			{
				return TimeManager.mSampleCount;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000197 RID: 407 RVA: 0x0000A34F File Offset: 0x0000854F
		public static float AverageDeltaTime
		{
			get
			{
				return TimeManager._AverageDeltaTime;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000198 RID: 408 RVA: 0x0000A356 File Offset: 0x00008556
		public static float SmoothedDeltaTime
		{
			get
			{
				if (Time.deltaTime <= TimeManager._AverageDeltaTime)
				{
					return Time.deltaTime;
				}
				return TimeManager._AverageDeltaTime;
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x0000A370 File Offset: 0x00008570
		static TimeManager()
		{
			if (TimeManager.Core == null)
			{
				TimeManager.Core = new GameObject("TimeManagerCore", new Type[] { typeof(TimeManagerCore) })
				{
					hideFlags = HideFlags.HideInHierarchy
				}.GetComponent<TimeManagerCore>();
			}
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000A3F4 File Offset: 0x000085F4
		public static void Initialize()
		{
			for (int i = 0; i < TimeManager.mSampleCount; i++)
			{
				TimeManager.mSamples[i] = Time.deltaTime;
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000A420 File Offset: 0x00008620
		public static void Update()
		{
			TimeManager.Relative60FPSDeltaTime = Time.deltaTime / 0.01666f;
			TimeManager.mSamples[TimeManager.mSampleIndex++] = Time.deltaTime;
			if (TimeManager.mSampleIndex >= TimeManager.mSampleCount)
			{
				TimeManager.mSampleIndex = 0;
			}
			float num = 0f;
			for (int i = 0; i < TimeManager.mSampleCount; i++)
			{
				num += TimeManager.mSamples[i];
			}
			TimeManager._AverageDeltaTime = num / (float)TimeManager.mSampleCount;
		}

		// Token: 0x040000FA RID: 250
		public static float Relative60FPSDeltaTime = 1f;

		// Token: 0x040000FB RID: 251
		private static int mSampleCount = 30;

		// Token: 0x040000FC RID: 252
		public static float _AverageDeltaTime = Time.fixedDeltaTime;

		// Token: 0x040000FD RID: 253
		public static TimeManagerCore Core = Object.FindObjectOfType<TimeManagerCore>();

		// Token: 0x040000FE RID: 254
		private static float[] mSamples = new float[TimeManager.mSampleCount];

		// Token: 0x040000FF RID: 255
		private static int mSampleIndex = 0;
	}
}
