using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000EF RID: 239
	public class PhysicsCast
	{
		// Token: 0x0600068B RID: 1675 RVA: 0x00017B3C File Offset: 0x00015D3C
		public static void ProyectarPunto(out Vector3 proyectedPoint, out Vector3 proyectedPointNormal, Vector3 position, Vector3 directionToProyectInto, LayerMask layer, float maxDistance, float backwardsStartDistanceMod, float backwardsDistance = 0.05f, Func<RaycastHit, bool> evaluador = null)
		{
			int num = 0;
			try
			{
				float num2 = maxDistance * backwardsStartDistanceMod;
				Vector3 vector = position - directionToProyectInto.normalized * num2;
				num = Physics.RaycastNonAlloc(new Ray(vector, directionToProyectInto), PhysicsCast.m_temp, maxDistance, layer, QueryTriggerInteraction.Ignore);
				RaycastHit? raycastHit = null;
				if (num > 0)
				{
					if (evaluador != null)
					{
						for (int i = 0; i < num; i++)
						{
							RaycastHit raycastHit2 = PhysicsCast.m_temp[i];
							if (evaluador(raycastHit2))
							{
								raycastHit = new RaycastHit?(raycastHit2);
							}
						}
					}
					else
					{
						raycastHit = new RaycastHit?(PhysicsCast.m_temp[0]);
					}
				}
				if (raycastHit == null)
				{
					proyectedPoint = vector + directionToProyectInto.normalized * maxDistance - directionToProyectInto.normalized * backwardsDistance;
					proyectedPointNormal = -directionToProyectInto;
				}
				else
				{
					proyectedPoint = raycastHit.Value.point + raycastHit.Value.normal.normalized * backwardsDistance;
					proyectedPointNormal = raycastHit.Value.normal;
				}
			}
			finally
			{
				Array.Clear(PhysicsCast.m_temp, 0, num);
			}
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x00017C98 File Offset: 0x00015E98
		public static int RaycastAllNonAlloc(Vector3 origin, Vector3 direction, RaycastHit[] results, float maxDistance = float.PositiveInfinity, int layermask = -5, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			return Physics.RaycastNonAlloc(origin, direction, results, maxDistance, layermask, queryTriggerInteraction);
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00017CA7 File Offset: 0x00015EA7
		public static int SphereCastNonAlloc(Vector3 origin, float radius, Vector3 direction, RaycastHit[] results, float maxDistance = float.PositiveInfinity, int layerMask = -5, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			return Physics.SphereCastNonAlloc(origin, radius, direction, results, maxDistance, layerMask, queryTriggerInteraction);
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00017CB8 File Offset: 0x00015EB8
		public static int OverlapSphereNonAlloc(Vector3 position, float radius, Collider[] results, int layerMask = -1, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			return Physics.OverlapSphereNonAlloc(position, radius, results, layerMask, queryTriggerInteraction);
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x00017CC5 File Offset: 0x00015EC5
		public static int OverlapCapsuleNonAlloc(Vector3 point0, Vector3 point1, float radius, Collider[] results, int layerMask = -1, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			return Physics.OverlapCapsuleNonAlloc(point0, point1, radius, results, layerMask, queryTriggerInteraction);
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x00017CD4 File Offset: 0x00015ED4
		public static bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			return Physics.SphereCast(origin, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x00017CE8 File Offset: 0x00015EE8
		public static bool CheckCollider(SphereCollider collider, float escala, float offsetEnMetros, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			Transform transform = collider.transform;
			Vector3 center = collider.center;
			return Physics.CheckSphere(transform.TransformPoint(center), escala * collider.radius + offsetEnMetros, layerMask, queryTriggerInteraction);
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x00017D1C File Offset: 0x00015F1C
		public static bool CheckCollider(CapsuleCollider collider, float escala, float offsetEnMetros, int layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			Vector3 vector;
			switch (collider.direction)
			{
			case 0:
				vector = Vector3.right;
				break;
			case 1:
				vector = Vector3.up;
				break;
			case 2:
				vector = Vector3.forward;
				break;
			default:
				throw new ArgumentOutOfRangeException(collider.direction.ToString());
			}
			float num = collider.height / 2f - collider.radius;
			Vector3 vector2 = collider.center + vector * num;
			Vector3 vector3 = collider.center - vector * num;
			return Physics.CheckCapsule(collider.transform.TransformPoint(vector2), collider.transform.TransformPoint(vector3), escala * collider.radius + offsetEnMetros, layerMask, queryTriggerInteraction);
		}

		// Token: 0x040001EC RID: 492
		private static RaycastHit[] m_temp = new RaycastHit[20];
	}
}
