using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

// Token: 0x0200001A RID: 26
public static class FloatExt
{
	// Token: 0x0600010D RID: 269 RVA: 0x000077EA File Offset: 0x000059EA
	public static string Serialized(this float value)
	{
		return value.ToString("R", CultureInfo.InvariantCulture);
	}

	// Token: 0x0600010E RID: 270 RVA: 0x00007800 File Offset: 0x00005A00
	public static float DeserializedAsFloat(this string value, float fallback = 0f)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return fallback;
		}
		float num;
		if (float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out num))
		{
			return num;
		}
		return fallback;
	}

	// Token: 0x0600010F RID: 271 RVA: 0x00007830 File Offset: 0x00005A30
	public static bool IsCorrupted(this string value)
	{
		float num;
		return string.IsNullOrWhiteSpace(value) || !float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out num);
	}

	// Token: 0x06000110 RID: 272 RVA: 0x0000785C File Offset: 0x00005A5C
	public static bool AlmostEquals(this float a, float b, float tolerance = 1.1754944E-38f)
	{
		return a == b || Mathf.Abs(a - b) < tolerance;
	}

	// Token: 0x06000111 RID: 273 RVA: 0x0000786F File Offset: 0x00005A6F
	public static float Promedio(this float a, float b)
	{
		return (a + b) / 2f;
	}

	// Token: 0x06000112 RID: 274 RVA: 0x0000787A File Offset: 0x00005A7A
	public static float Promedio(this float a, float b, float c)
	{
		return (a + b + c) / 3f;
	}

	// Token: 0x06000113 RID: 275 RVA: 0x00007888 File Offset: 0x00005A88
	public static float Promedio(this IReadOnlyList<float> valores)
	{
		if (valores.Count == 0)
		{
			return 0f;
		}
		float num = 0f;
		int count = valores.Count;
		for (int i = 0; i < count; i++)
		{
			num += valores[i];
		}
		return num / (float)count;
	}

	// Token: 0x06000114 RID: 276 RVA: 0x000078CC File Offset: 0x00005ACC
	public static float PromedioNormalizado(this float a, float b)
	{
		float num = a + b;
		if (num == 0f)
		{
			return 0f;
		}
		return a * (a / num) + b * (b / num);
	}

	// Token: 0x06000115 RID: 277 RVA: 0x000078F8 File Offset: 0x00005AF8
	public static float PromedioNormalizado(this float a, float b, float c)
	{
		float num = a + b + c;
		if (num == 0f)
		{
			return 0f;
		}
		return a * (a / num) + b * (b / num) + c * (c / num);
	}

	// Token: 0x06000116 RID: 278 RVA: 0x0000792C File Offset: 0x00005B2C
	public static float PromedioNormalizado(this IReadOnlyList<float> valores)
	{
		if (valores.Count == 0)
		{
			return 0f;
		}
		float num = 0f;
		int count = valores.Count;
		for (int i = 0; i < count; i++)
		{
			num += valores[i];
		}
		if (num == 0f)
		{
			return 0f;
		}
		float num2 = 0f;
		for (int j = 0; j < count; j++)
		{
			float num3 = valores[j];
			num2 += num3 * (num3 / num);
		}
		return num2;
	}

	// Token: 0x06000117 RID: 279 RVA: 0x000079A3 File Offset: 0x00005BA3
	public static float ZeroOrGreater(this float v)
	{
		if (v <= 0f)
		{
			return 0f;
		}
		return v;
	}

	// Token: 0x06000118 RID: 280 RVA: 0x000079B4 File Offset: 0x00005BB4
	public static double OutPow(this double x, double p)
	{
		if (x <= 0.0)
		{
			return 0.0;
		}
		if (x >= 1.0)
		{
			return 1.0;
		}
		if (p == 1.0)
		{
			return x;
		}
		return 1.0 - Math.Pow(1.0 - x, p);
	}

	// Token: 0x06000119 RID: 281 RVA: 0x00007A16 File Offset: 0x00005C16
	public static float OutPowPercentage(this float percentage, float p)
	{
		return (percentage / 100f).OutPow(p) * 100f;
	}

	// Token: 0x0600011A RID: 282 RVA: 0x00007A2B File Offset: 0x00005C2B
	public static float InPowPercentage(this float percentage, float p)
	{
		return (percentage / 100f).InPow(p) * 100f;
	}

	// Token: 0x0600011B RID: 283 RVA: 0x00007A40 File Offset: 0x00005C40
	public static float OutPow(this float x, float p)
	{
		if (x <= 0f)
		{
			return 0f;
		}
		if (x >= 1f)
		{
			return 1f;
		}
		if (p == 1f)
		{
			return x;
		}
		return 1f - Mathf.Pow(1f - x, p);
	}

	// Token: 0x0600011C RID: 284 RVA: 0x00007A7C File Offset: 0x00005C7C
	public static double InPow(this double x, double p)
	{
		if (x <= 0.0)
		{
			return 0.0;
		}
		if (x >= 1.0)
		{
			return 1.0;
		}
		if (p == 1.0)
		{
			return x;
		}
		return Math.Pow(x, p);
	}

	// Token: 0x0600011D RID: 285 RVA: 0x00007ACA File Offset: 0x00005CCA
	public static float InPow(this float x, float p)
	{
		if (x <= 0f)
		{
			return 0f;
		}
		if (x >= 1f)
		{
			return 1f;
		}
		if (p == 1f)
		{
			return x;
		}
		return Mathf.Pow(x, p);
	}

	// Token: 0x0600011E RID: 286 RVA: 0x00007AFC File Offset: 0x00005CFC
	[Obsolete("no es claro el uso y ademas es limitado")]
	public static float InPow(this float x, float p, float start)
	{
		if (x <= 0f)
		{
			return 0f;
		}
		if (x >= 1f)
		{
			return 1f;
		}
		if (x <= start)
		{
			return x;
		}
		if (start <= 0f)
		{
			return x.InPow(p);
		}
		float num = Mathf.InverseLerp(start, 1f, x);
		return Mathf.Lerp(start, 1f, num.InPow(p));
	}

	// Token: 0x0600011F RID: 287 RVA: 0x00007B5C File Offset: 0x00005D5C
	[Obsolete("no es claro el uso y ademas es limitado")]
	public static float OutPow(this float x, float p, float end)
	{
		if (x <= 0f)
		{
			return 0f;
		}
		if (x >= 1f)
		{
			return 1f;
		}
		if (x >= end)
		{
			return x;
		}
		if (end >= 1f)
		{
			return x.OutPow(p);
		}
		float num = Mathf.InverseLerp(0f, end, x);
		return Mathf.Lerp(0f, end, num.OutPow(p));
	}

	// Token: 0x06000120 RID: 288 RVA: 0x00007BBC File Offset: 0x00005DBC
	private static float _outPow(float x, float p, float start, float end)
	{
		float num = Mathf.InverseLerp(start, end, x);
		return Mathf.Lerp(start, end, num.OutPow(p));
	}

	// Token: 0x06000121 RID: 289 RVA: 0x00007BE0 File Offset: 0x00005DE0
	private static float _inPow(this float x, float p, float start, float end)
	{
		float num = Mathf.InverseLerp(start, end, x);
		return Mathf.Lerp(start, end, num.InPow(p));
	}

	// Token: 0x06000122 RID: 290 RVA: 0x00007C04 File Offset: 0x00005E04
	public static float InOutPow(this float x, float p, float middle)
	{
		if (x <= 0f)
		{
			return 0f;
		}
		if (x >= 1f)
		{
			return 1f;
		}
		if (x < middle)
		{
			return x._inPow(p, 0f, middle);
		}
		if (x > middle)
		{
			return FloatExt._outPow(x, p, middle, 1f);
		}
		return x;
	}

	// Token: 0x06000123 RID: 291 RVA: 0x00007C54 File Offset: 0x00005E54
	public static float OutInPow(this float x, float p, float middle)
	{
		if (x <= 0f)
		{
			return 0f;
		}
		if (x >= 1f)
		{
			return 1f;
		}
		if (x > middle)
		{
			return x._inPow(p, middle, 1f);
		}
		if (x < middle)
		{
			return FloatExt._outPow(x, p, 0f, middle);
		}
		return x;
	}

	// Token: 0x06000124 RID: 292 RVA: 0x00007CA4 File Offset: 0x00005EA4
	public static float OutInPowInverted(this float x, float p, float middle)
	{
		if (x <= 0f)
		{
			return 0f;
		}
		if (x >= 1f)
		{
			return 1f;
		}
		if (x > middle)
		{
			return FloatExt._outPow(x, p, middle, 1f);
		}
		if (x < middle)
		{
			return x._inPow(p, 0f, middle);
		}
		return x;
	}

	// Token: 0x06000125 RID: 293 RVA: 0x00007CF4 File Offset: 0x00005EF4
	public static float InInOutOutPow(this float x, float beforeInPow, float afterOutPow, float middle)
	{
		if (x <= 0f)
		{
			return 0f;
		}
		if (x >= 1f)
		{
			return 1f;
		}
		if (x < middle)
		{
			return x._inPow(beforeInPow, 0f, middle);
		}
		if (x > middle)
		{
			return FloatExt._outPow(x, afterOutPow, middle, 1f);
		}
		return x;
	}

	// Token: 0x06000126 RID: 294 RVA: 0x00007D44 File Offset: 0x00005F44
	public static float InInOutOutPowInverted(this float x, float beforeOutPow, float afterInPow, float middle)
	{
		if (x <= 0f)
		{
			return 0f;
		}
		if (x >= 1f)
		{
			return 1f;
		}
		if (x < middle)
		{
			return FloatExt._outPow(x, beforeOutPow, 0f, middle);
		}
		if (x > middle)
		{
			return x._inPow(afterInPow, middle, 1f);
		}
		return x;
	}

	// Token: 0x06000127 RID: 295 RVA: 0x00007D94 File Offset: 0x00005F94
	public static float InInPow(this float x, float beforeInPow, float afterInPow, float middle)
	{
		if (x <= 0f)
		{
			return 0f;
		}
		if (x >= 1f)
		{
			return 1f;
		}
		float num = x._inPow(beforeInPow, 0f, 1f);
		float num2 = x._inPow(afterInPow, 0f, 1f);
		float num3 = MathfExtension.InverseLerpConMedio(0f, middle, 1f, x);
		return Mathf.Lerp(num, num2, num3);
	}

	// Token: 0x06000128 RID: 296 RVA: 0x00007DFC File Offset: 0x00005FFC
	[Obsolete("toca hacerlo igual q ininpow ", true)]
	public static float OutOutPow(this float x, float power)
	{
		if (x <= 0f)
		{
			return 0f;
		}
		if (x >= 1f)
		{
			return 1f;
		}
		if (x < 0.5f)
		{
			return FloatExt._outPow(x, power, 0f, 0.5f);
		}
		if (x > 0.5f)
		{
			return FloatExt._outPow(x, power, 0.5f, 1f);
		}
		return x;
	}

	// Token: 0x06000129 RID: 297 RVA: 0x00007E5C File Offset: 0x0000605C
	public static float InOutPow(this float x, float power)
	{
		if (x <= 0f)
		{
			return 0f;
		}
		if (x >= 1f)
		{
			return 1f;
		}
		if (x < 0.5f)
		{
			return x._inPow(power, 0f, 0.5f);
		}
		if (x > 0.5f)
		{
			return FloatExt._outPow(x, power, 0.5f, 1f);
		}
		return x;
	}

	// Token: 0x0600012A RID: 298 RVA: 0x00007EBC File Offset: 0x000060BC
	public static float OutInPow(this float x, float inPow, float outPow, float middle)
	{
		if (x <= 0f)
		{
			return 0f;
		}
		if (x >= 1f)
		{
			return 1f;
		}
		if (x > middle)
		{
			return x._inPow(inPow, middle, 1f);
		}
		if (x < middle)
		{
			return FloatExt._outPow(x, outPow, 0f, middle);
		}
		return x;
	}

	// Token: 0x0600012B RID: 299 RVA: 0x00007F0C File Offset: 0x0000610C
	public static float OutInPowInverted(this float x, float inPow, float outPow, float middle)
	{
		if (x <= 0f)
		{
			return 0f;
		}
		if (x >= 1f)
		{
			return 1f;
		}
		if (x > middle)
		{
			return FloatExt._outPow(x, outPow, middle, 1f);
		}
		if (x < middle)
		{
			return x._inPow(inPow, 0f, middle);
		}
		return x;
	}

	// Token: 0x0600012C RID: 300 RVA: 0x00007F5C File Offset: 0x0000615C
	public static float OutInPow01(this float x, float min, float max, float inPow, float outPow, float middle)
	{
		float num = Mathf.InverseLerp(min, max, middle);
		float num2 = x.OutInPow(inPow, outPow, num);
		return Mathf.Lerp(min, max, num2);
	}

	// Token: 0x0600012D RID: 301 RVA: 0x00007F88 File Offset: 0x00006188
	public static float OutInPow01Clamped(this float x, float minClamp, float maxClamp, float inPow, float outPow, float middle)
	{
		float num = Mathf.InverseLerp(minClamp, maxClamp, x);
		float num2 = Mathf.InverseLerp(minClamp, maxClamp, middle);
		float num3 = num.OutInPow(inPow, outPow, num2);
		return Mathf.Lerp(minClamp, maxClamp, num3);
	}

	// Token: 0x0600012E RID: 302 RVA: 0x00007FBC File Offset: 0x000061BC
	public static float NormalizeToRange(this float val, float a, float b, float A, float B)
	{
		if (val <= a)
		{
			return A;
		}
		if (val >= b)
		{
			return B;
		}
		float num = (val - a) / (b - a);
		float num2 = B - A;
		return num * num2 + A;
	}

	// Token: 0x0600012F RID: 303 RVA: 0x00007FE6 File Offset: 0x000061E6
	[Obsolete]
	public static float ClampToAngle(this float val)
	{
		if (val > 360f)
		{
			return 360f;
		}
		if (val < -360f)
		{
			return -360f;
		}
		return val;
	}

	// Token: 0x06000130 RID: 304 RVA: 0x00008005 File Offset: 0x00006205
	[Obsolete]
	public static float ClampToAnglePositive(this float val)
	{
		if (val > 360f)
		{
			return 360f;
		}
		if (val < -360f)
		{
			return 360f;
		}
		if (val < 0f)
		{
			return val * -1f;
		}
		return val;
	}

	// Token: 0x06000131 RID: 305 RVA: 0x00008034 File Offset: 0x00006234
	[Obsolete]
	public static float ClampToAngle180Positive(this float val)
	{
		if (val > 180f)
		{
			return 180f;
		}
		if (val < -180f)
		{
			return 180f;
		}
		if (val < 0f)
		{
			return val * -1f;
		}
		return val;
	}

	// Token: 0x0400002A RID: 42
	public const float FLT_MIN_NORMAL = 1.1754944E-38f;
}
