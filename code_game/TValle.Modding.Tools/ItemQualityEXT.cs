using System;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime
{
	// Token: 0x02000008 RID: 8
	public static class ItemQualityEXT
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00002340 File Offset: 0x00000540
		public static ItemQuality LerpToItemQuality(this float t)
		{
			return (ItemQuality)Mathf.RoundToInt(ItemQualityEXT.Lerp(1f, 7f, 13f, t));
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000235C File Offset: 0x0000055C
		public static int Polarize(this ItemQuality itemQuality)
		{
			return itemQuality - ItemQuality.Common;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002364 File Offset: 0x00000564
		private static float Lerp(float a, float middle, float b, float t)
		{
			t = Mathf.Clamp01(t);
			if (t == 0.5f)
			{
				return middle;
			}
			if (t > 0.5f)
			{
				return Mathf.Lerp(middle, b, Mathf.InverseLerp(0.5f, 1f, t));
			}
			if (t < 0.5f)
			{
				return Mathf.Lerp(a, middle, Mathf.InverseLerp(0f, 0.5f, t));
			}
			throw new ArgumentOutOfRangeException();
		}
	}
}
