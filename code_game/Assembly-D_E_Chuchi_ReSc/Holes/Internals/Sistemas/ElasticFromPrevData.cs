using System;
using UnityEngine.Jobs;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Sistemas
{
	// Token: 0x020001AF RID: 431
	internal class ElasticFromPrevData : ElasticFromOtherData
	{
		// Token: 0x06000A32 RID: 2610 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool EsRoot()
		{
			return false;
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00006318 File Offset: 0x00004518
		protected override int IDIndex()
		{
			return 2;
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x0002E0B1 File Offset: 0x0002C2B1
		protected override TransformAccessArray GetArray(TransformsData transformsData)
		{
			return transformsData.prevAccess;
		}
	}
}
