using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.GestosFaciales
{
	// Token: 0x02000320 RID: 800
	public sealed class ReactorExagerarGestosFacialesOnGolpe : ReactorGestosFacialesBase<ICalculoDeEstimulo>
	{
		// Token: 0x06001440 RID: 5184 RVA: 0x0005EBBD File Offset: 0x0005CDBD
		protected sealed override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.coolDownGeneral = 0.1f;
			this.baseConfig.probabilidadPorSegundo = 100f;
			this.baseConfig.prioridad = ReactorSegundario.Prioridad.extraAlta;
		}

		// Token: 0x06001441 RID: 5185 RVA: 0x0005C547 File Offset: 0x0005A747
		protected override bool CalculoEsValido(ICalculoDeEstimulo calculo)
		{
			return calculo.tipo == TipoDeCalculoDeEstimulo.frame && calculo.tag == "golpe";
		}

		// Token: 0x06001442 RID: 5186 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return 1f;
		}

		// Token: 0x06001443 RID: 5187 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return 1f;
		}

		// Token: 0x06001444 RID: 5188 RVA: 0x0005EBF4 File Offset: 0x0005CDF4
		protected override bool ReaccionarCalculoBlokeandoParaReactor(ICalculoDeEstimulo calculo, out float blokearTiempo)
		{
			float num = (blokearTiempo = (this.configuracion.tiempoPromedioExagerando * base.duracionModPorExpresividad).Random(0.5f));
			this.dependencias.controller.ExagerarPor(num);
			return true;
		}

		// Token: 0x04000E85 RID: 3717
		public ReactorExagerarGestosFacialesOnGolpe.Configuracion configuracion = new ReactorExagerarGestosFacialesOnGolpe.Configuracion();

		// Token: 0x02000321 RID: 801
		[Serializable]
		public class Configuracion
		{
			// Token: 0x04000E86 RID: 3718
			public float tiempoPromedioExagerando = 2f;
		}
	}
}
