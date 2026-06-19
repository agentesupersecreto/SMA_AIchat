using System;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002C9 RID: 713
	[Serializable]
	public class ScaledValue
	{
		// Token: 0x06001D6B RID: 7531 RVA: 0x00038E24 File Offset: 0x00037024
		public ScaledValue(ValueScale scale, float value)
		{
			this.scale = scale;
			this.value = value;
		}

		// Token: 0x06001D6C RID: 7532 RVA: 0x00038E3C File Offset: 0x0003703C
		public ScaledValue(ScaledValue source)
		{
			if (source != null)
			{
				this.scale = source.scale;
				this.value = source.value;
			}
		}

		// Token: 0x06001D6D RID: 7533 RVA: 0x00038E70 File Offset: 0x00037070
		public ScaledValue()
		{
		}

		// Token: 0x06001D6F RID: 7535 RVA: 0x00038EA8 File Offset: 0x000370A8
		public float GetPixelValue(float windowSize)
		{
			if (this.scale == ValueScale.Pixel)
			{
				return this.value;
			}
			return this.value * windowSize;
		}

		// Token: 0x06001D70 RID: 7536 RVA: 0x00038EC4 File Offset: 0x000370C4
		public static ScaledValue FromPixelValue(float value)
		{
			return new ScaledValue(ValueScale.Pixel, value);
		}

		// Token: 0x06001D71 RID: 7537 RVA: 0x00038ED0 File Offset: 0x000370D0
		public static ScaledValue FromNormalizedValue(float value)
		{
			return new ScaledValue(ValueScale.Normalized, value);
		}

		// Token: 0x040010E7 RID: 4327
		public static readonly ScaledValue zero = new ScaledValue(ValueScale.Pixel, 0f);

		// Token: 0x040010E8 RID: 4328
		public static readonly ScaledValue max = new ScaledValue(ValueScale.Normalized, 1f);

		// Token: 0x040010E9 RID: 4329
		public ValueScale scale;

		// Token: 0x040010EA RID: 4330
		public float value;
	}
}
