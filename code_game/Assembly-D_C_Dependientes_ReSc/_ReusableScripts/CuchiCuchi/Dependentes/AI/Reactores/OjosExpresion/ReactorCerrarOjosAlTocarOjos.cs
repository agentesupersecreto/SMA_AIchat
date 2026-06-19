using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.OjosExpresion
{
	// Token: 0x0200030A RID: 778
	public sealed class ReactorCerrarOjosAlTocarOjos : ReacctorConExpresionDeOjos<ICalculoDeEstimuloTactil>
	{
		// Token: 0x060013AB RID: 5035 RVA: 0x0005C2E4 File Offset: 0x0005A4E4
		protected sealed override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.coolDownGeneral = 0.1f;
			this.baseConfig.probabilidadPorSegundo = 100f;
			this.baseConfig.prioridad = ReactorSegundario.Prioridad.alta;
		}

		// Token: 0x060013AC RID: 5036 RVA: 0x0005C318 File Offset: 0x0005A518
		protected override bool CalculoEsValido(ICalculoDeEstimuloTactil calculo)
		{
			return calculo.tipo == TipoDeCalculoDeEstimulo.frame && (ReactorSegundario.PartePrincipalEstimulada(calculo, false) == ParteDelCuerpoHumano.globosOculares || calculo.estimulo.ContineParte(ParteDelCuerpoHumano.globosOculares) || (calculo.estimulanteParte == ParteQuePuedeEstimular.semen && calculo.estimulo.ContineAlgunaDeEstasPartes(ParteDelCuerpoHumanoHelper.partesDeInteraccionRostro)));
		}

		// Token: 0x060013AD RID: 5037 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			return 1f;
		}

		// Token: 0x060013AE RID: 5038 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			return 1f;
		}

		// Token: 0x060013AF RID: 5039 RVA: 0x0005C370 File Offset: 0x0005A570
		protected override bool ReaccionarCalculoBlokeandoParaReactor(ICalculoDeEstimuloTactil calculo, out float blokearTiempo)
		{
			float num = 100f;
			float num2 = (blokearTiempo = this.configuracion.tiempoPromedioCerrados.Random(0.55f));
			switch (calculo.estimulo.side)
			{
			case Side.none:
			case Side.F:
			case Side.B:
				return this.m_OjosExpresionController.Cambiar(OjosExpresionController.Tipo.cerrar, 2147483646, num2, ControllerPrioridadConfig.prioridad, num, this.configuracion.tiempoModIn, this.configuracion.tiempoModOut);
			case Side.L:
				this.m_OjosExpresionController.Cambiar(OjosExpresionController.Tipo.guiñarR, 0, num2, ControllerPrioridadConfig.baja, (num * 0.333f).Random(0.333f), this.configuracion.tiempoModIn, this.configuracion.tiempoModOut);
				return this.m_OjosExpresionController.Cambiar(OjosExpresionController.Tipo.guiñarL, 2147483646, num2, ControllerPrioridadConfig.prioridad, num, this.configuracion.tiempoModIn, this.configuracion.tiempoModOut);
			case Side.R:
				this.m_OjosExpresionController.Cambiar(OjosExpresionController.Tipo.guiñarL, 0, num2, ControllerPrioridadConfig.baja, (num * 0.333f).Random(0.333f), this.configuracion.tiempoModIn, this.configuracion.tiempoModOut);
				return this.m_OjosExpresionController.Cambiar(OjosExpresionController.Tipo.guiñarR, 2147483646, num2, ControllerPrioridadConfig.prioridad, num, this.configuracion.tiempoModIn, this.configuracion.tiempoModOut);
			default:
				throw new ArgumentOutOfRangeException(calculo.estimulo.side.ToString());
			}
		}

		// Token: 0x04000E3A RID: 3642
		public ReactorCerrarOjosAlTocarOjos.Configuracion configuracion = new ReactorCerrarOjosAlTocarOjos.Configuracion();

		// Token: 0x0200030B RID: 779
		[Serializable]
		public class Configuracion
		{
			// Token: 0x04000E3B RID: 3643
			public float tiempoPromedioCerrados = 1.1f;

			// Token: 0x04000E3C RID: 3644
			public float tiempoModIn = 0.75f;

			// Token: 0x04000E3D RID: 3645
			public float tiempoModOut = 3f;
		}
	}
}
