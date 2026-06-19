using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000080 RID: 128
	public class VagLabioMultipleHitSkin : MultipleSphereProxyHitSkin
	{
		// Token: 0x06000333 RID: 819 RVA: 0x0000C466 File Offset: 0x0000A666
		public void Init(IHole anusHole, Skin VisualSkin, IReadOnlyList<SphereCollider> colliderss, Side side, BodyPartEnum parte, Transform boneTarget, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			if (anusHole == null)
			{
				throw new ArgumentNullException("anusHole", "anusHole null reference.");
			}
			this.m_anusHole = anusHole;
			base.Init(colliderss, side, parte, boneTarget, VisualSkin, layerMask, queryTriggerInteraction);
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0000C494 File Offset: 0x0000A694
		protected override bool DetectedColliderIsValid(Collider other)
		{
			return base.DetectedColliderIsValid(other) && (!this.m_anusHole.isPenetrated || !this.m_anusHole.IsPenetratedBy(other));
		}

		// Token: 0x0400023B RID: 571
		private IHole m_anusHole;
	}
}
