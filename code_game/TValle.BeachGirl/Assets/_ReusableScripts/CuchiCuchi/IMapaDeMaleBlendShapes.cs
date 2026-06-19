using System;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000CF RID: 207
	public interface IMapaDeMaleBlendShapes<T>
	{
		// Token: 0x170002BC RID: 700
		// (get) Token: 0x0600074B RID: 1867
		T fat { get; }

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x0600074C RID: 1868
		T thin { get; }

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x0600074D RID: 1869
		T muscle { get; }

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x0600074E RID: 1870
		T old { get; }
	}
}
