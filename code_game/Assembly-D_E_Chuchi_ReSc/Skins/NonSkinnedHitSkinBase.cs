using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200003F RID: 63
	public abstract class NonSkinnedHitSkinBase : HitSkin
	{
		// Token: 0x06000200 RID: 512 RVA: 0x00004252 File Offset: 0x00002452
		public override bool PointIsInside(Vector3 worldPoint)
		{
			return false;
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000201 RID: 513 RVA: 0x00007D7A File Offset: 0x00005F7A
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

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000202 RID: 514 RVA: 0x00007DAF File Offset: 0x00005FAF
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

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000203 RID: 515
		public abstract NonSkinnedHitSkinBase.BaseColliders baseColliders { get; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000204 RID: 516
		public abstract BodyPartEnum parte { get; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00007DDD File Offset: 0x00005FDD
		public sealed override BodyPartEnum? requiereBodyPartEnumCalculo
		{
			get
			{
				return new BodyPartEnum?(this.parte);
			}
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00007DEA File Offset: 0x00005FEA
		protected override bool CalcularPartesImpactadas(RaycastHit hit, IList<BodyPartEnum> result)
		{
			result.Add(this.parte);
			return true;
		}

		// Token: 0x04000104 RID: 260
		private List<Collider> m_collidersDeVirtalSkin;

		// Token: 0x04000105 RID: 261
		private HashSet<Collider> m_collidersDeVirtalSkinSet;

		// Token: 0x02000040 RID: 64
		[Serializable]
		public abstract class BaseColliders
		{
		}
	}
}
