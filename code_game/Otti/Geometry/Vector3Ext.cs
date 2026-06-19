using System;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x02000055 RID: 85
	public static class Vector3Ext
	{
		// Token: 0x0600040D RID: 1037 RVA: 0x00018DE8 File Offset: 0x00016FE8
		public static float SignedAngle(Vector3 rFrom, Vector3 rTo, Vector3 rAxis)
		{
			if (rTo == rFrom)
			{
				return 0f;
			}
			Vector3 vector = Vector3.Cross(rFrom, rTo);
			float num = Vector3.Dot(rFrom, rTo);
			return (float)((Vector3.Dot(rAxis, vector) < 0f) ? (-1) : 1) * Mathf.Atan2(vector.magnitude, num) * 57.29578f;
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00018E3C File Offset: 0x0001703C
		public static float SignedAngle(Vector3 rFrom, Vector3 rTo)
		{
			if (rTo == rFrom)
			{
				return 0f;
			}
			Vector3 vector = Vector3.Cross(rFrom, rTo);
			float num = (float)((vector.y < -0.0001f) ? (-1) : 1);
			float num2 = Vector3.Dot(rFrom, rTo);
			return num * Mathf.Atan2(vector.magnitude, num2) * 57.29578f;
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00018E8E File Offset: 0x0001708E
		public static float AngleTo(this Vector3 rFrom, Vector3 rTo)
		{
			return Vector3Ext.SignedAngle(rFrom, rTo);
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00018E98 File Offset: 0x00017098
		public static void DecomposeYawPitch(Transform rOwner, Vector3 rFrom, Vector3 rTo, ref float rYaw, ref float rPitch)
		{
			Vector3 vector = rTo - rFrom;
			rPitch = -Mathf.Atan2(vector.y, Mathf.Sqrt(vector.x * vector.x + vector.z * vector.z)) * 57.29578f + rOwner.rotation.eulerAngles.x;
			rYaw = -Mathf.Atan2(vector.z, vector.x) * 57.29578f + 90f - rOwner.rotation.eulerAngles.y;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x00018F2A File Offset: 0x0001712A
		public static float HorizontalMagnitude(this Vector3 rVector)
		{
			return Mathf.Sqrt(rVector.x * rVector.x + rVector.z * rVector.z);
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00018F4C File Offset: 0x0001714C
		public static float HorizontalSqrMagnitude(this Vector3 rVector)
		{
			return rVector.x * rVector.x + rVector.z * rVector.z;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00018F6C File Offset: 0x0001716C
		public static float HorizontalAngleTo(this Vector3 rFrom, Vector3 rTo)
		{
			float num = Mathf.Atan2(Vector3.Dot(Vector3.up, Vector3.Cross(rFrom, rTo)), Vector3.Dot(rFrom, rTo));
			num *= 57.29578f;
			if ((double)Mathf.Abs(num) < 0.0001)
			{
				num = 0f;
			}
			return num;
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00018FB8 File Offset: 0x000171B8
		public static float HorizontalAngleTo(this Vector3 rFrom, Vector3 rTo, Vector3 rUp)
		{
			float num = Mathf.Atan2(Vector3.Dot(rUp, Vector3.Cross(rFrom, rTo)), Vector3.Dot(rFrom, rTo));
			num *= 57.29578f;
			if ((double)Mathf.Abs(num) < 0.0001)
			{
				num = 0f;
			}
			return num;
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00019000 File Offset: 0x00017200
		public static float HorizontalAngleFrom(this Vector3 rTo, Vector3 rFrom)
		{
			float num = Mathf.Atan2(Vector3.Dot(Vector3.up, Vector3.Cross(rFrom, rTo)), Vector3.Dot(rFrom, rTo));
			num *= 57.29578f;
			if ((double)Mathf.Abs(num) < 0.0001)
			{
				num = 0f;
			}
			return num;
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0001904C File Offset: 0x0001724C
		public static float DistanceTo(this Vector3 rFrom, Vector3 rTo, float rYTolerance)
		{
			float num = rTo.y - rFrom.y;
			if (num > 0f)
			{
				num = Mathf.Max(num - rYTolerance, 0f);
			}
			else if (num < 0f)
			{
				num = Mathf.Min(num + rYTolerance, 0f);
			}
			rTo.y = rFrom.y + num;
			return Vector3.Distance(rFrom, rTo);
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x000190AC File Offset: 0x000172AC
		public static Vector3 DirectionTo(this Vector3 rFrom, Vector3 rTo)
		{
			return (rTo - rFrom).normalized;
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x000190C8 File Offset: 0x000172C8
		public static Vector3 NormalizeRotations(this Vector3 rThis)
		{
			Vector3 vector = rThis;
			rThis.x = ((rThis.x < -180f) ? (rThis.x + 360f) : ((rThis.x > 180f) ? (rThis.x - 360f) : rThis.x));
			rThis.y = ((rThis.y < -180f) ? (rThis.y + 360f) : ((rThis.y > 180f) ? (rThis.y - 360f) : rThis.y));
			rThis.z = ((rThis.z < -180f) ? (rThis.z + 360f) : ((rThis.z > 180f) ? (rThis.z - 360f) : rThis.z));
			return vector;
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x0001919F File Offset: 0x0001739F
		public static Vector3 AddRotation(this Vector3 rFrom, Vector3 rTo)
		{
			return rFrom + rTo;
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x000191A8 File Offset: 0x000173A8
		public static Vector3 AddRotation(this Vector3 rFrom, float rX, float rY, float rZ)
		{
			Vector3 vector = rFrom;
			vector.x += rX;
			vector.y += rY;
			vector.z += rZ;
			return vector;
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x000191E8 File Offset: 0x000173E8
		public static void FindOrthogonals(Vector3 rNormal, ref Vector3 rOrthoUp, ref Vector3 rOrthoRight)
		{
			rNormal.Normalize();
			rOrthoRight = Quaternion.AngleAxis(90f, Vector3.right) * rNormal;
			if (Mathf.Abs(Vector3.Dot(rNormal, rOrthoRight)) > 0.6f)
			{
				rOrthoRight = Quaternion.AngleAxis(90f, Vector3.up) * rNormal;
			}
			rOrthoRight.Normalize();
			rOrthoRight = Vector3.Cross(rNormal, rOrthoRight).normalized;
			rOrthoUp = Vector3.Cross(rNormal, rOrthoRight).normalized;
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00019284 File Offset: 0x00017484
		public static Vector3 PlaneNormal(Vector3 rVertexA, Vector3 rVertexB, Vector3 rVertexC)
		{
			Vector3 vector = rVertexB - rVertexA;
			return Vector3.Cross(rVertexC - rVertexA, vector).normalized;
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x000192B0 File Offset: 0x000174B0
		public static void PlaneFrom3Points(out Vector3 planeNormal, out Vector3 planePoint, Vector3 pointA, Vector3 pointB, Vector3 pointC)
		{
			planeNormal = Vector3.zero;
			planePoint = Vector3.zero;
			Vector3 vector = pointB - pointA;
			Vector3 vector2 = pointC - pointA;
			planeNormal = Vector3.Normalize(Vector3.Cross(vector, vector2));
			Vector3 vector3 = pointA + vector / 2f;
			Vector3 vector4 = pointA + vector2 / 2f;
			Vector3 vector5 = pointC - vector3;
			Vector3 vector6 = pointB - vector4;
			Vector3 vector7;
			Vector3Ext.ClosestPointsOnTwoLines(out planePoint, out vector7, vector3, vector5, vector4, vector6);
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x0001933C File Offset: 0x0001753C
		public static bool ClosestPointsOnTwoLines(out Vector3 closestPointLine1, out Vector3 closestPointLine2, Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
		{
			closestPointLine1 = Vector3.zero;
			closestPointLine2 = Vector3.zero;
			float num = Vector3.Dot(lineVec1, lineVec1);
			float num2 = Vector3.Dot(lineVec1, lineVec2);
			float num3 = Vector3.Dot(lineVec2, lineVec2);
			float num4 = num * num3 - num2 * num2;
			if (num4 != 0f)
			{
				Vector3 vector = linePoint1 - linePoint2;
				float num5 = Vector3.Dot(lineVec1, vector);
				float num6 = Vector3.Dot(lineVec2, vector);
				float num7 = (num2 * num6 - num5 * num3) / num4;
				float num8 = (num * num6 - num5 * num2) / num4;
				closestPointLine1 = linePoint1 + lineVec1 * num7;
				closestPointLine2 = linePoint2 + lineVec2 * num8;
				return true;
			}
			return false;
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x000193F0 File Offset: 0x000175F0
		public static Vector3 MoveTo(Vector3 rValue, Vector3 rTarget, float rVelocity, float rDeltaTime)
		{
			if (rValue == rTarget)
			{
				return rTarget;
			}
			Vector3 vector = (rTarget - rValue).normalized * rVelocity;
			Vector3 vector2 = rValue + vector * rDeltaTime;
			if (vector2.sqrMagnitude > rTarget.sqrMagnitude)
			{
				return rTarget;
			}
			return vector2;
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00019440 File Offset: 0x00017640
		public static Vector2 FromString(this Vector2 rThis, string rString)
		{
			string[] array = rString.Substring(1, rString.Length - 2).Split(',', StringSplitOptions.None);
			if (array.Length != 2)
			{
				return rThis;
			}
			rThis.x = float.Parse(array[0]);
			rThis.y = float.Parse(array[1]);
			return rThis;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0001948C File Offset: 0x0001768C
		public static Vector3 FromString(this Vector3 rThis, string rString)
		{
			string[] array = rString.Substring(1, rString.Length - 2).Split(',', StringSplitOptions.None);
			if (array.Length != 3)
			{
				return rThis;
			}
			rThis.x = float.Parse(array[0]);
			rThis.y = float.Parse(array[1]);
			rThis.z = float.Parse(array[2]);
			return rThis;
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x000194E8 File Offset: 0x000176E8
		public static Vector4 FromString(this Vector4 rThis, string rString)
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

		// Token: 0x06000423 RID: 1059 RVA: 0x00019552 File Offset: 0x00017752
		public static float Dot(this Vector3 rThis, Vector3 rTarget)
		{
			return rThis.x * rTarget.x + rThis.y * rTarget.y + rThis.z * rTarget.z;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00019580 File Offset: 0x00017780
		public static Vector3 SmoothStep(Vector3 rStart, Vector3 rEnd, float rTime)
		{
			if (rTime <= 0f)
			{
				return rStart;
			}
			if (rTime >= 1f)
			{
				return rEnd;
			}
			rTime = rTime * rTime * rTime * (rTime * (6f * rTime - 15f) + 10f);
			Vector3 vector = rEnd - rStart;
			float num = vector.magnitude * rTime;
			return rStart + vector.normalized * num;
		}

		// Token: 0x04000227 RID: 551
		public static Vector3 Null = new Vector3(float.MinValue, float.MinValue, float.MinValue);
	}
}
