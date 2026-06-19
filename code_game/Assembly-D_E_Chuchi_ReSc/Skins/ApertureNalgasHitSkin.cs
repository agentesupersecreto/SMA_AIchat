using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000046 RID: 70
	public class ApertureNalgasHitSkin : SingleSphereProxyHitSkin
	{
		// Token: 0x06000231 RID: 561 RVA: 0x0000818F File Offset: 0x0000638F
		public void Init(IHole vagHole, Skin VisualSkin, SphereCollider mainCollider, Side side, BodyPartEnum parte, Transform boneTarget, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			if (vagHole == null)
			{
				throw new ArgumentNullException("vagHole", "vagHole null reference.");
			}
			this.m_vagHole = vagHole;
			base.Init(mainCollider, side, parte, boneTarget, VisualSkin, layerMask, queryTriggerInteraction);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x000081BD File Offset: 0x000063BD
		protected override bool DetectedColliderIsValid(Collider other)
		{
			return base.DetectedColliderIsValid(other) && (!this.m_vagHole.isPenetrated || !this.m_vagHole.IsPenetratedBy(other));
		}

		// Token: 0x04000113 RID: 275
		private IHole m_vagHole;
	}
}
