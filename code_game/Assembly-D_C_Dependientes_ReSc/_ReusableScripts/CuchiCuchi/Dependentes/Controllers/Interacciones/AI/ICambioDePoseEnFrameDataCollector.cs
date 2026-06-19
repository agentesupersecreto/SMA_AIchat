using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI
{
	// Token: 0x020001C9 RID: 457
	public interface ICambioDePoseEnFrameDataCollector
	{
		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000AE0 RID: 2784
		IReadOnlyList<CambioDePoseData> ejecutadasEnFrame { get; }

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000AE1 RID: 2785
		IReadOnlyList<CambioDePoseData> detenidasEnFrame { get; }

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000AE2 RID: 2786
		Character character { get; }
	}
}
