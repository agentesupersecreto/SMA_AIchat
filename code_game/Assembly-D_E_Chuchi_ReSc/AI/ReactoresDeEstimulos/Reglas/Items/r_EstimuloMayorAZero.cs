using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003C1 RID: 961
	[Serializable]
	public sealed class r_EstimuloMayorAZero : ReglaItem
	{
		// Token: 0x060014D6 RID: 5334 RVA: 0x000591B8 File Offset: 0x000573B8
		public override bool Check(ICalculoDeEstimulo calculo)
		{
			ICalculoDeEstimuloConEstado calculoDeEstimuloConEstado = calculo as ICalculoDeEstimuloConEstado;
			return calculoDeEstimuloConEstado == null || calculoDeEstimuloConEstado.estimuloGeneradoEnFrame > 0f;
		}
	}
}
