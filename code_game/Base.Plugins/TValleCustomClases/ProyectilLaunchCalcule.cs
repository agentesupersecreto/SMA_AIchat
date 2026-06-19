using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000071 RID: 113
	public static class ProyectilLaunchCalcule
	{
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600036E RID: 878 RVA: 0x0000F041 File Offset: 0x0000D241
		public static float g
		{
			get
			{
				return -Physics.gravity.y;
			}
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0000F050 File Offset: 0x0000D250
		public static bool Calculate(float velocity, Vector3 direction, ProyectilLaunchMode launchType, out ProyectilLaunchCalculeResult result)
		{
			float num = ProyectilLaunchCalcule.Range(direction);
			float y = direction.y;
			float num2;
			bool launchAngle = ProyectilLaunchCalcule.GetLaunchAngle(num, velocity, y, launchType, out num2);
			result = default(ProyectilLaunchCalculeResult);
			result.altitude = y;
			result.range = num;
			result.initialVelocity = velocity;
			if (launchAngle)
			{
				result.launchAngle = num2;
				return launchAngle;
			}
			result.launchAngle = 45f;
			return launchAngle;
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0000F0A8 File Offset: 0x0000D2A8
		public static bool Calculate(float velocity, Vector3 direction, ProyectilLaunchMode launchType, out float launchAngle)
		{
			float num = ProyectilLaunchCalcule.Range(direction);
			float y = direction.y;
			return ProyectilLaunchCalcule.GetLaunchAngle(num, velocity, y, launchType, out launchAngle);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0000F0CB File Offset: 0x0000D2CB
		public static float Range(Vector3 targetDirection)
		{
			return Mathf.Sqrt(targetDirection.z * targetDirection.z + targetDirection.x * targetDirection.x);
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0000F0F0 File Offset: 0x0000D2F0
		public static bool GetLaunchAngle(float r, float v, float a, ProyectilLaunchMode LaunchAngle, out float angle)
		{
			float g = ProyectilLaunchCalcule.g;
			angle = 0f;
			float num = g * r;
			float num2 = v * v;
			float num3 = num * r;
			float num4 = 2f * a * v * v;
			float num5 = num2 * v * v - g * (num3 + num4);
			if (num5 < 0f)
			{
				return false;
			}
			if (LaunchAngle == ProyectilLaunchMode.low)
			{
				angle = Mathf.Atan((num2 - Mathf.Sqrt(num5)) / num) / 0.017453292f;
			}
			else if (LaunchAngle == ProyectilLaunchMode.hi)
			{
				angle = Mathf.Atan((num2 + Mathf.Sqrt(num5)) / num) / 0.017453292f;
			}
			return true;
		}
	}
}
