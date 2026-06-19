using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x020003A8 RID: 936
	public class ReactorGenerico : ReactorPadreSinLogicaACalculoDeEstimulo<ICalculoDeEstimulo>
	{
		// Token: 0x06001495 RID: 5269 RVA: 0x000588C1 File Offset: 0x00056AC1
		protected sealed override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.prioridad = ReactorSegundario.Prioridad.normal;
		}

		// Token: 0x06001496 RID: 5270 RVA: 0x000588D5 File Offset: 0x00056AD5
		protected sealed override bool CalculoEsValido(ICalculoDeEstimulo calculo)
		{
			return calculo.tipo > TipoDeCalculoDeEstimulo.None;
		}

		// Token: 0x06001497 RID: 5271 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return 1f;
		}
	}
}
