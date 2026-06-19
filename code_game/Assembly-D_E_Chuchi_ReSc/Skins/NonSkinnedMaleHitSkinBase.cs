using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000042 RID: 66
	public abstract class NonSkinnedMaleHitSkinBase : MaleHitSkin
	{
		// Token: 0x0600020C RID: 524 RVA: 0x00004252 File Offset: 0x00002452
		public override bool PointIsInside(Vector3 worldPoint)
		{
			return false;
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00007E29 File Offset: 0x00006029
		public sealed override List<Collider> skinColliders
		{
			get
			{
				if (this.m_collidersDeVirtalSkin == null)
				{
					this.m_collidersDeVirtalSkin = new List<Collider>();
				}
				if (this.m_collidersDeVirtalSkin.Count == 0)
				{
					base.GetComponentsInChildren<Collider>(true, this.m_collidersDeVirtalSkin);
				}
				return this.m_collidersDeVirtalSkin;
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00007E5E File Offset: 0x0000605E
		public sealed override HashSet<Collider> skinCollidersSet
		{
			get
			{
				if (this.m_collidersDeVirtalSkinSet == null || this.m_collidersDeVirtalSkinSet.Count == 0)
				{
					this.m_collidersDeVirtalSkinSet = new HashSet<Collider>(this.skinColliders);
				}
				return this.m_collidersDeVirtalSkinSet;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600020F RID: 527
		public abstract NonSkinnedMaleHitSkinBase.BaseColliders baseColliders { get; }

		// Token: 0x04000107 RID: 263
		private List<Collider> m_collidersDeVirtalSkin;

		// Token: 0x04000108 RID: 264
		private HashSet<Collider> m_collidersDeVirtalSkinSet;

		// Token: 0x02000043 RID: 67
		[Serializable]
		public abstract class BaseColliders
		{
		}
	}
}
