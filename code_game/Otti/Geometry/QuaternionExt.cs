using System;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x02000050 RID: 80
	public static class QuaternionExt
	{
		// Token: 0x060003E1 RID: 993 RVA: 0x0001705C File Offset: 0x0001525C
		public static bool IsEqual(Quaternion rLeft, Quaternion rRight)
		{
			return Mathf.Abs(rLeft.x - rRight.x) <= QuaternionExt.EPSILON && Mathf.Abs(rLeft.y - rRight.y) <= QuaternionExt.EPSILON && Mathf.Abs(rLeft.z - rRight.z) <= QuaternionExt.EPSILON && Mathf.Abs(rLeft.w - rRight.w) <= QuaternionExt.EPSILON;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x000170D8 File Offset: 0x000152D8
		public static bool IsEqual(ref Quaternion rLeft, ref Quaternion rRight)
		{
			return Mathf.Abs(rLeft.x - rRight.x) <= QuaternionExt.EPSILON && Mathf.Abs(rLeft.y - rRight.y) <= QuaternionExt.EPSILON && Mathf.Abs(rLeft.z - rRight.z) <= QuaternionExt.EPSILON && Mathf.Abs(rLeft.w - rRight.w) <= QuaternionExt.EPSILON;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00017154 File Offset: 0x00015354
		public static bool IsIdentity(this Quaternion rThis)
		{
			return rThis.x == 0f && rThis.y == 0f && rThis.z == 0f && (rThis.w == 1f || rThis.w == -1f);
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x000171AB File Offset: 0x000153AB
		public static Quaternion RotationTo(this Quaternion rFrom, Quaternion rTo)
		{
			return Quaternion.Inverse(rFrom) * rTo;
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x000171BC File Offset: 0x000153BC
		public static Quaternion OrientTo(this Quaternion rFrom, Quaternion rTo)
		{
			Quaternion quaternion = Quaternion.Inverse(rFrom);
			return rTo * quaternion;
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x000171D8 File Offset: 0x000153D8
		public static Quaternion Subtract(this Quaternion rLHS, Quaternion rRHS)
		{
			Quaternion quaternion;
			quaternion.x = rLHS.x - rRHS.x;
			quaternion.y = rLHS.y - rRHS.y;
			quaternion.z = rLHS.z - rRHS.z;
			quaternion.w = rLHS.w - rRHS.w;
			return quaternion;
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00017238 File Offset: 0x00015438
		public static Quaternion Normalize(this Quaternion rThis)
		{
			float num = Mathf.Sqrt(rThis.w * rThis.w + rThis.x * rThis.x + rThis.y * rThis.y + rThis.z * rThis.z);
			Quaternion quaternion;
			quaternion.x = rThis.x / num;
			quaternion.y = rThis.y / num;
			quaternion.z = rThis.z / num;
			quaternion.w = rThis.w / num;
			return quaternion;
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x000172C0 File Offset: 0x000154C0
		public static Quaternion Negate(this Quaternion rThis)
		{
			Quaternion quaternion;
			quaternion.x = -rThis.x;
			quaternion.y = -rThis.y;
			quaternion.z = -rThis.z;
			quaternion.w = -rThis.w;
			return quaternion;
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00017308 File Offset: 0x00015508
		public static Quaternion Conjugate(this Quaternion rThis)
		{
			Quaternion quaternion;
			quaternion.x = -rThis.x;
			quaternion.y = -rThis.y;
			quaternion.z = -rThis.z;
			quaternion.w = rThis.w;
			return quaternion;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00017350 File Offset: 0x00015550
		public static Vector3 Forward(this Quaternion rThis)
		{
			return new Vector3(2f * (rThis.x * rThis.z + rThis.w * rThis.y), 2f * (rThis.y * rThis.z - rThis.w * rThis.x), 1f - 2f * (rThis.x * rThis.x + rThis.y * rThis.y));
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x000173CC File Offset: 0x000155CC
		public static Vector3 Up(this Quaternion rThis)
		{
			return new Vector3(2f * (rThis.x * rThis.y - rThis.w * rThis.z), 1f - 2f * (rThis.x * rThis.x + rThis.z * rThis.z), 2f * (rThis.y * rThis.z + rThis.w * rThis.x));
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00017448 File Offset: 0x00015648
		public static Vector3 Right(this Quaternion rThis)
		{
			return new Vector3(1f - 2f * (rThis.y * rThis.y + rThis.z * rThis.z), 2f * (rThis.x * rThis.y + rThis.w * rThis.z), 2f * (rThis.x * rThis.z - rThis.w * rThis.y));
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x000174C4 File Offset: 0x000156C4
		public static Quaternion FromToRotation(Vector3 u, Vector3 v)
		{
			float num = Vector3.Dot(u.normalized, v.normalized);
			if (num >= 1f)
			{
				return Quaternion.identity;
			}
			if (num <= -1f)
			{
				Vector3 vector = Vector3.Cross(u, Vector3.right);
				if (vector.sqrMagnitude == 0f)
				{
					vector = Vector3.Cross(u, Vector3.up);
				}
				return Quaternion.AngleAxis(180f, vector);
			}
			float num2 = Mathf.Acos(num);
			Vector3 normalized = Vector3.Cross(u, v).normalized;
			return Quaternion.AngleAxis(num2 * 57.29578f, normalized);
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00017550 File Offset: 0x00015750
		public static void DecomposeSwingTwist(this Quaternion rThis, Vector3 rAxis, ref Quaternion rSwing, ref Quaternion rTwist)
		{
			Vector3 vector = rAxis.normalized;
			float num = Vector3.Dot(new Vector3(rThis.x, rThis.y, rThis.z), vector);
			vector *= num;
			rTwist.x = vector.x;
			rTwist.y = vector.y;
			rTwist.z = vector.z;
			rTwist.w = rThis.w;
			rTwist.Normalize();
			rSwing = rThis * Quaternion.Inverse(rTwist);
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x000175D8 File Offset: 0x000157D8
		public static void DecomposeTwistSwingAxisAngles(this Quaternion rThis, Vector3 rTwistAxis, ref float rTwistAngle, ref Vector3 rSwingAxis, ref float rSwingAngle)
		{
			rTwistAngle = 2f * Mathf.Atan2(rThis.y, rThis.w) * 57.29578f;
			Vector4 vector = new Vector4(0f, rThis.y, 0f, rThis.w) / Mathf.Sqrt(rThis.y * rThis.y + rThis.w * rThis.w);
			Quaternion quaternion = new Quaternion(vector.x, vector.y, vector.z, vector.w);
			Quaternion quaternion2 = rThis * quaternion.Conjugate();
			float num = Mathf.Sqrt(quaternion2.x * quaternion2.x + quaternion2.y * quaternion2.y + quaternion2.z * quaternion2.z);
			if (num <= 1E-06f)
			{
				rSwingAxis = Vector3.right;
				rSwingAngle = 0f;
				return;
			}
			float num2 = 1f / num;
			rSwingAxis.x = quaternion2.x * num2;
			rSwingAxis.y = quaternion2.y * num2;
			rSwingAxis.z = quaternion2.z * num2;
			if (quaternion2.w < 0f)
			{
				rSwingAngle = 2f * Mathf.Atan2(-num, -quaternion2.w) * 57.29578f;
				return;
			}
			rSwingAngle = 2f * Mathf.Atan2(num, quaternion2.w) * 57.29578f;
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00017738 File Offset: 0x00015938
		public static Quaternion FromString(this Quaternion rThis, string rString)
		{
			string[] array = rString.Substring(1, rString.Length - 2).Split(',', StringSplitOptions.None);
			if (array.Length != 4)
			{
				return rThis;
			}
			rThis.x = float.Parse(array[0]);
			rThis.y = float.Parse(array[1]);
			rThis.z = float.Parse(array[2]);
			rThis.w = float.Parse(array[3]);
			return rThis;
		}

		// Token: 0x04000220 RID: 544
		public static float EPSILON = 1E-06f;

		// Token: 0x04000221 RID: 545
		public static Quaternion InverseIdentity = new Quaternion(0f, 0f, 0f, -1f);
	}
}
