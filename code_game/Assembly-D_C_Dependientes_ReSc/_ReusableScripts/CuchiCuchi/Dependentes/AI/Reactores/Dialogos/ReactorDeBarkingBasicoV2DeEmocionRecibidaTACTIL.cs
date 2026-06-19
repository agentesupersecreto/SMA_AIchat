using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos
{
	// Token: 0x02000338 RID: 824
	public class ReactorDeBarkingBasicoV2DeEmocionRecibidaTACTIL : ReactorDeBarkingBasicoV2DeEmocionRecibida
	{
		// Token: 0x060014B6 RID: 5302 RVA: 0x00062AD0 File Offset: 0x00060CD0
		protected override bool EsCalculoEsValido(ICalculoDeInteracionEstimulante calculo)
		{
			if (calculo.estimuloBasico.tipoDeEstimulo != TipoDeEstimulo.tactil)
			{
				return false;
			}
			EstimuloTactil estimuloTactil = calculo.estimuloBasico as EstimuloTactil;
			return estimuloTactil != null && estimuloTactil.tipoDeEstimuloTactil == this.paraTipoDeEstimuloTactil && base.EsCalculoEsValido(calculo);
		}

		// Token: 0x04000ECF RID: 3791
		public TipoDeEstimuloTactil paraTipoDeEstimuloTactil;
	}
}
