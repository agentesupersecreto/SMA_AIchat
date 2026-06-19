using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x020000CD RID: 205
	public interface IConjuntoDeRopa
	{
		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060004FB RID: 1275
		string name { get; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060004FC RID: 1276
		IReadOnlyList<Pieza> piezas { get; }
	}
}
