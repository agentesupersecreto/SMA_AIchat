using System;
using UnityEngine;

// Token: 0x02000023 RID: 35
public class FPSCounter
{
	// Token: 0x06000161 RID: 353 RVA: 0x00008FA1 File Offset: 0x000071A1
	public static void Create()
	{
		if (FPSCounter.instance == null)
		{
			FPSCounter.instance = new FPSCounter();
			FPSCounter.instance.FPSNextPeriod = Time.realtimeSinceStartup + FPSCounter.FPSMeasurePeriod;
		}
	}

	// Token: 0x06000162 RID: 354 RVA: 0x00008FCC File Offset: 0x000071CC
	public static void Update()
	{
		FPSCounter.Create();
		FPSCounter.instance.FPSAccumulator++;
		if (Time.realtimeSinceStartup > FPSCounter.instance.FPSNextPeriod)
		{
			FPSCounter.currentFPS = (int)((float)FPSCounter.instance.FPSAccumulator / FPSCounter.FPSMeasurePeriod);
			FPSCounter.instance.FPSAccumulator = 0;
			FPSCounter.instance.FPSNextPeriod += FPSCounter.FPSMeasurePeriod;
		}
	}

	// Token: 0x04000049 RID: 73
	public static float FPSMeasurePeriod = 0.1f;

	// Token: 0x0400004A RID: 74
	private int FPSAccumulator;

	// Token: 0x0400004B RID: 75
	private float FPSNextPeriod;

	// Token: 0x0400004C RID: 76
	public static int currentFPS;

	// Token: 0x0400004D RID: 77
	private static FPSCounter instance;
}
