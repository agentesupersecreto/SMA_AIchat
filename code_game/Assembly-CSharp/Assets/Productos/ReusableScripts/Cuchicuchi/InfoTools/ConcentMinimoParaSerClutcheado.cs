using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200004C RID: 76
	public class ConcentMinimoParaSerClutcheado : ConcentMinimoParaToques
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600018D RID: 397 RVA: 0x0000DB64 File Offset: 0x0000BD64
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600018E RID: 398 RVA: 0x0000DB67 File Offset: 0x0000BD67
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[]
				{
					ParteQuePuedeEstimular.pene,
					ParteQuePuedeEstimular.propSexToy
				};
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600018F RID: 399 RVA: 0x0000DB78 File Offset: 0x0000BD78
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000190 RID: 400 RVA: 0x0000DB7B File Offset: 0x0000BD7B
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.tactil;
			}
		}
	}
}
