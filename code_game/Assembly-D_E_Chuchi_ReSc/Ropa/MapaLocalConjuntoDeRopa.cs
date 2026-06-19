using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x02000120 RID: 288
	public sealed class MapaLocalConjuntoDeRopa : CustomUpdatedMonobehaviourBase, IConjuntoDeRopa
	{
		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060006A4 RID: 1700 RVA: 0x0001F21D File Offset: 0x0001D41D
		IReadOnlyList<Pieza> IConjuntoDeRopa.piezas
		{
			get
			{
				return this.piezas;
			}
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string IConjuntoDeRopa.get_name()
		{
			return base.name;
		}

		// Token: 0x04000552 RID: 1362
		public List<Pieza> piezas = new List<Pieza>();
	}
}
