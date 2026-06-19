using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000074 RID: 116
	public static class ProyectilTrayectory
	{
		// Token: 0x06000373 RID: 883 RVA: 0x0000F17C File Offset: 0x0000D37C
		public static float GetRelativeY0(Vector3 startPosition, Vector3 targetPosition)
		{
			float y = startPosition.y;
			float y2 = targetPosition.y;
			if (y2 >= y)
			{
				return 0f;
			}
			return y - y2;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000F1A4 File Offset: 0x0000D3A4
		public static float HeightAtX(float xRange, float initialVelocity, float launchAngle, float g, float y0 = 0f)
		{
			float num = Mathf.Tan(launchAngle * 0.017453292f);
			float num2 = Mathf.Cos(launchAngle * 0.017453292f);
			float num3 = xRange * num;
			float num4 = g * (xRange * xRange);
			float num5 = initialVelocity * num2;
			float num6 = num5 * num5 * 2f;
			float num7 = num4 / num6;
			return y0 + num3 - num7;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0000F1EC File Offset: 0x0000D3EC
		public static float MaxHorizontalDistanceTraveled(float initialVelocity, float launchAngle, float g)
		{
			if (launchAngle <= 0f)
			{
				return 0f;
			}
			float num = Mathf.Sin(2f * launchAngle * 0.017453292f);
			float num2 = initialVelocity * initialVelocity;
			return num * num2 / g;
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000F224 File Offset: 0x0000D424
		public static float MaxHorizontalDistanceTraveled(float initialVelocity, float launchAngle, float g, float y0)
		{
			float num = Mathf.Sin(launchAngle * 0.017453292f);
			float num2 = Mathf.Cos(launchAngle * 0.017453292f);
			float num3 = num * initialVelocity;
			float num4 = num2 * initialVelocity;
			float num5 = Mathf.Pow(num3, 2f);
			float num6 = 2f * g * y0;
			float num7 = Mathf.Sqrt(num5 + num6);
			float num8 = num3 + num7;
			return num4 / g * num8;
		}
	}
}
