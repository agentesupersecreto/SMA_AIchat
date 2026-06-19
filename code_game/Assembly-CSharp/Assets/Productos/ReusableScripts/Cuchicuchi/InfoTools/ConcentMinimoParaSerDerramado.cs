using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200004E RID: 78
	public class ConcentMinimoParaSerDerramado : ConcentMinimoParaToques
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000197 RID: 407 RVA: 0x0000DBA7 File Offset: 0x0000BDA7
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000198 RID: 408 RVA: 0x0000DBAA File Offset: 0x0000BDAA
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.semen };
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000199 RID: 409 RVA: 0x0000DBBA File Offset: 0x0000BDBA
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600019A RID: 410 RVA: 0x0000DBBD File Offset: 0x0000BDBD
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.tactil;
			}
		}
	}
}
