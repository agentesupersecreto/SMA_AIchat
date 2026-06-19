using System;
using UnityEngine;

namespace com.ootii.Helpers
{
	// Token: 0x02000033 RID: 51
	public class NumberHelper
	{
		// Token: 0x06000272 RID: 626 RVA: 0x0000C0D0 File Offset: 0x0000A2D0
		public static float GetRandom(float rMin, float rMax)
		{
			return Random.Range(rMin, rMax);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000C0DC File Offset: 0x0000A2DC
		public static Vector3 GetRandom(Vector3 rCenter, float rRadius, bool rRandomizeY)
		{
			float num = rRadius * 2f * (float)NumberHelper.Randomizer.NextDouble() - rRadius;
			rCenter.x += num;
			if (rRandomizeY)
			{
				num = rRadius * 2f * (float)NumberHelper.Randomizer.NextDouble() - rRadius;
				rCenter.y += num;
			}
			num = rRadius * 2f * (float)NumberHelper.Randomizer.NextDouble() - rRadius;
			rCenter.z += num;
			return rCenter;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000C15C File Offset: 0x0000A35C
		public static float EaseInQuadratic(float rTime)
		{
			return rTime * rTime;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000C161 File Offset: 0x0000A361
		public static float EaseOutQuadratic(float rTime)
		{
			return rTime * (2f - rTime);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000C16C File Offset: 0x0000A36C
		public static float EaseInOutQuadratic(float rTime)
		{
			if ((rTime *= 2f) < 1f)
			{
				return 0.5f * rTime * rTime;
			}
			return -0.5f * ((rTime -= 1f) * (rTime - 2f) - 1f);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000C1A7 File Offset: 0x0000A3A7
		public static float EaseInOutCubic(float rTime)
		{
			return rTime * rTime * rTime * (rTime * (6f * rTime - 15f) + 10f);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000C1C4 File Offset: 0x0000A3C4
		public static float SmoothStep(float rStart, float rEnd, float rTime)
		{
			if (rTime <= 0f)
			{
				return rStart;
			}
			if (rTime >= 1f)
			{
				return rEnd;
			}
			float num = rTime * rTime * rTime * (rTime * (6f * rTime - 15f) + 10f);
			float num2 = (rEnd - rStart) * num;
			return rStart + num2;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000C20C File Offset: 0x0000A40C
		public static float SmoothStepTime(float rStart, float rEnd, float rValue)
		{
			if (rValue <= rStart)
			{
				return 0f;
			}
			if (rValue >= rEnd)
			{
				return 1f;
			}
			int num = 0;
			float num2 = 0f;
			float num3 = 1f;
			float num4;
			float num6;
			do
			{
				num++;
				num4 = num2 + (num3 - num2) * 0.5f;
				float num5 = NumberHelper.SmoothStep(rStart, rEnd, num4);
				num6 = rValue - num5;
				if (num6 > 0f)
				{
					num2 = num4;
				}
				else if (num6 < 0f)
				{
					num3 = num4;
				}
			}
			while (num < 40 && Mathf.Abs(num6) > 0.0001f);
			return num4;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000C29B File Offset: 0x0000A49B
		public static float ClampAngle(float rAngle, float rMin, float rMax)
		{
			if (rAngle < -360f)
			{
				rAngle += 360f;
			}
			if (rAngle > 360f)
			{
				rAngle -= 360f;
			}
			return Mathf.Clamp(rAngle, rMin, rMax);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000C2C7 File Offset: 0x0000A4C7
		public static float NormalizeAngle(float rAngle)
		{
			if (rAngle < -360f)
			{
				rAngle += 360f;
			}
			if (rAngle > 360f)
			{
				rAngle -= 360f;
			}
			return rAngle;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000C2EC File Offset: 0x0000A4EC
		public static float GetHorizontalDistance(Vector3 rFrom, Vector3 rTo)
		{
			rFrom.y = 0f;
			rTo.y = 0f;
			return (rTo - rFrom).magnitude;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000C320 File Offset: 0x0000A520
		public static void GetHorizontalDifference(Vector3 rFrom, Vector3 rTo, ref Vector3 rResult)
		{
			rFrom.y = 0f;
			rTo.y = 0f;
			rResult = rTo - rFrom;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000C348 File Offset: 0x0000A548
		public static float GetHorizontalAngle(Vector3 rFrom, Vector3 rTo)
		{
			float num = Mathf.Atan2(Vector3.Dot(Vector3.up, Vector3.Cross(rFrom, rTo)), Vector3.Dot(rFrom, rTo));
			num *= 57.29578f;
			if (Mathf.Abs(num) < 0.0001f)
			{
				num = 0f;
			}
			return num;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000C390 File Offset: 0x0000A590
		public static float GetHorizontalAngle(Vector3 rFrom, Vector3 rTo, Vector3 rUp)
		{
			float num = Mathf.Atan2(Vector3.Dot(rUp, Vector3.Cross(rFrom, rTo)), Vector3.Dot(rFrom, rTo));
			num *= 57.29578f;
			if (Mathf.Abs(num) < 0.0001f)
			{
				num = 0f;
			}
			return num;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000C3D3 File Offset: 0x0000A5D3
		public static void GetHorizontalQuaternion(Vector3 rFrom, Vector3 rTo, ref Quaternion rResult)
		{
			rFrom.y = 0f;
			rTo.y = 0f;
			rResult = Quaternion.LookRotation(rTo - rFrom);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000C3FF File Offset: 0x0000A5FF
		public static float Pow(float rBase, int rExponent)
		{
			if (rExponent == 0)
			{
				return 0f;
			}
			if (rExponent == 1)
			{
				return rBase;
			}
			while (rExponent > 1)
			{
				rBase *= rBase;
				rExponent--;
			}
			return rBase;
		}

		// Token: 0x04000185 RID: 389
		public static Random Randomizer = new Random();
	}
}
