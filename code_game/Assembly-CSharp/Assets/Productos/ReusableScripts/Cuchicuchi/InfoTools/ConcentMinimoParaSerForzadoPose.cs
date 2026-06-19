using System;
using System.Collections.Generic;
using Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets.Productos.ReusableScripts.Cuchicuchi.InfoTools
{
	// Token: 0x02000050 RID: 80
	public class ConcentMinimoParaSerForzadoPose : ConcentMinimoPara
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x0000DBE9 File Offset: 0x0000BDE9
		protected override DireccionDeEstimulo direccion
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x0000DBEC File Offset: 0x0000BDEC
		protected override IEnumerable<ParteQuePuedeEstimular> estimulamtes
		{
			get
			{
				return new ParteQuePuedeEstimular[] { ParteQuePuedeEstimular.manos };
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x0000DBF8 File Offset: 0x0000BDF8
		protected override string estimuloTag
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x0000DBFB File Offset: 0x0000BDFB
		protected override TipoDeEstimulo tipo
		{
			get
			{
				return TipoDeEstimulo.ejecucionDePose;
			}
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000DBFF File Offset: 0x0000BDFF
		protected override bool Ignorando(ParteDelCuerpoHumano estimulada)
		{
			return false;
		}
	}
}
