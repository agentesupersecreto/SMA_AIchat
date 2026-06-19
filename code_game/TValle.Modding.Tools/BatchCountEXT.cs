using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
public static class BatchCountEXT
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static int BatchCountONE(this int arrayLength)
	{
		return Mathf.Clamp(arrayLength + 1, 1, int.MaxValue);
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002060 File Offset: 0x00000260
	public static int BatchCountAllProcessors(this int arrayLength)
	{
		if (arrayLength == 0)
		{
			return 1;
		}
		int processorCount = SystemInfo.processorCount;
		int num = ((arrayLength <= processorCount) ? 0 : 1);
		return Mathf.Clamp(arrayLength / processorCount + num, 1, int.MaxValue);
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002094 File Offset: 0x00000294
	public static int BatchCountAllProcessorsButOne(this int arrayLength)
	{
		if (arrayLength == 0)
		{
			return 1;
		}
		int num = SystemInfo.processorCount - 1;
		return Mathf.Clamp(arrayLength / num + 1, 1, int.MaxValue);
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000020C0 File Offset: 0x000002C0
	public static int BatchCountLIGHT(this int arrayLength)
	{
		if (arrayLength == 0)
		{
			return 1;
		}
		int num = Mathf.Clamp(SystemInfo.processorCount / 2, 1, int.MaxValue);
		return Mathf.Clamp(arrayLength / num + 1, 1, int.MaxValue);
	}

	// Token: 0x06000005 RID: 5 RVA: 0x000020F8 File Offset: 0x000002F8
	public static int BatchCountSUPERLIGHT(this int arrayLength)
	{
		if (arrayLength == 0)
		{
			return 1;
		}
		int num = Mathf.Clamp(SystemInfo.processorCount / 4, 1, int.MaxValue);
		return Mathf.Clamp(arrayLength / num + 1, 1, int.MaxValue);
	}
}
