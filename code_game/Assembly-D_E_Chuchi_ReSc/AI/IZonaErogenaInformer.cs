using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000318 RID: 792
	public interface IZonaErogenaInformer
	{
		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x0600111C RID: 4380
		float frameMovement { get; }

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x0600111D RID: 4381
		Vector3 worldPosition { get; }

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x0600111E RID: 4382
		Vector3 worldNormal { get; }

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x0600111F RID: 4383
		ZonaErogenaSensibilidad sensibilidad { get; }

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x06001120 RID: 4384
		ZonaErogenaPrivacidad privacidad { get; }

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06001121 RID: 4385
		ZonaErogenaMaxPlacer maxPlacer { get; }

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06001122 RID: 4386
		ZonaErogenaUbicacion ubicacion { get; }
	}
}
