using System;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000049 RID: 73
	public class ConcentMinimoParaMirar : ConcentMinimoParaVisionesDadas
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000181 RID: 385 RVA: 0x0000DB1B File Offset: 0x0000BD1B
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.dada;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000182 RID: 386 RVA: 0x0000DB1E File Offset: 0x0000BD1E
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}
	}
}
