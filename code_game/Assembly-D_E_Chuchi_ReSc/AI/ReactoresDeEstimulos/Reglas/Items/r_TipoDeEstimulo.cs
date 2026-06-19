using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Reglas.Items
{
	// Token: 0x020003C6 RID: 966
	[Serializable]
	public sealed class r_TipoDeEstimulo : ReglaItem
	{
		// Token: 0x060014E0 RID: 5344 RVA: 0x000592D4 File Offset: 0x000574D4
		public override bool Check(ICalculoDeEstimulo calculo)
		{
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			if (calculoDeInteracionEstimulante == null)
			{
				return true;
			}
			int num = (int)calculoDeInteracionEstimulante.estimuloBasico.tipoDeEstimulo.ParceAFlags();
			return ((int)this.paraTipoDeEstimulo).HasFlag(num);
		}

		// Token: 0x040010F5 RID: 4341
		public TipoDeEstimuloFlags paraTipoDeEstimulo = (TipoDeEstimuloFlags)(-1);
	}
}
