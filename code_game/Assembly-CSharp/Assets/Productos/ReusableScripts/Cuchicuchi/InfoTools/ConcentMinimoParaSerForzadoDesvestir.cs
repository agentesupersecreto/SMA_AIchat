using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200004F RID: 79
	public class ConcentMinimoParaSerForzadoDesvestir : ConcentMinimoPara
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600019C RID: 412 RVA: 0x0000DBC8 File Offset: 0x0000BDC8
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600019D RID: 413 RVA: 0x0000DBCB File Offset: 0x0000BDCB
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.manos };
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600019E RID: 414 RVA: 0x0000DBD7 File Offset: 0x0000BDD7
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600019F RID: 415 RVA: 0x0000DBDA File Offset: 0x0000BDDA
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.desvestidura;
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0000DBDE File Offset: 0x0000BDDE
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
