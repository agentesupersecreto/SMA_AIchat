using System;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff
{
	// Token: 0x02000058 RID: 88
	public static class IFloatValuableBuffEXT
	{
		// Token: 0x060001D6 RID: 470 RVA: 0x00004595 File Offset: 0x00002795
		public static bool ValueIsValid(this IFloatValuableBuff valuable)
		{
			return float.IsFinite(valuable.buffValue);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x000045A2 File Offset: 0x000027A2
		public static int CalcAddingValuePriority(this IFloatValuableBuff valuable, float worstSubs, float bestAdds)
		{
			return IFloatValuableBuffEXT.CalcValuePriority(valuable.buffValue, worstSubs, bestAdds, 0f);
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x000045B6 File Offset: 0x000027B6
		public static int CalcMultiplyValuePriority(this IFloatValuableBuff valuable, float worstPercent, float bestPercent)
		{
			return IFloatValuableBuffEXT.CalcValuePriority((valuable.buffValue - 1f) * 100f, worstPercent, bestPercent, 0f);
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x000045D6 File Offset: 0x000027D6
		private static int CalcValuePriority(float value, float worst, float best, float @default = 0f)
		{
			return IFloatValuableBuffEXT.InverseLerp(worst, @default, best, value).LerpToItemQuality().Polarize();
		}

		// Token: 0x060001DA RID: 474 RVA: 0x000045EC File Offset: 0x000027EC
		private static float InverseLerp(float min, float middle, float max, float value)
		{
			bool flag = min > max;
			if (flag)
			{
				float num = min;
				min = max;
				max = num;
			}
			float num2;
			if (value > middle)
			{
				num2 = Mathf.Lerp(0.5f, 1f, Mathf.InverseLerp(middle, max, value));
			}
			else if (value < middle)
			{
				num2 = Mathf.Lerp(0f, 0.5f, Mathf.InverseLerp(min, middle, value));
			}
			else
			{
				num2 = 0.5f;
			}
			if (flag)
			{
				num2 = 1f - num2;
			}
			return num2;
		}
	}
}
