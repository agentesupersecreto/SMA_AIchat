using System;
using UnityEngine.Jobs;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Sistemas
{
	// Token: 0x020001B0 RID: 432
	internal class ElasticFromNextData : ElasticFromOtherData
	{
		// Token: 0x06000A36 RID: 2614 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool EsRoot()
		{
			return false;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x0000D704 File Offset: 0x0000B904
		protected override int IDIndex()
		{
			return 3;
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x0002E0B9 File Offset: 0x0002C2B9
		protected override TransformAccessArray GetArray(TransformsData transformsData)
		{
			return transformsData.nextAccess;
		}
	}
}
