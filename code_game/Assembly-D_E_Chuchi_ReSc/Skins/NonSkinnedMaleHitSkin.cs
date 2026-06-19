using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000041 RID: 65
	public abstract class NonSkinnedMaleHitSkin<Tcol> : NonSkinnedMaleHitSkinBase where Tcol : NonSkinnedMaleHitSkinBase.BaseColliders, new()
	{
		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000209 RID: 521 RVA: 0x00007E01 File Offset: 0x00006001
		public Tcol colliders
		{
			get
			{
				return this.m_colliders;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600020A RID: 522 RVA: 0x00007E09 File Offset: 0x00006009
		public sealed override NonSkinnedMaleHitSkinBase.BaseColliders baseColliders
		{
			get
			{
				return this.m_colliders;
			}
		}

		// Token: 0x04000106 RID: 262
		[ReadOnlyUI]
		[SerializeField]
		protected Tcol m_colliders = new Tcol();
	}
}
