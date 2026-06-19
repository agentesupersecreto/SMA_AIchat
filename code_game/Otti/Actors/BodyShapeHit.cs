using System;
using com.ootii.Collections;
using com.ootii.Geometry;
using UnityEngine;

namespace com.ootii.Actors
{
	// Token: 0x02000095 RID: 149
	public class BodyShapeHit
	{
		// Token: 0x0600086B RID: 2155 RVA: 0x0002CD56 File Offset: 0x0002AF56
		public void CalculateHitOrigin()
		{
			this.HitOrigin = this.Shape.CalculateHitOrigin(this.HitPoint, this.StartPosition, this.EndPosition);
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x0600086C RID: 2156 RVA: 0x0002CD7B File Offset: 0x0002AF7B
		public static int Length
		{
			get
			{
				return BodyShapeHit.sPool.Length;
			}
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x0002CD87 File Offset: 0x0002AF87
		public static BodyShapeHit Allocate()
		{
			return BodyShapeHit.sPool.Allocate();
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x0002CD94 File Offset: 0x0002AF94
		public static BodyShapeHit Allocate(BodyShapeHit rInstance)
		{
			if (rInstance == null)
			{
				return BodyShapeHit.sPool.Allocate();
			}
			BodyShapeHit bodyShapeHit = BodyShapeHit.sPool.Allocate();
			bodyShapeHit.Shape = rInstance.Shape;
			bodyShapeHit.StartPosition = rInstance.StartPosition;
			bodyShapeHit.EndPosition = rInstance.EndPosition;
			bodyShapeHit.HitCollider = rInstance.HitCollider;
			bodyShapeHit.HitOrigin = rInstance.HitOrigin;
			bodyShapeHit.HitPoint = rInstance.HitPoint;
			bodyShapeHit.HitNormal = rInstance.HitNormal;
			bodyShapeHit.HitDistance = rInstance.HitDistance;
			bodyShapeHit.HitRootDistance = rInstance.HitRootDistance;
			bodyShapeHit.HitPenetration = rInstance.HitPenetration;
			bodyShapeHit.IsPlatformHit = rInstance.IsPlatformHit;
			bodyShapeHit.Hit = rInstance.Hit;
			return bodyShapeHit;
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x0002CE4C File Offset: 0x0002B04C
		public static void Release(BodyShapeHit rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Shape = null;
			rInstance.StartPosition = Vector3.zero;
			rInstance.EndPosition = Vector3.zero;
			rInstance.HitCollider = null;
			rInstance.HitOrigin = Vector3.zero;
			rInstance.HitPoint = Vector3.zero;
			rInstance.HitNormal = Vector3.zero;
			rInstance.HitDistance = 0f;
			rInstance.HitPenetration = false;
			rInstance.Hit = RaycastExt.EmptyHitInfo;
			BodyShapeHit.sPool.Release(rInstance);
		}

		// Token: 0x0400045B RID: 1115
		public BodyShape Shape;

		// Token: 0x0400045C RID: 1116
		public Vector3 StartPosition;

		// Token: 0x0400045D RID: 1117
		public Vector3 EndPosition;

		// Token: 0x0400045E RID: 1118
		public Collider HitCollider;

		// Token: 0x0400045F RID: 1119
		public Vector3 HitOrigin;

		// Token: 0x04000460 RID: 1120
		public Vector3 HitPoint;

		// Token: 0x04000461 RID: 1121
		public Vector3 HitNormal;

		// Token: 0x04000462 RID: 1122
		public float HitDistance;

		// Token: 0x04000463 RID: 1123
		public float HitRootDistance;

		// Token: 0x04000464 RID: 1124
		public bool HitPenetration;

		// Token: 0x04000465 RID: 1125
		public bool IsPlatformHit;

		// Token: 0x04000466 RID: 1126
		public RaycastHit Hit;

		// Token: 0x04000467 RID: 1127
		private static ObjectPool<BodyShapeHit> sPool = new ObjectPool<BodyShapeHit>(20, 5);
	}
}
