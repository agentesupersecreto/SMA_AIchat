using System;
using UnityEngine;

// Token: 0x02000037 RID: 55
public static class RigidBodyForcesExt
{
	// Token: 0x060001FC RID: 508 RVA: 0x0000B2D0 File Offset: 0x000094D0
	public static bool IsPointInsideCollider(this Collider collider, Vector3 worldPoint, float epsilon = 0.0001f)
	{
		if (collider == null)
		{
			return false;
		}
		MeshCollider meshCollider = collider as MeshCollider;
		if (meshCollider != null && !meshCollider.convex)
		{
			return meshCollider.IsPointInsideMeshCollider(worldPoint, 5f);
		}
		return Vector3.SqrMagnitude(collider.ClosestPoint(worldPoint) - worldPoint) < epsilon * epsilon;
	}

	// Token: 0x060001FD RID: 509 RVA: 0x0000B320 File Offset: 0x00009520
	public static bool IsPointInsideMeshCollider(this MeshCollider meshCollider, Vector3 worldPoint, float halfMaxDistance = 5f)
	{
		if (meshCollider == null || meshCollider.sharedMesh == null)
		{
			return false;
		}
		int num = 1 << meshCollider.gameObject.layer;
		Vector3 right = Vector3.right;
		Vector3 vector = worldPoint - right * halfMaxDistance;
		Ray ray = new Ray(vector, right);
		bool queriesHitBackfaces = Physics.queriesHitBackfaces;
		Physics.queriesHitBackfaces = true;
		int num2 = 0;
		bool flag;
		try
		{
			num2 = Physics.RaycastNonAlloc(ray, RigidBodyForcesExt.m_hitsTEMP, halfMaxDistance * 2f, num, QueryTriggerInteraction.Ignore);
			int num3 = 0;
			for (int i = 0; i < num2; i++)
			{
				if (RigidBodyForcesExt.m_hitsTEMP[i].collider == meshCollider)
				{
					num3++;
				}
			}
			flag = (num3 & 1) == 1;
		}
		finally
		{
			Physics.queriesHitBackfaces = queriesHitBackfaces;
			Array.Clear(RigidBodyForcesExt.m_hitsTEMP, 0, num2);
		}
		return flag;
	}

	// Token: 0x060001FE RID: 510 RVA: 0x0000B400 File Offset: 0x00009600
	public static float KineticEnergy(this Rigidbody rb)
	{
		return 0.5f * rb.mass * rb.velocity.sqrMagnitude;
	}

	// Token: 0x060001FF RID: 511 RVA: 0x0000B428 File Offset: 0x00009628
	public static void ResetForces(this Rigidbody rb)
	{
		rb.angularVelocity = Vector3.zero;
		rb.velocity = Vector3.zero;
		rb.Sleep();
	}

	// Token: 0x06000200 RID: 512 RVA: 0x0000B448 File Offset: 0x00009648
	public static float GetExplosiveImpulseMod(this Rigidbody rb, Vector3 ExpPosition, float sqrRange)
	{
		float sqrMagnitude = (rb.transform.position - ExpPosition).sqrMagnitude;
		if (sqrMagnitude > sqrRange)
		{
			return 0f;
		}
		return (1f - sqrMagnitude / sqrRange).InPow(2f);
	}

	// Token: 0x06000201 RID: 513 RVA: 0x0000B48C File Offset: 0x0000968C
	public static float GetExplosiveImpulseMod(this Rigidbody rb, float sqrRange, Vector3 ExpDirection)
	{
		float sqrMagnitude = ExpDirection.sqrMagnitude;
		if (sqrMagnitude > sqrRange)
		{
			return 0f;
		}
		return (1f - sqrMagnitude / sqrRange).InPow(2f);
	}

	// Token: 0x06000202 RID: 514 RVA: 0x0000B4BE File Offset: 0x000096BE
	public static float GetExplosiveImpulseMod(this Rigidbody rb, float sqrRange, float expSqrDistance)
	{
		if (expSqrDistance > sqrRange)
		{
			return 0f;
		}
		return (1f - expSqrDistance / sqrRange).InPow(2f);
	}

	// Token: 0x06000203 RID: 515 RVA: 0x0000B4E0 File Offset: 0x000096E0
	public static void AddExplosiveImpulse(this Rigidbody rb, Vector3 ExpPosition, float impulse, float sqrRange)
	{
		if (impulse <= 0f)
		{
			return;
		}
		Vector3 vector = rb.transform.position - ExpPosition;
		float explosiveImpulseMod = rb.GetExplosiveImpulseMod(sqrRange, vector);
		if (explosiveImpulseMod <= 0f)
		{
			return;
		}
		rb.AddForce(vector * explosiveImpulseMod * impulse, ForceMode.Impulse);
	}

	// Token: 0x06000204 RID: 516 RVA: 0x0000B530 File Offset: 0x00009730
	public static void AddExplosiveImpulse(this Rigidbody rb, float impulse, Vector3 ExpPosition, float mod)
	{
		if (impulse <= 0f || mod <= 0f)
		{
			return;
		}
		Vector3 vector = rb.transform.position - ExpPosition;
		rb.AddForce(vector * mod * impulse, ForceMode.Impulse);
	}

	// Token: 0x06000205 RID: 517 RVA: 0x0000B574 File Offset: 0x00009774
	public static void AddExplosiveImpulse(this Rigidbody rb, float mod, float impulse, Vector3 ExpDirection)
	{
		if (impulse <= 0f || mod <= 0f)
		{
			return;
		}
		rb.AddForce(ExpDirection * mod * impulse, ForceMode.Impulse);
	}

	// Token: 0x04000067 RID: 103
	private static RaycastHit[] m_hitsTEMP = new RaycastHit[100];
}
