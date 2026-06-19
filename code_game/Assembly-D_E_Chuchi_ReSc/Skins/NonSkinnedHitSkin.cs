using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200003E RID: 62
	public abstract class NonSkinnedHitSkin<Tcol> : NonSkinnedHitSkinBase where Tcol : NonSkinnedHitSkinBase.BaseColliders, new()
	{
		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060001FD RID: 509 RVA: 0x00007D52 File Offset: 0x00005F52
		public Tcol colliders
		{
			get
			{
				return this.m_colliders;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060001FE RID: 510 RVA: 0x00007D5A File Offset: 0x00005F5A
		public sealed override NonSkinnedHitSkinBase.BaseColliders baseColliders
		{
			get
			{
				return this.m_colliders;
			}
		}

		// Token: 0x04000103 RID: 259
		[ReadOnlyUI]
		[SerializeField]
		protected Tcol m_colliders = new Tcol();
	}
}
