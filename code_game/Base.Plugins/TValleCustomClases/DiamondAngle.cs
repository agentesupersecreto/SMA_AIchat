using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000055 RID: 85
	public static class DiamondAngle
	{
		// Token: 0x060002A9 RID: 681 RVA: 0x0000D4DB File Offset: 0x0000B6DB
		public static float FastAngleCalcule(Vector2 invertDirection)
		{
			return DiamondAngle.DiamondAngleToDegrees(DiamondAngle.Angle(invertDirection.x, invertDirection.y));
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000D4F3 File Offset: 0x0000B6F3
		public static float FastAngleCalcule(float right, float up)
		{
			return DiamondAngle.DiamondAngleToDegrees(DiamondAngle.Angle(right, up));
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000D501 File Offset: 0x0000B701
		public static float FastAngleCalculeAbsolute(Vector2 invertDirection)
		{
			return DiamondAngle.absolute(DiamondAngle.DiamondAngleToDegrees(DiamondAngle.Angle(invertDirection.x, invertDirection.y)));
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000D51E File Offset: 0x0000B71E
		public static float FastAngleCalculeAbsolute(float right, float up)
		{
			return DiamondAngle.absolute(DiamondAngle.DiamondAngleToDegrees(DiamondAngle.Angle(right, up)));
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000D531 File Offset: 0x0000B731
		[Obsolete]
		private static float FastAngleCalcule(Vector3 invertDirection)
		{
			return DiamondAngle.absolute(DiamondAngle.DiamondAngleToDegrees(DiamondAngle.Angle((invertDirection.x + invertDirection.y) / 2f, invertDirection.z)));
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000D55C File Offset: 0x0000B75C
		public static float Angle(float right, float up)
		{
			if (right == 0f && up == 0f)
			{
				return 0f;
			}
			if (right >= 0f)
			{
				if (up < 0f)
				{
					return 1f - up / (-up + right);
				}
				return right / (up + right);
			}
			else
			{
				if (up >= 0f)
				{
					return 3f + up / (up - right);
				}
				return 2f - right / (-up - right);
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000D5C4 File Offset: 0x0000B7C4
		public static float RadiansToDiamondAngle(float rad)
		{
			Vector2 vector = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
			return DiamondAngle.Angle(vector.y, vector.x);
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000D5F8 File Offset: 0x0000B7F8
		public static float DiamondAngleToRadians(float dia)
		{
			Vector2 vector = DiamondAngle.DiamondAngleToPoint(dia);
			return Mathf.Atan2(vector.y, vector.x);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000D620 File Offset: 0x0000B820
		public static Vector2 DiamondAngleToPoint(float dia)
		{
			return new Vector2((dia < 2f) ? (1f - dia) : (dia - 3f), (dia < 3f) ? ((dia > 1f) ? (2f - dia) : dia) : (dia - 4f));
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000D66D File Offset: 0x0000B86D
		public static float DegreesToRadians(float degrees)
		{
			return degrees * 0.017453292f;
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000D676 File Offset: 0x0000B876
		public static float RadiansToDegrees(float radians)
		{
			return radians * 57.29578f;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000D680 File Offset: 0x0000B880
		public static float DiamondAngleToDegrees(float dia)
		{
			if (dia < 0f || dia > 4f)
			{
				throw new ArgumentOutOfRangeException("DiamondAngleToDegrees");
			}
			if (dia < 2f)
			{
				return dia * 180f / 2f;
			}
			return -180f + (dia - 2f) * 180f / 2f;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000D6D7 File Offset: 0x0000B8D7
		private static float absolute(float v)
		{
			if (v < 0f)
			{
				return v * -1f;
			}
			return v;
		}
	}
}
