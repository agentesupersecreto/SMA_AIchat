using System;
using System.Collections.Generic;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200003C RID: 60
	public abstract class MultipleProxyHitSkin<TCollider> : EmulatedHitSkin where TCollider : Collider
	{
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00007AEE File Offset: 0x00005CEE
		public override Side side
		{
			get
			{
				return this.m_side;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060001ED RID: 493 RVA: 0x00007AF6 File Offset: 0x00005CF6
		public override List<Collider> skinColliders
		{
			get
			{
				return this.m_skinColliders;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060001EE RID: 494 RVA: 0x00007AFE File Offset: 0x00005CFE
		public override HashSet<Collider> skinCollidersSet
		{
			get
			{
				return this.m_skinCollidersSet;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00006060 File Offset: 0x00004260
		public override Rigidbody rigid
		{
			get
			{
				return null;
			}
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00007B08 File Offset: 0x00005D08
		public void Init(IReadOnlyList<TCollider> colliderss, Side side, BodyPartEnum parte, Transform boneTarget, Skin VisualSkin, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction)
		{
			if (colliderss == null || colliderss.Count == 0)
			{
				throw new ArgumentNullException("collider", "collider null reference.");
			}
			this.m_layerMask = layerMask;
			this.m_queryTriggerInteraction = queryTriggerInteraction;
			this.m_side = side;
			foreach (TCollider tcollider in colliderss)
			{
				if (this.m_skinCollidersSet.Add(tcollider))
				{
					this.m_skinColliders.Add(tcollider);
					EmulatedHitSkin.ColliderCheckerBase colliderCheckerBase = this.ObtenerCheckDeCollider(tcollider);
					if (colliderCheckerBase == null)
					{
						throw new ArgumentNullException("check", "check null reference.");
					}
					if (colliderCheckerBase.ownCollider == null)
					{
						throw new ArgumentNullException("check.ownCollider", "check.ownCollider null reference.");
					}
					this.m_checks.Add(colliderCheckerBase);
				}
			}
			base.InitEmulated(parte, boneTarget, VisualSkin);
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00007BF0 File Offset: 0x00005DF0
		protected sealed override int ObtenerLayersDeCasteo()
		{
			if (!base.isHitSkinInit)
			{
				throw new NotSupportedException();
			}
			return this.m_layerMask;
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00007C0B File Offset: 0x00005E0B
		protected sealed override QueryTriggerInteraction ObtenerQueryTriggerInteraction()
		{
			if (!base.isHitSkinInit)
			{
				throw new NotSupportedException();
			}
			return this.m_queryTriggerInteraction;
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00007C21 File Offset: 0x00005E21
		protected sealed override IReadOnlyList<EmulatedHitSkin.ColliderCheckerBase> ObtenerChecks()
		{
			return this.m_checks;
		}

		// Token: 0x060001F4 RID: 500
		protected abstract EmulatedHitSkin.ColliderCheckerBase ObtenerCheckDeCollider(TCollider col);

		// Token: 0x060001F5 RID: 501 RVA: 0x00007C29 File Offset: 0x00005E29
		protected sealed override bool UsaPhysicsRelativeVelocity(IColisionEmuladaData data, EmulatedHitSkin.ColliderCheckerBase checker, RaycastHit hit, Vector3 emulatedRelativeVelocity, out Vector3 physicsRelativeVelocity)
		{
			physicsRelativeVelocity = default(Vector3);
			return false;
		}

		// Token: 0x040000F9 RID: 249
		[ReadOnlyUI]
		[SerializeField]
		private Side m_side;

		// Token: 0x040000FA RID: 250
		[ReadOnlyUI]
		[SerializeField]
		private List<Collider> m_skinColliders = new List<Collider>();

		// Token: 0x040000FB RID: 251
		private HashSet<Collider> m_skinCollidersSet = new HashSet<Collider>();

		// Token: 0x040000FC RID: 252
		[SerializeField]
		private LayerMask m_layerMask;

		// Token: 0x040000FD RID: 253
		[SerializeField]
		private QueryTriggerInteraction m_queryTriggerInteraction;

		// Token: 0x040000FE RID: 254
		private List<EmulatedHitSkin.ColliderCheckerBase> m_checks = new List<EmulatedHitSkin.ColliderCheckerBase>();
	}
}
