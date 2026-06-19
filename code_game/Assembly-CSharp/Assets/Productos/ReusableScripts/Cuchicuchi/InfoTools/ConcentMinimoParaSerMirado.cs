using System;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000054 RID: 84
	public class ConcentMinimoParaSerMirado : ConcentMinimoParaVisiones
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x0000DC6B File Offset: 0x0000BE6B
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x0000DC6E File Offset: 0x0000BE6E
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}
	}
}
