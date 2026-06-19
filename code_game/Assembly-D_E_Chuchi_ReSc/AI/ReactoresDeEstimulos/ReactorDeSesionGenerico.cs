using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x020003A7 RID: 935
	public sealed class ReactorDeSesionGenerico : ReactorPadreSinLogicaACalculoDeEstimulo<ICalculoDeEstimulo>
	{
		// Token: 0x06001491 RID: 5265 RVA: 0x0005888E File Offset: 0x00056A8E
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.prioridad = ReactorSegundario.Prioridad.alta;
		}

		// Token: 0x06001492 RID: 5266 RVA: 0x000588A2 File Offset: 0x00056AA2
		protected override bool CalculoEsValido(ICalculoDeEstimulo calculo)
		{
			return calculo.tipo == TipoDeCalculoDeEstimulo.sesionComienza || calculo.tipo == TipoDeCalculoDeEstimulo.sesionEnCurso || calculo.tipo == TipoDeCalculoDeEstimulo.sesionTermina;
		}

		// Token: 0x06001493 RID: 5267 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return 1f;
		}
	}
}
