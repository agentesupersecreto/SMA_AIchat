using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x020003A6 RID: 934
	public sealed class ReactorDeFrameGenerico : ReactorPadreSinLogicaACalculoDeEstimulo<ICalculoDeEstimulo>
	{
		// Token: 0x0600148D RID: 5261 RVA: 0x00058867 File Offset: 0x00056A67
		protected sealed override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.prioridad = ReactorSegundario.Prioridad.baja;
		}

		// Token: 0x0600148E RID: 5262 RVA: 0x0005887B File Offset: 0x00056A7B
		protected sealed override bool CalculoEsValido(ICalculoDeEstimulo calculo)
		{
			return calculo.tipo == TipoDeCalculoDeEstimulo.frame;
		}

		// Token: 0x0600148F RID: 5263 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return 1f;
		}
	}
}
