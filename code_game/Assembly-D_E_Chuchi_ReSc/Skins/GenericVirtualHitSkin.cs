using System;
using Assets._ReusableScripts.CuchiCuchi.Skins.Colliders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200004F RID: 79
	public class GenericVirtualHitSkin : NonSkinnedHitSkin<GenericVirtualHitSkin.Colliders>
	{
		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000255 RID: 597 RVA: 0x0000842E File Offset: 0x0000662E
		public sealed override BodyPartEnum parte
		{
			get
			{
				return this.bodyPartEnum;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000256 RID: 598 RVA: 0x00008436 File Offset: 0x00006636
		public sealed override Side side
		{
			get
			{
				return this.bodyPartSide;
			}
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000843E File Offset: 0x0000663E
		public virtual void Init(HitPartEnum hitParte, BodyPartEnum parte, Transform boneTarget, Skin VisualSkin, Side side)
		{
			this.bodyPartSide = side;
			this.bodyPartEnum = parte;
			this.Init(hitParte, boneTarget, VisualSkin);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00008459 File Offset: 0x00006659
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			base.colliders.generic = GenericBoneCollider.Crear<GenericBoneCollider>(this, base.boneTarget, base.transform, 1f);
		}

		// Token: 0x0400011B RID: 283
		public Side bodyPartSide;

		// Token: 0x0400011C RID: 284
		public BodyPartEnum bodyPartEnum;

		// Token: 0x02000050 RID: 80
		[Serializable]
		public class Colliders : NonSkinnedHitSkinBase.BaseColliders
		{
			// Token: 0x0400011D RID: 285
			public GenericBoneCollider generic;
		}
	}
}
