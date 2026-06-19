using System;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x0200004B RID: 75
	public static class Matrix4x4Ext
	{
		// Token: 0x060003BC RID: 956 RVA: 0x00015698 File Offset: 0x00013898
		public static Vector3 Position(this Matrix4x4 rMatrix)
		{
			return rMatrix.GetColumn(3);
		}

		// Token: 0x060003BD RID: 957 RVA: 0x000156A7 File Offset: 0x000138A7
		public static Quaternion Rotation(this Matrix4x4 rMatrix)
		{
			return Quaternion.LookRotation(rMatrix.GetColumn(2), rMatrix.GetColumn(1));
		}

		// Token: 0x060003BE RID: 958 RVA: 0x000156C8 File Offset: 0x000138C8
		public static Vector3 Scale(this Matrix4x4 rMatrix)
		{
			return new Vector3(rMatrix.GetColumn(0).magnitude, rMatrix.GetColumn(1).magnitude, rMatrix.GetColumn(2).magnitude);
		}
	}
}
