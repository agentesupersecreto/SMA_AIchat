using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000057 RID: 87
	public class ConcentMinimoParaSerPedidoPose : ConcentMinimoPara
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x0000DCC3 File Offset: 0x0000BEC3
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x0000DCC6 File Offset: 0x0000BEC6
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.boca };
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x0000DCD6 File Offset: 0x0000BED6
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060001CA RID: 458 RVA: 0x0000DCD9 File Offset: 0x0000BED9
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.peticionEjecucionDePose;
			}
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0000DCDD File Offset: 0x0000BEDD
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
