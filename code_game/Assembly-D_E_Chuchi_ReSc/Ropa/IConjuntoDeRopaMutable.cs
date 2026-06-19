using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000CE RID: 206
	public interface IConjuntoDeRopaMutable : IConjuntoDeRopa
	{
		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060004FD RID: 1277
		// (set) Token: 0x060004FE RID: 1278
		string name { get; set; }

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060004FF RID: 1279
		// (set) Token: 0x06000500 RID: 1280
		List<Pieza> piezas { get; set; }
	}
}
