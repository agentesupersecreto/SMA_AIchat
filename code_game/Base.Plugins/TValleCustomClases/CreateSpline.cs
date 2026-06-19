using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x0200006C RID: 108
	public static class CreateSpline
	{
		// Token: 0x06000347 RID: 839 RVA: 0x0000E2C0 File Offset: 0x0000C4C0
		public static Vector3 GetPoint(Vector3[] pts, float t)
		{
			float num = 1f - t;
			float num2 = num * num;
			float num3 = t * t;
			return pts[0] * (num2 * num) + pts[1] * (3f * num2 * t) + pts[2] * (3f * num * num3) + pts[3] * (num3 * t);
		}
	}
}
