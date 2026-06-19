using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000084 RID: 132
	public struct AngleLimits
	{
		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060003BE RID: 958 RVA: 0x00010256 File Offset: 0x0000E456
		public static AngleLimits All
		{
			get
			{
				return new AngleLimits(-180f, 180f, 180f);
			}
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0001026C File Offset: 0x0000E46C
		public AngleLimits(float lowVertical, float highVertical, float horizontal)
		{
			this.lowVertical = Mathf.Clamp(lowVertical, -180f, 180f);
			this.highVertical = Mathf.Clamp(highVertical, -180f, 180f);
			this.horizontal = Mathf.Clamp(horizontal, 0f, 180f);
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x000102BB File Offset: 0x0000E4BB
		public bool IsInLimits(float Vertical, float Horizontal)
		{
			return Vertical >= this.lowVertical && Vertical <= this.highVertical && Horizontal <= this.horizontal;
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x000102E0 File Offset: 0x0000E4E0
		public bool IsInLimits(Vector3 localDirection)
		{
			float num;
			float num2;
			AngleLimits.GetAngles(localDirection, out num, out num2);
			return num >= this.lowVertical && num <= this.highVertical && num2 <= this.horizontal;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x00010317 File Offset: 0x0000E517
		public static void GetAngles(Vector3 localDirection, out float vertical, out float horizontal)
		{
			vertical = CalculeAimAngleLimits.LocalVerticalAngle(localDirection);
			horizontal = CalculeAimAngleLimits.LocalHorizontalAngle(localDirection);
		}

		// Token: 0x040000CB RID: 203
		public float lowVertical;

		// Token: 0x040000CC RID: 204
		public float highVertical;

		// Token: 0x040000CD RID: 205
		public float horizontal;
	}
}
