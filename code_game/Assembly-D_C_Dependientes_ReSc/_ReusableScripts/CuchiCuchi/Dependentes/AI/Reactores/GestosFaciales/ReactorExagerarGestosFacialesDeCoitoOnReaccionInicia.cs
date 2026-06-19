using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.ConExpresiones;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.GestosFaciales
{
	// Token: 0x0200031C RID: 796
	public sealed class ReactorExagerarGestosFacialesDeCoitoOnReaccionInicia : ReactorExpresionBase<ICalculoDeEstimuloTactil>
	{
		// Token: 0x06001432 RID: 5170 RVA: 0x0005E9C8 File Offset: 0x0005CBC8
		protected sealed override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.coolDownGeneral = 20f;
			this.baseConfig.probabilidadPorSegundo = 100f;
			this.baseConfig.prioridad = ReactorSegundario.Prioridad.alta;
			this.baseConfig.probabilidadEsSoloUnoFrame = true;
		}

		// Token: 0x06001433 RID: 5171 RVA: 0x0005EA08 File Offset: 0x0005CC08
		protected override bool CalculoEsValido(ICalculoDeEstimuloTactil calculo)
		{
			return calculo.tipo == TipoDeCalculoDeEstimulo.sesionComienza;
		}

		// Token: 0x06001434 RID: 5172 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			return 1f;
		}

		// Token: 0x06001435 RID: 5173 RVA: 0x0005EA13 File Offset: 0x0005CC13
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			return this.m_Personalidad.GetModPorTraitHumano(TraitHumano.muecas, 1f, 0.25f, 1f);
		}

		// Token: 0x06001436 RID: 5174 RVA: 0x0005EA34 File Offset: 0x0005CC34
		protected override bool ReaccionarCalculoBlokeandoParaReactor(ICalculoDeEstimuloTactil calculo, out float blokearTiempo)
		{
			float num = (blokearTiempo = (this.configuracion.tiempoPromedioExagerando * base.GetModPorExpresividad(1f, 1f, 0.25f)).Random(0.25f));
			this.m_ControlladorDeGestosFaciales.TryExagerarYSuprimirOtros(calculo.emocion.reaccion, num, 1f, 0.88f, 0.666f, null);
			return true;
		}

		// Token: 0x04000E81 RID: 3713
		public ReactorExagerarGestosFacialesDeCoitoOnReaccionInicia.Configuracion configuracion = new ReactorExagerarGestosFacialesDeCoitoOnReaccionInicia.Configuracion();

		// Token: 0x0200031D RID: 797
		[Serializable]
		public class Configuracion
		{
			// Token: 0x04000E82 RID: 3714
			public float tiempoPromedioExagerando = 5f;
		}
	}
}
