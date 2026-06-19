using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000053 RID: 83
	public class ConcentMinimoParaSerManipulado : ConcentMinimoPara
	{
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x0000DC4A File Offset: 0x0000BE4A
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x0000DC4D File Offset: 0x0000BE4D
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.manos };
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x0000DC59 File Offset: 0x0000BE59
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x0000DC5C File Offset: 0x0000BE5C
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.manipulandoBone;
			}
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0000DC60 File Offset: 0x0000BE60
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
