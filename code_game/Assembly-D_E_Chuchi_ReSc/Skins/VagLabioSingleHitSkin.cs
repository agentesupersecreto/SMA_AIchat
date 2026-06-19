using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000081 RID: 129
	public class VagLabioSingleHitSkin : SingleSphereProxyHitSkin
	{
		// Token: 0x06000336 RID: 822 RVA: 0x0000C4C7 File Offset: 0x0000A6C7
		public void Init(IHole anusHole, Skin VisualSkin, SphereCollider mainCollider, Side side, BodyPartEnum parte, Transform boneTarget, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			if (anusHole == null)
			{
				throw new ArgumentNullException("anusHole", "anusHole null reference.");
			}
			this.m_anusHole = anusHole;
			base.Init(mainCollider, side, parte, boneTarget, VisualSkin, layerMask, queryTriggerInteraction);
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0000C4F5 File Offset: 0x0000A6F5
		protected override bool DetectedColliderIsValid(Collider other)
		{
			return base.DetectedColliderIsValid(other) && (!this.m_anusHole.isPenetrated || !this.m_anusHole.IsPenetratedBy(other));
		}

		// Token: 0x0400023C RID: 572
		private IHole m_anusHole;
	}
}
