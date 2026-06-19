using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000055 RID: 85
	public class ConcentMinimoParaSerPedidoDesvestir : ConcentMinimoPara
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060001BB RID: 443 RVA: 0x0000DC79 File Offset: 0x0000BE79
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060001BC RID: 444 RVA: 0x0000DC7C File Offset: 0x0000BE7C
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.boca };
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060001BD RID: 445 RVA: 0x0000DC8C File Offset: 0x0000BE8C
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060001BE RID: 446 RVA: 0x0000DC8F File Offset: 0x0000BE8F
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.peticionDesvestidura;
			}
		}

		// Token: 0x060001BF RID: 447 RVA: 0x0000DC93 File Offset: 0x0000BE93
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
