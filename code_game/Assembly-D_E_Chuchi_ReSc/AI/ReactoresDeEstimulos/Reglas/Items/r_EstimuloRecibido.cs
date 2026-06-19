using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003C2 RID: 962
	[Serializable]
	public sealed class r_EstimuloRecibido : ReglaItem
	{
		// Token: 0x060014D8 RID: 5336 RVA: 0x000591E0 File Offset: 0x000573E0
		public override bool Check(ICalculoDeEstimulo calculo)
		{
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			return calculoDeInteracionEstimulante == null || calculoDeInteracionEstimulante.estimuloBasico.tipo == DireccionDeEstimulo.recibida;
		}
	}
}
