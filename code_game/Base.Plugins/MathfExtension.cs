using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

// Token: 0x02000019 RID: 25
public static class MathfExtension
{
	// Token: 0x060000C3 RID: 195 RVA: 0x00006090 File Offset: 0x00004290
	public static float DiminishingReturnAdd(float value, float maxValue, float power)
	{
		if (maxValue < 0f)
		{
			throw new InvalidCastException();
		}
		value = ((value < 0f) ? 0f : value);
		float num = MathfExtension.InverseLerpUnclamped(0f, maxValue, value);
		float num2 = 1f - Mathf.Exp(-num * power);
		return MathfExtension.Lerp(0f, maxValue, num2);
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x000060E8 File Offset: 0x000042E8
	public static float DiminishingReturnMul(float mod, float minMod, float maxMod, float power)
	{
		if (minMod > 1f || minMod <= 0f)
		{
			throw new InvalidCastException();
		}
		if (maxMod < 1f)
		{
			throw new InvalidCastException();
		}
		mod = ((mod <= 0f) ? 1f : mod);
		bool flag = mod < 1f;
		float num = (flag ? MathfExtension.InverseLerpUnclamped(1f, 1f / minMod, 1f / mod) : MathfExtension.InverseLerpUnclamped(1f, maxMod, mod));
		float num2 = 1f - Mathf.Exp(-num * power);
		if (!flag)
		{
			return MathfExtension.Lerp(1f, maxMod, num2);
		}
		return 1f / MathfExtension.Lerp(1f, 1f / minMod, num2);
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00006194 File Offset: 0x00004394
	public static float DiminishingReturnAdd(float value, float minValue, float maxValue, float power)
	{
		if (minValue > 0f)
		{
			throw new InvalidCastException();
		}
		if (maxValue < 0f)
		{
			throw new InvalidCastException();
		}
		bool flag = value < 0f;
		float num = MathfExtension.InverseLerpUnclampedAlMedio(minValue, 0f, maxValue, value);
		float num2 = 1f - Mathf.Exp(-num * power);
		if (!flag)
		{
			return MathfExtension.Lerp(0f, maxValue, num2);
		}
		return MathfExtension.Lerp(0f, minValue, num2);
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x000061FE File Offset: 0x000043FE
	public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTimeIncreasing, float smoothTimeDecreasing)
	{
		return Mathf.SmoothDamp(current, target, ref currentVelocity, (current < target) ? smoothTimeIncreasing : smoothTimeDecreasing);
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x00006211 File Offset: 0x00004411
	public static float Max(float a, float b, float c, float d)
	{
		return Mathf.Max(a, Mathf.Max(b, Mathf.Max(c, d)));
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x00006226 File Offset: 0x00004426
	public static float Max(float a, float b, float c, float d, float e)
	{
		return Mathf.Max(a, Mathf.Max(b, Mathf.Max(c, Mathf.Max(d, e))));
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x00006242 File Offset: 0x00004442
	public static float Max(float a, float b, float c, float d, float e, float f, float g)
	{
		return Mathf.Max(a, Mathf.Max(b, Mathf.Max(c, Mathf.Max(d, Mathf.Max(e, Mathf.Max(f, g))))));
	}

	// Token: 0x060000CA RID: 202 RVA: 0x0000626C File Offset: 0x0000446C
	public static int Max(int a, int b, int c, int d)
	{
		return Mathf.Max(a, Mathf.Max(b, Mathf.Max(c, d)));
	}

	// Token: 0x060000CB RID: 203 RVA: 0x00006281 File Offset: 0x00004481
	public static int Max(int a, int b, int c, int d, int e)
	{
		return Mathf.Max(a, Mathf.Max(b, Mathf.Max(c, Mathf.Max(d, e))));
	}

	// Token: 0x060000CC RID: 204 RVA: 0x0000629D File Offset: 0x0000449D
	public static int Max(int a, int b, int c, int d, int e, int f, int g)
	{
		return Mathf.Max(a, Mathf.Max(b, Mathf.Max(c, Mathf.Max(d, Mathf.Max(e, Mathf.Max(f, g))))));
	}

	// Token: 0x060000CD RID: 205 RVA: 0x000062C8 File Offset: 0x000044C8
	public static void Normalizar(ref float a, ref float b, ref float c, ref float d)
	{
		a = Mathf.Clamp01(a);
		b = Mathf.Clamp01(b);
		c = Mathf.Clamp01(c);
		d = Mathf.Clamp01(d);
		float num = a + b + c + d;
		if (num == 0f)
		{
			a = 0.25f;
			b = 0.25f;
			c = 0.25f;
			d = 0.25f;
			return;
		}
		a /= num;
		b /= num;
		c /= num;
		d /= num;
	}

	// Token: 0x060000CE RID: 206 RVA: 0x00006344 File Offset: 0x00004544
	public static float ExagerarWeigths(this IReadOnlyList<float> weigths, ref float[] resultMods, float power)
	{
		if (resultMods == null || resultMods.Length != weigths.Count)
		{
			resultMods = weigths.ToArray<float>();
		}
		float num = float.MinValue;
		for (int i = 0; i < weigths.Count; i++)
		{
			float num2 = Mathf.Clamp01(weigths[i]);
			if (num2 > num)
			{
				num = num2;
			}
		}
		if (num == 0f)
		{
			for (int j = 0; j < resultMods.Length; j++)
			{
				resultMods[j] = 1f;
			}
			return 0f;
		}
		for (int k = 0; k < weigths.Count; k++)
		{
			float num3 = Mathf.Clamp01(weigths[k]);
			float num4 = num3;
			num4 /= num;
			num4 = num4.InPow(power);
			num4 *= num;
			if (num3 > 0f)
			{
				num4 /= num3;
				resultMods[k] = num4;
			}
			else
			{
				resultMods[k] = 1f;
			}
		}
		return num;
	}

	// Token: 0x060000CF RID: 207 RVA: 0x0000641C File Offset: 0x0000461C
	public static float ExagerarWeigths(ref float a, ref float b, ref float c, ref float d, float power)
	{
		a = Mathf.Clamp01(a);
		b = Mathf.Clamp01(b);
		c = Mathf.Clamp01(c);
		d = Mathf.Clamp01(d);
		float num = Mathf.Max(a, Mathf.Max(b, Mathf.Max(c, d)));
		if (num == 0f)
		{
			return 0f;
		}
		a /= num;
		b /= num;
		c /= num;
		d /= num;
		a = a.InPow(power);
		b = b.InPow(power);
		c = c.InPow(power);
		d = d.InPow(power);
		a *= num;
		b *= num;
		c *= num;
		d *= num;
		return num;
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x000064D0 File Offset: 0x000046D0
	public static void ExagerarWeigths(ref float a, ref float b, ref float c, ref float d, ref float e, float power)
	{
		a = Mathf.Clamp01(a);
		b = Mathf.Clamp01(b);
		c = Mathf.Clamp01(c);
		d = Mathf.Clamp01(d);
		e = Mathf.Clamp01(e);
		float num = Mathf.Max(a, Mathf.Max(b, Mathf.Max(c, Mathf.Max(d, e))));
		if (num == 0f)
		{
			return;
		}
		a /= num;
		b /= num;
		c /= num;
		d /= num;
		e /= num;
		a = a.InPow(power);
		b = b.InPow(power);
		c = c.InPow(power);
		d = d.InPow(power);
		e = e.InPow(power);
		a *= num;
		b *= num;
		c *= num;
		d *= num;
		e *= num;
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x000065B0 File Offset: 0x000047B0
	public static void ExagerarWeigths(ref float a, ref float b, ref float c, ref float d, ref float e, ref float f, ref float g, float power)
	{
		a = Mathf.Clamp01(a);
		b = Mathf.Clamp01(b);
		c = Mathf.Clamp01(c);
		d = Mathf.Clamp01(d);
		e = Mathf.Clamp01(e);
		f = Mathf.Clamp01(f);
		g = Mathf.Clamp01(g);
		float num = Mathf.Max(a, Mathf.Max(b, Mathf.Max(c, Mathf.Max(d, Mathf.Max(e, Mathf.Max(f, g))))));
		if (num == 0f)
		{
			return;
		}
		a /= num;
		b /= num;
		c /= num;
		d /= num;
		e /= num;
		f /= num;
		g /= num;
		a = a.InPow(power);
		b = b.InPow(power);
		c = c.InPow(power);
		d = d.InPow(power);
		e = e.InPow(power);
		f = f.InPow(power);
		g = g.InPow(power);
		a *= num;
		b *= num;
		c *= num;
		d *= num;
		e *= num;
		f *= num;
		g *= num;
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x000066EE File Offset: 0x000048EE
	public static bool EnRango(float testValue, float bound1, float bound2)
	{
		return testValue >= Mathf.Min(bound1, bound2) && testValue <= Mathf.Max(bound1, bound2);
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x00006709 File Offset: 0x00004909
	public static bool EnRangoMinimo(float testValue, float bound1, float bound2)
	{
		return testValue >= Mathf.Min(bound1, bound2);
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x00006718 File Offset: 0x00004918
	public static Vector3 RandomLocalDirection(float minAngle, float maxAngle)
	{
		float num = minAngle.ToDirectionAngle();
		float num2 = maxAngle.ToDirectionAngle();
		float num3 = minAngle.ToRectAngle();
		float num4 = maxAngle.ToRectAngle();
		float num5 = Mathf.InverseLerp(0f, 180f, num);
		float num6 = Mathf.InverseLerp(0f, 180f, num2);
		num5 = MathfExtension.LerpConMedio(1f, 0f, -1f, num5);
		num6 = MathfExtension.LerpConMedio(1f, 0f, -1f, num6);
		float num7 = Mathf.InverseLerp(0f, 90f, num3);
		float num8 = Mathf.InverseLerp(0f, 90f, num4);
		return new Vector3(global::UnityEngine.Random.Range(num7, num8) * MathfExtension.RandomPolarizacion(), global::UnityEngine.Random.Range(num7, num8) * MathfExtension.RandomPolarizacion(), global::UnityEngine.Random.Range(num5, num6));
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x000067E5 File Offset: 0x000049E5
	public static float RandomPolarizacion()
	{
		if (global::UnityEngine.Random.value <= 0.5f)
		{
			return 1f;
		}
		return -1f;
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00006800 File Offset: 0x00004A00
	public static float ModularClamp(float val, float min, float max, float rangemin = -180f, float rangemax = 180f)
	{
		float num = Mathf.Abs(rangemax - rangemin);
		if ((val %= num) < 0f)
		{
			val += num;
		}
		return Mathf.Clamp(val + Mathf.Min(rangemin, rangemax), min, max);
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x0000683C File Offset: 0x00004A3C
	public static float ClampAngle(float angle, float min, float max)
	{
		float num = (min + max) * 0.5f - 180f;
		float num2 = (float)(Mathf.FloorToInt((angle - num) / 360f) * 360);
		min += num2;
		max += num2;
		return Mathf.Clamp(angle, min, max);
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00006881 File Offset: 0x00004A81
	public static float ClampAngle2(float angle, float min, float max)
	{
		return MathfExtension.ClampAngle(angle, min, max) % 360f;
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x00006894 File Offset: 0x00004A94
	public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
	{
		Vector3 vector = b - a;
		return Vector3.Dot(value - a, vector) / Vector3.Dot(vector, vector);
	}

	// Token: 0x060000DA RID: 218 RVA: 0x000068C0 File Offset: 0x00004AC0
	public static float MoveTowardsSmoothEnd(float current, float target, float maxDelta, float smoothEnd_OutPower)
	{
		float num = 1f - Mathf.InverseLerp(0f, current, target);
		num = Mathf.Clamp(num, 0.0001f, float.MaxValue);
		num = num.OutPow(smoothEnd_OutPower);
		return Mathf.MoveTowards(current, target, maxDelta * num);
	}

	// Token: 0x060000DB RID: 219 RVA: 0x00006903 File Offset: 0x00004B03
	public static bool Approximately(Vector3 a, Vector3 b, float epsilonSq = 0.0001f)
	{
		return Vector3.SqrMagnitude(a - b) <= epsilonSq;
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00006917 File Offset: 0x00004B17
	public static bool Approximately(Quaternion a, Quaternion b, float range = 0f)
	{
		return Quaternion.Dot(a, b) >= 1f - range;
	}

	// Token: 0x060000DD RID: 221 RVA: 0x0000692C File Offset: 0x00004B2C
	public static bool Approximately(float a, float b, float epsilon = 1E-45f)
	{
		return a.AlmostEqualV2(b, epsilon);
	}

	// Token: 0x060000DE RID: 222 RVA: 0x00006938 File Offset: 0x00004B38
	public static bool AlmostEqual(Vector2 v1, Vector2 v2, float precision = 0.001f)
	{
		float num = v1.x - v2.x;
		if (((num < 0f) ? (num * -1f) : num) > precision)
		{
			return false;
		}
		float num2 = v1.y - v2.y;
		return ((num2 < 0f) ? (num2 * -1f) : num2) <= precision;
	}

	// Token: 0x060000DF RID: 223 RVA: 0x00006990 File Offset: 0x00004B90
	public static bool AlmostEqualV2(this float a, float b, float epsilon = 1E-45f)
	{
		if (a == b)
		{
			return true;
		}
		float num = math.abs(a);
		float num2 = math.abs(b);
		float num3 = math.abs(a - b);
		if (a == 0f || b == 0f || num + num2 < 1.1754944E-38f)
		{
			return num3 < epsilon * 1.1754944E-38f;
		}
		return num3 / (num + num2) < epsilon;
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x000069E8 File Offset: 0x00004BE8
	public static bool AlmostEqual(Vector3 v1, Vector3 v2, float precision = 0.001f)
	{
		float num = v1.x - v2.x;
		if (((num < 0f) ? (num * -1f) : num) > precision)
		{
			return false;
		}
		float num2 = v1.y - v2.y;
		if (((num2 < 0f) ? (num2 * -1f) : num2) > precision)
		{
			return false;
		}
		float num3 = v1.z - v2.z;
		return ((num3 < 0f) ? (num3 * -1f) : num3) <= precision;
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x00006A68 File Offset: 0x00004C68
	public static bool AlmostEqual(ref Vector3 v1, ref Vector3 v2, float precision)
	{
		float num = v1.x - v2.x;
		if (((num < 0f) ? (num * -1f) : num) > precision)
		{
			return false;
		}
		float num2 = v1.y - v2.y;
		if (((num2 < 0f) ? (num2 * -1f) : num2) > precision)
		{
			return false;
		}
		float num3 = v1.z - v2.z;
		return ((num3 < 0f) ? (num3 * -1f) : num3) <= precision;
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x00006AE8 File Offset: 0x00004CE8
	public static bool AlmostEqual(Quaternion q1, Quaternion q2, float maxAngleDegrees = 0.1f)
	{
		float num = Mathf.Cos(maxAngleDegrees * 0.017453292f * 0.5f);
		return Mathf.Abs(Quaternion.Dot(q1, q2)) >= num;
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x00006B1C File Offset: 0x00004D1C
	public static bool AlmostEqual(float v1, float v2, float precision)
	{
		float num = v1 - v2;
		return ((num < 0f) ? (num * -1f) : num) <= precision;
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x00006B48 File Offset: 0x00004D48
	public static void NormalizarWeighted(this IList<float> floats)
	{
		float num = 0f;
		for (int i = 0; i < floats.Count; i++)
		{
			num += floats[i];
		}
		if (num == 0f)
		{
			return;
		}
		for (int j = 0; j < floats.Count; j++)
		{
			float num2 = floats[j];
			floats[j] = num2 / num * num2;
		}
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x00006BA4 File Offset: 0x00004DA4
	public static float Clamp01(float value, float min, float max)
	{
		if (value < min || value < 0f)
		{
			return 0f;
		}
		if (value > max || value > 1f)
		{
			return 1f;
		}
		float num = (min + max) / 2f;
		return MathfExtension.InverseLerpConMedio(min, num, max, value);
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x00006BE8 File Offset: 0x00004DE8
	public static float MoveTowardsAngleSmooth(float current, float target, float maxDelta, float smoothFrom, float outPow)
	{
		float num = Mathf.InverseLerp(0f, smoothFrom, Mathf.Abs(current - target)).OutPow(outPow);
		num = Mathf.Max(0.001f, num);
		return Mathf.MoveTowardsAngle(current, target, num * maxDelta);
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x00006C28 File Offset: 0x00004E28
	public static float LerpMinToMax(float valueToMin, float valueToMax, float min, float max, float outPower, float currentValue)
	{
		float num = Mathf.InverseLerp(valueToMin, valueToMax, currentValue);
		num = num.OutPow(outPower);
		return Mathf.Lerp(min, max, num);
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x00006C54 File Offset: 0x00004E54
	public static float LerpMinToMaxAlMedio(float valueToMin, float valueToMedio, float valueToMax, float min, float medio, float max, float outPower, float inPower, float currentValue)
	{
		float num = MathfExtension.InverseLerpConMedio(valueToMin, valueToMedio, valueToMax, currentValue);
		num = num.OutPow(outPower);
		num = num.InPow(inPower);
		return MathfExtension.LerpConMedio(min, medio, max, num);
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x00006C8C File Offset: 0x00004E8C
	public static float LerpMinToMax(float valueToMin, float valueToMax, float min, float max, float outPower, float inPower, float currentValue)
	{
		float num = Mathf.InverseLerp(valueToMin, valueToMax, currentValue);
		num = num.OutPow(outPower);
		num = num.InPow(inPower);
		return Mathf.Lerp(min, max, num);
	}

	// Token: 0x060000EA RID: 234 RVA: 0x00006CC0 File Offset: 0x00004EC0
	public static Quaternion SlerpConMedio(Quaternion a, Quaternion middle, Quaternion b, float t, float outPow1 = 1f, float outPow2 = 1f)
	{
		t = Mathf.Clamp01(t);
		if (t == 0.5f)
		{
			return middle;
		}
		if (t > 0.5f)
		{
			return Quaternion.Slerp(middle, b, Mathf.InverseLerp(0.5f, 1f, t.OutPow(outPow2)));
		}
		if (t < 0.5f)
		{
			return Quaternion.Slerp(a, middle, Mathf.InverseLerp(0f, 0.5f, t.OutPow(outPow1)));
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x060000EB RID: 235 RVA: 0x00006D34 File Offset: 0x00004F34
	public static Vector3 LerpConMedio(Vector3 a, Vector3 middle, Vector3 b, float t, float outPow1 = 1f, float outPow2 = 1f)
	{
		t = Mathf.Clamp01(t);
		if (t == 0.5f)
		{
			return middle;
		}
		if (t > 0.5f)
		{
			return Vector3.Lerp(middle, b, Mathf.InverseLerp(0.5f, 1f, t.OutPow(outPow2)));
		}
		if (t < 0.5f)
		{
			return Vector3.Lerp(a, middle, Mathf.InverseLerp(0f, 0.5f, t.OutPow(outPow1)));
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x060000EC RID: 236 RVA: 0x00006DA8 File Offset: 0x00004FA8
	public static Color LerpConMedio(Color a, Color middle, Color b, float t, float outPow1 = 1f, float outPow2 = 1f)
	{
		t = Mathf.Clamp01(t);
		if (t == 0.5f)
		{
			return middle;
		}
		if (t > 0.5f)
		{
			return Color.Lerp(middle, b, Mathf.InverseLerp(0.5f, 1f, t.OutPow(outPow2)));
		}
		if (t < 0.5f)
		{
			return Color.Lerp(a, middle, Mathf.InverseLerp(0f, 0.5f, t.OutPow(outPow1)));
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x060000ED RID: 237 RVA: 0x00006E1C File Offset: 0x0000501C
	public static Vector3 SlerpConMedio(Vector3 a, Vector3 middle, Vector3 b, float t, float outPow1 = 1f, float outPow2 = 1f)
	{
		t = Mathf.Clamp01(t);
		if (t == 0.5f)
		{
			return middle;
		}
		if (t > 0.5f)
		{
			return Vector3.Slerp(middle, b, Mathf.InverseLerp(0.5f, 1f, t.OutPow(outPow2)));
		}
		if (t < 0.5f)
		{
			return Vector3.Slerp(a, middle, Mathf.InverseLerp(0f, 0.5f, t.OutPow(outPow1)));
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x060000EE RID: 238 RVA: 0x00006E90 File Offset: 0x00005090
	public static float LerpConMedio(float _0, float _33, float _66, float _100, float t)
	{
		t = Mathf.Clamp01(t);
		if (t >= 0.6666667f)
		{
			return Mathf.Lerp(_66, _100, Mathf.InverseLerp(0.6666667f, 1f, t));
		}
		if (t < 0.6666667f && t > 0.33333334f)
		{
			return Mathf.Lerp(_33, _66, Mathf.InverseLerp(0.33333334f, 0.6666667f, t));
		}
		if (t <= 0.33333334f)
		{
			return Mathf.Lerp(_0, _33, Mathf.InverseLerp(0f, 0.33333334f, t));
		}
		throw new ArgumentOutOfRangeException();
	}

	// Token: 0x060000EF RID: 239 RVA: 0x00006F1C File Offset: 0x0000511C
	public static float LerpConMedio(float a, float middle, float b, float t)
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

	// Token: 0x060000F0 RID: 240 RVA: 0x00006F80 File Offset: 0x00005180
	public static float MultiLerp(float t, [TupleElementNames(new string[] { "value", "innerT" })] params ValueTuple<float, float>[] sortedPuntos)
	{
		float num;
		float num2;
		float num3;
		MathfExtension.MultiLerp_GetStartEnd<float>(t, 0f, out num, out num2, out num3, sortedPuntos);
		return Mathf.Lerp(num, num2, num3);
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x00006FA8 File Offset: 0x000051A8
	public static Vector3 MultiLerp(float t, [TupleElementNames(new string[] { "punto", "innerT" })] params ValueTuple<Vector3, float>[] sortedPuntos)
	{
		Vector3 vector;
		Vector3 vector2;
		float num;
		MathfExtension.MultiLerp_GetStartEnd<Vector3>(t, Vector3.zero, out vector, out vector2, out num, sortedPuntos);
		return Vector3.Lerp(vector, vector2, num);
	}

	// Token: 0x060000F2 RID: 242 RVA: 0x00006FD0 File Offset: 0x000051D0
	public static Vector3 MultiSlerp(float t, [TupleElementNames(new string[] { "punto", "innerT" })] params ValueTuple<Vector3, float>[] sortedPuntos)
	{
		Vector3 vector;
		Vector3 vector2;
		float num;
		MathfExtension.MultiLerp_GetStartEnd<Vector3>(t, Vector3.zero, out vector, out vector2, out num, sortedPuntos);
		return Vector3.Slerp(vector, vector2, num);
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x00006FF8 File Offset: 0x000051F8
	public static Quaternion MultiSlerp(float t, [TupleElementNames(new string[] { "punto", "innerT" })] params ValueTuple<Quaternion, float>[] sortedPuntos)
	{
		Quaternion quaternion;
		Quaternion quaternion2;
		float num;
		MathfExtension.MultiLerp_GetStartEnd<Quaternion>(t, Quaternion.identity, out quaternion, out quaternion2, out num, sortedPuntos);
		return Quaternion.Slerp(quaternion, quaternion2, num);
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x00007020 File Offset: 0x00005220
	private static void MultiLerp_GetStartEnd<T>(float t, T defaultValue, out T start, out T end, out float innerT, [TupleElementNames(new string[] { "punto", "innerT" })] params ValueTuple<T, float>[] sorted)
	{
		t = Mathf.Clamp01(t);
		if (sorted.Length == 0)
		{
			start = defaultValue;
			end = defaultValue;
			innerT = 0f;
			return;
		}
		if (sorted.Length == 1)
		{
			start = sorted[0].Item1;
			end = sorted[0].Item1;
			innerT = 0f;
			return;
		}
		if (sorted[0].Item2 != 0f)
		{
			Debug.LogError("puntos no estar hechos correctamente");
		}
		if (sorted[sorted.Length - 1].Item2 != 1f)
		{
			Debug.LogError("puntos no estar hechos correctamente");
		}
		int num = -1;
		int num2 = -1;
		if (sorted.Length == 2)
		{
			num = 0;
			num2 = 1;
		}
		else
		{
			ValueTuple<T, float> valueTuple = sorted[0];
			for (int i = 1; i < sorted.Length; i++)
			{
				ValueTuple<T, float> valueTuple2 = sorted[i];
				if (t >= valueTuple.Item2 && t <= valueTuple2.Item2)
				{
					num = i - 1;
					num2 = i;
					break;
				}
				valueTuple = valueTuple2;
			}
		}
		ValueTuple<T, float> valueTuple3 = sorted[num];
		ValueTuple<T, float> valueTuple4 = sorted[num2];
		innerT = Mathf.InverseLerp(valueTuple3.Item2, valueTuple4.Item2, t);
		start = valueTuple3.Item1;
		end = valueTuple4.Item1;
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x00007164 File Offset: 0x00005364
	public static float LerpPolarizadoDeDespalzamiento(float min, float middle, float max, float modPolarizado, bool invertir = false)
	{
		if (modPolarizado == 0f)
		{
			return middle;
		}
		if (invertir)
		{
			modPolarizado *= -1f;
			float num = min;
			min = max;
			max = num;
		}
		if (modPolarizado < 0f)
		{
			float num2 = Mathf.Clamp01(Mathf.Abs(modPolarizado));
			return Mathf.Lerp(middle, -min, num2);
		}
		float num3 = Mathf.Clamp01(modPolarizado);
		return Mathf.Lerp(middle, max, num3);
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x000071BC File Offset: 0x000053BC
	public static float LerpPolarizado(float min, float middle, float max, float modPolarizado, bool invertir = false)
	{
		if (modPolarizado == 0f)
		{
			return middle;
		}
		if (invertir)
		{
			modPolarizado *= -1f;
			int num = ((min < 0f) ? (-1) : 1);
			int num2 = ((max < 0f) ? (-1) : 1);
			float num3 = Mathf.Abs(min);
			min = Mathf.Abs(max) * (float)num;
			max = num3 * (float)num2;
		}
		if (modPolarizado < 0f)
		{
			float num4 = Mathf.Clamp01(Mathf.Abs(modPolarizado));
			return Mathf.Lerp(middle, min, num4);
		}
		float num5 = Mathf.Clamp01(modPolarizado);
		return Mathf.Lerp(middle, max, num5);
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x0000723C File Offset: 0x0000543C
	public static float LerpPolarizado(float min, float middle, float max, float modPolarizado, float modPolarizadoPost)
	{
		float num = MathfExtension.LerpPolarizado(min, middle, max, modPolarizado, false);
		if (modPolarizadoPost < 0f)
		{
			float num2 = Mathf.Clamp01(Mathf.Abs(modPolarizadoPost));
			return Mathf.Lerp(num, min, num2);
		}
		float num3 = Mathf.Clamp01(modPolarizadoPost);
		return Mathf.Lerp(num, max, num3);
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x00007284 File Offset: 0x00005484
	public static Vector3 LerpPolarizado(Vector3 min, Vector3 middle, Vector3 max, float modPolarizado)
	{
		if (modPolarizado == 0f)
		{
			return middle;
		}
		if (modPolarizado < 0f)
		{
			float num = Mathf.Clamp01(Mathf.Abs(modPolarizado));
			return Vector3.Lerp(middle, min, num);
		}
		float num2 = Mathf.Clamp01(modPolarizado);
		return Vector3.Lerp(middle, max, num2);
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x000072C7 File Offset: 0x000054C7
	public static double Lerp(double from, double to, double value)
	{
		if (value < 0.0)
		{
			return from;
		}
		if (value > 1.0)
		{
			return to;
		}
		return (to - from) * value + from;
	}

	// Token: 0x060000FA RID: 250 RVA: 0x000072EC File Offset: 0x000054EC
	public static float Lerp(float from, float to, float value)
	{
		if (value < 0f)
		{
			return from;
		}
		if (value > 1f)
		{
			return to;
		}
		return (to - from) * value + from;
	}

	// Token: 0x060000FB RID: 251 RVA: 0x00007309 File Offset: 0x00005509
	public static float LerpUnclamped(float from, float to, float value)
	{
		return (1f - value) * from + value * to;
	}

	// Token: 0x060000FC RID: 252 RVA: 0x00007318 File Offset: 0x00005518
	public static double Clamp01(double value)
	{
		if (value > 1.0)
		{
			return 1.0;
		}
		if (value < 0.0)
		{
			return 0.0;
		}
		return value;
	}

	// Token: 0x060000FD RID: 253 RVA: 0x00007348 File Offset: 0x00005548
	public static double InverseLerp(double from, double to, double value)
	{
		if (from < to)
		{
			if (value < from)
			{
				return 0.0;
			}
			if (value > to)
			{
				return 1.0;
			}
		}
		else
		{
			if (value < to)
			{
				return 1.0;
			}
			if (value > from)
			{
				return 0.0;
			}
		}
		return (value - from) / (to - from);
	}

	// Token: 0x060000FE RID: 254 RVA: 0x00007398 File Offset: 0x00005598
	public static float InverseLerp(float from, float to, float value)
	{
		if (from < to)
		{
			if (value < from)
			{
				return 0f;
			}
			if (value > to)
			{
				return 1f;
			}
		}
		else
		{
			if (value < to)
			{
				return 1f;
			}
			if (value > from)
			{
				return 0f;
			}
		}
		return (value - from) / (to - from);
	}

	// Token: 0x060000FF RID: 255 RVA: 0x000073CD File Offset: 0x000055CD
	public static float InverseLerpPolarizado(float min, float middle, float max, float value)
	{
		if (value > middle)
		{
			return Mathf.InverseLerp(middle, max, value);
		}
		if (value < middle)
		{
			return -Mathf.InverseLerp(middle, min, value);
		}
		return 0f;
	}

	// Token: 0x06000100 RID: 256 RVA: 0x000073F0 File Offset: 0x000055F0
	public static float InverseLerpConMedio(float min, float middle, float max, float value)
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

	// Token: 0x06000101 RID: 257 RVA: 0x00007458 File Offset: 0x00005658
	public static float InverseLerpConMedio(float _0, float _33, float _66, float _100, float value)
	{
		bool flag = _0 > _100;
		if (flag)
		{
			float num = _0;
			float num2 = _33;
			float num3 = _66;
			_0 = _100;
			_33 = num3;
			_66 = num2;
			_100 = num;
		}
		if (_0 > _100)
		{
			throw new InvalidOperationException();
		}
		float num4;
		if (value >= _66)
		{
			num4 = Mathf.Lerp(0.6666667f, 1f, Mathf.InverseLerp(_66, _100, value));
		}
		else if (value < _66 && value > _33)
		{
			num4 = Mathf.Lerp(0.33333334f, 0.6666667f, Mathf.InverseLerp(_33, _66, value));
		}
		else
		{
			if (value > _33)
			{
				throw new ArgumentOutOfRangeException();
			}
			num4 = Mathf.Lerp(0f, 0.33333334f, Mathf.InverseLerp(_0, _33, value));
		}
		if (flag)
		{
			num4 = 1f - num4;
		}
		return num4;
	}

	// Token: 0x06000102 RID: 258 RVA: 0x000074F8 File Offset: 0x000056F8
	public static float InverseLerpAlMedio(float min, float middle, float max, float value)
	{
		float num;
		if (middle == value)
		{
			num = 1f;
		}
		else if (value > middle)
		{
			num = 1f - Mathf.InverseLerp(middle, max, value);
		}
		else
		{
			if (value >= middle)
			{
				throw new ArgumentOutOfRangeException();
			}
			num = Mathf.InverseLerp(min, middle, value);
		}
		return num;
	}

	// Token: 0x06000103 RID: 259 RVA: 0x0000753C File Offset: 0x0000573C
	public static float InverseLerpUnclampedAlMedio(float min, float middle, float max, float value)
	{
		float num;
		if (middle == value)
		{
			num = 0f;
		}
		else if (value > middle)
		{
			num = MathfExtension.InverseLerpUnclamped(middle, max, value);
		}
		else
		{
			if (value >= middle)
			{
				throw new ArgumentOutOfRangeException();
			}
			num = MathfExtension.InverseLerpUnclamped(middle, min, value);
		}
		return num;
	}

	// Token: 0x06000104 RID: 260 RVA: 0x0000757A File Offset: 0x0000577A
	public static float InverseLerpUnclamped(float a, float b, float value)
	{
		if (a == b)
		{
			return 0f;
		}
		return (value - a) / (b - a);
	}

	// Token: 0x06000105 RID: 261 RVA: 0x0000758D File Offset: 0x0000578D
	public static float SmoothStep(float from, float to, float value)
	{
		if (value < 0f)
		{
			return from;
		}
		if (value > 1f)
		{
			return to;
		}
		value = value * value * (3f - 2f * value);
		return (1f - value) * from + value * to;
	}

	// Token: 0x06000106 RID: 262 RVA: 0x000075C3 File Offset: 0x000057C3
	public static float SmoothStepUnclamped(float from, float to, float value)
	{
		value = value * value * (3f - 2f * value);
		return (1f - value) * from + value * to;
	}

	// Token: 0x06000107 RID: 263 RVA: 0x000075E5 File Offset: 0x000057E5
	public static float SuperLerp(float from, float to, float from2, float to2, float value)
	{
		if (from2 < to2)
		{
			if (value < from2)
			{
				value = from2;
			}
			else if (value > to2)
			{
				value = to2;
			}
		}
		else if (value < to2)
		{
			value = to2;
		}
		else if (value > from2)
		{
			value = from2;
		}
		return (to - from) * ((value - from2) / (to2 - from2)) + from;
	}

	// Token: 0x06000108 RID: 264 RVA: 0x0000761F File Offset: 0x0000581F
	public static float SuperLerpUnclamped(float from, float to, float from2, float to2, float value)
	{
		return (to - from) * ((value - from2) / (to2 - from2)) + from;
	}

	// Token: 0x06000109 RID: 265 RVA: 0x00007630 File Offset: 0x00005830
	public static Color ColorLerp(Color c1, Color c2, float value)
	{
		if (value > 1f)
		{
			return c2;
		}
		if (value < 0f)
		{
			return c1;
		}
		return new Color(c1.r + (c2.r - c1.r) * value, c1.g + (c2.g - c1.g) * value, c1.b + (c2.b - c1.b) * value, c1.a + (c2.a - c1.a) * value);
	}

	// Token: 0x0600010A RID: 266 RVA: 0x000076B0 File Offset: 0x000058B0
	public static Vector2 Vector2Lerp(Vector2 v1, Vector2 v2, float value)
	{
		if (value > 1f)
		{
			return v2;
		}
		if (value < 0f)
		{
			return v1;
		}
		return new Vector2(v1.x + (v2.x - v1.x) * value, v1.y + (v2.y - v1.y) * value);
	}

	// Token: 0x0600010B RID: 267 RVA: 0x00007704 File Offset: 0x00005904
	public static Vector3 Vector3Lerp(Vector3 v1, Vector3 v2, float value)
	{
		if (value > 1f)
		{
			return v2;
		}
		if (value < 0f)
		{
			return v1;
		}
		return new Vector3(v1.x + (v2.x - v1.x) * value, v1.y + (v2.y - v1.y) * value, v1.z + (v2.z - v1.z) * value);
	}

	// Token: 0x0600010C RID: 268 RVA: 0x0000776C File Offset: 0x0000596C
	public static Vector4 Vector4Lerp(Vector4 v1, Vector4 v2, float value)
	{
		if (value > 1f)
		{
			return v2;
		}
		if (value < 0f)
		{
			return v1;
		}
		return new Vector4(v1.x + (v2.x - v1.x) * value, v1.y + (v2.y - v1.y) * value, v1.z + (v2.z - v1.z) * value, v1.w + (v2.w - v1.w) * value);
	}
}
