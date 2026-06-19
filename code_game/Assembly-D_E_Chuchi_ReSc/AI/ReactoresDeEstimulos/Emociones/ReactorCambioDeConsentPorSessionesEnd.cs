using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.Cambiadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Personalidades.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos.Emociones
{
	// Token: 0x020003CC RID: 972
	public class ReactorCambioDeConsentPorSessionesEnd : ReactorACalculoDeEstimulo<ICalculoDeInteracionEstimulanteConEstado>
	{
		// Token: 0x060014F4 RID: 5364 RVA: 0x00059594 File Offset: 0x00057794
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_ConsentToHero = this.GetComponentEnRoot(false);
			if (this.m_ConsentToHero == null)
			{
				throw new ArgumentNullException("m_ConsentToHero", "m_ConsentToHero null reference.");
			}
			this.m_Personalidad = this.GetComponentEnRoot(false);
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			this.m_ConsentNecesario = this.GetComponentEnRoot(false);
			if (this.m_ConsentNecesario == null)
			{
				throw new ArgumentNullException("m_ConsentNecesario", "m_ConsentNecesario null reference.");
			}
			this.m_ConsentPorInteraciones = this.GetComponentEnRoot(false);
			if (this.m_ConsentPorInteraciones == null)
			{
				throw new ArgumentNullException("m_ConsentPorInteraciones", "m_ConsentPorInteraciones null reference.");
			}
		}

		// Token: 0x060014F5 RID: 5365 RVA: 0x00059654 File Offset: 0x00057854
		protected override bool CalculoEsValido(ICalculoDeInteracionEstimulanteConEstado calculo)
		{
			if (calculo.tipo != TipoDeCalculoDeEstimulo.sesionTermina)
			{
				return false;
			}
			if (calculo.estimuloBasico.tipo != DireccionDeEstimulo.recibida)
			{
				return false;
			}
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			if (reaccion != ReaccionHumana.rabia && reaccion != ReaccionHumana.placer)
			{
				return false;
			}
			switch (calculo.estimuloBasico.tipoDeEstimulo)
			{
			case TipoDeEstimulo.tactil:
			case TipoDeEstimulo.visual:
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
			case TipoDeEstimulo.manipulandoBone:
			{
				if (calculo.estimuloBasico.tipoDeEstimulo == TipoDeEstimulo.visual && calculo.emocion.reaccion == ReaccionHumana.rabia)
				{
					return false;
				}
				ICalculoDeInteracionEstimulanteDeParteEstimulante calculoDeInteracionEstimulanteDeParteEstimulante = calculo as ICalculoDeInteracionEstimulanteDeParteEstimulante;
				if (calculoDeInteracionEstimulanteDeParteEstimulante == null)
				{
					return false;
				}
				float num;
				this.m_ConsentNecesario.EsConsentidoMaximoConJerarquia(calculoDeInteracionEstimulanteDeParteEstimulante, out num, null, null);
				return num >= 0.75f;
			}
			default:
				return false;
			}
		}

		// Token: 0x060014F6 RID: 5366 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float CoolDownModificadorParaCalculo(ICalculoDeInteracionEstimulanteConEstado calculo)
		{
			return 1f;
		}

		// Token: 0x060014F7 RID: 5367 RVA: 0x00030684 File Offset: 0x0002E884
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeInteracionEstimulanteConEstado calculo)
		{
			return 1f;
		}

		// Token: 0x060014F8 RID: 5368 RVA: 0x00059734 File Offset: 0x00057934
		protected override bool ReaccionarCalculo(ICalculoDeInteracionEstimulanteConEstado calculo)
		{
			if (this.m_ConsentPorInteraciones.alMaximo || this.m_ConsentToHero.valueAtMax)
			{
				return false;
			}
			MapaDePersonalidad personalidad = this.m_Personalidad.currentPersonalidad.personalidad;
			if (personalidad == null)
			{
				return false;
			}
			UmbralBasico.Estado estado;
			ReactorSegundario.GetEstadoConMasEstimuloTotal(calculo, out estado);
			if (estado.postModificador <= 0f)
			{
				return false;
			}
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			float num;
			if (reaccion != ReaccionHumana.rabia)
			{
				if (reaccion != ReaccionHumana.placer)
				{
					throw new ArgumentOutOfRangeException();
				}
				num = this.m_aumentoPorPlacerMod;
			}
			else
			{
				num = -this.m_disminucionPorRageMod;
			}
			float num2;
			switch (calculo.estimuloBasico.tipoDeEstimulo)
			{
			case TipoDeEstimulo.tactil:
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.manipulandoBone:
				num2 = personalidad.consentPorSessiones.tactilMod;
				goto IL_0107;
			case TipoDeEstimulo.visual:
				num2 = personalidad.consentPorSessiones.visualMod;
				goto IL_0107;
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
				num2 = personalidad.consentPorSessiones.coitalMod;
				goto IL_0107;
			}
			throw new ArgumentOutOfRangeException();
			IL_0107:
			float num3 = estado.estimulacionGeneradaTotal * estado.postModificador * num * num2;
			this.m_ConsentPorInteraciones.Cambiar(num3, calculo as ICalculoDeEstimuloCompleto);
			return true;
		}

		// Token: 0x040010FF RID: 4351
		[SerializeField]
		private float m_disminucionPorRageMod = 1f;

		// Token: 0x04001100 RID: 4352
		[SerializeField]
		private float m_aumentoPorPlacerMod = 1f;

		// Token: 0x04001101 RID: 4353
		private ConsentNecesario m_ConsentNecesario;

		// Token: 0x04001102 RID: 4354
		private ConsentToHero m_ConsentToHero;

		// Token: 0x04001103 RID: 4355
		private Personalidad m_Personalidad;

		// Token: 0x04001104 RID: 4356
		private ConsentPorInteraciones m_ConsentPorInteraciones;
	}
}
