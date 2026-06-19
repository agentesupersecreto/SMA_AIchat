using System;
using Assets._ReusableScripts.UI.Interacciones.Donas.Abstracts;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa.UI
{
	// Token: 0x02000140 RID: 320
	[Obsolete("usar la version para THS")]
	public class OpcionesDeDonaDeRopaCubre : GenericOpcionesDeDonaDeEnumerable<RopaCubre, OpcionesDeDonaDeRopaCubre.CurrentClicked>
	{
		// Token: 0x06000753 RID: 1875 RVA: 0x00022673 File Offset: 0x00020873
		public override bool DibujarIndex(int index)
		{
			return GenericOpcionesDeDonaDeEnumerable<RopaCubre, OpcionesDeDonaDeRopaCubre.CurrentClicked>.valores[index] != RopaCubre.None && GenericOpcionesDeDonaDeEnumerable<RopaCubre, OpcionesDeDonaDeRopaCubre.CurrentClicked>.valores[index] != RopaCubre.pene && GenericOpcionesDeDonaDeEnumerable<RopaCubre, OpcionesDeDonaDeRopaCubre.CurrentClicked>.valores[index] != RopaCubre.testiculos;
		}

		// Token: 0x02000141 RID: 321
		[Serializable]
		public class CurrentClicked : OpcionesDeDonaCurrentClicked<RopaCubre>
		{
			// Token: 0x040005CC RID: 1484
			public bool puedeDesvestir = true;
		}
	}
}
