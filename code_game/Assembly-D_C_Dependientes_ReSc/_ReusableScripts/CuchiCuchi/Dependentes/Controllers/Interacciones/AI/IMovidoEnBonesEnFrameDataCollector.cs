using System;
using System.Collections.Generic;
using Assets.Base.Bones.Gizmos.BeachGirl.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI
{
	// Token: 0x020001D1 RID: 465
	public interface IMovidoEnBonesEnFrameDataCollector
	{
		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000AF2 RID: 2802
		GizmoDeBoneRMInfo boneInfo { get; }

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000AF3 RID: 2803
		IReadOnlyList<ManipulacionDeBoneData> guiadosEnFrame { get; }

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000AF4 RID: 2804
		IReadOnlyList<ManipulacionDeBoneData> manipuladosEnFrame { get; }

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000AF5 RID: 2805
		Character character { get; }
	}
}
