using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x0200004B RID: 75
	public class ConcentMinimoParaSerBesado : ConcentMinimoParaToques
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000188 RID: 392 RVA: 0x0000DB43 File Offset: 0x0000BD43
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000189 RID: 393 RVA: 0x0000DB46 File Offset: 0x0000BD46
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.boca };
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600018A RID: 394 RVA: 0x0000DB56 File Offset: 0x0000BD56
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600018B RID: 395 RVA: 0x0000DB59 File Offset: 0x0000BD59
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.tactil;
			}
		}
	}
}
