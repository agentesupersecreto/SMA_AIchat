using System;
using UnityEngine.Jobs;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Internals.Sistemas
{
	// Token: 0x020001AE RID: 430
	internal class ElasticFromRootData : ElasticFromOtherData
	{
		// Token: 0x06000A2E RID: 2606 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool EsRoot()
		{
			return true;
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x0002E0A1 File Offset: 0x0002C2A1
		protected override TransformAccessArray GetArray(TransformsData transformsData)
		{
			return transformsData.rootAccess;
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00005F51 File Offset: 0x00004151
		protected override int IDIndex()
		{
			return 1;
		}
	}
}
