using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000056 RID: 86
	public class ConcentMinimoParaSerPedidoMoverBone : ConcentMinimoPara
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x0000DC9E File Offset: 0x0000BE9E
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x0000DCA1 File Offset: 0x0000BEA1
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.boca };
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x0000DCB1 File Offset: 0x0000BEB1
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x0000DCB4 File Offset: 0x0000BEB4
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.guiandoBone;
			}
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000DCB8 File Offset: 0x0000BEB8
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
