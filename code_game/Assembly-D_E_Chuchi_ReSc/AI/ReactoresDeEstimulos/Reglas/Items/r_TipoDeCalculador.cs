using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003C4 RID: 964
	[Serializable]
	public sealed class r_TipoDeCalculador : ReglaItem
	{
		// Token: 0x060014DC RID: 5340 RVA: 0x00059264 File Offset: 0x00057464
		public override bool Check(ICalculoDeEstimulo calculo)
		{
			if (calculo.producidoPor == null)
			{
				return false;
			}
			int tipo = (int)calculo.producidoPor.tipo;
			return ((int)this.paraTiposDeCalculo).HasFlag(tipo);
		}

		// Token: 0x040010F3 RID: 4339
		public TipoDeCalculadorDeEstimulo paraTiposDeCalculo = (TipoDeCalculadorDeEstimulo)(-1);
	}
}
