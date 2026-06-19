using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.OjosExpresion
{
	// Token: 0x0200030C RID: 780
	public sealed class ReactorCerrarOjosOnGolpe : ReacctorConExpresionDeOjos<ICalculoDeEstimulo>
	{
		// Token: 0x060013B2 RID: 5042 RVA: 0x0005C513 File Offset: 0x0005A713
		protected sealed override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.coolDownGeneral = 0.1f;
			this.baseConfig.probabilidadPorSegundo = 100f;
			this.baseConfig.prioridad = ReactorSegundario.Prioridad.extraAlta;
		}

		// Token: 0x060013B3 RID: 5043 RVA: 0x0005C547 File Offset: 0x0005A747
		protected sealed override bool CalculoEsValido(ICalculoDeEstimulo calculo)
		{
			return calculo.tipo == TipoDeCalculoDeEstimulo.frame && calculo.tag == "golpe";
		}

		// Token: 0x060013B4 RID: 5044 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected sealed override float CoolDownModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return 1f;
		}

		// Token: 0x060013B5 RID: 5045 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return 1f;
		}

		// Token: 0x060013B6 RID: 5046 RVA: 0x0005C564 File Offset: 0x0005A764
		protected override bool ReaccionarCalculoBlokeandoParaReactor(ICalculoDeEstimulo calculo, out float blokearTiempo)
		{
			float num = 100f.Random(0.6f);
			float num2 = (blokearTiempo = this.configuracion.tiempoPromedioCerrados.Random(0.75f));
			num2 *= Mathf.InverseLerp(0f, 100f, num).InPow(5f);
			return this.m_OjosExpresionController.Cambiar(OjosExpresionController.Tipo.cerrar, int.MaxValue, num2, ControllerPrioridadConfig.prioridad, num, this.configuracion.tiempoModIn, this.configuracion.tiempoModOut);
		}

		// Token: 0x04000E3E RID: 3646
		public ReactorCerrarOjosOnGolpe.Configuracion configuracion = new ReactorCerrarOjosOnGolpe.Configuracion();

		// Token: 0x0200030D RID: 781
		[Serializable]
		public class Configuracion
		{
			// Token: 0x04000E3F RID: 3647
			public float tiempoPromedioCerrados = 0.7f;

			// Token: 0x04000E40 RID: 3648
			public float tiempoModIn = 0.75f;

			// Token: 0x04000E41 RID: 3649
			public float tiempoModOut = 2f;
		}
	}
}
