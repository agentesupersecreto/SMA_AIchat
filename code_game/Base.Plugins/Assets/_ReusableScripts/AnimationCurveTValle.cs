using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._ReusableScripts
{
	// Token: 0x02000176 RID: 374
	public static class AnimationCurveTValle
	{
		// Token: 0x06000B1B RID: 2843 RVA: 0x00025460 File Offset: 0x00023660
		public static AnimationCurve EaseInOut(float timeStart, float valueStart, float timeMiddle, float valueMiddle, float timeEnd, float valueEnd)
		{
			return AnimationCurveTValle.Combinar(new Keyframe[]
			{
				new Keyframe(timeStart, valueStart),
				new Keyframe(timeMiddle, valueMiddle)
			}, new Keyframe[]
			{
				new Keyframe(timeMiddle, valueMiddle),
				new Keyframe(timeEnd, valueEnd)
			});
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x000254B8 File Offset: 0x000236B8
		public static AnimationCurve Combinar(Keyframe[] a, Keyframe[] b)
		{
			Keyframe keyframe = a[a.Length - 1];
			Keyframe keyframe2 = b[0];
			int num = ((keyframe.time == keyframe2.time) ? 1 : 0);
			List<Keyframe> list = new List<Keyframe>(a);
			for (int i = num; i < b.Length; i++)
			{
				list.Add(b[i]);
			}
			return new AnimationCurve(list.ToArray());
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0002551C File Offset: 0x0002371C
		public static void SmoothAllTargentes(this AnimationCurve curve)
		{
			for (int i = 0; i < curve.length; i++)
			{
				curve.SmoothTangents(i, 0f);
			}
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x00025548 File Offset: 0x00023748
		public static void SmoothOut(this IList<Keyframe> keyframe, float startDuration, float outPower)
		{
			float num = keyframe.Duracion();
			if (startDuration > num)
			{
				return;
			}
			for (int i = 0; i < keyframe.Count; i++)
			{
				Keyframe keyframe2 = keyframe[i];
				float num2 = 1f - Mathf.InverseLerp(startDuration, num, keyframe2.time);
				keyframe2.value *= num2.OutPow(outPower);
				keyframe[i] = keyframe2;
			}
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x000255AC File Offset: 0x000237AC
		public static void Normalizar(this AnimationCurve curve)
		{
			Keyframe[] keys = curve.keys;
			keys.Normalizar();
			curve.keys = keys;
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x000255D0 File Offset: 0x000237D0
		public static void Normalizar(this IList<Keyframe> keyframe)
		{
			float num = keyframe.Duracion();
			for (int i = 0; i < keyframe.Count; i++)
			{
				Keyframe keyframe2 = keyframe[i];
				keyframe2.time /= num;
				keyframe[i] = keyframe2;
			}
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x00025614 File Offset: 0x00023814
		public static float Duracion(this IList<Keyframe> keyframe)
		{
			return keyframe[keyframe.Count - 1].time;
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x00025638 File Offset: 0x00023838
		public static float Duracion(this AnimationCurve curve)
		{
			return curve[curve.length - 1].time;
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x0002565C File Offset: 0x0002385C
		public static float MaxAmplitudAbs(this AnimationCurve curve)
		{
			float num = 0f;
			for (int i = 0; i < curve.length; i++)
			{
				float num2 = Mathf.Abs(curve[i].value);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x0002569C File Offset: 0x0002389C
		public static float MaxAmplitudAbs(this IList<Keyframe> keyframe)
		{
			float num = 0f;
			for (int i = 0; i < keyframe.Count; i++)
			{
				float num2 = Mathf.Abs(keyframe[i].value);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x000256DC File Offset: 0x000238DC
		public static bool ContieneData(this AnimationCurve curve)
		{
			return curve != null && curve.length > 0;
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x000256EC File Offset: 0x000238EC
		public static void AddTimeToAll(this AnimationCurve curve, float time)
		{
			foreach (Keyframe keyframe in curve.keys)
			{
				keyframe.time += time;
			}
			Keyframe[] keys;
			curve.keys = keys;
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x0002572C File Offset: 0x0002392C
		public static float GetCurveTimeForValue(this AnimationCurve curveToCheck, float value, int accuracy)
		{
			float time = curveToCheck.keys[0].time;
			float time2 = curveToCheck.keys[curveToCheck.length - 1].time;
			float num = time;
			float num2 = time2 - time;
			for (int i = 0; i < accuracy; i++)
			{
				float num3 = curveToCheck.Evaluate(num);
				float num4 = Mathf.Abs(value - num3);
				float num5 = num + num2;
				float num6 = curveToCheck.Evaluate(num5);
				if (Mathf.Abs(value - num6) < num4)
				{
					num = num5;
					num3 = num6;
				}
				num2 = Mathf.Abs(num2 * 0.5f) * ((Mathf.Abs(num3) > Mathf.Abs(value)) ? (-1f) : 1f);
			}
			return num;
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x000257D8 File Offset: 0x000239D8
		public static AnimationCurve MoverHaciaAdelanteConInicialEnZero(this AnimationCurve original, float time, bool fixTimeRange, bool fixValueRange)
		{
			float time2 = original[0].time;
			float num = original.Duracion();
			if (time > num)
			{
				throw new NotSupportedException();
			}
			if (time == num)
			{
				AnimationCurve animationCurve = new AnimationCurve(original.keys);
				animationCurve.AddTimeToAll(time);
				return animationCurve;
			}
			Keyframe[] array = new Keyframe[original.length * 2];
			for (int i = 0; i < original.length; i++)
			{
				array[i] = original[i];
			}
			for (int j = 0; j < original.length; j++)
			{
				Keyframe keyframe = original[j];
				keyframe.time += num;
				array[j + original.length] = keyframe;
			}
			float num2 = original.Evaluate(time);
			for (int k = 0; k < array.Length; k++)
			{
				Keyframe keyframe2 = array[k];
				keyframe2.value -= num2;
				keyframe2.time -= time;
				array[k] = keyframe2;
			}
			Keyframe[] array2;
			if (fixTimeRange)
			{
				array2 = array.FixDuracion(time2, num);
			}
			else
			{
				array2 = array;
			}
			if (fixValueRange)
			{
				float num3 = original.MaxAmplitudAbs();
				float num4 = array2.MaxAmplitudAbs();
				array2.Amplificar(num3 / num4);
			}
			return new AnimationCurve(array2);
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x00025918 File Offset: 0x00023B18
		public static Keyframe[] FixDuracion(this IList<Keyframe> keyframe, float startTime, float endTime)
		{
			Keyframe[] array;
			try
			{
				for (int i = 0; i < keyframe.Count; i++)
				{
					Keyframe keyframe2 = keyframe[i];
					if (keyframe2.time >= startTime && keyframe2.time <= endTime)
					{
						AnimationCurveTValle.TEMP1.Add(keyframe2);
					}
				}
				array = AnimationCurveTValle.TEMP1.ToArray<Keyframe>();
			}
			finally
			{
				AnimationCurveTValle.TEMP1.Clear();
			}
			return array;
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x00025988 File Offset: 0x00023B88
		public static void FixDuracion(this AnimationCurve original, float startTime, float endTime)
		{
			original.keys = original.keys.FixDuracion(startTime, endTime);
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x000259A0 File Offset: 0x00023BA0
		public static void Amplificar(this IList<Keyframe> keyframe, float mod)
		{
			for (int i = 0; i < keyframe.Count; i++)
			{
				Keyframe keyframe2 = keyframe[i];
				keyframe2.value *= mod;
				keyframe[i] = keyframe2;
			}
		}

		// Token: 0x04000372 RID: 882
		private static IList<Keyframe> TEMP1 = new List<Keyframe>();
	}
}
