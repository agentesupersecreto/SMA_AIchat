using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200007B RID: 123
	public class SingleCapsuleProxyHitSkin : SingleProxyHitSkin
	{
		// Token: 0x06000325 RID: 805 RVA: 0x0000C27E File Offset: 0x0000A47E
		public void Init(CapsuleCollider mainCollider, Side side, BodyPartEnum parte, Transform boneTarget, Skin VisualSkin, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			this.m_Check = new SingleCapsuleProxyHitSkin.CapsuleCheck(mainCollider, 0.003f);
			base.InitSingle(mainCollider, side, parte, boneTarget, VisualSkin, layerMask, queryTriggerInteraction);
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0000C2A2 File Offset: 0x0000A4A2
		protected override EmulatedHitSkin.ColliderCheckerBase ObtenerCheck()
		{
			return this.m_Check;
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool DetectedColliderIsValid(Collider other)
		{
			return true;
		}

		// Token: 0x04000234 RID: 564
		[ReadOnlyUI]
		[SerializeField]
		private SingleCapsuleProxyHitSkin.CapsuleCheck m_Check;

		// Token: 0x0200007C RID: 124
		[Serializable]
		public class CapsuleCheck : ColliderChecker<CapsuleCollider>
		{
			// Token: 0x06000329 RID: 809 RVA: 0x0000C2B2 File Offset: 0x0000A4B2
			public CapsuleCheck(CapsuleCollider collider, float offsetEnMetros)
				: base(collider)
			{
				this.m_offsetEnMetros = offsetEnMetros;
			}

			// Token: 0x0600032A RID: 810 RVA: 0x0000C2C4 File Offset: 0x0000A4C4
			public sealed override int DoCheck(Collider[] results, int layerMask, QueryTriggerInteraction queryTriggerInteraction, float offsetMod)
			{
				Vector3 vector;
				switch (this.m_collider.direction)
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
					throw new ArgumentOutOfRangeException(this.m_collider.direction.ToString());
				}
				float num = this.m_collider.height / 2f - this.m_collider.radius;
				Vector3 vector2 = this.m_collider.center + vector * num;
				Vector3 vector3 = this.m_collider.center - vector * num;
				return PhysicsCast.OverlapCapsuleNonAlloc(this.m_collider.transform.TransformPoint(vector2), this.m_collider.transform.TransformPoint(vector3), this.currentColliderEscala * (this.m_collider.radius + this.m_offsetEnMetros * offsetMod), results, layerMask, queryTriggerInteraction);
			}

			// Token: 0x04000235 RID: 565
			[SerializeField]
			protected float m_offsetEnMetros;
		}
	}
}
