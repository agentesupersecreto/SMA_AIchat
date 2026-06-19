using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Interacciones
{
	// Token: 0x02000315 RID: 789
	public sealed class ReacctorCubrirPartesPrivadasAlSerTocado : ReacctorDeInteraccionesPartesPrivadasConRopa<ICalculoDeEstimuloTactil>
	{
		// Token: 0x060013F7 RID: 5111 RVA: 0x0005D5DB File Offset: 0x0005B7DB
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
		}

		// Token: 0x060013F8 RID: 5112 RVA: 0x0005D60E File Offset: 0x0005B80E
		protected override float ModDeRequerimientoPorVestidura(int cantidadDePiezasCubriendo)
		{
			return 1f + 0.05f * (float)cantidadDePiezasCubriendo;
		}

		// Token: 0x060013F9 RID: 5113 RVA: 0x0005D620 File Offset: 0x0005B820
		protected override float ModDePudorPorVestidura(int cantidadDePiezasCubriendo)
		{
			float num = 1f;
			num += 0.05f * (float)cantidadDePiezasCubriendo;
			return 1f / num;
		}

		// Token: 0x060013FA RID: 5114 RVA: 0x0005D645 File Offset: 0x0005B845
		protected override void OnCalculoEnEnPartePrivada(ICalculoDeEstimuloTactil calculo)
		{
			base.OnCalculoEnEnPartePrivada(calculo);
			this.m_currentPersonalidadWeight = base.personalidadWeight;
		}

		// Token: 0x060013FB RID: 5115 RVA: 0x0005D65C File Offset: 0x0005B85C
		protected override bool IncluirNalgas(ICalculoDeEstimuloTactil calculo)
		{
			if (calculo.estimulanteParte == ParteQuePuedeEstimular.propSexToy)
			{
				Component getRealEstimulante = calculo.estimulo.GetRealEstimulante;
				TipoDeProp? tipoDeProp;
				if (getRealEstimulante == null)
				{
					tipoDeProp = null;
				}
				else
				{
					IPertenecibleDeCharacter componentInParent = getRealEstimulante.GetComponentInParent<IPertenecibleDeCharacter>();
					if (componentInParent == null)
					{
						tipoDeProp = null;
					}
					else
					{
						ICharacter inmediateOwner = componentInParent.inmediateOwner;
						if (inmediateOwner == null)
						{
							tipoDeProp = null;
						}
						else
						{
							IDefinedProp component = inmediateOwner.GetComponent<IDefinedProp>();
							tipoDeProp = ((component != null) ? new TipoDeProp?(component.tipo) : null);
						}
					}
				}
				TipoDeProp? tipoDeProp2 = tipoDeProp;
				if (tipoDeProp2 != null && tipoDeProp2.Value == TipoDeProp.jeringa)
				{
					return false;
				}
			}
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.9f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.3f;
		}

		// Token: 0x060013FC RID: 5116 RVA: 0x0005D727 File Offset: 0x0005B927
		protected override bool IncluirTetas(ICalculoDeEstimuloTactil calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.9f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.3f;
		}

		// Token: 0x060013FD RID: 5117 RVA: 0x0005D767 File Offset: 0x0005B967
		protected override bool IncluirVientre(ICalculoDeEstimuloTactil calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.95f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.35f;
		}

		// Token: 0x060013FE RID: 5118 RVA: 0x0005D7A7 File Offset: 0x0005B9A7
		protected override bool IncluirPezones(ICalculoDeEstimuloTactil calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.8f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.2f;
		}

		// Token: 0x060013FF RID: 5119 RVA: 0x0005D7E7 File Offset: 0x0005B9E7
		protected override bool IncluirAno(ICalculoDeEstimuloTactil calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.75f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.15f;
		}

		// Token: 0x06001400 RID: 5120 RVA: 0x0005D7A7 File Offset: 0x0005B9A7
		protected override bool IncluirVagina(ICalculoDeEstimuloTactil calculo)
		{
			if (calculo.emocion.reaccion == ReaccionHumana.placer)
			{
				return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.8f;
			}
			return this.m_currentPersonalidadWeight / this.m_currentModDeRequerimientoPorVestidura >= 0.2f;
		}

		// Token: 0x06001401 RID: 5121 RVA: 0x0005D828 File Offset: 0x0005BA28
		protected override bool EstimuloEnPartesPrivadasEsValido(ICalculoDeEstimuloTactil calculo)
		{
			if (calculo.tipo != TipoDeCalculoDeEstimulo.frame)
			{
				return false;
			}
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			if (reaccion <= ReaccionHumana.rabia)
			{
				if (reaccion != ReaccionHumana.dolor && reaccion != ReaccionHumana.rabia)
				{
					return false;
				}
			}
			else if (reaccion != ReaccionHumana.placer && reaccion != ReaccionHumana.miedo && reaccion != ReaccionHumana.decepcion)
			{
				return false;
			}
			return true;
		}

		// Token: 0x06001402 RID: 5122 RVA: 0x0005D874 File Offset: 0x0005BA74
		protected override float ObtenerModificadorDeCoolDown(ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloTactil>.Tipo tipo, ICalculoDeEstimuloTactil calculo)
		{
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			float num;
			if (reaccion <= ReaccionHumana.rabia)
			{
				if (reaccion == ReaccionHumana.dolor)
				{
					num = 3f;
					goto IL_0080;
				}
				if (reaccion == ReaccionHumana.rabia)
				{
					num = 1f;
					if (this.m_ConsentForzado.EsCorrupted(calculo))
					{
						num = 10f;
						goto IL_0080;
					}
					goto IL_0080;
				}
			}
			else
			{
				if (reaccion == ReaccionHumana.placer)
				{
					num = 20f;
					goto IL_0080;
				}
				if (reaccion == ReaccionHumana.miedo)
				{
					num = 0.5f;
					goto IL_0080;
				}
				if (reaccion == ReaccionHumana.decepcion)
				{
					num = 5f;
					goto IL_0080;
				}
			}
			throw new ArgumentOutOfRangeException(tipo.ToString());
			IL_0080:
			num *= base.pudorInvertMod * this.m_currentModDePudorPorVestiduraInvertido;
			switch (tipo)
			{
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloTactil>.Tipo.nalgas:
				return 2f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloTactil>.Tipo.ano:
				return 1f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloTactil>.Tipo.vientre:
				return 2f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloTactil>.Tipo.vagina:
				return 1f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloTactil>.Tipo.tetas:
				return 2f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloTactil>.Tipo.pezones:
				return 1f * num;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x0005D978 File Offset: 0x0005BB78
		protected override float ObtenerModificadorDeProbabilidad(ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloTactil>.Tipo tipo, ICalculoDeEstimuloTactil calculo)
		{
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			float num;
			if (reaccion <= ReaccionHumana.rabia)
			{
				if (reaccion == ReaccionHumana.dolor)
				{
					num = 0.16666667f;
					goto IL_0080;
				}
				if (reaccion == ReaccionHumana.rabia)
				{
					num = 1f;
					if (this.m_ConsentForzado.EsCorrupted(calculo))
					{
						num = 0.05f;
						goto IL_0080;
					}
					goto IL_0080;
				}
			}
			else
			{
				if (reaccion == ReaccionHumana.placer)
				{
					num = 0.025f;
					goto IL_0080;
				}
				if (reaccion == ReaccionHumana.miedo)
				{
					num = 2f;
					goto IL_0080;
				}
				if (reaccion == ReaccionHumana.decepcion)
				{
					num = 0.1f;
					goto IL_0080;
				}
			}
			throw new ArgumentOutOfRangeException(tipo.ToString());
			IL_0080:
			num *= base.pudorMod * this.m_currentModDePudorPorVestidura;
			switch (tipo)
			{
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloTactil>.Tipo.nalgas:
				return 0.5f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloTactil>.Tipo.ano:
				return 1f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloTactil>.Tipo.vientre:
				return 0.5f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloTactil>.Tipo.vagina:
				return 1f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloTactil>.Tipo.tetas:
				return 0.5f * num;
			case ReacctorDeInteraccionesPartesPrivadas<ICalculoDeEstimuloTactil>.Tipo.pezones:
				return 1f * num;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x0005DA7C File Offset: 0x0005BC7C
		protected override bool ReaccionarAEstimuloEnPartesPrivadas(ICalculoDeEstimuloTactil calculo)
		{
			float num = (this.baseConfig.coolDownGeneral * 3f * base.pudorMod).Random(0.5f);
			int num2 = ReactorSegundario.PrioridadParcer(calculo, 1.0);
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

		// Token: 0x04000E68 RID: 3688
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentPersonalidadWeight;

		// Token: 0x04000E69 RID: 3689
		private ConsentCorrupted m_ConsentForzado;
	}
}
