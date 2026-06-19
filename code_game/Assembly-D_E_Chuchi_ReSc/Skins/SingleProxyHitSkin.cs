using System;
using System.Collections.Generic;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000045 RID: 69
	public abstract class SingleProxyHitSkin : EmulatedHitSkin
	{
		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000226 RID: 550 RVA: 0x0000805A File Offset: 0x0000625A
		public override Side side
		{
			get
			{
				return this.m_side;
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000227 RID: 551 RVA: 0x00008062 File Offset: 0x00006262
		public override List<Collider> skinColliders
		{
			get
			{
				return this.m_skinColliders;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000228 RID: 552 RVA: 0x0000806A File Offset: 0x0000626A
		public override HashSet<Collider> skinCollidersSet
		{
			get
			{
				return this.m_skinCollidersSet;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000229 RID: 553 RVA: 0x00008072 File Offset: 0x00006272
		public override Rigidbody rigid
		{
			get
			{
				return this.m_skinColliders[0].attachedRigidbody;
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00008088 File Offset: 0x00006288
		public void InitSingle(Collider mainCollider, Side side, BodyPartEnum parte, Transform BoneTarget, Skin VisualSkin, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			if (mainCollider == null)
			{
				throw new ArgumentNullException("mainCollider", "mainCollider null reference.");
			}
			this.m_layerMask = layerMask;
			this.m_queryTriggerInteraction = queryTriggerInteraction;
			this.m_side = side;
			this.m_skinColliders.Add(mainCollider);
			this.m_skinCollidersSet.Add(mainCollider);
			EmulatedHitSkin.ColliderCheckerBase colliderCheckerBase = this.ObtenerCheck();
			if (colliderCheckerBase == null)
			{
				throw new ArgumentNullException("check", "check null reference.");
			}
			if (colliderCheckerBase.ownCollider == null)
			{
				throw new ArgumentNullException("check.ownCollider", "check.ownCollider null reference.");
			}
			this.m_checks.Add(colliderCheckerBase);
			base.InitEmulated(parte, BoneTarget, VisualSkin);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000812D File Offset: 0x0000632D
		protected sealed override int ObtenerLayersDeCasteo()
		{
			if (!base.isHitSkinInit)
			{
				throw new NotSupportedException();
			}
			return this.m_layerMask;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00008148 File Offset: 0x00006348
		protected sealed override QueryTriggerInteraction ObtenerQueryTriggerInteraction()
		{
			if (!base.isHitSkinInit)
			{
				throw new NotSupportedException();
			}
			return this.m_queryTriggerInteraction;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000815E File Offset: 0x0000635E
		protected sealed override IReadOnlyList<EmulatedHitSkin.ColliderCheckerBase> ObtenerChecks()
		{
			return this.m_checks;
		}

		// Token: 0x0600022E RID: 558
		protected abstract EmulatedHitSkin.ColliderCheckerBase ObtenerCheck();

		// Token: 0x0600022F RID: 559 RVA: 0x00007C29 File Offset: 0x00005E29
		protected sealed override bool UsaPhysicsRelativeVelocity(IColisionEmuladaData data, EmulatedHitSkin.ColliderCheckerBase checker, RaycastHit hit, Vector3 emulatedRelativeVelocity, out Vector3 physicsRelativeVelocity)
		{
			physicsRelativeVelocity = default(Vector3);
			return false;
		}

		// Token: 0x0400010D RID: 269
		[ReadOnlyUI]
		[SerializeField]
		private Side m_side;

		// Token: 0x0400010E RID: 270
		[ReadOnlyUI]
		[SerializeField]
		private List<Collider> m_skinColliders = new List<Collider>();

		// Token: 0x0400010F RID: 271
		private HashSet<Collider> m_skinCollidersSet = new HashSet<Collider>();

		// Token: 0x04000110 RID: 272
		[SerializeField]
		private LayerMask m_layerMask;

		// Token: 0x04000111 RID: 273
		[SerializeField]
		private QueryTriggerInteraction m_queryTriggerInteraction;

		// Token: 0x04000112 RID: 274
		private List<EmulatedHitSkin.ColliderCheckerBase> m_checks = new List<EmulatedHitSkin.ColliderCheckerBase>();
	}
}
