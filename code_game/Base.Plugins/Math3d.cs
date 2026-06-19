using System;
using UnityEngine;

// Token: 0x02000017 RID: 23
public static class Math3d
{
	// Token: 0x06000084 RID: 132 RVA: 0x00004C2C File Offset: 0x00002E2C
	public static Vector3 EnsureNormalized(Vector3 v)
	{
		float sqrMagnitude = v.sqrMagnitude;
		if (sqrMagnitude < Mathf.Epsilon)
		{
			return Vector3.zero;
		}
		if (Mathf.Abs(sqrMagnitude - 1f) < 0.0001f)
		{
			return v;
		}
		return v / Mathf.Sqrt(sqrMagnitude);
	}

	// Token: 0x06000085 RID: 133 RVA: 0x00004C70 File Offset: 0x00002E70
	public static Vector3 ProjectIfFacing(Vector3 vector, Vector3 onNormal)
	{
		onNormal = Math3d.EnsureNormalized(onNormal);
		if (onNormal == Vector3.zero)
		{
			return Vector3.zero;
		}
		float num = Vector3.Dot(vector, onNormal);
		if (num <= 0f)
		{
			return Vector3.zero;
		}
		return onNormal * num;
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00004CB8 File Offset: 0x00002EB8
	public static Vector3 ProjectPointOnConeSurfaceOrInside(Vector3 coneNormal, Vector3 conePoint, float coneAngle, Vector3 posicion, bool debugDraw, float maxDistance = float.PositiveInfinity)
	{
		Vector3 vector = posicion - conePoint;
		if (vector.sqrMagnitude > maxDistance * maxDistance)
		{
			return posicion;
		}
		Vector3 vector2 = Math3d.ProjectDirectionOnConeSurfaceOrInside(coneNormal, coneAngle, vector);
		return conePoint + vector2;
	}

	// Token: 0x06000087 RID: 135 RVA: 0x00004CF0 File Offset: 0x00002EF0
	public static Vector3 ProjectDirectionOnConeSurfaceOrInside(Vector3 coneNormal, float coneAngle, Vector3 direction)
	{
		coneNormal = coneNormal.normalized;
		float num = Vector3.Angle(coneNormal, direction);
		if (num <= coneAngle)
		{
			return direction;
		}
		float magnitude = direction.magnitude;
		direction = direction.normalized;
		Vector3 normalized = Vector3.Cross(coneNormal, direction).normalized;
		Quaternion quaternion = Quaternion.LookRotation(direction, normalized);
		Quaternion quaternion2 = Quaternion.LookRotation(coneNormal, normalized);
		float num2 = Mathf.InverseLerp(0f, num, coneAngle);
		direction = Quaternion.Slerp(quaternion2, quaternion, num2) * Vector3.forward;
		return direction.SetMagnitud(magnitude);
	}

	// Token: 0x06000088 RID: 136 RVA: 0x00004D70 File Offset: 0x00002F70
	public static Vector3 CalculateSurfaceNormalDirection(Vector3 v1, Vector3 v2, Vector3 v3)
	{
		Vector3 vector = v2 - v1;
		Vector3 vector2 = v3 - v1;
		return new Vector3
		{
			x = vector.y * vector2.z - vector.z * vector2.y,
			y = vector.z * vector2.x - vector.x * vector2.z,
			z = vector.x * vector2.y - vector.y * vector2.x
		};
	}

	// Token: 0x06000089 RID: 137 RVA: 0x00004DFC File Offset: 0x00002FFC
	public static Vector3 CalculateSurfaceNormal(Vector3 v1, Vector3 v2, Vector3 v3)
	{
		return Math3d.CalculateSurfaceNormalDirection(v1, v2, v3).normalized;
	}

	// Token: 0x0600008A RID: 138 RVA: 0x00004E1C File Offset: 0x0000301C
	public static Vector3 CalculateBarycentricCoordinate(Vector3 p, Vector3 a, Vector3 b, Vector3 c)
	{
		Vector3 vector = b - a;
		Vector3 vector2 = c - a;
		Vector3 vector3 = p - a;
		float num = Math3d.Dot(vector, vector);
		float num2 = Math3d.Dot(vector, vector2);
		float num3 = Math3d.Dot(vector2, vector2);
		float num4 = Math3d.Dot(vector3, vector);
		float num5 = Math3d.Dot(vector3, vector2);
		float num6 = num * num3 - num2 * num2;
		Vector3 vector4 = default(Vector3);
		vector4.y = (num3 * num4 - num2 * num5) / num6;
		vector4.z = (num * num5 - num2 * num4) / num6;
		vector4.x = 1f - vector4.y - vector4.z;
		return vector4;
	}

	// Token: 0x0600008B RID: 139 RVA: 0x00004EC1 File Offset: 0x000030C1
	public static float Dot(Vector3 lhs, Vector3 rhs)
	{
		return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
	}

	// Token: 0x0600008C RID: 140 RVA: 0x00004EEC File Offset: 0x000030EC
	public static Vector3 AddVectorLength(Vector3 vector, float size)
	{
		float num = Vector3.Magnitude(vector);
		float num2 = (num + size) / num;
		return vector * num2;
	}

	// Token: 0x0600008D RID: 141 RVA: 0x00004F0D File Offset: 0x0000310D
	public static Vector3 SetVectorLength(Vector3 vector, float size)
	{
		return Vector3.Normalize(vector) * size;
	}

	// Token: 0x0600008E RID: 142 RVA: 0x00004F1B File Offset: 0x0000311B
	public static Quaternion SubtractRotation(Quaternion B, Quaternion A)
	{
		return Quaternion.Inverse(A) * B;
	}

	// Token: 0x0600008F RID: 143 RVA: 0x00004F29 File Offset: 0x00003129
	public static Quaternion AddRotation(Quaternion A, Quaternion B)
	{
		return A * B;
	}

	// Token: 0x06000090 RID: 144 RVA: 0x00004F32 File Offset: 0x00003132
	public static Vector3 TransformDirectionMath(Quaternion rotation, Vector3 vector)
	{
		return rotation * vector;
	}

	// Token: 0x06000091 RID: 145 RVA: 0x00004F3B File Offset: 0x0000313B
	public static Vector3 InverseTransformDirectionMath(Quaternion rotation, Vector3 vector)
	{
		return Quaternion.Inverse(rotation) * vector;
	}

	// Token: 0x06000092 RID: 146 RVA: 0x00004F4C File Offset: 0x0000314C
	public static Vector3 RotateVectorFromTo(Quaternion from, Quaternion to, Vector3 vector)
	{
		Quaternion quaternion = Math3d.SubtractRotation(to, from);
		Vector3 vector2 = Math3d.InverseTransformDirectionMath(from, vector);
		Vector3 vector3 = quaternion * vector2;
		return Math3d.TransformDirectionMath(from, vector3);
	}

	// Token: 0x06000093 RID: 147 RVA: 0x00004F78 File Offset: 0x00003178
	public static bool PlanePlaneIntersection(out Vector3 linePoint, out Vector3 lineVec, Vector3 plane1Normal, Vector3 plane1Position, Vector3 plane2Normal, Vector3 plane2Position)
	{
		linePoint = Vector3.zero;
		lineVec = Vector3.zero;
		lineVec = Vector3.Cross(plane1Normal, plane2Normal);
		Vector3 vector = Vector3.Cross(plane2Normal, lineVec);
		float num = Vector3.Dot(plane1Normal, vector);
		if (Mathf.Abs(num) > 0.006f)
		{
			Vector3 vector2 = plane1Position - plane2Position;
			float num2 = Vector3.Dot(plane1Normal, vector2) / num;
			linePoint = plane2Position + num2 * vector;
			return true;
		}
		return false;
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00004FF8 File Offset: 0x000031F8
	public static bool LinePlaneIntersection(out Vector3 intersection, Vector3 linePoint, Vector3 lineVec, Vector3 planeNormal, Vector3 planePoint)
	{
		intersection = Vector3.zero;
		float num = Vector3.Dot(planePoint - linePoint, planeNormal);
		float num2 = Vector3.Dot(lineVec, planeNormal);
		if (num2 != 0f)
		{
			float num3 = num / num2;
			Vector3 vector = Math3d.SetVectorLength(lineVec, num3);
			intersection = linePoint + vector;
			return true;
		}
		return false;
	}

	// Token: 0x06000095 RID: 149 RVA: 0x0000504C File Offset: 0x0000324C
	public static bool LineLineIntersection(out Vector3 intersection, Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
	{
		Vector3 vector = linePoint2 - linePoint1;
		Vector3 vector2 = Vector3.Cross(lineVec1, lineVec2);
		Vector3 vector3 = Vector3.Cross(vector, lineVec2);
		if (Mathf.Abs(Vector3.Dot(vector, vector2)) < 0.0001f && vector2.sqrMagnitude > 0.0001f)
		{
			float num = Vector3.Dot(vector3, vector2) / vector2.sqrMagnitude;
			intersection = linePoint1 + lineVec1 * num;
			return true;
		}
		intersection = Vector3.zero;
		return false;
	}

	// Token: 0x06000096 RID: 150 RVA: 0x000050C4 File Offset: 0x000032C4
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

	// Token: 0x06000097 RID: 151 RVA: 0x00005178 File Offset: 0x00003378
	public static Vector3 ProjectPointOnLine(Vector3 linePoint, Vector3 lineVec, Vector3 point)
	{
		if (Mathf.Abs(lineVec.sqrMagnitude - 1f) > 1E-06f)
		{
			lineVec = lineVec.normalized;
		}
		float num = Vector3.Dot(point - linePoint, lineVec);
		return linePoint + lineVec * num;
	}

	// Token: 0x06000098 RID: 152 RVA: 0x000051C4 File Offset: 0x000033C4
	public static Vector3 ProjectPointOnLineSegment(Vector3 linePoint1, Vector3 linePoint2, Vector3 point)
	{
		Vector3 vector = Math3d.ProjectPointOnLine(linePoint1, (linePoint2 - linePoint1).normalized, point);
		int num = Math3d.PointOnWhichSideOfLineSegment(linePoint1, linePoint2, vector);
		if (num == 0)
		{
			return vector;
		}
		if (num == 1)
		{
			return linePoint1;
		}
		if (num == 2)
		{
			return linePoint2;
		}
		return Vector3.zero;
	}

	// Token: 0x06000099 RID: 153 RVA: 0x00005208 File Offset: 0x00003408
	public static Vector3 ProjectPointOnPlane(Vector3 planeNormal, Vector3 planePoint, Vector3 point)
	{
		float num = Math3d.SignedDistancePlanePoint(planeNormal, planePoint, point);
		num *= -1f;
		Vector3 vector = Math3d.SetVectorLength(planeNormal, num);
		return point + vector;
	}

	// Token: 0x0600009A RID: 154 RVA: 0x00005238 File Offset: 0x00003438
	public static Vector3 ProjectPointOnPlaneCone(Vector3 planeNormal, Vector3 planePoint, Vector3 point, float angleToPlane, float distance, bool invertDirection = false)
	{
		Vector3 vector = Math3d.ProjectPointOnPlane(planeNormal, planePoint, point);
		if (angleToPlane == 90f)
		{
			return vector;
		}
		if (planePoint == point)
		{
			return planePoint + planeNormal.normalized * distance;
		}
		Quaternion quaternion;
		if (MathfExtension.AlmostEqual(vector, planePoint, 0.0001f))
		{
			quaternion = Quaternion.identity;
		}
		else
		{
			Vector3 vector2 = vector - planePoint;
			if (invertDirection)
			{
				quaternion = Quaternion.LookRotation(-vector2, planeNormal);
			}
			else
			{
				quaternion = Quaternion.LookRotation(vector2, planeNormal);
			}
		}
		Quaternion quaternion2 = quaternion * Quaternion.AngleAxis(90f - angleToPlane, -Vector3.right);
		return planePoint + quaternion2 * Vector3.forward * distance;
	}

	// Token: 0x0600009B RID: 155 RVA: 0x000052E4 File Offset: 0x000034E4
	public static Vector3 ProjectVectorOnPlane(Vector3 planeNormal, Vector3 vector)
	{
		if (planeNormal.sqrMagnitude > 1.0001f)
		{
			planeNormal = planeNormal.normalized;
		}
		return vector - Vector3.Dot(vector, planeNormal) * planeNormal;
	}

	// Token: 0x0600009C RID: 156 RVA: 0x00005310 File Offset: 0x00003510
	public static float SignedDistancePlanePoint(Vector3 planeNormal, Vector3 planePoint, Vector3 point)
	{
		return Vector3.Dot(planeNormal, point - planePoint);
	}

	// Token: 0x0600009D RID: 157 RVA: 0x0000531F File Offset: 0x0000351F
	public static float SignedDotProduct(Vector3 vectorA, Vector3 vectorB, Vector3 normal)
	{
		return Vector3.Dot(Vector3.Cross(normal, vectorA), vectorB);
	}

	// Token: 0x0600009E RID: 158 RVA: 0x00005330 File Offset: 0x00003530
	public static float SignedVectorAngle(Vector3 referenceVector, Vector3 otherVector, Vector3 normal)
	{
		Vector3 vector = Vector3.Cross(normal, referenceVector);
		return Vector3.Angle(referenceVector, otherVector) * Mathf.Sign(Vector3.Dot(vector, otherVector));
	}

	// Token: 0x0600009F RID: 159 RVA: 0x0000535C File Offset: 0x0000355C
	public static float AngleVectorPlane(Vector3 vector, Vector3 normal)
	{
		float num = (float)Math.Acos((double)Vector3.Dot(vector, normal));
		return 1.5707964f - num;
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00005380 File Offset: 0x00003580
	public static float DotProductAngle(Vector3 vec1, Vector3 vec2)
	{
		double num = (double)Vector3.Dot(vec1, vec2);
		if (num < -1.0)
		{
			num = -1.0;
		}
		if (num > 1.0)
		{
			num = 1.0;
		}
		return (float)Math.Acos(num);
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x000053CC File Offset: 0x000035CC
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
		Math3d.ClosestPointsOnTwoLines(out planePoint, out vector7, vector3, vector5, vector4, vector6);
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x00005458 File Offset: 0x00003658
	public static Vector3 GetForwardVector(Quaternion q)
	{
		return q * Vector3.forward;
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x00005465 File Offset: 0x00003665
	public static Vector3 GetUpVector(Quaternion q)
	{
		return q * Vector3.up;
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x00005472 File Offset: 0x00003672
	public static Vector3 GetRightVector(Quaternion q)
	{
		return q * Vector3.right;
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x0000547F File Offset: 0x0000367F
	public static Quaternion QuaternionFromMatrix(Matrix4x4 m)
	{
		return Quaternion.LookRotation(m.GetColumn(2), m.GetColumn(1));
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x000054A0 File Offset: 0x000036A0
	public static Vector3 PositionFromMatrix(Matrix4x4 m)
	{
		Vector4 column = m.GetColumn(3);
		return new Vector3(column.x, column.y, column.z);
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x000054D0 File Offset: 0x000036D0
	public static void LookRotationExtended(ref GameObject gameObjectInOut, Vector3 alignWithVector, Vector3 alignWithNormal, Vector3 customForward, Vector3 customUp)
	{
		Quaternion quaternion = Quaternion.LookRotation(alignWithVector, alignWithNormal);
		Quaternion quaternion2 = Quaternion.LookRotation(customForward, customUp);
		gameObjectInOut.transform.rotation = quaternion * Quaternion.Inverse(quaternion2);
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x00005508 File Offset: 0x00003708
	public static void PreciseAlign(ref GameObject gameObjectInOut, Vector3 alignWithVector, Vector3 alignWithNormal, Vector3 alignWithPosition, Vector3 triangleForward, Vector3 triangleNormal, Vector3 trianglePosition)
	{
		Math3d.LookRotationExtended(ref gameObjectInOut, alignWithVector, alignWithNormal, triangleForward, triangleNormal);
		Vector3 vector = gameObjectInOut.transform.TransformPoint(trianglePosition);
		Vector3 vector2 = alignWithPosition - vector;
		gameObjectInOut.transform.Translate(vector2, Space.World);
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x00005546 File Offset: 0x00003746
	public static void VectorsToTransform(ref GameObject gameObjectInOut, Vector3 positionVector, Vector3 directionVector, Vector3 normalVector)
	{
		gameObjectInOut.transform.position = positionVector;
		gameObjectInOut.transform.rotation = Quaternion.LookRotation(directionVector, normalVector);
	}

	// Token: 0x060000AA RID: 170 RVA: 0x00005568 File Offset: 0x00003768
	public static int PointOnWhichSideOfLineSegment(Vector3 linePoint1, Vector3 linePoint2, Vector3 point)
	{
		Vector3 vector = linePoint2 - linePoint1;
		Vector3 vector2 = point - linePoint1;
		if (Vector3.Dot(vector2, vector) <= 0f)
		{
			return 1;
		}
		if (vector2.magnitude <= vector.magnitude)
		{
			return 0;
		}
		return 2;
	}

	// Token: 0x060000AB RID: 171 RVA: 0x000055A8 File Offset: 0x000037A8
	public static int PointOnWhichSideOfLineSegmentProyected(Vector3 linePoint1, Vector3 linePoint2, Vector3 point)
	{
		Vector3 vector = Math3d.ProjectPointOnLine(linePoint1, (linePoint2 - linePoint1).normalized, point);
		return Math3d.PointOnWhichSideOfLineSegment(linePoint1, linePoint2, vector);
	}

	// Token: 0x060000AC RID: 172 RVA: 0x000055D4 File Offset: 0x000037D4
	public static float MouseDistanceToLine(Vector3 linePoint1, Vector3 linePoint2)
	{
		Camera main = Camera.main;
		Vector3 mousePosition = Input.mousePosition;
		Vector3 vector = main.WorldToScreenPoint(linePoint1);
		Vector3 vector2 = main.WorldToScreenPoint(linePoint2);
		Vector3 vector3 = Math3d.ProjectPointOnLineSegment(vector, vector2, mousePosition);
		vector3 = new Vector3(vector3.x, vector3.y, 0f);
		return (vector3 - mousePosition).magnitude;
	}

	// Token: 0x060000AD RID: 173 RVA: 0x0000562C File Offset: 0x0000382C
	public static float MouseDistanceToCircle(Vector3 point, float radius)
	{
		Camera main = Camera.main;
		Vector3 mousePosition = Input.mousePosition;
		Vector3 vector = main.WorldToScreenPoint(point);
		vector = new Vector3(vector.x, vector.y, 0f);
		return (vector - mousePosition).magnitude - radius;
	}

	// Token: 0x060000AE RID: 174 RVA: 0x00005674 File Offset: 0x00003874
	public static bool IsLineInRectangle(Vector3 linePoint1, Vector3 linePoint2, Vector3 rectA, Vector3 rectB, Vector3 rectC, Vector3 rectD)
	{
		bool flag = false;
		bool flag2 = Math3d.IsPointInRectangle(linePoint1, rectA, rectC, rectB, rectD);
		if (!flag2)
		{
			flag = Math3d.IsPointInRectangle(linePoint2, rectA, rectC, rectB, rectD);
		}
		if (!flag2 && !flag)
		{
			bool flag3 = Math3d.AreLineSegmentsCrossing(linePoint1, linePoint2, rectA, rectB);
			bool flag4 = Math3d.AreLineSegmentsCrossing(linePoint1, linePoint2, rectB, rectC);
			bool flag5 = Math3d.AreLineSegmentsCrossing(linePoint1, linePoint2, rectC, rectD);
			bool flag6 = Math3d.AreLineSegmentsCrossing(linePoint1, linePoint2, rectD, rectA);
			return flag3 || flag4 || flag5 || flag6;
		}
		return true;
	}

	// Token: 0x060000AF RID: 175 RVA: 0x000056DC File Offset: 0x000038DC
	public static bool IsPointInRectangle(Vector3 point, Vector3 rectA, Vector3 rectC, Vector3 rectB, Vector3 rectD)
	{
		Vector3 vector = rectC - rectA;
		float num = -(vector.magnitude / 2f);
		vector = Math3d.AddVectorLength(vector, num);
		Vector3 vector2 = rectA + vector;
		Vector3 vector3 = rectB - rectA;
		float num2 = vector3.magnitude / 2f;
		Vector3 vector4 = rectD - rectA;
		float num3 = vector4.magnitude / 2f;
		float magnitude = (Math3d.ProjectPointOnLine(vector2, vector3.normalized, point) - point).magnitude;
		return (Math3d.ProjectPointOnLine(vector2, vector4.normalized, point) - point).magnitude <= num2 && magnitude <= num3;
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x00005784 File Offset: 0x00003984
	public static bool AreLineSegmentsCrossing(Vector3 pointA1, Vector3 pointA2, Vector3 pointB1, Vector3 pointB2)
	{
		Vector3 vector = pointA2 - pointA1;
		Vector3 vector2 = pointB2 - pointB1;
		Vector3 vector3;
		Vector3 vector4;
		if (Math3d.ClosestPointsOnTwoLines(out vector3, out vector4, pointA1, vector.normalized, pointB1, vector2.normalized))
		{
			bool flag = Math3d.PointOnWhichSideOfLineSegment(pointA1, pointA2, vector3) != 0;
			int num = Math3d.PointOnWhichSideOfLineSegment(pointB1, pointB2, vector4);
			return !flag && num == 0;
		}
		return false;
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x000057D8 File Offset: 0x000039D8
	public static float LinearFunction2DBasic(float x, float Qx, float Qy)
	{
		return x * (Qy / Qx);
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x000057E0 File Offset: 0x000039E0
	public static float LinearFunction2DFull(float x, float Px, float Py, float Qx, float Qy)
	{
		float num = Qy - Py;
		float num2 = Qx - Px;
		float num3 = num / num2;
		return Py + num3 * (x - Px);
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x00005800 File Offset: 0x00003A00
	public static Vector3 RotDiffToSpeedVec(Quaternion rotation, float deltaTime)
	{
		float num;
		if (rotation.eulerAngles.x <= 180f)
		{
			num = rotation.eulerAngles.x;
		}
		else
		{
			num = rotation.eulerAngles.x - 360f;
		}
		float num2;
		if (rotation.eulerAngles.y <= 180f)
		{
			num2 = rotation.eulerAngles.y;
		}
		else
		{
			num2 = rotation.eulerAngles.y - 360f;
		}
		float num3;
		if (rotation.eulerAngles.z <= 180f)
		{
			num3 = rotation.eulerAngles.z;
		}
		else
		{
			num3 = rotation.eulerAngles.z - 360f;
		}
		return new Vector3(num / deltaTime, num2 / deltaTime, num3 / deltaTime);
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x000058BC File Offset: 0x00003ABC
	public static Quaternion LookAtLocalVerticalPriority(Transform transform, Vector3 diretionToLookAt, Vector3 initialLocalRight, bool drawAxis = false)
	{
		Vector3 vector = transform.parent.TransformDirection(initialLocalRight);
		Vector3 normalized = Vector3.Cross(diretionToLookAt, vector).normalized;
		Quaternion quaternion = Quaternion.LookRotation(diretionToLookAt, normalized);
		if (drawAxis)
		{
			Debug.DrawRay(transform.position, transform.right * 0.1f, Color.red, Time.deltaTime, false);
			Debug.DrawRay(transform.position, transform.up * 0.1f, Color.green, Time.deltaTime, false);
			Debug.DrawRay(transform.position, transform.forward * 0.1f, Color.blue, Time.deltaTime, false);
		}
		return quaternion;
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x00005964 File Offset: 0x00003B64
	public static Quaternion LookAtLocalLateralPriority(Transform transform, Vector3 diretionToLookAt, Vector3 initialLocalUp, bool drawAxis = false)
	{
		Vector3 vector = transform.parent.TransformDirection(initialLocalUp);
		Quaternion quaternion = Quaternion.LookRotation(diretionToLookAt, vector);
		if (drawAxis)
		{
			Debug.DrawRay(transform.position, transform.right * 0.1f, Color.red, Time.deltaTime, false);
			Debug.DrawRay(transform.position, transform.up * 0.1f, Color.green, Time.deltaTime, false);
			Debug.DrawRay(transform.position, transform.forward * 0.1f, Color.blue, Time.deltaTime, false);
		}
		return quaternion;
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x000059FA File Offset: 0x00003BFA
	public static Quaternion LookAtLocalTwistSameAsTarget(Vector3 ownPosition, Vector3 targetPosition, Vector3 targetUp)
	{
		return Quaternion.LookRotation(targetPosition - ownPosition, targetUp);
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x00005A09 File Offset: 0x00003C09
	public static Quaternion DampedTrackRotationInsideArmature(Transform own, Transform target, Quaternion ownInitialLocalRotation, Vector3 axis, bool drawAxis)
	{
		if (own.parent == null)
		{
			throw new ArgumentNullException("own.parent", "se requiere un transform con padre.");
		}
		return Math3d.DampedTrackRotation(own, target, ownInitialLocalRotation, own.parent.rotation, axis, drawAxis);
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00005A3F File Offset: 0x00003C3F
	public static Quaternion DampedTrackRotation(Transform own, Transform target, Quaternion ownInitialLocalRotation, Vector3 axis, bool drawAxis)
	{
		return Math3d.DampedTrackRotation(own.position, target, ownInitialLocalRotation, own.parent.rotation, axis, drawAxis);
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x00005A5C File Offset: 0x00003C5C
	public static Quaternion DampedTrackRotation(Transform own, Transform target, Quaternion ownInitialLocalRotation, Quaternion ownParentRotation, Vector3 axis, bool drawAxis)
	{
		return Math3d.DampedTrackRotation(own.position, target, ownInitialLocalRotation, ownParentRotation, axis, drawAxis);
	}

	// Token: 0x060000BA RID: 186 RVA: 0x00005A70 File Offset: 0x00003C70
	public static Quaternion DampedTrackRotation(Vector3 ownWorldPosition, Transform target, Quaternion ownInitialLocalRotation, Quaternion ownParentRotation, Vector3 axis, bool drawAxis)
	{
		return Math3d.DampedTrackRotation(ownWorldPosition, target.position, ownInitialLocalRotation, ownParentRotation, axis, drawAxis);
	}

	// Token: 0x060000BB RID: 187 RVA: 0x00005A84 File Offset: 0x00003C84
	public static Quaternion DampedTrackRotation(Vector3 ownWorldPosition, Vector3 targetWorldPosition, Quaternion ownInitialLocalRotation, Quaternion ownParentRotation, Vector3 axis, bool drawAxis)
	{
		Vector3 vector = (ownParentRotation * ownInitialLocalRotation * axis).normalized;
		if (vector.sqrMagnitude == 0f)
		{
			vector = axis;
		}
		Vector3 vector2 = (targetWorldPosition - ownWorldPosition).normalized;
		if (vector2.sqrMagnitude == 0f)
		{
			vector2 = vector;
		}
		Vector3 vector3 = Vector3.Cross(vector2, vector);
		float num = Vector3.Dot(vector2, vector);
		num = Mathf.Acos(Mathf.Max(-1f, Mathf.Min(1f, num))) * 57.29578f;
		Quaternion quaternion = Quaternion.Inverse(Quaternion.AngleAxis(num, vector3)) * ownParentRotation * ownInitialLocalRotation;
		if (drawAxis)
		{
			Debug.DrawRay(ownWorldPosition, quaternion * Vector3.right * 0.1f, Color.red, Time.deltaTime, false);
			Debug.DrawRay(ownWorldPosition, quaternion * Vector3.up * 0.1f, Color.green, Time.deltaTime, false);
			Debug.DrawRay(ownWorldPosition, quaternion * Vector3.forward * 0.1f, Color.blue, Time.deltaTime, false);
		}
		return quaternion;
	}
}
