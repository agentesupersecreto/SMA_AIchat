using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000079 RID: 121
	public static class VectorFastComparer
	{
		// Token: 0x0600038F RID: 911 RVA: 0x0000F380 File Offset: 0x0000D580
		public static bool AlmostEqual(this Vector3 v1, Vector3 v2, float precision = 0.003f)
		{
			return VectorFastComparer.abs(v1.x - v2.x) <= precision && VectorFastComparer.abs(v1.y - v2.y) <= precision && VectorFastComparer.abs(v1.z - v2.z) <= precision;
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0000F3D3 File Offset: 0x0000D5D3
		private static float abs(float v)
		{
			if (v < 0f)
			{
				return v * -1f;
			}
			return v;
		}
	}
}
