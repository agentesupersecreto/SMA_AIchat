using System;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x0200004A RID: 74
	public class GeometryExt
	{
		// Token: 0x06000393 RID: 915 RVA: 0x00012050 File Offset: 0x00010250
		static GeometryExt()
		{
			GeometryExt.SphericalDirections[0] = Vector3.forward;
			GeometryExt.SphericalDirections[1] = Vector3.back;
			GeometryExt.SphericalDirections[2] = Vector3.right;
			GeometryExt.SphericalDirections[3] = Vector3.left;
			GeometryExt.SphericalDirections[4] = Vector3.up;
			GeometryExt.SphericalDirections[5] = Vector3.down;
			GeometryExt.SphericalDirections[6] = Vector3.Normalize(new Vector3(1f, 1f, 1f));
			GeometryExt.SphericalDirections[7] = Vector3.Normalize(new Vector3(-1f, 1f, 1f));
			GeometryExt.SphericalDirections[8] = Vector3.Normalize(new Vector3(1f, -1f, 1f));
			GeometryExt.SphericalDirections[9] = Vector3.Normalize(new Vector3(-1f, -1f, 1f));
			GeometryExt.SphericalDirections[10] = Vector3.Normalize(new Vector3(1f, 1f, -1f));
			GeometryExt.SphericalDirections[11] = Vector3.Normalize(new Vector3(-1f, 1f, -1f));
			GeometryExt.SphericalDirections[12] = Vector3.Normalize(new Vector3(1f, -1f, -1f));
			GeometryExt.SphericalDirections[13] = Vector3.Normalize(new Vector3(-1f, -1f, -1f));
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0001220C File Offset: 0x0001040C
		public static Vector3 ClosestPoint(Vector3 rPoint, Collider rCollider, int rCollisionLayers = -1)
		{
			if (rCollisionLayers > -1 && rCollider != null && rCollider.gameObject != null && ((1 << rCollider.gameObject.layer) & rCollisionLayers) == 0)
			{
				return Vector3Ext.Null;
			}
			Vector3 vector = Vector3Ext.Null;
			if (rCollider is BoxCollider)
			{
				vector = GeometryExt.ClosestPoint(rPoint, (BoxCollider)rCollider);
			}
			else if (rCollider is SphereCollider)
			{
				vector = GeometryExt.ClosestPoint(rPoint, (SphereCollider)rCollider);
			}
			else if (rCollider is CapsuleCollider)
			{
				vector = GeometryExt.ClosestPoint(rPoint, (CapsuleCollider)rCollider);
			}
			else if (rCollider is CharacterController)
			{
				vector = GeometryExt.ClosestPoint(rPoint, (CharacterController)rCollider);
			}
			else if (rCollider is TerrainCollider)
			{
				vector = GeometryExt.ClosestPoint(rPoint, (TerrainCollider)rCollider, 4f, rCollisionLayers);
			}
			else if (rCollider is MeshCollider)
			{
				MeshCollider meshCollider = (MeshCollider)rCollider;
				if (!(meshCollider.sharedMesh == null))
				{
					if (meshCollider.sharedMesh.name == "Plane")
					{
						Transform transform = meshCollider.transform;
						Vector3 size = meshCollider.sharedMesh.bounds.size;
						size.y = 0.001f;
						vector = GeometryExt.ClosestPoint(rPoint, transform, Vector3.zero, size);
					}
					else if (!meshCollider.sharedMesh.isReadable)
					{
						vector = meshCollider.ClosestPointOnBounds(rPoint);
						Debug.LogWarning(string.Format("{0}'s mesh is not imported as 'Read/Write Enabled' and may not be accurate. For accurate collisions, check 'Read/Write Enabled' on the model's import settings.", meshCollider.name));
					}
					else
					{
						vector = MeshExt.ClosestPoint(rPoint, 0f, rCollider.gameObject.transform, meshCollider.sharedMesh);
					}
				}
			}
			return vector;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00012398 File Offset: 0x00010598
		public static Vector3 ClosestPoint(Vector3 rPoint, float rRadius, Collider rCollider, int rCollisionLayers = -1)
		{
			if (rCollisionLayers > -1 && rCollider != null && rCollider.gameObject != null && ((1 << rCollider.gameObject.layer) & rCollisionLayers) == 0)
			{
				return Vector3Ext.Null;
			}
			Vector3 vector = Vector3Ext.Null;
			if (rCollider is BoxCollider)
			{
				vector = GeometryExt.ClosestPoint(rPoint, (BoxCollider)rCollider);
			}
			else if (rCollider is SphereCollider)
			{
				vector = GeometryExt.ClosestPoint(rPoint, (SphereCollider)rCollider);
			}
			else if (rCollider is CapsuleCollider)
			{
				vector = GeometryExt.ClosestPoint(rPoint, (CapsuleCollider)rCollider);
			}
			else if (rCollider is CharacterController)
			{
				vector = GeometryExt.ClosestPoint(rPoint, (CharacterController)rCollider);
			}
			else if (rCollider is TerrainCollider)
			{
				vector = GeometryExt.ClosestPoint(rPoint, (TerrainCollider)rCollider, rRadius, rCollisionLayers);
			}
			else if (rCollider is MeshCollider)
			{
				MeshCollider meshCollider = (MeshCollider)rCollider;
				if (!(meshCollider.sharedMesh == null))
				{
					if (meshCollider.sharedMesh.name == "Plane")
					{
						Transform transform = meshCollider.transform;
						Vector3 size = meshCollider.sharedMesh.bounds.size;
						size.y = 0.001f;
						vector = GeometryExt.ClosestPoint(rPoint, transform, Vector3.zero, size);
					}
					else if (!meshCollider.sharedMesh.isReadable)
					{
						vector = meshCollider.ClosestPointOnBounds(rPoint);
						Debug.LogWarning(string.Format("{0}'s mesh is not imported as 'Read/Write Enabled' and may not be accurate. For accurate collisions, check 'Read/Write Enabled' on the model's import settings.", meshCollider.name));
					}
					else
					{
						vector = MeshExt.ClosestPoint(rPoint, rRadius, rCollider.gameObject.transform, meshCollider.sharedMesh);
					}
				}
			}
			return vector;
		}

		// Token: 0x06000396 RID: 918 RVA: 0x0001251C File Offset: 0x0001071C
		public static Vector3 ClosestPoint(Vector3 rPoint, Vector3 rLineStart, Vector3 rLineEnd)
		{
			Vector3 vector = rLineEnd - rLineStart;
			Vector3 vector2 = Vector3.Project(rPoint - rLineStart, vector);
			Vector3 vector3 = vector2 + rLineStart;
			if (Vector3.Dot(vector2, vector) < 0f)
			{
				vector3 = rLineStart;
			}
			else if (vector2.sqrMagnitude > vector.sqrMagnitude)
			{
				vector3 = rLineEnd;
			}
			return vector3;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x0001256C File Offset: 0x0001076C
		public static Vector3 ClosestPoint(ref Vector3 point, ref Vector3 vertex1, ref Vector3 vertex2, ref Vector3 vertex3)
		{
			Vector3 vector = vertex2 - vertex1;
			Vector3 vector2 = vertex3 - vertex1;
			Vector3 vector3 = point - vertex1;
			float num = Vector3.Dot(vector, vector3);
			float num2 = Vector3.Dot(vector2, vector3);
			if (num <= 0f && num2 <= 0f)
			{
				return vertex1;
			}
			Vector3 vector4 = point - vertex2;
			float num3 = Vector3.Dot(vector, vector4);
			float num4 = Vector3.Dot(vector2, vector4);
			if (num3 >= 0f && num4 <= num3)
			{
				return vertex2;
			}
			float num5 = num * num4 - num3 * num2;
			if (num5 <= 0f && num >= 0f && num3 <= 0f)
			{
				float num6 = num / (num - num3);
				return vertex1 + num6 * vector;
			}
			Vector3 vector5 = point - vertex3;
			float num7 = Vector3.Dot(vector, vector5);
			float num8 = Vector3.Dot(vector2, vector5);
			if (num8 >= 0f && num7 <= num8)
			{
				return vertex3;
			}
			float num9 = num7 * num2 - num * num8;
			if (num9 <= 0f && num2 >= 0f && num8 <= 0f)
			{
				float num10 = num2 / (num2 - num8);
				return vertex1 + num10 * vector2;
			}
			float num11 = num3 * num8 - num7 * num4;
			if (num11 <= 0f && num4 - num3 >= 0f && num7 - num8 >= 0f)
			{
				float num12 = (num4 - num3) / (num4 - num3 + (num7 - num8));
				return vertex2 + num12 * (vertex3 - vertex2);
			}
			float num13 = 1f / (num11 + num9 + num5);
			float num14 = num9 * num13;
			float num15 = num5 * num13;
			return vertex1 + vector * num14 + vector2 * num15;
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0001277C File Offset: 0x0001097C
		public static Vector3 ClosestPoint(Vector3 rPoint, Vector3 rPosition, float rRadius)
		{
			Vector3 vector = Vector3.Normalize(rPoint - rPosition) * rRadius;
			return rPosition + vector;
		}

		// Token: 0x06000399 RID: 921 RVA: 0x000127A4 File Offset: 0x000109A4
		public static Vector3 ClosestPoint(Vector3 rPoint, Transform rTransform, Vector3 rCenter, Vector3 rColliderSize)
		{
			Vector3 vector = rColliderSize * 0.5f;
			Vector3 vector2 = ((rTransform != null) ? rTransform.InverseTransformPoint(rPoint) : rPoint);
			if (vector2.x < -vector.x || vector2.x > vector.x || vector2.y < -vector.y || vector2.y > vector.y || vector2.z < -vector.z || vector2.z > vector.z)
			{
				vector2 -= rCenter;
				vector2.x = Mathf.Clamp(vector2.x, -vector.x, vector.x);
				vector2.y = Mathf.Clamp(vector2.y, -vector.y, vector.y);
				vector2.z = Mathf.Clamp(vector2.z, -vector.z, vector.z);
				vector2 += rCenter;
			}
			else
			{
				float num = vector.x - Mathf.Abs(vector2.x);
				float num2 = vector.y - Mathf.Abs(vector2.y);
				float num3 = vector.z - Mathf.Abs(vector2.z);
				if (num < num2 && num < num3)
				{
					vector2.x = ((vector2.x < 0f) ? (-vector.x) : vector.x);
				}
				else if (num2 < num && num2 < num3)
				{
					vector2.y = ((vector2.y < 0f) ? (-vector.y) : vector.y);
				}
				else
				{
					vector2.z = ((vector2.z < 0f) ? (-vector.z) : vector.z);
				}
			}
			if (rTransform == null)
			{
				return vector2;
			}
			return rTransform.TransformPoint(vector2);
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0001296C File Offset: 0x00010B6C
		public static Vector3 ClosestPoint(Vector3 rPoint, Vector3 rLineStart, Vector3 rLineEnd, float rRadius)
		{
			Vector3 vector = rLineEnd - rLineStart;
			Vector3 vector2 = Vector3.Project(rPoint - rLineStart, vector);
			Vector3 vector3 = vector2 + rLineStart;
			if (Vector3.Dot(vector2, vector) < 0f)
			{
				vector3 = rLineStart;
			}
			else if (vector2.sqrMagnitude > vector.sqrMagnitude)
			{
				vector3 = rLineEnd;
			}
			return vector3 + (rPoint - vector3).normalized * rRadius;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x000129D8 File Offset: 0x00010BD8
		public static Vector3 ClosestPoint(Vector3 rPoint, SphereCollider rCollider)
		{
			Transform transform = rCollider.transform;
			Vector3 vector = Vector3.Normalize(rPoint - (transform.position + rCollider.center)) * (rCollider.radius * transform.localScale.x);
			return transform.position + rCollider.center + vector;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00012A38 File Offset: 0x00010C38
		public static Vector3 ClosestPoint(Vector3 rPoint, CapsuleCollider rCollider)
		{
			Vector3 vector = Vector3.zero;
			Transform transform = rCollider.transform;
			Vector3 vector2 = transform.InverseTransformPoint(rPoint);
			float num = rCollider.height * 0.5f;
			if (rCollider.direction == 0)
			{
				Vector3 vector3 = Vector3.right * (num - rCollider.radius);
				if (vector2.x > rCollider.center.x + num - rCollider.radius)
				{
					vector = GeometryExt.ClosestPoint(vector2, rCollider.center + vector3, rCollider.radius);
				}
				else if (vector2.x < rCollider.center.x - num + rCollider.radius)
				{
					vector = GeometryExt.ClosestPoint(vector2, rCollider.center - vector3, rCollider.radius);
				}
				else
				{
					vector = GeometryExt.ClosestPoint(vector2, rCollider.center - vector3, rCollider.center + vector3);
					vector = GeometryExt.ClosestPoint(vector2, vector, rCollider.radius);
				}
				return transform.TransformPoint(vector);
			}
			if (rCollider.direction == 1)
			{
				Vector3 vector4 = Vector3.up * (num - rCollider.radius);
				if (vector2.y > rCollider.center.y + num - rCollider.radius)
				{
					vector = GeometryExt.ClosestPoint(vector2, rCollider.center + vector4, rCollider.radius);
				}
				else if (vector2.y < rCollider.center.y - num + rCollider.radius)
				{
					vector = GeometryExt.ClosestPoint(vector2, rCollider.center - vector4, rCollider.radius);
				}
				else
				{
					vector = GeometryExt.ClosestPoint(vector2, rCollider.center - vector4, rCollider.center + vector4);
					vector = GeometryExt.ClosestPoint(vector2, vector, rCollider.radius);
				}
				return transform.TransformPoint(vector);
			}
			Vector3 vector5 = Vector3.forward * (num - rCollider.radius);
			if (vector2.z > rCollider.center.z + num - rCollider.radius)
			{
				vector = GeometryExt.ClosestPoint(vector2, rCollider.center + vector5, rCollider.radius);
			}
			else if (vector2.z < rCollider.center.z - num + rCollider.radius)
			{
				vector = GeometryExt.ClosestPoint(vector2, rCollider.center - vector5, rCollider.radius);
			}
			else
			{
				vector = GeometryExt.ClosestPoint(vector2, rCollider.center - vector5, rCollider.center + vector5);
				vector = GeometryExt.ClosestPoint(vector2, vector, rCollider.radius);
			}
			return transform.TransformPoint(vector);
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00012CB0 File Offset: 0x00010EB0
		public static Vector3 ClosestPoint(Vector3 rPoint, BoxCollider rCollider)
		{
			Transform transform = rCollider.transform;
			Vector3 vector = rCollider.size * 0.5f;
			Vector3 vector2 = transform.InverseTransformPoint(rPoint);
			if (vector2.x < -vector.x || vector2.x > vector.x || vector2.y < -vector.y || vector2.y > vector.y || vector2.z < -vector.z || vector2.z > vector.z)
			{
				vector2 -= rCollider.center;
				vector2.x = Mathf.Clamp(vector2.x, -vector.x, vector.x);
				vector2.y = Mathf.Clamp(vector2.y, -vector.y, vector.y);
				vector2.z = Mathf.Clamp(vector2.z, -vector.z, vector.z);
				vector2 += rCollider.center;
			}
			else
			{
				float num = vector.x - Mathf.Abs(vector2.x);
				float num2 = vector.y - Mathf.Abs(vector2.y);
				float num3 = vector.z - Mathf.Abs(vector2.z);
				if (num < num2 && num < num3)
				{
					vector2.x = ((vector2.x < 0f) ? (-vector.x) : vector.x);
				}
				else if (num2 < num && num2 < num3)
				{
					vector2.y = ((vector2.y < 0f) ? (-vector.y) : vector.y);
				}
				else
				{
					vector2.z = ((vector2.z < 0f) ? (-vector.z) : vector.z);
				}
			}
			return transform.TransformPoint(vector2);
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00012E70 File Offset: 0x00011070
		public static Vector3 ClosestPoint(Vector3 rPoint, TerrainCollider rCollider, float rRadius = 4f, int rCollisionLayers = -1)
		{
			RaycastHit raycastHit = default(RaycastHit);
			raycastHit.distance = float.MaxValue;
			for (int i = 0; i < GeometryExt.SphericalDirections.Length; i++)
			{
				RaycastHit raycastHit2;
				if (Physics.Raycast(rPoint, GeometryExt.SphericalDirections[i], out raycastHit2, rRadius + 0.05f, rCollisionLayers, QueryTriggerInteraction.Ignore) && raycastHit2.collider == rCollider && raycastHit2.distance < raycastHit.distance && !GeometryExt.IgnoreCollider(raycastHit2.collider))
				{
					raycastHit = raycastHit2;
				}
			}
			if (raycastHit.distance < 3.4028235E+38f)
			{
				return raycastHit.point;
			}
			return Vector3Ext.Null;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00012F0C File Offset: 0x0001110C
		public static Vector3 ClosestPoint(Vector3 rPoint, Vector3 rDirection, float rRadius, TerrainCollider rCollider, int rCollisionLayers = -1)
		{
			RaycastHit raycastHit;
			if (rDirection.sqrMagnitude > 0f && Physics.SphereCast(rPoint, rRadius * 0.5f, rDirection, out raycastHit, rRadius, rCollisionLayers, QueryTriggerInteraction.Ignore) && raycastHit.collider == rCollider)
			{
				RaycastHit raycastHit2;
				if (Physics.Raycast(rPoint, raycastHit.point - rPoint, out raycastHit2, rRadius + 0.01f, rCollisionLayers, QueryTriggerInteraction.Ignore) && raycastHit2.collider == rCollider)
				{
					raycastHit = raycastHit2;
				}
				return raycastHit.point;
			}
			raycastHit = default(RaycastHit);
			raycastHit.distance = float.MaxValue;
			for (int i = 0; i < GeometryExt.SphericalDirections.Length; i++)
			{
				RaycastHit raycastHit3;
				if (Physics.Raycast(rPoint, GeometryExt.SphericalDirections[i], out raycastHit3, rRadius + 0.05f, rCollisionLayers, QueryTriggerInteraction.Ignore) && raycastHit3.collider == rCollider && raycastHit3.distance < raycastHit.distance && !GeometryExt.IgnoreCollider(raycastHit3.collider))
				{
					raycastHit = raycastHit3;
				}
			}
			if (raycastHit.distance < 3.4028235E+38f)
			{
				return raycastHit.point;
			}
			return Vector3Ext.Null;
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x00013018 File Offset: 0x00011218
		public static Vector3 ClosestPoint(Vector3 rPoint, CharacterController rController)
		{
			Vector3 vector = Vector3.zero;
			Transform transform = rController.transform;
			Vector3 vector2 = rPoint - transform.position;
			Vector3 vector3 = Vector3.up * (rController.height * 0.5f - rController.radius);
			if (vector2.y > rController.height - rController.radius)
			{
				vector = GeometryExt.ClosestPoint(vector2, rController.center + vector3, rController.radius);
			}
			else if (vector2.y < rController.radius)
			{
				vector = GeometryExt.ClosestPoint(vector2, rController.center - vector3, rController.radius);
			}
			else
			{
				vector = GeometryExt.ClosestPoint(vector2, rController.center - vector3, rController.center + vector3);
				vector = GeometryExt.ClosestPoint(vector2, vector, rController.radius);
			}
			return vector + transform.position;
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x000130F0 File Offset: 0x000112F0
		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, float rRadius, Collider rCollider, ref Vector3 rLinePoint, ref Vector3 rColliderPoint, int rCollisionLayers = -1)
		{
			if (rCollisionLayers > -1 && rCollider != null && rCollider.gameObject != null && ((1 << rCollider.gameObject.layer) & rCollisionLayers) == 0)
			{
				return;
			}
			if (rCollider is BoxCollider)
			{
				GeometryExt.ClosestPoints(rStart, rEnd, (BoxCollider)rCollider, ref rLinePoint, ref rColliderPoint);
				return;
			}
			if (rCollider is SphereCollider)
			{
				GeometryExt.ClosestPoints(rStart, rEnd, (SphereCollider)rCollider, ref rLinePoint, ref rColliderPoint);
				return;
			}
			if (rCollider is CapsuleCollider)
			{
				GeometryExt.ClosestPoints(rStart, rEnd, (CapsuleCollider)rCollider, ref rLinePoint, ref rColliderPoint);
				return;
			}
			if (rCollider is CharacterController)
			{
				GeometryExt.ClosestPoints(rStart, rEnd, (CharacterController)rCollider, ref rLinePoint, ref rColliderPoint);
				return;
			}
			if (rCollider is TerrainCollider)
			{
				GeometryExt.ClosestPoints(rStart, rEnd, (TerrainCollider)rCollider, ref rLinePoint, ref rColliderPoint, rRadius, rCollisionLayers);
				return;
			}
			if (rCollider is MeshCollider)
			{
				GeometryExt.ClosestPoints(rStart, rEnd, rRadius, (MeshCollider)rCollider, ref rLinePoint, ref rColliderPoint);
			}
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x000131D0 File Offset: 0x000113D0
		public static void ClosestPoints(Vector3 rStart1, Vector3 rEnd1, Vector3 rStart2, Vector3 rEnd2, ref Vector3 rLine1Point, ref Vector3 rLine2Point)
		{
			Vector3 vector = rEnd1 - rStart1;
			float num = vector.magnitude * 0.5f;
			Vector3 normalized = vector.normalized;
			Vector3 vector2 = rStart1 + normalized * num;
			Vector3 vector3 = rEnd2 - rStart2;
			float num2 = vector3.magnitude * 0.5f;
			Vector3 normalized2 = vector3.normalized;
			Vector3 vector4 = rStart2 + normalized2 * num2;
			Vector3 vector5 = vector2 - vector4;
			float num3 = -normalized.Dot(normalized2);
			float num4 = vector5.Dot(normalized);
			float num5 = -vector5.Dot(normalized2);
			float num6 = Mathf.Abs(1f - num3 * num3);
			float num7;
			float num8;
			if (num6 >= 0.0001f)
			{
				num7 = num3 * num5 - num4;
				num8 = num3 * num4 - num5;
				float num9 = num * num6;
				float num10 = num2 * num6;
				if (num7 >= -num9)
				{
					if (num7 <= num9)
					{
						if (num8 >= -num10)
						{
							if (num8 <= num10)
							{
								float num11 = 1f / num6;
								num7 *= num11;
								num8 *= num11;
							}
							else
							{
								num8 = num2;
								float num12 = -(num3 * num8 + num4);
								if (num12 < -num)
								{
									num7 = -num;
								}
								else if (num12 <= num)
								{
									num7 = num12;
								}
								else
								{
									num7 = num;
								}
							}
						}
						else
						{
							num8 = -num2;
							float num13 = -(num3 * num8 + num4);
							if (num13 < -num)
							{
								num7 = -num;
							}
							else if (num13 <= num)
							{
								num7 = num13;
							}
							else
							{
								num7 = num;
							}
						}
					}
					else if (num8 >= -num10)
					{
						if (num8 <= num10)
						{
							num7 = num;
							float num14 = -(num3 * num7 + num5);
							if (num14 < -num2)
							{
								num8 = -num2;
							}
							else if (num14 <= num2)
							{
								num8 = num14;
							}
							else
							{
								num8 = num2;
							}
						}
						else
						{
							num8 = num2;
							float num15 = -(num3 * num8 + num4);
							if (num15 < -num)
							{
								num7 = -num;
							}
							else if (num15 <= num)
							{
								num7 = num15;
							}
							else
							{
								num7 = num;
								float num16 = -(num3 * num7 + num5);
								if (num16 < -num2)
								{
									num8 = -num2;
								}
								else if (num16 <= num2)
								{
									num8 = num16;
								}
								else
								{
									num8 = num2;
								}
							}
						}
					}
					else
					{
						num8 = -num2;
						float num17 = -(num3 * num8 + num4);
						if (num17 < -num)
						{
							num7 = -num;
						}
						else if (num17 <= num)
						{
							num7 = num17;
						}
						else
						{
							num7 = num;
							float num18 = -(num3 * num7 + num5);
							if (num18 > num2)
							{
								num8 = num2;
							}
							else if (num18 >= -num2)
							{
								num8 = num18;
							}
							else
							{
								num8 = -num2;
							}
						}
					}
				}
				else if (num8 >= -num10)
				{
					if (num8 <= num10)
					{
						num7 = -num;
						float num19 = -(num3 * num7 + num5);
						if (num19 < -num2)
						{
							num8 = -num2;
						}
						else if (num19 <= num2)
						{
							num8 = num19;
						}
						else
						{
							num8 = num2;
						}
					}
					else
					{
						num8 = num2;
						float num20 = -(num3 * num8 + num4);
						if (num20 > num)
						{
							num7 = num;
						}
						else if (num20 >= -num)
						{
							num7 = num20;
						}
						else
						{
							num7 = -num;
							float num21 = -(num3 * num7 + num5);
							if (num21 < -num2)
							{
								num8 = -num2;
							}
							else if (num21 <= num2)
							{
								num8 = num21;
							}
							else
							{
								num8 = num2;
							}
						}
					}
				}
				else
				{
					num8 = -num2;
					float num22 = -(num3 * num8 + num4);
					if (num22 > num)
					{
						num7 = num;
					}
					else if (num22 >= -num)
					{
						num7 = num22;
					}
					else
					{
						num7 = -num;
						float num23 = -(num3 * num7 + num5);
						if (num23 < -num2)
						{
							num8 = -num2;
						}
						else if (num23 <= num2)
						{
							num8 = num23;
						}
						else
						{
							num8 = num2;
						}
					}
				}
			}
			else
			{
				float num24 = num + num2;
				float num25 = ((num3 > 0f) ? (-1f) : 1f);
				float num26 = -((num4 - num25 * num5) * 0.5f);
				if (num26 < -num24)
				{
					num26 = -num24;
				}
				else if (num26 > num24)
				{
					num26 = num24;
				}
				num8 = -num25 * num26 * num2 / num24;
				num7 = num26 + num25 * num8;
			}
			rLine1Point = vector2 + normalized * num7;
			rLine2Point = vector4 + normalized2 * num8;
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x000135F4 File Offset: 0x000117F4
		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, Vector3 rPosition, float rRadius, ref Vector3 rLinePoint, ref Vector3 rColliderPoint)
		{
			Vector3 vector = rEnd - rStart;
			Vector3 normalized = vector.normalized;
			Vector3 vector2 = rPosition - rStart;
			float num = Vector3.Dot(vector2, normalized);
			float num2 = Mathf.Min((normalized * Mathf.Max(num, 0f)).magnitude, vector.magnitude);
			rLinePoint = rStart + normalized * num2;
			vector2 = rPosition - rLinePoint;
			rColliderPoint = rLinePoint + vector2.normalized * (vector2.magnitude - rRadius);
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00013694 File Offset: 0x00011894
		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, Transform rTransform, Vector3 rCenter, Vector3 rColliderSize, ref Vector3 rLinePoint, ref Vector3 rColliderPoint)
		{
			Vector3 vector = rEnd - rStart;
			Vector3 normalized = vector.normalized;
			Vector3 vector2 = rStart + normalized * (vector.magnitude * 0.5f);
			Vector3 vector3 = vector2 - rTransform.position;
			Vector3 right = rTransform.right;
			Vector3 up = rTransform.up;
			Vector3 forward = rTransform.forward;
			Vector3 vector4 = new Vector3(vector3.Dot(right), vector3.Dot(up), vector3.Dot(forward));
			Vector3 vector5 = new Vector3(normalized.Dot(right), normalized.Dot(up), normalized.Dot(forward));
			Vector3 vector6 = rColliderSize * 0.5f;
			vector6.x *= rTransform.lossyScale.x;
			vector6.y *= rTransform.lossyScale.y;
			vector6.z *= rTransform.lossyScale.z;
			if (vector5.x < 0f)
			{
				vector4.x = -vector4.x;
				vector5.x = -vector5.x;
			}
			if (vector5.y < 0f)
			{
				vector4.y = -vector4.y;
				vector5.y = -vector5.y;
			}
			if (vector5.z < 0f)
			{
				vector4.z = -vector4.z;
				vector5.z = -vector5.z;
			}
			float num = 0f;
			if (vector5.x > 0f)
			{
				if (vector5.y > 0f)
				{
					if (vector5.z > 0f)
					{
						GeometryExt.GetLineDistanceFromBoxExtent(ref vector6, ref vector4, ref vector5, ref num);
					}
					else
					{
						GeometryExt.GetLineDistanceFromBoxExtent(ref vector6, ref vector4, ref vector5, 0, 1, ref num);
					}
				}
				else if (vector5.z > 0f)
				{
					GeometryExt.GetLineDistanceFromBoxExtent(ref vector6, ref vector4, ref vector5, 0, 2, ref num);
				}
				else
				{
					GeometryExt.GetLineDistanceFromBoxExtent(ref vector6, ref vector4, ref vector5, 0, ref num);
				}
			}
			else if (vector5.y > 0f)
			{
				if (vector5.z > 0f)
				{
					GeometryExt.GetLineDistanceFromBoxExtent(ref vector6, ref vector4, ref vector5, 1, 2, ref num);
				}
				else
				{
					GeometryExt.GetLineDistanceFromBoxExtent(ref vector6, ref vector4, ref vector5, 1, ref num);
				}
			}
			else if (vector5.z > 0f)
			{
				GeometryExt.GetLineDistanceFromBoxExtent(ref vector6, ref vector4, ref vector5, 2, ref num);
			}
			else
			{
				num = 0f;
			}
			rLinePoint = vector2 + normalized * num;
			float num2 = vector.magnitude / 2f;
			if (num >= -num2)
			{
				if (num > num2)
				{
					rLinePoint = rEnd;
				}
			}
			else
			{
				rLinePoint = rStart;
			}
			rColliderPoint = GeometryExt.ClosestPoint(rLinePoint, rTransform, rCenter, rColliderSize);
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00013944 File Offset: 0x00011B44
		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, SphereCollider rCollider, ref Vector3 rLinePoint, ref Vector3 rColliderPoint)
		{
			Transform transform = rCollider.transform;
			float num = rCollider.radius * transform.lossyScale.x;
			Vector3 vector = rEnd - rStart;
			Vector3 normalized = vector.normalized;
			Vector3 vector2 = transform.position + rCollider.center - rStart;
			float num2 = Vector3.Dot(vector2, normalized);
			float num3 = Mathf.Min((normalized * Mathf.Max(num2, 0f)).magnitude, vector.magnitude);
			rLinePoint = rStart + normalized * num3;
			vector2 = transform.position + rCollider.center - rLinePoint;
			rColliderPoint = rLinePoint + vector2.normalized * (vector2.magnitude - num);
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00013A20 File Offset: 0x00011C20
		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, CapsuleCollider rCollider, ref Vector3 rLinePoint, ref Vector3 rColliderPoint)
		{
			Transform transform = rCollider.transform;
			float height = rCollider.height;
			float radius = rCollider.radius;
			Vector3 zero = Vector3.zero;
			zero[rCollider.direction] = height / 2f - radius;
			Vector3 vector = transform.TransformPoint(rCollider.center - zero);
			Vector3 vector2 = transform.TransformPoint(rCollider.center + zero);
			GeometryExt.ClosestPoints(rStart, rEnd, vector, vector2, ref rLinePoint, ref rColliderPoint);
			Vector3 vector3 = rLinePoint - rColliderPoint;
			rColliderPoint += vector3.normalized * (radius * transform.lossyScale.x);
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00013AD4 File Offset: 0x00011CD4
		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, BoxCollider rCollider, ref Vector3 rLinePoint, ref Vector3 rColliderPoint)
		{
			Transform transform = rCollider.transform;
			Vector3 vector = rEnd - rStart;
			Vector3 normalized = vector.normalized;
			Vector3 vector2 = rStart + normalized * (vector.magnitude * 0.5f);
			Vector3 vector3 = vector2 - transform.position;
			Vector3 right = transform.right;
			Vector3 up = transform.up;
			Vector3 forward = transform.forward;
			Vector3 vector4 = new Vector3(vector3.Dot(right), vector3.Dot(up), vector3.Dot(forward));
			Vector3 vector5 = new Vector3(normalized.Dot(right), normalized.Dot(up), normalized.Dot(forward));
			Vector3 vector6 = rCollider.size * 0.5f;
			vector6.x *= transform.lossyScale.x;
			vector6.y *= transform.lossyScale.y;
			vector6.z *= transform.lossyScale.z;
			if (vector5.x < 0f)
			{
				vector4.x = -vector4.x;
				vector5.x = -vector5.x;
			}
			if (vector5.y < 0f)
			{
				vector4.y = -vector4.y;
				vector5.y = -vector5.y;
			}
			if (vector5.z < 0f)
			{
				vector4.z = -vector4.z;
				vector5.z = -vector5.z;
			}
			float num = 0f;
			if (vector5.x > 0f)
			{
				if (vector5.y > 0f)
				{
					if (vector5.z > 0f)
					{
						GeometryExt.GetLineDistanceFromBoxExtent(ref vector6, ref vector4, ref vector5, ref num);
					}
					else
					{
						GeometryExt.GetLineDistanceFromBoxExtent(ref vector6, ref vector4, ref vector5, 0, 1, ref num);
					}
				}
				else if (vector5.z > 0f)
				{
					GeometryExt.GetLineDistanceFromBoxExtent(ref vector6, ref vector4, ref vector5, 0, 2, ref num);
				}
				else
				{
					GeometryExt.GetLineDistanceFromBoxExtent(ref vector6, ref vector4, ref vector5, 0, ref num);
				}
			}
			else if (vector5.y > 0f)
			{
				if (vector5.z > 0f)
				{
					GeometryExt.GetLineDistanceFromBoxExtent(ref vector6, ref vector4, ref vector5, 1, 2, ref num);
				}
				else
				{
					GeometryExt.GetLineDistanceFromBoxExtent(ref vector6, ref vector4, ref vector5, 1, ref num);
				}
			}
			else if (vector5.z > 0f)
			{
				GeometryExt.GetLineDistanceFromBoxExtent(ref vector6, ref vector4, ref vector5, 2, ref num);
			}
			else
			{
				num = 0f;
			}
			rLinePoint = vector2 + normalized * num;
			float num2 = vector.magnitude / 2f;
			if (num >= -num2)
			{
				if (num > num2)
				{
					rLinePoint = rEnd;
				}
			}
			else
			{
				rLinePoint = rStart;
			}
			rColliderPoint = GeometryExt.ClosestPoint(rLinePoint, rCollider);
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00013D8C File Offset: 0x00011F8C
		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, CharacterController rController, ref Vector3 rLinePoint, ref Vector3 rColliderPoint)
		{
			Transform transform = rController.transform;
			Vector3 zero = Vector3.zero;
			zero[1] = rController.height / 2f - rController.radius;
			Vector3 vector = transform.TransformPoint(rController.center - zero);
			Vector3 vector2 = transform.TransformPoint(rController.center + zero);
			GeometryExt.ClosestPoints(rStart, rEnd, vector, vector2, ref rLinePoint, ref rColliderPoint);
			Vector3 vector3 = rColliderPoint - rLinePoint;
			rColliderPoint = rLinePoint + vector3.normalized * (vector3.magnitude - rController.radius);
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00013E30 File Offset: 0x00012030
		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, TerrainCollider rCollider, ref Vector3 rLinePoint, ref Vector3 rColliderPoint, float rRadius = 4f, int rCollisionLayers = -1)
		{
			float num = float.MaxValue;
			float magnitude = (rEnd - rStart).magnitude;
			Vector3 normalized = (rEnd - rStart).normalized;
			for (float num2 = 0f; num2 < magnitude + rRadius; num2 += rRadius)
			{
				if (num2 > magnitude)
				{
					num2 = magnitude;
				}
				Vector3 vector = rStart + normalized * num2;
				Vector3 vector2 = GeometryExt.ClosestPoint(vector, rRadius, rCollider, rCollisionLayers);
				if (vector2 != Vector3Ext.Null)
				{
					float sqrMagnitude = (vector2 - vector).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						rLinePoint = vector;
						rColliderPoint = vector2;
						num = sqrMagnitude;
					}
				}
				if (num2 == magnitude)
				{
					break;
				}
			}
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00013EE4 File Offset: 0x000120E4
		public static void ClosestPoints(Vector3 rStart, Vector3 rEnd, float rRadius, MeshCollider rCollider, ref Vector3 rLinePoint, ref Vector3 rColliderPoint)
		{
			if (rCollider == null || rCollider.sharedMesh == null)
			{
				return;
			}
			if (rCollider.sharedMesh.name == "Plane")
			{
				Transform transform = rCollider.transform;
				Vector3 size = rCollider.sharedMesh.bounds.size;
				size.y = 0.001f;
				GeometryExt.ClosestPoints(rStart, rEnd, transform, Vector3.zero, size, ref rLinePoint, ref rColliderPoint);
				return;
			}
			Vector3 vector = rEnd - rStart;
			float magnitude = vector.magnitude;
			if (magnitude != 0f)
			{
				float num = rRadius * GeometryExt.LineMeshStepFactor;
				float num2 = float.MaxValue;
				Vector3 normalized = vector.normalized;
				for (float num3 = 0f; num3 < magnitude + num; num3 += num)
				{
					if (num3 > magnitude)
					{
						num3 = magnitude;
					}
					Vector3 vector2 = rStart + normalized * num3;
					Vector3 vector3;
					if (!rCollider.sharedMesh.isReadable)
					{
						vector3 = rCollider.ClosestPointOnBounds(vector2);
						Debug.LogWarning(string.Format("{0}'s mesh is not imported as 'Read/Write Enabled' and may not be accurate. For accurate collisions, check 'Read/Write Enabled' on the model's import settings.", rCollider.name));
					}
					else
					{
						vector3 = MeshExt.ClosestPoint(vector2, rRadius, rCollider.gameObject.transform, rCollider.sharedMesh);
					}
					if (vector3 != Vector3Ext.Null)
					{
						float sqrMagnitude = (vector3 - vector2).sqrMagnitude;
						if (sqrMagnitude < num2)
						{
							rLinePoint = vector2;
							rColliderPoint = vector3;
							num2 = sqrMagnitude;
						}
					}
					if (num3 == magnitude)
					{
						break;
					}
				}
				return;
			}
			rLinePoint = rStart;
			if (!rCollider.sharedMesh.isReadable)
			{
				rColliderPoint = rCollider.ClosestPointOnBounds(rStart);
				Debug.LogWarning(string.Format("{0}'s mesh is not imported as 'Read/Write Enabled' and may not be accurate. For accurate collisions, check 'Read/Write Enabled' on the model's import settings.", rCollider.name));
				return;
			}
			rColliderPoint = MeshExt.ClosestPoint(rStart, rRadius, rCollider.gameObject.transform, rCollider.sharedMesh);
		}

		// Token: 0x060003AB RID: 939 RVA: 0x000140A8 File Offset: 0x000122A8
		public static bool RaySphereIntersect(Vector3 rRayStart, Vector3 rRayDirection, Vector3 rSphereCenter, float rSphereRadius)
		{
			Vector3 vector = rSphereCenter - rRayStart;
			if (Vector3.Dot(rRayDirection, vector) <= 0f)
			{
				return false;
			}
			Vector3 vector2 = Vector3.Project(vector, rRayDirection);
			return Vector3.Distance(vector, vector2) <= rSphereRadius;
		}

		// Token: 0x060003AC RID: 940 RVA: 0x000140E4 File Offset: 0x000122E4
		public static bool LinePlaneIntersect(Vector3 rLineStart, Vector3 rLineEnd, Plane rPlane)
		{
			Vector3 vector = rLineEnd - rLineStart;
			float num = Vector3.Dot(rPlane.normal, vector);
			if (Mathf.Abs(num) > 0.0001f)
			{
				float num2 = -(Vector3.Dot(rPlane.normal, rLineStart) + rPlane.distance) / num;
				return num2 >= 0f && num2 <= 1f;
			}
			return false;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00014144 File Offset: 0x00012344
		public static bool LineSphereIntersect(Vector3 rLineStart, Vector3 rLineEnd, Vector3 rSphereCenter, float rSphereRadius)
		{
			Vector3 vector = rLineEnd - rLineStart;
			float magnitude = vector.magnitude;
			Vector3 normalized = vector.normalized;
			Vector3 vector2 = rSphereCenter - rLineStart;
			if (Vector3.Dot(normalized, vector2) <= 0f)
			{
				return false;
			}
			Vector3 vector3 = Vector3.Project(vector2, normalized);
			float num = Vector3.Distance(vector2, vector3);
			if (num > rSphereRadius)
			{
				return false;
			}
			if (Mathf.Abs(num - rSphereRadius) < 0.0001f)
			{
				if (Vector3.Distance(vector3, rLineStart) > magnitude)
				{
					return false;
				}
			}
			else
			{
				float num2 = Mathf.Sqrt(rSphereRadius * rSphereRadius - num * num);
				if (vector3.magnitude - num2 > magnitude)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x000141D8 File Offset: 0x000123D8
		public static bool LineCylinderIntersect(Vector3 rLineStart, Vector3 rLineEnd, Transform rTransform, float rHeight, float rRadius)
		{
			Matrix4x4 inverse = Matrix4x4.TRS(rTransform.position, rTransform.rotation, Vector3.one).inverse;
			Vector3 vector = inverse.MultiplyPoint(rLineStart);
			Vector3 vector2 = (inverse.MultiplyPoint(rLineEnd) - vector) * 0.5f;
			Vector3 vector3 = new Vector3(Mathf.Abs(vector2.x), Mathf.Abs(vector2.y), Mathf.Abs(vector2.z));
			Vector3 vector4 = new Vector3(rRadius, rHeight * 0.5f, rRadius);
			Vector3 vector5 = -vector4;
			Vector3 vector6 = (vector4 - vector5) * 0.5f;
			Vector3 vector7 = vector + vector2 - (vector5 + vector4) * 0.5f;
			return Mathf.Abs(vector7.x) <= vector6.x + vector3.x && Mathf.Abs(vector7.y) <= vector6.y + vector3.y && Mathf.Abs(vector7.z) <= vector6.z + vector3.z && Mathf.Abs(vector2.y * vector7.z - vector2.z * vector7.y) <= vector6.y * vector3.z + vector6.z * vector3.y + 0.0001f && Mathf.Abs(vector2.z * vector7.x - vector2.x * vector7.z) <= vector6.z * vector3.x + vector6.x * vector3.z + 0.0001f && Mathf.Abs(vector2.x * vector7.y - vector2.y * vector7.x) <= vector6.x * vector3.y + vector6.y * vector3.x + 0.0001f;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x000143E0 File Offset: 0x000125E0
		public static bool LineCylinderFromBaseIntersect(Vector3 rLineStart, Vector3 rLineEnd, Transform rTransform, float rHeight, float rRadius)
		{
			Matrix4x4 inverse = Matrix4x4.TRS(rTransform.position + rTransform.up * -(rHeight / 2f), rTransform.rotation, Vector3.one).inverse;
			Vector3 vector = inverse.MultiplyPoint(rLineStart);
			Vector3 vector2 = (inverse.MultiplyPoint(rLineEnd) - vector) * 0.5f;
			Vector3 vector3 = new Vector3(Mathf.Abs(vector2.x), Mathf.Abs(vector2.y), Mathf.Abs(vector2.z));
			Vector3 vector4 = new Vector3(rRadius, rHeight * 0.5f, rRadius);
			Vector3 vector5 = -vector4;
			Vector3 vector6 = (vector4 - vector5) * 0.5f;
			Vector3 vector7 = vector + vector2 - (vector5 + vector4) * 0.5f;
			return Mathf.Abs(vector7.x) <= vector6.x + vector3.x && Mathf.Abs(vector7.y) <= vector6.y + vector3.y && Mathf.Abs(vector7.z) <= vector6.z + vector3.z && Mathf.Abs(vector2.y * vector7.z - vector2.z * vector7.y) <= vector6.y * vector3.z + vector6.z * vector3.y + 0.0001f && Mathf.Abs(vector2.z * vector7.x - vector2.x * vector7.z) <= vector6.z * vector3.x + vector6.x * vector3.z + 0.0001f && Mathf.Abs(vector2.x * vector7.y - vector2.y * vector7.x) <= vector6.x * vector3.y + vector6.y * vector3.x + 0.0001f;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00014600 File Offset: 0x00012800
		public static bool LineBoxIntersect(Vector3 rLineStart, Vector3 rLineEnd, Transform rTransform, float rWidth, float rHeight, float rDepth)
		{
			Matrix4x4 inverse = Matrix4x4.TRS(rTransform.position, rTransform.rotation, Vector3.one).inverse;
			Vector3 vector = inverse.MultiplyPoint(rLineStart);
			Vector3 vector2 = (inverse.MultiplyPoint(rLineEnd) - vector) * 0.5f;
			Vector3 vector3 = new Vector3(Mathf.Abs(vector2.x), Mathf.Abs(vector2.y), Mathf.Abs(vector2.z));
			Vector3 vector4 = new Vector3(rWidth * 0.5f, rHeight * 0.5f, rDepth * 0.5f);
			Vector3 vector5 = -vector4;
			Vector3 vector6 = (vector4 - vector5) * 0.5f;
			Vector3 vector7 = vector + vector2 - (vector5 + vector4) * 0.5f;
			return Mathf.Abs(vector7.x) <= vector6.x + vector3.x && Mathf.Abs(vector7.y) <= vector6.y + vector3.y && Mathf.Abs(vector7.z) <= vector6.z + vector3.z && Mathf.Abs(vector2.y * vector7.z - vector2.z * vector7.y) <= vector6.y * vector3.z + vector6.z * vector3.y + 0.0001f && Mathf.Abs(vector2.z * vector7.x - vector2.x * vector7.z) <= vector6.z * vector3.x + vector6.x * vector3.z + 0.0001f && Mathf.Abs(vector2.x * vector7.y - vector2.y * vector7.x) <= vector6.x * vector3.y + vector6.y * vector3.x + 0.0001f;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00014814 File Offset: 0x00012A14
		public static bool LineBoxFromBaseIntersect(Vector3 rLineStart, Vector3 rLineEnd, Vector3 rPosition, Quaternion rRotation, float rWidth, float rHeight, float rDepth)
		{
			Matrix4x4 inverse = Matrix4x4.TRS(rPosition, rRotation, Vector3.one).inverse;
			Vector3 vector = inverse.MultiplyPoint(rLineStart);
			Vector3 vector2 = (inverse.MultiplyPoint(rLineEnd) - vector) * 0.5f;
			Vector3 vector3 = new Vector3(Mathf.Abs(vector2.x), Mathf.Abs(vector2.y), Mathf.Abs(vector2.z));
			Vector3 vector4 = new Vector3(rWidth * 0.5f, rHeight * 0.5f, rDepth);
			Vector3 vector5 = new Vector3(rWidth * -0.5f, rHeight * -0.5f, 0f);
			Vector3 vector6 = (vector4 - vector5) * 0.5f;
			Vector3 vector7 = vector + vector2 - (vector5 + vector4) * 0.5f;
			return Mathf.Abs(vector7.x) <= vector6.x + vector3.x && Mathf.Abs(vector7.y) <= vector6.y + vector3.y && Mathf.Abs(vector7.z) <= vector6.z + vector3.z && Mathf.Abs(vector2.y * vector7.z - vector2.z * vector7.y) <= vector6.y * vector3.z + vector6.z * vector3.y + 0.0001f && Mathf.Abs(vector2.z * vector7.x - vector2.x * vector7.z) <= vector6.z * vector3.x + vector6.x * vector3.z + 0.0001f && Mathf.Abs(vector2.x * vector7.y - vector2.y * vector7.x) <= vector6.x * vector3.y + vector6.y * vector3.x + 0.0001f;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x00014A2C File Offset: 0x00012C2C
		public static bool CylinderContainsPoint(Vector3 pt1, Vector3 pt2, float rRadius, Vector3 testpt)
		{
			float num = rRadius * rRadius;
			float sqrMagnitude = (pt2 - pt1).sqrMagnitude;
			float num2 = pt2.x - pt1.x;
			float num3 = pt2.y - pt1.y;
			float num4 = pt2.z - pt1.z;
			float num5 = testpt.x - pt1.x;
			float num6 = testpt.y - pt1.y;
			float num7 = testpt.z - pt1.z;
			float num8 = num5 * num2 + num6 * num3 + num7 * num4;
			return num8 >= 0f && num8 <= sqrMagnitude && num5 * num5 + num6 * num6 + num7 * num7 - num8 * num8 / sqrMagnitude <= num;
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x00014AE8 File Offset: 0x00012CE8
		public static bool ContainsPoint(Vector3 rPoint, BoxCollider rCollider)
		{
			Transform transform = rCollider.transform;
			Vector3 vector = rCollider.size * 0.5f;
			Vector3 vector2 = transform.InverseTransformPoint(rPoint);
			return vector2.x >= -vector.x && vector2.x <= vector.x && vector2.y >= -vector.y && vector2.y <= vector.y && vector2.z >= -vector.z && vector2.z <= vector.z;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00014B70 File Offset: 0x00012D70
		private static bool IgnoreCollider(Collider rCollider)
		{
			if (rCollider == null || rCollider.transform == null)
			{
				return true;
			}
			if (rCollider.isTrigger)
			{
				return true;
			}
			if (GeometryExt.Ignore != null)
			{
				if (rCollider.transform == GeometryExt.Ignore)
				{
					return true;
				}
				if (GeometryExt.IsDescendant(GeometryExt.Ignore, rCollider.transform))
				{
					return true;
				}
			}
			if (GeometryExt.IgnoreArray != null)
			{
				for (int i = 0; i < GeometryExt.IgnoreArray.Length; i++)
				{
					if (rCollider.transform == GeometryExt.IgnoreArray[i])
					{
						return true;
					}
					if (GeometryExt.IsDescendant(GeometryExt.IgnoreArray[i], rCollider.transform))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00014C1C File Offset: 0x00012E1C
		private static bool IsDescendant(Transform rParent, Transform rDescendant)
		{
			if (rParent == null)
			{
				return false;
			}
			Transform transform = rDescendant;
			while (transform != null)
			{
				if (transform == rParent)
				{
					return true;
				}
				transform = transform.parent;
			}
			return false;
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00014C54 File Offset: 0x00012E54
		private static void GetLineDistanceFromBoxFace(ref Vector3 rBoxExtents, ref Vector3 rBoxPoint, ref Vector3 rBoxDirection, ref Vector3 rExtentToPoint, int rIndex0, int rIndex1, int rIndex2, ref float mLineDistance)
		{
			Vector3 vector = default(Vector3);
			vector[rIndex1] = rBoxPoint[rIndex1] + rBoxExtents[rIndex1];
			vector[rIndex2] = rBoxPoint[rIndex2] + rBoxExtents[rIndex2];
			if (rBoxDirection[rIndex0] * vector[rIndex1] >= rBoxDirection[rIndex1] * rExtentToPoint[rIndex0])
			{
				if (rBoxDirection[rIndex0] * vector[rIndex2] >= rBoxDirection[rIndex2] * rExtentToPoint[rIndex0])
				{
					float num = 1f / rBoxDirection[rIndex0];
					mLineDistance = -rExtentToPoint[rIndex0] * num;
					return;
				}
				float num2 = rBoxDirection[rIndex0] * rBoxDirection[rIndex0] + rBoxDirection[rIndex2] * rBoxDirection[rIndex2];
				float num3 = num2 * vector[rIndex1] - rBoxDirection[rIndex1] * (rBoxDirection[rIndex0] * rExtentToPoint[rIndex0] + rBoxDirection[rIndex2] * vector[rIndex2]);
				if (num3 <= 2f * num2 * rBoxExtents[rIndex1])
				{
					float num4 = num3 / num2;
					num2 += rBoxDirection[rIndex1] * rBoxDirection[rIndex1];
					num3 = vector[rIndex1] - num4;
					float num5 = rBoxDirection[rIndex0] * rExtentToPoint[rIndex0] + rBoxDirection[rIndex1] * num3 + rBoxDirection[rIndex2] * vector[rIndex2];
					mLineDistance = -num5 / num2;
					return;
				}
				num2 += rBoxDirection[rIndex1] * rBoxDirection[rIndex1];
				float num6 = rBoxDirection[rIndex0] * rExtentToPoint[rIndex0] + rBoxDirection[rIndex1] * rExtentToPoint[rIndex1] + rBoxDirection[rIndex2] * vector[rIndex2];
				mLineDistance = -num6 / num2;
				return;
			}
			else if (rBoxDirection[rIndex0] * vector[rIndex2] >= rBoxDirection[rIndex2] * rExtentToPoint[rIndex0])
			{
				float num7 = rBoxDirection[rIndex0] * rBoxDirection[rIndex0] + rBoxDirection[rIndex1] * rBoxDirection[rIndex1];
				float num8 = num7 * vector[rIndex2] - rBoxDirection[rIndex2] * (rBoxDirection[rIndex0] * rExtentToPoint[rIndex0] + rBoxDirection[rIndex1] * vector[rIndex1]);
				if (num8 <= 2f * num7 * rBoxExtents[rIndex2])
				{
					float num9 = num8 / num7;
					num7 += rBoxDirection[rIndex2] * rBoxDirection[rIndex2];
					num8 = vector[rIndex2] - num9;
					float num10 = rBoxDirection[rIndex0] * rExtentToPoint[rIndex0] + rBoxDirection[rIndex1] * vector[rIndex1] + rBoxDirection[rIndex2] * num8;
					mLineDistance = -num10 / num7;
					return;
				}
				num7 += rBoxDirection[rIndex2] * rBoxDirection[rIndex2];
				float num11 = rBoxDirection[rIndex0] * rExtentToPoint[rIndex0] + rBoxDirection[rIndex1] * vector[rIndex1] + rBoxDirection[rIndex2] * rExtentToPoint[rIndex2];
				mLineDistance = -num11 / num7;
				return;
			}
			else
			{
				float num12 = rBoxDirection[rIndex0] * rBoxDirection[rIndex0] + rBoxDirection[rIndex2] * rBoxDirection[rIndex2];
				float num13 = num12 * vector[rIndex1] - rBoxDirection[rIndex1] * (rBoxDirection[rIndex0] * rExtentToPoint[rIndex0] + rBoxDirection[rIndex2] * vector[rIndex2]);
				if (num13 >= 0f)
				{
					float num15;
					if (num13 <= 2f * num12 * rBoxExtents[rIndex1])
					{
						float num14 = num13 / num12;
						num12 += rBoxDirection[rIndex1] * rBoxDirection[rIndex1];
						num13 = vector[rIndex1] - num14;
						num15 = rBoxDirection[rIndex0] * rExtentToPoint[rIndex0] + rBoxDirection[rIndex1] * num13 + rBoxDirection[rIndex2] * vector[rIndex2];
						mLineDistance = -num15 / num12;
						return;
					}
					num12 += rBoxDirection[rIndex1] * rBoxDirection[rIndex1];
					num15 = rBoxDirection[rIndex0] * rExtentToPoint[rIndex0] + rBoxDirection[rIndex1] * rExtentToPoint[rIndex1] + rBoxDirection[rIndex2] * vector[rIndex2];
					mLineDistance = -num15 / num12;
					return;
				}
				else
				{
					num12 = rBoxDirection[rIndex0] * rBoxDirection[rIndex0] + rBoxDirection[rIndex1] * rBoxDirection[rIndex1];
					num13 = num12 * vector[rIndex2] - rBoxDirection[rIndex2] * (rBoxDirection[rIndex0] * rExtentToPoint[rIndex0] + rBoxDirection[rIndex1] * vector[rIndex1]);
					float num15;
					if (num13 < 0f)
					{
						num12 += rBoxDirection[rIndex2] * rBoxDirection[rIndex2];
						num15 = rBoxDirection[rIndex0] * rExtentToPoint[rIndex0] + rBoxDirection[rIndex1] * vector[rIndex1] + rBoxDirection[rIndex2] * vector[rIndex2];
						mLineDistance = -num15 / num12;
						return;
					}
					if (num13 <= 2f * num12 * rBoxExtents[rIndex2])
					{
						float num16 = num13 / num12;
						num12 += rBoxDirection[rIndex2] * rBoxDirection[rIndex2];
						num13 = vector[rIndex2] - num16;
						num15 = rBoxDirection[rIndex0] * rExtentToPoint[rIndex0] + rBoxDirection[rIndex1] * vector[rIndex1] + rBoxDirection[rIndex2] * num13;
						mLineDistance = -num15 / num12;
						return;
					}
					num12 += rBoxDirection[rIndex2] * rBoxDirection[rIndex2];
					num15 = rBoxDirection[rIndex0] * rExtentToPoint[rIndex0] + rBoxDirection[rIndex1] * vector[rIndex1] + rBoxDirection[rIndex2] * rExtentToPoint[rIndex2];
					mLineDistance = -num15 / num12;
					return;
				}
			}
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0001526C File Offset: 0x0001346C
		private static void GetLineDistanceFromBoxExtent(ref Vector3 rBoxExtents, ref Vector3 rBoxPoint, ref Vector3 rBoxDirection, ref float rLineDistance)
		{
			Vector3 vector = new Vector3(rBoxPoint.x - rBoxExtents[0], rBoxPoint.y - rBoxExtents[1], rBoxPoint.z - rBoxExtents[2]);
			if (rBoxDirection.y * vector.x >= rBoxDirection.x * vector.y)
			{
				if (rBoxDirection.z * vector.x >= rBoxDirection.x * vector.z)
				{
					GeometryExt.GetLineDistanceFromBoxFace(ref rBoxExtents, ref rBoxPoint, ref rBoxDirection, ref vector, 0, 1, 2, ref rLineDistance);
					return;
				}
				GeometryExt.GetLineDistanceFromBoxFace(ref rBoxExtents, ref rBoxPoint, ref rBoxDirection, ref vector, 2, 0, 1, ref rLineDistance);
				return;
			}
			else
			{
				if (rBoxDirection.z * vector.y >= rBoxDirection.y * vector.z)
				{
					GeometryExt.GetLineDistanceFromBoxFace(ref rBoxExtents, ref rBoxPoint, ref rBoxDirection, ref vector, 1, 2, 0, ref rLineDistance);
					return;
				}
				GeometryExt.GetLineDistanceFromBoxFace(ref rBoxExtents, ref rBoxPoint, ref rBoxDirection, ref vector, 2, 0, 1, ref rLineDistance);
				return;
			}
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0001533C File Offset: 0x0001353C
		private static void GetLineDistanceFromBoxExtent(ref Vector3 rBoxExtents, ref Vector3 rBoxPoint, ref Vector3 rBoxDirection, int rIndex0, int rIndex1, ref float rLineDistance)
		{
			float num = rBoxPoint[rIndex0] - rBoxExtents[rIndex0];
			float num2 = rBoxPoint[rIndex1] - rBoxExtents[rIndex1];
			float num3 = rBoxDirection[rIndex1] * num;
			float num4 = rBoxDirection[rIndex0] * num2;
			if (num3 >= num4)
			{
				rBoxPoint[rIndex0] = rBoxExtents[rIndex0];
				num2 = rBoxPoint[rIndex1] + rBoxExtents[rIndex1];
				float num5;
				if (num3 - rBoxDirection[rIndex0] * num2 >= 0f)
				{
					num5 = 1f / (rBoxDirection[rIndex0] * rBoxDirection[rIndex0] + rBoxDirection[rIndex1] * rBoxDirection[rIndex1]);
					rLineDistance = -(rBoxDirection[rIndex0] * num + rBoxDirection[rIndex1] * num2) * num5;
					return;
				}
				num5 = 1f / rBoxDirection[rIndex0];
				rLineDistance = -num * num5;
				return;
			}
			else
			{
				rBoxPoint[rIndex1] = rBoxExtents[rIndex1];
				num = rBoxPoint[rIndex0] + rBoxExtents[rIndex0];
				float num5;
				if (num4 - rBoxDirection[rIndex1] * num >= 0f)
				{
					num5 = 1f / (rBoxDirection[rIndex0] * rBoxDirection[rIndex0] + rBoxDirection[rIndex1] * rBoxDirection[rIndex1]);
					rLineDistance = -(rBoxDirection[rIndex0] * num + rBoxDirection[rIndex1] * num2) * num5;
					return;
				}
				num5 = 1f / rBoxDirection[rIndex1];
				rLineDistance = -num2 * num5;
				return;
			}
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x000154AD File Offset: 0x000136AD
		private static void GetLineDistanceFromBoxExtent(ref Vector3 rBoxExtents, ref Vector3 rBoxPoint, ref Vector3 rBoxDirection, int rIndex0, ref float mLineDistance)
		{
			mLineDistance = (rBoxExtents[rIndex0] - rBoxPoint[rIndex0]) / rBoxDirection[rIndex0];
		}

		// Token: 0x060003BA RID: 954 RVA: 0x000154CC File Offset: 0x000136CC
		private static void GetClosestPointFromTerrain(TerrainCollider rCollider, Vector3 rStart, Vector3 rEnd)
		{
			Vector3 position = rCollider.transform.position;
			TerrainData terrainData = rCollider.terrainData;
			int heightmapResolution = terrainData.heightmapResolution;
			int heightmapResolution2 = terrainData.heightmapResolution;
			Vector3 size = terrainData.size;
			size = new Vector3(size.x / (float)(heightmapResolution - 1), size.y, size.z / (float)(heightmapResolution2 - 1));
			float[,] heights = terrainData.GetHeights(0, 0, heightmapResolution, heightmapResolution2);
			Vector3[] array = new Vector3[heightmapResolution * heightmapResolution2];
			for (int i = 0; i < heightmapResolution2; i++)
			{
				for (int j = 0; j < heightmapResolution; j++)
				{
					array[i * heightmapResolution + j] = Vector3.Scale(size, new Vector3((float)(-(float)i), heights[j, i], (float)j)) + position;
				}
			}
			int[] array2 = new int[(heightmapResolution - 1) * (heightmapResolution2 - 1) * 6];
			int k = 0;
			for (int l = 0; l < heightmapResolution2 - 1; l++)
			{
				for (int m = 0; m < heightmapResolution - 1; m++)
				{
					array2[k++] = l * heightmapResolution + m;
					array2[k++] = (l + 1) * heightmapResolution + m;
					array2[k++] = l * heightmapResolution + m + 1;
					array2[k++] = (l + 1) * heightmapResolution + m;
					array2[k++] = (l + 1) * heightmapResolution + m + 1;
					array2[k++] = l * heightmapResolution + m + 1;
				}
			}
			for (k = 0; k < array2.Length; k += 3)
			{
				Vector3.SqrMagnitude(GeometryExt.ClosestPoint(ref rEnd, ref array[array2[k]], ref array[array2[k + 1]], ref array[array2[k + 2]]) - rEnd);
			}
		}

		// Token: 0x040001FF RID: 511
		public const float EPSILON = 0.0001f;

		// Token: 0x04000200 RID: 512
		public static float LineMeshStepFactor = 0.2f;

		// Token: 0x04000201 RID: 513
		public static Transform Ignore = null;

		// Token: 0x04000202 RID: 514
		public static Transform[] IgnoreArray = null;

		// Token: 0x04000203 RID: 515
		public static Vector3[] SphericalDirections = new Vector3[14];
	}
}
