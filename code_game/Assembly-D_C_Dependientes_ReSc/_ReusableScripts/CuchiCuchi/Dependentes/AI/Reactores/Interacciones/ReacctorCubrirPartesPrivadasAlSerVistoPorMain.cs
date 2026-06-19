using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Interacciones
{
	// Token: 0x02000316 RID: 790
	public sealed class ReacctorCubrirPartesPrivadasAlSerVistoPorMain : ReacctorDeInteraccionesPartesPrivadasConRopa<ICalculoDeEstimuloVisual>
	{
		// Token: 0x06001406 RID: 5126 RVA: 0x0005DB36 File Offset: 0x0005BD36
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
		}

		// Token: 0x06001407 RID: 5127 RVA: 0x0005D193 File Offset: 0x0005B393
		protected override float ModDeRequerimientoPorVestidura(int cantidadDePiezasCubriendo)
		{
			return 1f + 0.5f * (float)cantidadDePiezasCubriendo;
		}

		// Token: 0x06001408 RID: 5128 RVA: 0x0005DB6C File Offset: 0x0005BD6C
		protected override float ModDePudorPorVestidura(int cantidadDePiezasCubriendo)
		{
			float num = 1f;
			num += 0.5f * (float)cantidadDePiezasCubriendo;
			return 1f / num;
		}

		// Token: 0x06001409 RID: 5129 RVA: 0x0005DB91 File Offset: 0x0005BD91
		protected override void OnCalculoEnEnPartePrivada(ICalculoDeEstimuloVisual calculo)
		{
			base.OnCalculoEnEnPartePrivada(calculo);
			this.m_currentPersonalidadWeight = base.personalidadWeight;
		}

		// Token: 0x0600140A RID: 5130 RVA: 0x0005DBA6 File Offset: 0x0005BDA6
		protected override bool IncluirNalgas(ICalculoDeEstimuloVisual calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.95f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.5f;
		}

		// Token: 0x0600140B RID: 5131 RVA: 0x0005DBA6 File Offset: 0x0005BDA6
		protected override bool IncluirTetas(ICalculoDeEstimuloVisual calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.95f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.5f;
		}

		// Token: 0x0600140C RID: 5132 RVA: 0x0005DBE6 File Offset: 0x0005BDE6
		protected override bool IncluirVientre(ICalculoDeEstimuloVisual calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.99f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.55f;
		}

		// Token: 0x0600140D RID: 5133 RVA: 0x0005DC26 File Offset: 0x0005BE26
		protected override bool IncluirPezones(ICalculoDeEstimuloVisual calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.95f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.35f;
		}

		// Token: 0x0600140E RID: 5134 RVA: 0x0005DC66 File Offset: 0x0005BE66
		protected override bool IncluirAno(ICalculoDeEstimuloVisual calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.9f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.3f;
		}

		// Token: 0x0600140F RID: 5135 RVA: 0x0005DC26 File Offset: 0x0005BE26
		protected override bool IncluirVagina(ICalculoDeEstimuloVisual calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.95f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.35f;
		}

		// Token: 0x06001410 RID: 5136 RVA: 0x0005DCA8 File Offset: 0x0005BEA8
		protected override bool EstimuloEnPartesPrivadasEsValido(ICalculoDeEstimuloVisual calculo)
		{
			if (calculo.tipo != TipoDeCalculoDeEstimulo.sesionEnCurso)
			{
				return false;
			}
			if (calculo.estimuloBasico.tipo != DireccionDeEstimulo.recibida)
			{
				return false;
			}
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			return reaccion == ReaccionHumana.rabia || reaccion == ReaccionHumana.placer || reaccion == ReaccionHumana.miedo;
		}

		// Token: 0x06001411 RID: 5137 RVA: 0x0005DCF0 File Offset: 0x0005BEF0
		protected override float ObtenerModificadorDeCoolDown(ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloVisual>.Tipo tipo, ICalculoDeEstimuloVisual calculo)
		{
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			float num;
			if (reaccion != ReaccionHumana.rabia)
			{
				if (reaccion != ReaccionHumana.placer)
				{
					if (reaccion != ReaccionHumana.miedo)
					{
						throw new ArgumentOutOfRangeException(tipo.ToString());
					}
					num = 0.5f;
				}
				else
				{
					num = 20f;
				}
			}
			else
			{
				num = 1f;
				if (this.m_ConsentForzado.EsCorrupted(calculo))
				{
					num = 10f;
				}
			}
			num *= base.pudorInvertMod * this.m_currentModDePudorPorVestiduraInvertido;
			switch (tipo)
			{
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloVisual>.Tipo.nalgas:
				return 2f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloVisual>.Tipo.ano:
				return 1f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloVisual>.Tipo.vientre:
				return 2f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloVisual>.Tipo.vagina:
				return 1f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloVisual>.Tipo.tetas:
				return 2f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloVisual>.Tipo.pezones:
				return 1f * num;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06001412 RID: 5138 RVA: 0x0005DDD0 File Offset: 0x0005BFD0
		protected override float ObtenerModificadorDeProbabilidad(ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloVisual>.Tipo tipo, ICalculoDeEstimuloVisual calculo)
		{
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			float num;
			if (reaccion != ReaccionHumana.rabia)
			{
				if (reaccion != ReaccionHumana.placer)
				{
					if (reaccion != ReaccionHumana.miedo)
					{
						throw new ArgumentOutOfRangeException(tipo.ToString());
					}
					num = 2f;
				}
				else
				{
					num = 0.025f;
				}
			}
			else
			{
				num = 1f;
				if (this.m_ConsentForzado.EsCorrupted(calculo))
				{
					num = 0.05f;
				}
			}
			num *= base.pudorMod * this.m_currentModDePudorPorVestidura;
			switch (tipo)
			{
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloVisual>.Tipo.nalgas:
				return 0.5f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloVisual>.Tipo.ano:
				return 1f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloVisual>.Tipo.vientre:
				return 0.5f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloVisual>.Tipo.vagina:
				return 1f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloVisual>.Tipo.tetas:
				return 0.5f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloVisual>.Tipo.pezones:
				return 1f * num;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06001413 RID: 5139 RVA: 0x0005DEB0 File Offset: 0x0005C0B0
		protected override bool ReaccionarAEstimuloEnPartesPrivadas(ICalculoDeEstimuloVisual calculo)
		{
			float num = (this.baseConfig.coolDownGeneral * 3f * base.pudorMod).Random(0.5f);
			int num2 = ReactorSegundario.PrioridadParcer(calculo, 1.0) / 2;
			Interaccion interaccion;
			if (base.YaSeEstaTapando(this.m_Tipo, out interaccion))
			{
				return interaccion.Ejecutar(num2, num, ControllerPrioridadConfig.prioridad, 1f, 1f, false);
			}
			Side side;
			FullBodyBipedEffector fullBodyBipedEffector;
			Interaccion interaccion2;
			return this.m_InteractionEffectorController.TryGetFreeNotLockedHand(out side, out fullBodyBipedEffector) && (base.TryObtenerParaUsar(this.m_Tipo, side, out interaccion2) && interaccion2 != null && interaccion2.Ejecutar(num2, num, ControllerPrioridadConfig.prioridad, 1f, 1f, false));
		}

		// Token: 0x04000E6A RID: 3690
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentPersonalidadWeight;

		// Token: 0x04000E6B RID: 3691
		private ConsentCorrupted m_ConsentForzado;
	}
}
