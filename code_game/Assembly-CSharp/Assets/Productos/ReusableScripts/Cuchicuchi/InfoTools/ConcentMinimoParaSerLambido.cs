using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000052 RID: 82
	public class ConcentMinimoParaSerLambido : ConcentMinimoParaToques
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060001AD RID: 429 RVA: 0x0000DC2C File Offset: 0x0000BE2C
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060001AE RID: 430 RVA: 0x0000DC2F File Offset: 0x0000BE2F
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.lengua };
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060001AF RID: 431 RVA: 0x0000DC3C File Offset: 0x0000BE3C
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x0000DC3F File Offset: 0x0000BE3F
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.tactil;
			}
		}
	}
}
