using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x0200006E RID: 110
	public class MultipleCapsuleProxyHitSkin : MultipleProxyHitSkin<CapsuleCollider>
	{
		// Token: 0x060002EF RID: 751 RVA: 0x00007535 File Offset: 0x00005735
		protected sealed override EmulatedHitSkin.ColliderCheckerBase ObtenerCheckDeCollider(CapsuleCollider col)
		{
			return new SingleCapsuleProxyHitSkin.CapsuleCheck(col, 0.003f);
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool DetectedColliderIsValid(Collider other)
		{
			return true;
		}
	}
}
