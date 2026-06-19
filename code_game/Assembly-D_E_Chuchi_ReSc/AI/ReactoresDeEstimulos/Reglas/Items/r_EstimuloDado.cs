using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003C0 RID: 960
	[Serializable]
	public sealed class r_EstimuloDado : ReglaItem
	{
		// Token: 0x060014D4 RID: 5332 RVA: 0x00059190 File Offset: 0x00057390
		public override bool Check(ICalculoDeEstimulo calculo)
		{
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			return calculoDeInteracionEstimulante == null || calculoDeInteracionEstimulante.estimuloBasico.tipo == DireccionDeEstimulo.dada;
		}
	}
}
