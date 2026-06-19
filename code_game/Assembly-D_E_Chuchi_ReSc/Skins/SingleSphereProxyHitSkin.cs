using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200007D RID: 125
	public class SingleSphereProxyHitSkin : SingleProxyHitSkin
	{
		// Token: 0x0600032B RID: 811 RVA: 0x0000C3B9 File Offset: 0x0000A5B9
		public void Init(SphereCollider mainCollider, Side side, BodyPartEnum parte, Transform boneTarget, Skin VisualSkin, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			this.m_SphereCheck = new SingleSphereProxyHitSkin.SphereCheck(mainCollider, 0.003f);
			base.InitSingle(mainCollider, side, parte, boneTarget, VisualSkin, layerMask, queryTriggerInteraction);
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0000C3DD File Offset: 0x0000A5DD
		protected override EmulatedHitSkin.ColliderCheckerBase ObtenerCheck()
		{
			return this.m_SphereCheck;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool DetectedColliderIsValid(Collider other)
		{
			return true;
		}

		// Token: 0x04000236 RID: 566
		[ReadOnlyUI]
		[SerializeField]
		private SingleSphereProxyHitSkin.SphereCheck m_SphereCheck;

		// Token: 0x0200007E RID: 126
		[Serializable]
		public class SphereCheck : ColliderChecker<SphereCollider>
		{
			// Token: 0x0600032F RID: 815 RVA: 0x0000C3E5 File Offset: 0x0000A5E5
			public SphereCheck(SphereCollider collider, float offsetEnMetros)
				: base(collider)
			{
				this.m_offsetEnMetros = offsetEnMetros;
			}

			// Token: 0x06000330 RID: 816 RVA: 0x0000C3F8 File Offset: 0x0000A5F8
			public sealed override int DoCheck(Collider[] results, int layerMask, QueryTriggerInteraction queryTriggerInteraction, float offsetMod)
			{
				Transform transform = this.m_collider.transform;
				Vector3 center = this.m_collider.center;
				return PhysicsCast.OverlapSphereNonAlloc(transform.TransformPoint(center), this.currentColliderEscala * (this.m_collider.radius + this.m_offsetEnMetros * offsetMod), results, layerMask, queryTriggerInteraction);
			}

			// Token: 0x04000237 RID: 567
			[SerializeField]
			protected float m_offsetEnMetros;
		}
	}
}
