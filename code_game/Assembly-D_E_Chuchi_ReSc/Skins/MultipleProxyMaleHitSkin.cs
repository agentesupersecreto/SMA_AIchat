using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200003D RID: 61
	public abstract class MultipleProxyMaleHitSkin<TCollider> : EmulatedMaleHitSkin where TCollider : Collider
	{
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00007C5D File Offset: 0x00005E5D
		public override Side side
		{
			get
			{
				return this.m_side;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x00007C65 File Offset: 0x00005E65
		public override List<Collider> skinColliders
		{
			get
			{
				return this.m_skinColliders;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00007C6D File Offset: 0x00005E6D
		public override HashSet<Collider> skinCollidersSet
		{
			get
			{
				return this.m_skinCollidersSet;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060001FA RID: 506 RVA: 0x00007C75 File Offset: 0x00005E75
		public override Rigidbody rigid
		{
			get
			{
				return this.m_rigid;
			}
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00007C80 File Offset: 0x00005E80
		public void Init(IReadOnlyList<TCollider> colliderss, Side side, ParteQuePuedeEstimular parte, Transform boneTarget, Skin VisualSkin, Rigidbody Rigid)
		{
			if (colliderss == null || colliderss.Count == 0)
			{
				throw new ArgumentNullException("collider", "collider null reference.");
			}
			if (Rigid == null)
			{
				throw new ArgumentNullException("Rigid", "Rigid null reference.");
			}
			this.m_rigid = Rigid;
			this.m_side = side;
			foreach (TCollider tcollider in colliderss)
			{
				if (this.m_skinCollidersSet.Add(tcollider))
				{
					this.m_skinColliders.Add(tcollider);
				}
			}
			base.InitEmulated(parte, boneTarget, VisualSkin);
		}

		// Token: 0x040000FF RID: 255
		[ReadOnlyUI]
		[SerializeField]
		private Side m_side;

		// Token: 0x04000100 RID: 256
		[ReadOnlyUI]
		[SerializeField]
		private Rigidbody m_rigid;

		// Token: 0x04000101 RID: 257
		[ReadOnlyUI]
		[SerializeField]
		private List<Collider> m_skinColliders = new List<Collider>();

		// Token: 0x04000102 RID: 258
		private HashSet<Collider> m_skinCollidersSet = new HashSet<Collider>();
	}
}
