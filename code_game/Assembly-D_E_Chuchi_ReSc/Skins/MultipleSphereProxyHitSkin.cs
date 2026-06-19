using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins
{
	// Token: 0x02000070 RID: 112
	public class MultipleSphereProxyHitSkin : MultipleProxyHitSkin<SphereCollider>
	{
		// Token: 0x060002F3 RID: 755 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool DetectedColliderIsValid(Collider other)
		{
			return true;
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000AFD1 File Offset: 0x000091D1
		protected override EmulatedHitSkin.ColliderCheckerBase ObtenerCheckDeCollider(SphereCollider col)
		{
			return new SingleSphereProxyHitSkin.SphereCheck(col, 0.003f);
		}
	}
}
