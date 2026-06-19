using System;
using System.Collections.Generic;
using com.ootii.Graphics;
using UnityEngine;

namespace com.ootii.Geometry
{
	// Token: 0x02000051 RID: 81
	public static class RaycastExt
	{
		// Token: 0x060003F2 RID: 1010 RVA: 0x000177CC File Offset: 0x000159CC
		public static bool SafeRaycast(Vector3 rRayStart, Vector3 rRayDirection, float rDistance = 1000f, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true)
		{
			if (rIgnore == null && rIgnoreList == null && rLayerMask != -1)
			{
				return Physics.Raycast(rRayStart, rRayDirection, rDistance, rLayerMask, rIgnoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
			}
			int num = RaycastExt.SharedHitArray.Length;
			for (int i = 0; i < num; i++)
			{
				RaycastExt.SharedHitArray[i] = RaycastExt.EmptyHitInfo;
			}
			int num2;
			if (rLayerMask != -1)
			{
				num2 = Physics.RaycastNonAlloc(rRayStart, rRayDirection, RaycastExt.SharedHitArray, rDistance, rLayerMask, rIgnoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
			}
			else
			{
				num2 = Physics.RaycastNonAlloc(rRayStart, rRayDirection, RaycastExt.SharedHitArray, rDistance);
			}
			if (num2 == 0)
			{
				return false;
			}
			if (num2 != 1)
			{
				for (int j = 0; j < num2; j++)
				{
					if (!rIgnoreTriggers || !RaycastExt.SharedHitArray[j].collider.isTrigger)
					{
						Transform transform = RaycastExt.SharedHitArray[j].collider.transform;
						if (!(rIgnore != null) || !RaycastExt.IsDescendant(rIgnore, transform))
						{
							if (rIgnoreList != null)
							{
								bool flag = false;
								for (int k = 0; k < rIgnoreList.Count; k++)
								{
									if (RaycastExt.IsDescendant(rIgnoreList[k], transform))
									{
										flag = true;
										break;
									}
								}
								if (flag)
								{
									goto IL_0181;
								}
							}
							return true;
						}
					}
					IL_0181:;
				}
				return false;
			}
			if (rIgnoreTriggers && RaycastExt.SharedHitArray[0].collider.isTrigger)
			{
				return false;
			}
			Transform transform2 = RaycastExt.SharedHitArray[0].collider.transform;
			if (rIgnore != null && RaycastExt.IsDescendant(rIgnore, transform2))
			{
				return false;
			}
			if (rIgnoreList != null)
			{
				for (int l = 0; l < rIgnoreList.Count; l++)
				{
					if (RaycastExt.IsDescendant(rIgnoreList[l], transform2))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0001796C File Offset: 0x00015B6C
		public static bool SafeRaycast(Vector3 rRayStart, Vector3 rRayDirection, out RaycastHit rHitInfo, float rDistance = 1000f, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true, bool rDebug = false)
		{
			if (rIgnore == null && rIgnoreList == null && rLayerMask != -1)
			{
				return Physics.Raycast(rRayStart, rRayDirection, out rHitInfo, rDistance, rLayerMask, rIgnoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
			}
			rHitInfo = RaycastExt.EmptyHitInfo;
			int num = RaycastExt.SharedHitArray.Length;
			for (int i = 0; i < num; i++)
			{
				RaycastExt.SharedHitArray[i] = RaycastExt.EmptyHitInfo;
			}
			int num2;
			if (rLayerMask != -1)
			{
				num2 = Physics.RaycastNonAlloc(rRayStart, rRayDirection, RaycastExt.SharedHitArray, rDistance, rLayerMask, rIgnoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
			}
			else
			{
				num2 = Physics.RaycastNonAlloc(rRayStart, rRayDirection, RaycastExt.SharedHitArray, rDistance);
			}
			if (num2 == 0)
			{
				return false;
			}
			if (num2 != 1)
			{
				for (int j = 0; j < num2; j++)
				{
					if (!rIgnoreTriggers || !RaycastExt.SharedHitArray[j].collider.isTrigger)
					{
						Transform transform = RaycastExt.SharedHitArray[j].collider.transform;
						if (!(rIgnore != null) || !RaycastExt.IsDescendant(rIgnore, transform))
						{
							if (rIgnoreList != null)
							{
								bool flag = false;
								for (int k = 0; k < rIgnoreList.Count; k++)
								{
									if (RaycastExt.IsDescendant(rIgnoreList[k], transform))
									{
										flag = true;
										break;
									}
								}
								if (flag)
								{
									goto IL_01DF;
								}
							}
							if (rHitInfo.collider == null || RaycastExt.SharedHitArray[j].distance < rHitInfo.distance)
							{
								rHitInfo = RaycastExt.SharedHitArray[j];
							}
						}
					}
					IL_01DF:;
				}
				return rHitInfo.collider != null;
			}
			if (rIgnoreTriggers && RaycastExt.SharedHitArray[0].collider.isTrigger)
			{
				return false;
			}
			Transform transform2 = RaycastExt.SharedHitArray[0].collider.transform;
			if (rIgnore != null && RaycastExt.IsDescendant(rIgnore, transform2))
			{
				return false;
			}
			if (rIgnoreList != null)
			{
				for (int l = 0; l < rIgnoreList.Count; l++)
				{
					if (RaycastExt.IsDescendant(rIgnoreList[l], transform2))
					{
						return false;
					}
				}
			}
			rHitInfo = RaycastExt.SharedHitArray[0];
			return true;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00017B78 File Offset: 0x00015D78
		public static int SafeRaycastAll(Vector3 rRayStart, Vector3 rRayDirection, out RaycastHit[] rHitArray, float rDistance = 1000f, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true)
		{
			rHitArray = null;
			int num = RaycastExt.SharedHitArray.Length;
			for (int i = 0; i < num; i++)
			{
				RaycastExt.SharedHitArray[i] = RaycastExt.EmptyHitInfo;
			}
			int num2;
			if (rLayerMask != -1)
			{
				num2 = Physics.RaycastNonAlloc(rRayStart, rRayDirection, RaycastExt.SharedHitArray, rDistance, rLayerMask, rIgnoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
			}
			else
			{
				num2 = Physics.RaycastNonAlloc(rRayStart, rRayDirection, RaycastExt.SharedHitArray, rDistance);
			}
			if (num2 == 0)
			{
				return 0;
			}
			if (num2 != 1)
			{
				int num3 = 0;
				for (int j = 0; j < num2; j++)
				{
					bool flag = false;
					Transform transform = RaycastExt.SharedHitArray[j].collider.transform;
					if (rIgnoreTriggers && RaycastExt.SharedHitArray[j].collider.isTrigger)
					{
						flag = true;
					}
					if (rIgnore != null && RaycastExt.IsDescendant(rIgnore, transform))
					{
						flag = true;
					}
					if (rIgnoreList != null)
					{
						for (int k = 0; k < rIgnoreList.Count; k++)
						{
							if (RaycastExt.IsDescendant(rIgnoreList[k], transform))
							{
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						num2--;
						for (int l = j; l < num2; l++)
						{
							RaycastExt.SharedHitArray[l] = RaycastExt.SharedHitArray[l + 1];
						}
						j--;
					}
					else
					{
						num3++;
					}
				}
				rHitArray = RaycastExt.SharedHitArray;
				return num3;
			}
			if (rIgnoreTriggers && RaycastExt.SharedHitArray[0].collider.isTrigger)
			{
				return 0;
			}
			Transform transform2 = RaycastExt.SharedHitArray[0].collider.transform;
			if (rIgnore != null && RaycastExt.IsDescendant(rIgnore, transform2))
			{
				return 0;
			}
			if (rIgnoreList != null)
			{
				for (int m = 0; m < rIgnoreList.Count; m++)
				{
					if (RaycastExt.IsDescendant(rIgnoreList[m], transform2))
					{
						return 0;
					}
				}
			}
			rHitArray = RaycastExt.SharedHitArray;
			return 1;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00017D4C File Offset: 0x00015F4C
		public static bool SafeSphereCast(Vector3 rRayStart, Vector3 rRayDirection, float rRadius, float rDistance = 1000f, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true)
		{
			if (rIgnore == null && rIgnoreList == null && rLayerMask != -1)
			{
				RaycastHit raycastHit;
				return Physics.SphereCast(rRayStart, rRadius, rRayDirection, out raycastHit, rDistance, rLayerMask, rIgnoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
			}
			int num = RaycastExt.SharedHitArray.Length;
			for (int i = 0; i < num; i++)
			{
				RaycastExt.SharedHitArray[i] = RaycastExt.EmptyHitInfo;
			}
			int num2;
			if (rLayerMask != -1)
			{
				num2 = Physics.SphereCastNonAlloc(rRayStart, rRadius, rRayDirection, RaycastExt.SharedHitArray, rDistance, rLayerMask, rIgnoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
			}
			else
			{
				num2 = Physics.SphereCastNonAlloc(rRayStart, rRadius, rRayDirection, RaycastExt.SharedHitArray, rDistance);
			}
			if (num2 == 0)
			{
				return false;
			}
			if (num2 != 1)
			{
				for (int j = 0; j < num2; j++)
				{
					if (!rIgnoreTriggers || !RaycastExt.SharedHitArray[j].collider.isTrigger)
					{
						Transform transform = RaycastExt.SharedHitArray[j].collider.transform;
						if (!(rIgnore != null) || !RaycastExt.IsDescendant(rIgnore, transform))
						{
							if (rIgnoreList != null)
							{
								bool flag = false;
								for (int k = 0; k < rIgnoreList.Count; k++)
								{
									if (RaycastExt.IsDescendant(rIgnoreList[k], transform))
									{
										flag = true;
										break;
									}
								}
								if (flag)
								{
									goto IL_018D;
								}
							}
							return true;
						}
					}
					IL_018D:;
				}
				return false;
			}
			if (rIgnoreTriggers && RaycastExt.SharedHitArray[0].collider.isTrigger)
			{
				return false;
			}
			Transform transform2 = RaycastExt.SharedHitArray[0].collider.transform;
			if (rIgnore != null && RaycastExt.IsDescendant(rIgnore, transform2))
			{
				return false;
			}
			if (rIgnoreList != null)
			{
				for (int l = 0; l < rIgnoreList.Count; l++)
				{
					if (RaycastExt.IsDescendant(rIgnoreList[l], transform2))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00017EF8 File Offset: 0x000160F8
		public static bool SafeSphereCast(Vector3 rRayStart, Vector3 rRayDirection, float rRadius, out RaycastHit rHitInfo, float rDistance = 1000f, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true)
		{
			if (rIgnore == null && rIgnoreList == null && rLayerMask != -1)
			{
				return Physics.SphereCast(rRayStart, rRadius, rRayDirection, out rHitInfo, rDistance, rLayerMask, rIgnoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
			}
			rHitInfo = RaycastExt.EmptyHitInfo;
			int num = RaycastExt.SharedHitArray.Length;
			for (int i = 0; i < num; i++)
			{
				RaycastExt.SharedHitArray[i] = RaycastExt.EmptyHitInfo;
			}
			int num2;
			if (rLayerMask != -1)
			{
				num2 = Physics.SphereCastNonAlloc(rRayStart, rRadius, rRayDirection, RaycastExt.SharedHitArray, rDistance, rLayerMask, rIgnoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
			}
			else
			{
				num2 = Physics.SphereCastNonAlloc(rRayStart, rRadius, rRayDirection, RaycastExt.SharedHitArray, rDistance);
			}
			if (num2 == 0)
			{
				return false;
			}
			if (num2 != 1)
			{
				for (int j = 0; j < num2; j++)
				{
					if (!rIgnoreTriggers || !RaycastExt.SharedHitArray[j].collider.isTrigger)
					{
						Transform transform = RaycastExt.SharedHitArray[j].collider.transform;
						if (!(rIgnore != null) || !RaycastExt.IsDescendant(rIgnore, transform))
						{
							if (rIgnoreList != null)
							{
								bool flag = false;
								for (int k = 0; k < rIgnoreList.Count; k++)
								{
									if (RaycastExt.IsDescendant(rIgnoreList[k], transform))
									{
										flag = true;
										break;
									}
								}
								if (flag)
								{
									goto IL_01E5;
								}
							}
							if (rHitInfo.collider == null || RaycastExt.SharedHitArray[j].distance < rHitInfo.distance)
							{
								rHitInfo = RaycastExt.SharedHitArray[j];
							}
						}
					}
					IL_01E5:;
				}
				return rHitInfo.collider != null;
			}
			if (rIgnoreTriggers && RaycastExt.SharedHitArray[0].collider.isTrigger)
			{
				return false;
			}
			Transform transform2 = RaycastExt.SharedHitArray[0].collider.transform;
			if (rIgnore != null && RaycastExt.IsDescendant(rIgnore, transform2))
			{
				return false;
			}
			if (rIgnoreList != null)
			{
				for (int l = 0; l < rIgnoreList.Count; l++)
				{
					if (RaycastExt.IsDescendant(rIgnoreList[l], transform2))
					{
						return false;
					}
				}
			}
			rHitInfo = RaycastExt.SharedHitArray[0];
			return true;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0001810C File Offset: 0x0001630C
		public static int SafeSphereCastAll(Vector3 rRayStart, Vector3 rRayDirection, float rRadius, out RaycastHit[] rHitArray, float rDistance = 1000f, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true)
		{
			rHitArray = null;
			int num = RaycastExt.SharedHitArray.Length;
			for (int i = 0; i < num; i++)
			{
				RaycastExt.SharedHitArray[i] = RaycastExt.EmptyHitInfo;
			}
			int num2;
			if (rLayerMask != -1)
			{
				num2 = Physics.SphereCastNonAlloc(rRayStart, rRadius, rRayDirection, RaycastExt.SharedHitArray, rDistance, rLayerMask, rIgnoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
			}
			else
			{
				num2 = Physics.SphereCastNonAlloc(rRayStart, rRadius, rRayDirection, RaycastExt.SharedHitArray, rDistance);
			}
			if (num2 == 0)
			{
				return 0;
			}
			if (num2 != 1)
			{
				int num3 = 0;
				for (int j = 0; j < num2; j++)
				{
					bool flag = false;
					Transform transform = RaycastExt.SharedHitArray[j].collider.transform;
					if (rIgnoreTriggers && RaycastExt.SharedHitArray[j].collider.isTrigger)
					{
						flag = true;
					}
					if (rIgnore != null && RaycastExt.IsDescendant(rIgnore, transform))
					{
						flag = true;
					}
					if (rIgnoreList != null)
					{
						for (int k = 0; k < rIgnoreList.Count; k++)
						{
							if (RaycastExt.IsDescendant(rIgnoreList[k], transform))
							{
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						num2--;
						for (int l = j; l < num2; l++)
						{
							RaycastExt.SharedHitArray[l] = RaycastExt.SharedHitArray[l + 1];
						}
						j--;
					}
					else
					{
						num3++;
					}
				}
				rHitArray = RaycastExt.SharedHitArray;
				return num3;
			}
			if (rIgnoreTriggers && RaycastExt.SharedHitArray[0].collider.isTrigger)
			{
				return 0;
			}
			Transform transform2 = RaycastExt.SharedHitArray[0].collider.transform;
			if (rIgnore != null && RaycastExt.IsDescendant(rIgnore, transform2))
			{
				return 0;
			}
			if (rIgnoreList != null)
			{
				for (int m = 0; m < rIgnoreList.Count; m++)
				{
					if (RaycastExt.IsDescendant(rIgnoreList[m], transform2))
					{
						return 0;
					}
				}
			}
			rHitArray = RaycastExt.SharedHitArray;
			return 1;
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x000182E4 File Offset: 0x000164E4
		public static int SafeOverlapSphere(Vector3 rPosition, float rRadius, out Collider[] rColliderArray, int rLayerMask = -1, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true)
		{
			rColliderArray = null;
			int num;
			if (rLayerMask != -1)
			{
				num = Physics.OverlapSphereNonAlloc(rPosition, rRadius, RaycastExt.SharedColliderArray, rLayerMask, rIgnoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide);
			}
			else
			{
				num = Physics.OverlapSphereNonAlloc(rPosition, rRadius, RaycastExt.SharedColliderArray);
			}
			if (num == 0)
			{
				return 0;
			}
			if (num != 1)
			{
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					bool flag = false;
					Transform transform = RaycastExt.SharedColliderArray[i].transform;
					if (rIgnoreTriggers && RaycastExt.SharedColliderArray[i].isTrigger)
					{
						flag = true;
					}
					if (rIgnore != null && RaycastExt.IsDescendant(rIgnore, transform))
					{
						flag = true;
					}
					if (rIgnoreList != null)
					{
						for (int j = 0; j < rIgnoreList.Count; j++)
						{
							if (RaycastExt.IsDescendant(rIgnoreList[j], transform))
							{
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						num--;
						for (int k = i; k < num; k++)
						{
							RaycastExt.SharedColliderArray[k] = RaycastExt.SharedColliderArray[k + 1];
						}
						i--;
					}
					else
					{
						num2++;
					}
				}
				rColliderArray = RaycastExt.SharedColliderArray;
				return num2;
			}
			if (rIgnoreTriggers && RaycastExt.SharedColliderArray[0].isTrigger)
			{
				return 0;
			}
			Transform transform2 = RaycastExt.SharedColliderArray[0].transform;
			if (rIgnore != null && RaycastExt.IsDescendant(rIgnore, transform2))
			{
				return 0;
			}
			if (rIgnoreList != null)
			{
				for (int l = 0; l < rIgnoreList.Count; l++)
				{
					if (RaycastExt.IsDescendant(rIgnoreList[l], transform2))
					{
						return 0;
					}
				}
			}
			rColliderArray = RaycastExt.SharedColliderArray;
			return 1;
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00018458 File Offset: 0x00016658
		public static bool SafeSpiralCast(Transform rRootTransform, out RaycastHit rHitInfo, float rRadius = 8f, float rDistance = 1000f, float rDegreesPerStep = 27f, int rLayerMask = -1, string rTag = null, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true, bool rDebug = false)
		{
			rHitInfo = RaycastExt.EmptyHitInfo;
			float num = 2f * (360f / rDegreesPerStep);
			float num2 = rRadius / num;
			float num3 = 0f;
			float num4 = 0f;
			Vector3 zero = Vector3.zero;
			float num5 = 1f / num;
			Color white = Color.white;
			num = num + 360f / rDegreesPerStep - 1f;
			int num6 = 0;
			while ((float)num6 < num)
			{
				zero.x = num4 * Mathf.Cos(num3 * 0.017453292f);
				zero.y = num4 * Mathf.Sin(num3 * 0.017453292f);
				zero.z = rDistance;
				if (rDebug)
				{
					GraphicsManager.DrawLine(rRootTransform.position, rRootTransform.TransformPoint(zero), (num6 == 0) ? Color.red : white, null, 0f);
				}
				Vector3 normalized = (rRootTransform.TransformPoint(zero) - rRootTransform.position).normalized;
				RaycastHit raycastHit;
				if (RaycastExt.SafeRaycast(rRootTransform.position, normalized, out raycastHit, rDistance, rLayerMask, rIgnore, rIgnoreList, rIgnoreTriggers, rDebug))
				{
					GameObject gameObject = raycastHit.collider.gameObject;
					if (!(gameObject.transform == rRootTransform) && !(raycastHit.collider is TerrainCollider) && (rTag == null || rTag.Length <= 0 || gameObject.CompareTag(rTag)))
					{
						rHitInfo = raycastHit;
						return true;
					}
				}
				else
				{
					num3 += rDegreesPerStep;
					num4 = Mathf.Min(num4 + num2, rRadius);
					if (rDebug)
					{
						white.r -= num5;
						white.g -= num5;
					}
				}
				num6++;
			}
			return false;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x000185EC File Offset: 0x000167EC
		public static bool SafeCircularCast(Vector3 rRayStart, Vector3 rRayDirection, Vector3 rRayUp, out RaycastHit rHitInfo, float rDistance = 1000f, float rDegreesPerStep = 30f, int rLayerMask = -1, string rTag = null, Transform rIgnore = null, List<Transform> rIgnoreList = null, bool rIgnoreTriggers = true, bool rDebug = false)
		{
			for (float num = 0f; num <= 360f; num += rDegreesPerStep)
			{
				Vector3 vector = Quaternion.AngleAxis(num, rRayUp) * rRayDirection;
				if (rDebug)
				{
					GraphicsManager.DrawLine(rRayStart, rRayStart + vector * rDistance, Color.cyan, null, 5f);
				}
				RaycastHit raycastHit;
				if (RaycastExt.SafeRaycast(rRayStart, vector, out raycastHit, rDistance, rLayerMask, rIgnore, rIgnoreList, rIgnoreTriggers, rDebug))
				{
					GameObject gameObject = raycastHit.collider.gameObject;
					if (rTag == null || rTag.Length <= 0 || gameObject.CompareTag(rTag))
					{
						rHitInfo = raycastHit;
						return true;
					}
				}
			}
			rHitInfo = RaycastExt.EmptyHitInfo;
			return false;
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00018694 File Offset: 0x00016894
		public static bool GetForwardEdge(Transform rTransform, float rMaxDistance, float rMaxHeight, int rCollisionLayers, out RaycastHit rEdgeHitInfo)
		{
			rEdgeHitInfo = RaycastExt.EmptyHitInfo;
			Vector3 vector = rTransform.position + rTransform.up * (rMaxHeight + 0.001f);
			Vector3 vector2 = rTransform.forward;
			float num = rMaxDistance * 1.5f;
			if (RaycastExt.SafeRaycast(vector, vector2, out rEdgeHitInfo, num, rCollisionLayers, rTransform, null, true, false))
			{
				return false;
			}
			vector += rTransform.forward * rMaxDistance;
			vector2 = -rTransform.up;
			if (!RaycastExt.SafeRaycast(vector, vector2, out rEdgeHitInfo, rMaxHeight, rCollisionLayers, rTransform, null, true, false))
			{
				return false;
			}
			float num2 = rMaxHeight + 0.001f - rEdgeHitInfo.distance;
			vector = rTransform.position + rTransform.up * (num2 - 0.001f);
			vector2 = rTransform.forward;
			return RaycastExt.SafeRaycast(vector, vector2, out rEdgeHitInfo, rMaxDistance, rCollisionLayers, rTransform, null, true, false);
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0001876C File Offset: 0x0001696C
		public static bool GetForwardEdge(Transform rTransform, Vector3 rPosition, float rMinHeight, float rMaxHeight, float rMaxDepth, int rCollisionLayers, out RaycastHit rEdgeHitInfo)
		{
			rEdgeHitInfo = RaycastExt.EmptyHitInfo;
			Vector3 vector = rPosition + rTransform.up * (rMaxHeight + 0.001f);
			Vector3 vector2 = rTransform.forward;
			if (RaycastExt.SafeRaycast(vector, vector2, out rEdgeHitInfo, rMaxDepth, rCollisionLayers, rTransform, null, false, true))
			{
				return false;
			}
			vector += rTransform.forward * rMaxDepth;
			vector2 = -rTransform.up;
			float num = rMaxHeight - rMinHeight;
			if (!RaycastExt.SafeRaycast(vector, vector2, out rEdgeHitInfo, num, rCollisionLayers, rTransform, null, false, true))
			{
				return false;
			}
			float num2 = rMaxHeight + 0.001f - rEdgeHitInfo.distance;
			vector = rPosition + rTransform.up * (num2 - 0.001f);
			vector2 = rTransform.forward;
			return RaycastExt.SafeRaycast(vector, vector2, out rEdgeHitInfo, rMaxDepth, rCollisionLayers, rTransform, null, false, true);
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x0001883C File Offset: 0x00016A3C
		public static bool GetForwardEdge(Transform rTransform, float rMaxDistance, float rMaxHeight, float rMinHeight, int rCollisionLayers, out RaycastHit rEdgeHitInfo)
		{
			rEdgeHitInfo = RaycastExt.EmptyHitInfo;
			Vector3 vector = rTransform.position + rTransform.up * (rMinHeight + 0.001f);
			Vector3 vector2 = rTransform.forward;
			if (!RaycastExt.SafeRaycast(vector, vector2, out rEdgeHitInfo, rMaxDistance, rCollisionLayers, rTransform, null, true, false))
			{
				return false;
			}
			float distance = rEdgeHitInfo.distance;
			vector = rTransform.position + rTransform.up * (rMaxHeight + 0.001f);
			vector2 = rTransform.forward;
			if (RaycastExt.SafeRaycast(vector, vector2, out rEdgeHitInfo, rMaxDistance, rCollisionLayers, rTransform, null, true, false) && rEdgeHitInfo.distance < distance + 0.1f)
			{
				return false;
			}
			vector += rTransform.forward * (distance + 0.001f);
			vector2 = -rTransform.up;
			if (!RaycastExt.SafeRaycast(vector, vector2, out rEdgeHitInfo, rMaxHeight, rCollisionLayers, rTransform, null, true, false))
			{
				return false;
			}
			float num = rMaxHeight + 0.001f - rEdgeHitInfo.distance;
			vector = rTransform.position + rTransform.up * (num - 0.001f);
			vector2 = rTransform.forward;
			return RaycastExt.SafeRaycast(vector, vector2, out rEdgeHitInfo, rMaxDistance, rCollisionLayers, rTransform, null, true, false);
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0001896C File Offset: 0x00016B6C
		public static bool GetForwardEdge2(Transform rTransform, float rMinHeight, float rMaxHeight, float rEdgeDepth, float rMaxDepth, int rCollisionLayers, out RaycastHit rEdgeHitInfo)
		{
			return RaycastExt.GetForwardEdge2(rTransform, rTransform.position, rTransform.forward, rTransform.up, rMinHeight, rMaxHeight, rEdgeDepth, rMaxDepth, rCollisionLayers, out rEdgeHitInfo);
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0001899C File Offset: 0x00016B9C
		public static bool GetForwardEdge2(Transform rTransform, Vector3 rPosition, float rMinHeight, float rMaxHeight, float rEdgeDepth, float rMaxDepth, int rCollisionLayers, out RaycastHit rEdgeHitInfo)
		{
			return RaycastExt.GetForwardEdge2(rTransform, rPosition, rTransform.forward, rTransform.up, rMinHeight, rMaxHeight, rEdgeDepth, rMaxDepth, rCollisionLayers, out rEdgeHitInfo);
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x000189C8 File Offset: 0x00016BC8
		public static bool GetForwardEdge2(Transform rTransform, Vector3 rPosition, Vector3 rForward, Vector3 rUp, float rMinHeight, float rMaxHeight, float rEdgeDepth, float rMaxDepth, int rCollisionLayers, out RaycastHit rEdgeHitInfo)
		{
			rEdgeHitInfo = RaycastExt.EmptyHitInfo;
			float num = 0f;
			float num2 = float.MaxValue;
			float num3 = float.MaxValue;
			if (RaycastExt.SafeRaycast(rPosition + rUp * (rMaxHeight - 0.001f), rForward, out rEdgeHitInfo, rMaxDepth, rCollisionLayers, rTransform, null, false, true))
			{
				num2 = rEdgeHitInfo.distance;
				num3 = num2;
			}
			else if (RaycastExt.SafeRaycast(rPosition + rUp * (rMinHeight + (rMaxHeight - rMinHeight) * 0.5f), rForward, out rEdgeHitInfo, rMaxDepth, rCollisionLayers, rTransform, null, false, true))
			{
				num2 = rEdgeHitInfo.distance;
			}
			if (num2 < 3.4028235E+38f)
			{
				Vector3 vector = rPosition + rForward * (num2 + 0.001f) + rUp * (rMaxHeight + 0.001f);
				Vector3 vector2 = -rUp;
				float num4 = rMaxHeight - rMinHeight;
				if (!RaycastExt.SafeRaycast(vector, vector2, out rEdgeHitInfo, num4, rCollisionLayers, rTransform, null, true, false))
				{
					return false;
				}
				num = rMaxHeight - (rEdgeHitInfo.distance + 0.001f);
			}
			else
			{
				Vector3 vector2 = -rUp;
				float num4 = rMaxHeight - rMinHeight;
				for (float num5 = rEdgeDepth; num5 <= rMaxDepth; num5 += rEdgeDepth * 0.5f)
				{
					if (RaycastExt.SafeRaycast(rPosition + rForward * num5 + rUp * (rMaxHeight + 0.001f), vector2, out rEdgeHitInfo, num4, rCollisionLayers, rTransform, null, false, true))
					{
						num = rMaxHeight - (rEdgeHitInfo.distance + 0.001f);
						break;
					}
				}
			}
			return num != 0f && RaycastExt.SafeRaycast(rPosition + rUp * num, rForward, out rEdgeHitInfo, rMaxDepth, rCollisionLayers, rTransform, null, false, true) && num3 - rEdgeHitInfo.distance >= rEdgeDepth;
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x00018B70 File Offset: 0x00016D70
		public static void Sort(RaycastHit[] rHitArray, int rCount)
		{
			if (rHitArray == null)
			{
				return;
			}
			if (rHitArray.Length <= 1)
			{
				return;
			}
			if (rCount > rHitArray.Length)
			{
				rCount = rHitArray.Length;
			}
			for (int i = 1; i < rCount; i++)
			{
				int num = i;
				RaycastHit raycastHit = rHitArray[i];
				while (num > 0 && rHitArray[num - 1].distance > raycastHit.distance)
				{
					rHitArray[num] = rHitArray[num - 1];
					num--;
				}
				rHitArray[num] = raycastHit;
			}
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x00018BE4 File Offset: 0x00016DE4
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

		// Token: 0x04000222 RID: 546
		public const int MAX_HITS = 40;

		// Token: 0x04000223 RID: 547
		public static RaycastHitDistanceComparer HitDistanceComparer = new RaycastHitDistanceComparer();

		// Token: 0x04000224 RID: 548
		public static RaycastHit EmptyHitInfo = default(RaycastHit);

		// Token: 0x04000225 RID: 549
		public static RaycastHit[] SharedHitArray = new RaycastHit[40];

		// Token: 0x04000226 RID: 550
		public static Collider[] SharedColliderArray = new Collider[40];
	}
}
