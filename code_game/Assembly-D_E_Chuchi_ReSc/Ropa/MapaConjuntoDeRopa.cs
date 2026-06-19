using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x02000108 RID: 264
	[CreateAssetMenu(fileName = "MapaConjuntoDeRopa", menuName = "Objetos/Ropa/MapaConjuntoDeRopa")]
	public class MapaConjuntoDeRopa : AplicableScriptable, IConjuntoDeRopa
	{
		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000674 RID: 1652 RVA: 0x0001ED61 File Offset: 0x0001CF61
		IReadOnlyList<Pieza> IConjuntoDeRopa.piezas
		{
			get
			{
				return this.piezas;
			}
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string IConjuntoDeRopa.get_name()
		{
			return base.name;
		}

		// Token: 0x04000456 RID: 1110
		public List<Pieza> piezas = new List<Pieza>();
	}
}
