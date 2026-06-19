using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200004A RID: 74
	public class ConcentMinimoParaSerAcariciado : ConcentMinimoParaToques
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000184 RID: 388 RVA: 0x0000DB29 File Offset: 0x0000BD29
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000185 RID: 389 RVA: 0x0000DB2C File Offset: 0x0000BD2C
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.manos };
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000186 RID: 390 RVA: 0x0000DB38 File Offset: 0x0000BD38
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}
	}
}
