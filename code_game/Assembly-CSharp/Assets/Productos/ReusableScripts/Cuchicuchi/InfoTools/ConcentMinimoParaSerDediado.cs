using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200004D RID: 77
	public class ConcentMinimoParaSerDediado : ConcentMinimoParaToques
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000192 RID: 402 RVA: 0x0000DB86 File Offset: 0x0000BD86
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000193 RID: 403 RVA: 0x0000DB89 File Offset: 0x0000BD89
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.dedo };
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000194 RID: 404 RVA: 0x0000DB99 File Offset: 0x0000BD99
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000195 RID: 405 RVA: 0x0000DB9C File Offset: 0x0000BD9C
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.tactil;
			}
		}
	}
}
