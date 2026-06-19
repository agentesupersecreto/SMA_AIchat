using System;

// Token: 0x02000016 RID: 22
[Serializable]
public struct LerpMinToMaxItem
{
	// Token: 0x17000011 RID: 17
	// (get) Token: 0x06000082 RID: 130 RVA: 0x00004BB8 File Offset: 0x00002DB8
	public static LerpMinToMaxItem @default
	{
		get
		{
			return new LerpMinToMaxItem
			{
				valueToMax = 1f,
				max = 1f,
				outPower = 1f,
				inPower = 1f
			};
		}
	}

	// Token: 0x06000083 RID: 131 RVA: 0x00004BFE File Offset: 0x00002DFE
	public float Lerp(float currentValue)
	{
		return MathfExtension.LerpMinToMax(this.valueToMin, this.valueToMax, this.min, this.max, this.outPower, this.inPower, currentValue);
	}

	// Token: 0x0400001C RID: 28
	public float valueToMin;

	// Token: 0x0400001D RID: 29
	public float valueToMax;

	// Token: 0x0400001E RID: 30
	public float min;

	// Token: 0x0400001F RID: 31
	public float max;

	// Token: 0x04000020 RID: 32
	public float outPower;

	// Token: 0x04000021 RID: 33
	public float inPower;
}
