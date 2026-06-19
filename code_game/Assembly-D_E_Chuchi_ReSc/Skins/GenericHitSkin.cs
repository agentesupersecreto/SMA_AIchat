using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200004D RID: 77
	public class GenericHitSkin : HitSkin
	{
		// Token: 0x0600024B RID: 587 RVA: 0x00004252 File Offset: 0x00002452
		public override bool PointIsInside(Vector3 worldPoint)
		{
			return false;
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600024C RID: 588 RVA: 0x00008390 File Offset: 0x00006590
		protected override bool? isKinematic
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600024D RID: 589 RVA: 0x000083A6 File Offset: 0x000065A6
		public override BodyPartEnum? requiereBodyPartEnumCalculo
		{
			get
			{
				return new BodyPartEnum?(this.bodyPartEnum);
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600024E RID: 590 RVA: 0x00004252 File Offset: 0x00002452
		public override Side side
		{
			get
			{
				return Side.none;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600024F RID: 591 RVA: 0x000083B3 File Offset: 0x000065B3
		public override List<Collider> skinColliders
		{
			get
			{
				return this.m_colliders;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000250 RID: 592 RVA: 0x000083BB File Offset: 0x000065BB
		public override HashSet<Collider> skinCollidersSet
		{
			get
			{
				return this.m_collidersSet;
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x000083C4 File Offset: 0x000065C4
		protected override bool CalcularPartesImpactadas(RaycastHit hit, IList<BodyPartEnum> result)
		{
			result.Add(this.requiereBodyPartEnumCalculo.Value);
			return true;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000083E6 File Offset: 0x000065E6
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.rigid.GetComponentsInChildren<Collider>(this.m_colliders);
			this.m_collidersSet = new HashSet<Collider>(this.m_colliders);
		}

		// Token: 0x04000118 RID: 280
		public BodyPartEnum bodyPartEnum;

		// Token: 0x04000119 RID: 281
		private List<Collider> m_colliders = new List<Collider>();

		// Token: 0x0400011A RID: 282
		private HashSet<Collider> m_collidersSet = new HashSet<Collider>();
	}
}
