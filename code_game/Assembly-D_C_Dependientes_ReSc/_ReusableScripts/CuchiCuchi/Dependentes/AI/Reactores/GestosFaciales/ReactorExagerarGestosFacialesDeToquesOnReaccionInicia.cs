using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.ConExpresiones;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.GestosFaciales
{
	// Token: 0x0200031E RID: 798
	public sealed class ReactorExagerarGestosFacialesDeToquesOnReaccionInicia : ReactorExpresionBase<ICalculoDeEstimuloTactil>
	{
		// Token: 0x06001439 RID: 5177 RVA: 0x0005EAC9 File Offset: 0x0005CCC9
		protected sealed override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.coolDownGeneral = 20f;
			this.baseConfig.probabilidadPorSegundo = 100f;
			this.baseConfig.prioridad = ReactorSegundario.Prioridad.normal;
			this.baseConfig.probabilidadEsSoloUnoFrame = true;
		}

		// Token: 0x0600143A RID: 5178 RVA: 0x0005EA08 File Offset: 0x0005CC08
		protected override bool CalculoEsValido(ICalculoDeEstimuloTactil calculo)
		{
			return calculo.tipo == TipoDeCalculoDeEstimulo.sesionComienza;
		}

		// Token: 0x0600143B RID: 5179 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			return 1f;
		}

		// Token: 0x0600143C RID: 5180 RVA: 0x0005EB09 File Offset: 0x0005CD09
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			return this.m_Personalidad.GetModPorTraitHumano(TraitHumano.muecas, 1f, 0.2f, 1f);
		}

		// Token: 0x0600143D RID: 5181 RVA: 0x0005EB28 File Offset: 0x0005CD28
		protected override bool ReaccionarCalculoBlokeandoParaReactor(ICalculoDeEstimuloTactil calculo, out float blokearTiempo)
		{
			float num = (blokearTiempo = (this.configuracion.tiempoPromedioExagerando * base.GetModPorExpresividad(1f, 1f, 0.25f)).Random(0.25f));
			this.m_ControlladorDeGestosFaciales.TryExagerarYSuprimirOtros(calculo.emocion.reaccion, num, 1f, 0.666f, 0.333f, null);
			return true;
		}

		// Token: 0x04000E83 RID: 3715
		public ReactorExagerarGestosFacialesDeToquesOnReaccionInicia.Configuracion configuracion = new ReactorExagerarGestosFacialesDeToquesOnReaccionInicia.Configuracion();

		// Token: 0x0200031F RID: 799
		[Serializable]
		public class Configuracion
		{
			// Token: 0x04000E84 RID: 3716
			public float tiempoPromedioExagerando = 3f;
		}
	}
}
