using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Interacciones
{
	// Token: 0x02000314 RID: 788
	public sealed class ReacctorCubrirPartesPrivadasAlSerDesvestido : ReacctorDeInteraccionesPartesPrivadasConRopa<ICalculoDeEstimuloPorDesvestir>
	{
		// Token: 0x060013E8 RID: 5096 RVA: 0x0005D160 File Offset: 0x0005B360
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
		}

		// Token: 0x060013E9 RID: 5097 RVA: 0x0005D193 File Offset: 0x0005B393
		protected override float ModDeRequerimientoPorVestidura(int cantidadDePiezasCubriendo)
		{
			return 1f + 0.5f * (float)cantidadDePiezasCubriendo;
		}

		// Token: 0x060013EA RID: 5098 RVA: 0x0005D1A4 File Offset: 0x0005B3A4
		protected override float ModDePudorPorVestidura(int cantidadDePiezasCubriendo)
		{
			float num = 1f;
			num += 0.5f * (float)cantidadDePiezasCubriendo;
			return 1f / num;
		}

		// Token: 0x060013EB RID: 5099 RVA: 0x0005D1C9 File Offset: 0x0005B3C9
		protected override void OnCalculoEnEnPartePrivada(ICalculoDeEstimuloPorDesvestir calculo)
		{
			base.OnCalculoEnEnPartePrivada(calculo);
			this.m_currentPersonalidadWeight = base.personalidadWeight;
		}

		// Token: 0x060013EC RID: 5100 RVA: 0x0005D1DE File Offset: 0x0005B3DE
		protected override bool IncluirNalgas(ICalculoDeEstimuloPorDesvestir calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.6f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.2f;
		}

		// Token: 0x060013ED RID: 5101 RVA: 0x0005D1DE File Offset: 0x0005B3DE
		protected override bool IncluirTetas(ICalculoDeEstimuloPorDesvestir calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.6f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.2f;
		}

		// Token: 0x060013EE RID: 5102 RVA: 0x0005D21E File Offset: 0x0005B41E
		protected override bool IncluirVientre(ICalculoDeEstimuloPorDesvestir calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.75f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.25f;
		}

		// Token: 0x060013EF RID: 5103 RVA: 0x0005D25E File Offset: 0x0005B45E
		protected override bool IncluirPezones(ICalculoDeEstimuloPorDesvestir calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.45f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.15f;
		}

		// Token: 0x060013F0 RID: 5104 RVA: 0x0005D29E File Offset: 0x0005B49E
		protected override bool IncluirAno(ICalculoDeEstimuloPorDesvestir calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.3f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.1f;
		}

		// Token: 0x060013F1 RID: 5105 RVA: 0x0005D25E File Offset: 0x0005B45E
		protected override bool IncluirVagina(ICalculoDeEstimuloPorDesvestir calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.45f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.15f;
		}

		// Token: 0x060013F2 RID: 5106 RVA: 0x0005D2E0 File Offset: 0x0005B4E0
		protected override bool EstimuloEnPartesPrivadasEsValido(ICalculoDeEstimuloPorDesvestir calculo)
		{
			bool parcial = calculo.estimulo.parcial;
			if (parcial && !this.m_desvestiduraParcialEsValida)
			{
				return false;
			}
			if (!parcial && !this.m_desvestiduraCompletaEsValida)
			{
				return false;
			}
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			return reaccion == ReaccionHumana.rabia || reaccion == ReaccionHumana.placer || reaccion == ReaccionHumana.miedo;
		}

		// Token: 0x060013F3 RID: 5107 RVA: 0x0005D334 File Offset: 0x0005B534
		protected override float ObtenerModificadorDeCoolDown(ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloPorDesvestir>.Tipo tipo, ICalculoDeEstimuloPorDesvestir calculo)
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
					num = 3f;
				}
			}
			num *= base.pudorInvertMod * this.m_currentModDePudorPorVestiduraInvertido / 8f;
			switch (tipo)
			{
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloPorDesvestir>.Tipo.nalgas:
				return 2f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloPorDesvestir>.Tipo.ano:
				return 1f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloPorDesvestir>.Tipo.vientre:
				return 2f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloPorDesvestir>.Tipo.vagina:
				return 1f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloPorDesvestir>.Tipo.tetas:
				return 2f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloPorDesvestir>.Tipo.pezones:
				return 1f * num;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x060013F4 RID: 5108 RVA: 0x0005D418 File Offset: 0x0005B618
		protected override float ObtenerModificadorDeProbabilidad(ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloPorDesvestir>.Tipo tipo, ICalculoDeEstimuloPorDesvestir calculo)
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
					num = 0.33333334f;
				}
			}
			num *= base.pudorMod * this.m_currentModDePudorPorVestidura * 8f;
			switch (tipo)
			{
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloPorDesvestir>.Tipo.nalgas:
				return 0.5f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloPorDesvestir>.Tipo.ano:
				return 1f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloPorDesvestir>.Tipo.vientre:
				return 0.5f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloPorDesvestir>.Tipo.vagina:
				return 1f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloPorDesvestir>.Tipo.tetas:
				return 0.5f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloPorDesvestir>.Tipo.pezones:
				return 1f * num;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x060013F5 RID: 5109 RVA: 0x0005D4FC File Offset: 0x0005B6FC
		protected override bool ReaccionarAEstimuloEnPartesPrivadas(ICalculoDeEstimuloPorDesvestir calculo)
		{
			float num = (this.baseConfig.coolDownGeneral * 10f * base.pudorMod).Random(0.5f);
			if (!calculo.estimulo.parcial)
			{
				num *= 5f;
			}
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

		// Token: 0x04000E64 RID: 3684
		[Header("Al Ser Desvestido Config")]
		[SerializeField]
		private bool m_desvestiduraParcialEsValida = true;

		// Token: 0x04000E65 RID: 3685
		[SerializeField]
		private bool m_desvestiduraCompletaEsValida = true;

		// Token: 0x04000E66 RID: 3686
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentPersonalidadWeight;

		// Token: 0x04000E67 RID: 3687
		private ConsentCorrupted m_ConsentForzado;
	}
}
