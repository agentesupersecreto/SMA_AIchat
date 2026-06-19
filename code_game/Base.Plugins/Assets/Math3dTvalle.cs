using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200012D RID: 301
	public static class Math3dTvalle
	{
		// Token: 0x06000864 RID: 2148 RVA: 0x0001BFB4 File Offset: 0x0001A1B4
		public static Vector3 TransformPointUnscaled(this Transform transform, Transform scaleProxy, Vector3 position)
		{
			return Matrix4x4.TRS(transform.position, transform.rotation, scaleProxy.lossyScale).MultiplyPoint3x4(position);
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x0001BFE4 File Offset: 0x0001A1E4
		public static Vector3 InverseTransformPointUnscaled(this Transform transform, Transform scaleProxy, Vector3 position)
		{
			return Matrix4x4.TRS(transform.position, transform.rotation, scaleProxy.lossyScale).inverse.MultiplyPoint3x4(position);
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x0001C01C File Offset: 0x0001A21C
		public static bool PuntoEstaDelanteDePlano(Vector3 planeNormal, Vector3 planePoint, Vector3 point)
		{
			Vector3 normalized = (point - planePoint).normalized;
			return Vector3.Dot(planeNormal, normalized) > 0f;
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x0001C04D File Offset: 0x0001A24D
		public static Matrix4x4 Invert_LocalAToLocalB(Matrix4x4 localAToLocalB, Matrix4x4 bLocalToWorldMatrix)
		{
			return bLocalToWorldMatrix * localAToLocalB.inverse;
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x0001C05C File Offset: 0x0001A25C
		public static Matrix4x4 LocalAToLocalB(Matrix4x4 aLocalToWorldMatrix, Matrix4x4 bWorldToLocalMatrix)
		{
			return bWorldToLocalMatrix * aLocalToWorldMatrix;
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x0001C065 File Offset: 0x0001A265
		public static Matrix4x4 LocalAToLocalB(Transform a, Transform b)
		{
			return b.worldToLocalMatrix * a.localToWorldMatrix;
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x0001C078 File Offset: 0x0001A278
		public static Matrix4x4 WorldIsTransform(Transform transform, Transform newWorld)
		{
			return newWorld.worldToLocalMatrix * transform.localToWorldMatrix;
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x0001C08C File Offset: 0x0001A28C
		public static Vector3 LimitDirectionAngleV2(Vector3 forward, Vector3 directionToTarget, float maxAngle, Vector3? debug_WoldPos = null)
		{
			float num = maxAngle * 0.017453292f;
			return Vector3.RotateTowards(forward, directionToTarget, num, 1f);
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x0001C0B0 File Offset: 0x0001A2B0
		public static Vector3 LimitDirectionAngleOnPlaneV2(Vector3 forward, Vector3 directionToTarget, Vector3 planeNormal, float maxAngle, Vector3? debug_WoldPos = null)
		{
			float num = maxAngle * 0.017453292f;
			if (planeNormal.sqrMagnitude != 1f)
			{
				planeNormal = planeNormal.normalized;
			}
			Vector3 vector = Math3d.ProjectVectorOnPlane(planeNormal, directionToTarget);
			return Vector3.RotateTowards(forward, vector, num, 1f);
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x0001C0F4 File Offset: 0x0001A2F4
		public static bool AngleOnPlaneExcedidoV2(Vector3 forward, Vector3 directionToTarget, Vector3 planeNormal, float maxAngle, Vector3 debug_WoldPos)
		{
			if (planeNormal.sqrMagnitude != 1f)
			{
				planeNormal = planeNormal.normalized;
			}
			Vector3 vector = Math3d.ProjectVectorOnPlane(planeNormal, directionToTarget);
			Vector3 vector2 = Math3d.ProjectVectorOnPlane(planeNormal, forward);
			return Vector3.Angle(vector, vector2) > maxAngle;
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x0001C130 File Offset: 0x0001A330
		[Obsolete("usar var2", true)]
		public static Vector3 ConstraintInsideCone(Vector3 coneNormal, Vector3 conePoint, float coneAngle, float coneDistance, Vector3 point)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x0001C138 File Offset: 0x0001A338
		public static Vector3 ProjectPointOnConeSurface(Vector3 coneNormal, Vector3 conePoint, float coneAngle, float coneDistance, Vector3 point, bool invertDirection = false)
		{
			if (coneNormal.sqrMagnitude != 1f)
			{
				coneNormal = coneNormal.normalized;
			}
			Vector3 vector = Math3d.ProjectPointOnPlane(coneNormal, conePoint, point);
			if (coneAngle == 90f)
			{
				return vector;
			}
			if (conePoint == point)
			{
				return conePoint + coneNormal * coneDistance;
			}
			Quaternion quaternion2;
			if (!MathfExtension.AlmostEqual(vector, conePoint, 0.0001f))
			{
				Vector3 normalized = (vector - conePoint).normalized;
				Quaternion quaternion;
				if (invertDirection)
				{
					quaternion = Quaternion.LookRotation(-normalized, coneNormal);
				}
				else
				{
					quaternion = Quaternion.LookRotation(normalized, coneNormal);
				}
				quaternion2 = quaternion * Quaternion.AngleAxis(90f - coneAngle, -Vector3.right);
			}
			else
			{
				quaternion2 = Quaternion.LookRotation(coneNormal);
			}
			float num = Vector3.Distance(conePoint, point);
			return conePoint + quaternion2 * Vector3.forward * Mathf.Min(num, coneDistance);
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x0001C214 File Offset: 0x0001A414
		public static Vector3 ProjectPointInsideCone(Vector3 coneNormal, Vector3 conePoint, float coneAngle, float coneDistance, Vector3 point)
		{
			if (coneNormal.sqrMagnitude != 1f)
			{
				coneNormal = coneNormal.normalized;
			}
			Vector3 vector = point - conePoint;
			if (Vector3.Angle(coneNormal, vector) <= coneAngle)
			{
				return point;
			}
			Vector3 vector2 = Math3d.ProjectPointOnPlane(coneNormal, conePoint, point);
			if (coneAngle == 90f)
			{
				return vector2;
			}
			if (conePoint == point)
			{
				return point;
			}
			if (MathfExtension.AlmostEqual(vector2, conePoint, 0.0001f))
			{
				return conePoint;
			}
			Quaternion quaternion = Quaternion.LookRotation((vector2 - conePoint).normalized, coneNormal) * Quaternion.AngleAxis(coneAngle, Vector3.right);
			Vector3 vector3 = quaternion * Vector3.forward;
			Vector3 vector4 = quaternion * Vector3.up;
			if (Vector3.Dot(vector.normalized, vector4) <= 0f)
			{
				return conePoint;
			}
			return Math3d.ProjectPointOnPlane(vector3, conePoint, point);
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x0001C2E1 File Offset: 0x0001A4E1
		public static float AngleOnPlane(Vector3 planeNormal, Vector3 planePoint, Vector3 aDirection, Vector3 bDirection, bool debug = false)
		{
			aDirection = Math3d.ProjectVectorOnPlane(planeNormal, aDirection);
			bDirection = Math3d.ProjectVectorOnPlane(planeNormal, bDirection);
			return Vector3.Angle(aDirection, bDirection);
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x0001C2FF File Offset: 0x0001A4FF
		public static Quaternion ClampRotation(Quaternion from, Quaternion to, float maxDegrees)
		{
			return Quaternion.RotateTowards(from, to, maxDegrees);
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x0001C30C File Offset: 0x0001A50C
		public static Vector3 LimitDirectionAngle(Vector3 directionToTarget, float maxAngle)
		{
			float num;
			Vector3 vector;
			Quaternion.LookRotation(directionToTarget).ToAngleAxis(out num, out vector);
			if (num < 0f)
			{
				throw new NotSupportedException();
			}
			return Quaternion.AngleAxis(Mathf.Clamp(num, 0f, maxAngle), vector) * Vector3.forward;
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x0001C358 File Offset: 0x0001A558
		public static Vector3 LimitDirectionAngleOnPlane(Vector3 forward, Vector3 up, Vector3 directionToTarget, Vector3 planeNormal, float maxAngle, Vector3? debug_WoldPos = null)
		{
			Vector3 vector = Math3d.ProjectVectorOnPlane(planeNormal, directionToTarget);
			float num;
			Vector3 vector2;
			Quaternion.FromToRotation(forward, vector).ToAngleAxis(out num, out vector2);
			if (num < 0f)
			{
				throw new NotSupportedException();
			}
			Vector3 vector3 = Quaternion.LookRotation(forward, up) * Quaternion.AngleAxis(Mathf.Clamp(num, 0f, maxAngle), vector2) * Vector3.forward;
			if (debug_WoldPos != null)
			{
				Vector3 value = debug_WoldPos.Value;
			}
			return vector3;
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x0001C3C8 File Offset: 0x0001A5C8
		public static float GetAngleOnNormal(Vector3 planeNormal, Vector3 planePoint, Vector3 targetPosition, bool debug = false)
		{
			Vector3 vector = targetPosition - planePoint;
			Vector3 vector2 = Math3d.ProjectPointOnPlane(planeNormal, planePoint, targetPosition) - planePoint;
			return Vector3.Angle(vector, vector2);
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x0001C3F4 File Offset: 0x0001A5F4
		public static float GetAngleOnNormalPolarity(Vector3 planeNormal, Vector3 planePoint, Vector3 targetPosition, Vector3 planeCross, bool debug = false)
		{
			Vector3 vector = targetPosition - planePoint;
			Vector3 vector2 = Math3d.ProjectPointOnPlane(planeNormal, planePoint, targetPosition) - planePoint;
			float num = Vector3.Angle(vector, vector2);
			Vector3 vector3 = Vector3.Cross(vector, vector2);
			if (Vector3.Dot(planeCross, vector3) < 0f)
			{
				num *= -1f;
			}
			return num;
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x0001C440 File Offset: 0x0001A640
		public static float GetHorizontalAngle(Transform own, Transform target, bool polarity = false)
		{
			return Math3dTvalle.GetHorizontalAngle(own, target.position, polarity);
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x0001C450 File Offset: 0x0001A650
		public static float GetHorizontalAngle(Transform own, Vector3 worldPosition, bool polarity = false)
		{
			Vector3 vector = own.InverseTransformPoint(worldPosition);
			float num = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
			if (!polarity)
			{
				num = Mathf.Abs(num);
			}
			return num;
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x0001C488 File Offset: 0x0001A688
		public static float GetHorizontalAngle(Quaternion ownWorldRotation, Vector3 ownWorldPosition, Vector3 targetWorldPosition, bool polarity = false)
		{
			Vector3 vector = targetWorldPosition - ownWorldPosition;
			return Math3dTvalle.GetHorizontalDirectionAngle(ownWorldRotation, vector, polarity);
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x0001C4A5 File Offset: 0x0001A6A5
		public static float GetHorizontalAngle(Vector3 worldForward, Vector3 worldUp, Vector3 ownWorldPosition, Vector3 targetWorldPosition, bool polarity = false)
		{
			return Math3dTvalle.GetHorizontalAngle(Quaternion.LookRotation(worldForward, worldUp), ownWorldPosition, targetWorldPosition, polarity);
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x0001C4B8 File Offset: 0x0001A6B8
		public static float GetHorizontalDirectionAngle(Quaternion ownWorldRotation, Vector3 WorldDirection, bool polarity = false)
		{
			Vector3 vector = Quaternion.Inverse(ownWorldRotation) * WorldDirection;
			float num = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
			if (!polarity)
			{
				num = Mathf.Abs(num);
			}
			return num;
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x0001C4F5 File Offset: 0x0001A6F5
		public static float GetHorizontalDirectionAngle(Vector3 worldForward, Vector3 worldUp, Vector3 WorldDirection, bool polarity = false)
		{
			return Math3dTvalle.GetHorizontalDirectionAngle(Quaternion.LookRotation(worldForward, worldUp), WorldDirection, polarity);
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x0001C508 File Offset: 0x0001A708
		public static void GetDirectionAngle(out float vertical, out float horizontal, Quaternion ownWorldRotation, Vector3 WorldDirection, bool polarity = false)
		{
			Vector3 vector = Quaternion.Inverse(ownWorldRotation) * WorldDirection;
			horizontal = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
			if (!polarity)
			{
				horizontal = Mathf.Abs(horizontal);
			}
			vertical = Math3dTvalle.GetAngleOnNormal(ownWorldRotation * Vector3.up, Vector3.zero, WorldDirection, false);
			if (polarity)
			{
				vertical *= ((vector.y < 0f) ? (-1f) : 1f);
			}
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x0001C584 File Offset: 0x0001A784
		public static void GetDirectionAngle(out float vertical, out float verticalOnPlane, out float horizontal, Quaternion ownWorldRotation, Vector3 WorldDirection, bool polarity = false)
		{
			Vector3 vector = Quaternion.Inverse(ownWorldRotation) * WorldDirection;
			horizontal = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
			Vector3 vector2 = Math3d.ProjectVectorOnPlane(ownWorldRotation * Vector3.right, WorldDirection);
			if (!polarity)
			{
				horizontal = Mathf.Abs(horizontal);
			}
			vertical = Math3dTvalle.GetAngleOnNormal(ownWorldRotation * Vector3.up, Vector3.zero, WorldDirection, false);
			verticalOnPlane = Math3dTvalle.GetAngleOnNormal(ownWorldRotation * Vector3.up, Vector3.zero, vector2, false);
			if (polarity)
			{
				vertical *= ((vector.y < 0f) ? (-1f) : 1f);
				Vector3 vector3 = Quaternion.Inverse(ownWorldRotation) * vector2;
				verticalOnPlane *= ((vector3.y < 0f) ? (-1f) : 1f);
			}
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x0001C658 File Offset: 0x0001A858
		public static void GetVerticalAndHorizontalAngleOnPlane(out float vertical, out float horizontal, Vector3 worldForward, Vector3 worldUp, Vector3 ownWorldPosition, Vector3 targetWorldPosition, bool polarity = false)
		{
			Vector3 vector = Math3d.ProjectPointOnPlane(worldForward, ownWorldPosition, targetWorldPosition) - ownWorldPosition;
			Vector3 vector2 = Quaternion.Inverse(Quaternion.LookRotation(worldForward, worldUp)) * vector;
			vector2.z = 0f;
			vector2 = vector2.normalized;
			vertical = Mathf.Asin(vector2.y) * 57.29578f;
			horizontal = Mathf.Asin(vector2.x) * 57.29578f;
			if (!polarity)
			{
				vertical = Mathf.Abs(vertical);
				horizontal = Mathf.Abs(horizontal);
			}
		}
	}
}
