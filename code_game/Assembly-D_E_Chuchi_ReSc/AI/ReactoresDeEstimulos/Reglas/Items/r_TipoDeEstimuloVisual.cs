using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003C7 RID: 967
	[Serializable]
	public class r_TipoDeEstimuloVisual : ReglaItem
	{
		// Token: 0x060014E2 RID: 5346 RVA: 0x0005931C File Offset: 0x0005751C
		public override bool Check(ICalculoDeEstimulo calculo)
		{
			ICalculoDeEstimuloVisual calculoDeEstimuloVisual = calculo as ICalculoDeEstimuloVisual;
			return calculoDeEstimuloVisual != null && this.paraTipoDeEstimuloVisual == calculoDeEstimuloVisual.estimulo.tipoDeEstimuloVisual;
		}

		// Token: 0x040010F6 RID: 4342
		public TipoDeEstimuloVisual paraTipoDeEstimuloVisual;
	}
}
