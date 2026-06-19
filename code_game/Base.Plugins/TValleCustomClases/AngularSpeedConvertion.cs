using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x0200004F RID: 79
	public static class AngularSpeedConvertion
	{
		// Token: 0x0600027D RID: 637 RVA: 0x0000CB87 File Offset: 0x0000AD87
		public static Vector3 DegreesPerSecond(Vector3 radiansPerSecond)
		{
			return radiansPerSecond * 0.1591549f * 360f;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000CB9E File Offset: 0x0000AD9E
		public static float DegreesPerSecond(float radiansPerSecond)
		{
			return radiansPerSecond * 0.1591549f * 360f;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000CBAD File Offset: 0x0000ADAD
		public static double RadiansPerSecond(float degreesPerSecond)
		{
			return (double)degreesPerSecond / 360.0 / 0.1591549;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000CBC5 File Offset: 0x0000ADC5
		public static Vector3 GetLocalAngularVelocity(Rigidbody rigidbody, Transform transform)
		{
			return transform.InverseTransformDirection(rigidbody.angularVelocity);
		}

		// Token: 0x020001AC RID: 428
		public static class YAxis
		{
			// Token: 0x06000C10 RID: 3088 RVA: 0x000266B5 File Offset: 0x000248B5
			public static float DegreesPerSecond(Vector3 angularVelocity)
			{
				return Mathf.Abs(AngularSpeedConvertion.DegreesPerSecond(angularVelocity.y));
			}

			// Token: 0x06000C11 RID: 3089 RVA: 0x000266C8 File Offset: 0x000248C8
			public static Vector3 DegreesToAngularVelocity(float yAngle, float mod = 1f)
			{
				float num = (float)AngularSpeedConvertion.RadiansPerSecond(yAngle * mod);
				return new Vector3(0f, num, 0f);
			}
		}

		// Token: 0x020001AD RID: 429
		public static class XAxis
		{
			// Token: 0x06000C12 RID: 3090 RVA: 0x000266EF File Offset: 0x000248EF
			public static float DegreesPerSecond(Vector3 angularVelocity)
			{
				return Mathf.Abs(AngularSpeedConvertion.DegreesPerSecond(angularVelocity.x));
			}
		}

		// Token: 0x020001AE RID: 430
		public static class ZAxis
		{
			// Token: 0x06000C13 RID: 3091 RVA: 0x00026701 File Offset: 0x00024901
			public static float DegreesPerSecond(Vector3 angularVelocity)
			{
				return Mathf.Abs(AngularSpeedConvertion.DegreesPerSecond(angularVelocity.z));
			}
		}
	}
}
