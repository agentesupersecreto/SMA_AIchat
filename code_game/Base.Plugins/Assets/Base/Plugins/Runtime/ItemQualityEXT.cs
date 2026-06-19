using System;
using UnityEngine;

namespace Assets.Base.Plugins.Runtime
{
	// Token: 0x0200017C RID: 380
	public static class ItemQualityEXT
	{
		// Token: 0x06000B41 RID: 2881 RVA: 0x00025B26 File Offset: 0x00023D26
		public static ItemQuality DesPolarize(this int polar)
		{
			return polar + ItemQuality.Common;
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x00025B2C File Offset: 0x00023D2C
		public static float Promediar(this ItemQuality itemQuality1, ItemQuality itemQuality2)
		{
			float num = (float)itemQuality1;
			float num2 = (float)itemQuality2;
			return (num + num2) / 2f;
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x00025B48 File Offset: 0x00023D48
		public static float Promediar(this ItemQuality itemQuality1, ItemQuality itemQuality2, ItemQuality itemQuality3)
		{
			float num = (float)itemQuality1;
			float num2 = (float)itemQuality2;
			float num3 = (float)itemQuality3;
			return (num + num2 + num3) / 3f;
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x00025B68 File Offset: 0x00023D68
		public static float Promediar(this ItemQuality itemQuality1, ItemQuality itemQuality2, ItemQuality itemQuality3, ItemQuality itemQuality4)
		{
			float num = (float)itemQuality1;
			float num2 = (float)itemQuality2;
			float num3 = (float)itemQuality3;
			float num4 = (float)itemQuality4;
			return (num + num2 + num3 + num4) / 4f;
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x00025B8C File Offset: 0x00023D8C
		public static float Promediar(this ItemQuality itemQuality1, ItemQuality itemQuality2, ItemQuality itemQuality3, ItemQuality itemQuality4, ItemQuality itemQuality5)
		{
			float num = (float)itemQuality1;
			float num2 = (float)itemQuality2;
			float num3 = (float)itemQuality3;
			float num4 = (float)itemQuality4;
			float num5 = (float)itemQuality5;
			return (num + num2 + num3 + num4 + num5) / 5f;
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x00025BB8 File Offset: 0x00023DB8
		public static float Promediar(this ItemQuality itemQuality1, ItemQuality itemQuality2, ItemQuality itemQuality3, ItemQuality itemQuality4, ItemQuality itemQuality5, ItemQuality itemQuality6)
		{
			float num = (float)itemQuality1;
			float num2 = (float)itemQuality2;
			float num3 = (float)itemQuality3;
			float num4 = (float)itemQuality4;
			float num5 = (float)itemQuality5;
			float num6 = (float)itemQuality6;
			return (num + num2 + num3 + num4 + num5 + num6) / 6f;
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x00025BEC File Offset: 0x00023DEC
		public static float Promediar(this ItemQuality itemQuality1, params ItemQuality[] others)
		{
			float num = (float)itemQuality1;
			for (int i = 0; i < others.Length; i++)
			{
				num += (float)others[i];
			}
			return num / (float)(others.Length + 1);
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x00025C1C File Offset: 0x00023E1C
		public static ItemQuality Combinar(this ItemQuality itemQuality1, ItemQuality itemQuality2)
		{
			float num = (float)itemQuality1;
			float num2 = (float)itemQuality2;
			return (ItemQuality)Mathf.RoundToInt((num + num2) / 2f);
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x00025C3C File Offset: 0x00023E3C
		public static ItemQuality Combinar(this ItemQuality itemQuality1, ItemQuality itemQuality2, ItemQuality itemQuality3)
		{
			float num = (float)itemQuality1;
			float num2 = (float)itemQuality2;
			float num3 = (float)itemQuality3;
			return (ItemQuality)Mathf.RoundToInt((num + num2 + num3) / 3f);
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x00025C60 File Offset: 0x00023E60
		public static ItemQuality Combinar(this ItemQuality itemQuality1, ItemQuality itemQuality2, ItemQuality itemQuality3, ItemQuality itemQuality4)
		{
			float num = (float)itemQuality1;
			float num2 = (float)itemQuality2;
			float num3 = (float)itemQuality3;
			float num4 = (float)itemQuality4;
			return (ItemQuality)Mathf.RoundToInt((num + num2 + num3 + num4) / 4f);
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x00025C8C File Offset: 0x00023E8C
		public static ItemQuality Combinar(this ItemQuality itemQuality1, ItemQuality itemQuality2, ItemQuality itemQuality3, ItemQuality itemQuality4, ItemQuality itemQuality5)
		{
			float num = (float)itemQuality1;
			float num2 = (float)itemQuality2;
			float num3 = (float)itemQuality3;
			float num4 = (float)itemQuality4;
			float num5 = (float)itemQuality5;
			return (ItemQuality)Mathf.RoundToInt((num + num2 + num3 + num4 + num5) / 5f);
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x00025CBC File Offset: 0x00023EBC
		public static ItemQuality Combinar(this ItemQuality itemQuality1, ItemQuality itemQuality2, ItemQuality itemQuality3, ItemQuality itemQuality4, ItemQuality itemQuality5, ItemQuality itemQuality6)
		{
			float num = (float)itemQuality1;
			float num2 = (float)itemQuality2;
			float num3 = (float)itemQuality3;
			float num4 = (float)itemQuality4;
			float num5 = (float)itemQuality5;
			float num6 = (float)itemQuality6;
			return (ItemQuality)Mathf.RoundToInt((num + num2 + num3 + num4 + num5 + num6) / 6f);
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x00025CF4 File Offset: 0x00023EF4
		public static ItemQuality Combinar(this ItemQuality itemQuality1, params ItemQuality[] others)
		{
			float num = (float)itemQuality1;
			for (int i = 0; i < others.Length; i++)
			{
				num += (float)others[i];
			}
			return (ItemQuality)Mathf.RoundToInt(num / (float)(others.Length + 1));
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x00025D26 File Offset: 0x00023F26
		public static Color GetColorParaFondoNegro(this ItemQuality itemQuality)
		{
			return Color.Lerp(itemQuality.GetColor(), Color.white, 0.333f);
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x00025D40 File Offset: 0x00023F40
		public static Color GetColor(this ItemQuality itemQuality)
		{
			switch (itemQuality)
			{
			case ItemQuality.None:
			case ItemQuality.Poor:
				return Color.grey;
			case ItemQuality.Doomed:
				return new Color(0.18f, 0.31f, 0.31f);
			case ItemQuality.Cursed:
				return new Color(0.38f, 0f, 0f);
			case ItemQuality.Haunted:
				return new Color(0.2f, 0f, 0.4f);
			case ItemQuality.Brittle:
				return Color.Lerp(Color.black, Color.grey, 0.666f);
			case ItemQuality.Defective:
				return new Color(0.4f, 0.13f, 0.13f);
			case ItemQuality.Common:
				return Color.white;
			case ItemQuality.Uncommon:
				return new Color(0.12f, 1f, 0f);
			case ItemQuality.Rare:
				return new Color(0f, 0.44f, 0.87f);
			case ItemQuality.Epic:
				return new Color(0.64f, 0.21f, 0.93f);
			case ItemQuality.Legendary:
				return new Color(1f, 0.5f, 0f);
			case ItemQuality.Artifact:
				return new Color(0.9f, 0.8f, 0.5f);
			case ItemQuality.Relic:
				return new Color(1f, 0.753f, 0.796f);
			default:
				throw new ArgumentOutOfRangeException(itemQuality.ToString());
			}
		}
	}
}
