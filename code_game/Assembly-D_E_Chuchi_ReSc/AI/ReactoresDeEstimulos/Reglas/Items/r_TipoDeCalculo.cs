using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003C5 RID: 965
	[Serializable]
	public sealed class r_TipoDeCalculo : ReglaItem
	{
		// Token: 0x060014DE RID: 5342 RVA: 0x000592A4 File Offset: 0x000574A4
		public override bool Check(ICalculoDeEstimulo calculo)
		{
			int tipo = (int)calculo.tipo;
			return ((int)this.paraTipoDeCalculo).HasFlag(tipo);
		}

		// Token: 0x040010F4 RID: 4340
		public TipoDeCalculoDeEstimulo paraTipoDeCalculo = (TipoDeCalculoDeEstimulo)(-1);
	}
}
