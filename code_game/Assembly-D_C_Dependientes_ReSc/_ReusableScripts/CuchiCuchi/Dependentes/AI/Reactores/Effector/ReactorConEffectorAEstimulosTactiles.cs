using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.AI.Reactores.Effector
{
	// Token: 0x020002D8 RID: 728
	public sealed class ReactorConEffectorAEstimulosTactiles : ReactorConEffector<ICalculoDeEstimuloTactil>
	{
		// Token: 0x06001281 RID: 4737 RVA: 0x00058156 File Offset: 0x00056356
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
		}

		// Token: 0x06001282 RID: 4738 RVA: 0x0005818C File Offset: 0x0005638C
		protected override bool CalculoEsValido(ICalculoDeEstimuloTactil calculo)
		{
			return calculo.estimulo.normalDefinida && calculo.estimulo.normalGlobalDelEstimulo.sqrMagnitude > 0f && base.PuedeReaccinarPorOxigeno(ReactorConEffector<ICalculoDeEstimuloTactil>.TipoDeOxigeno.cansamiento) && base.PuedeReaccionPorManipulacion();
		}

		// Token: 0x06001283 RID: 4739 RVA: 0x000581D4 File Offset: 0x000563D4
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloTactil calculo)
		{
			ReactorConEffector<ICalculoDeEstimuloTactil>.EffectorsControllerTipo effectorsControllerTipo = this.ConvertirParteEnumEnEffectorType(ReactorSegundario.PartePrincipalEstimulada(calculo, false));
			EffectorsController.Tipo tipo;
			EffectorsController.Tipo? tipo2;
			this.ConvertirParteEnumEnEffectorTypeSide(out tipo, out tipo2, effectorsControllerTipo, calculo.estimulo.side);
			bool flag;
			bool flag2;
			if (ReactorConEffector<ICalculoDeEstimuloTactil>.TiposEstanAtados(ref tipo, ref tipo2, this.dependencias.interactionEffectorController, out flag, out flag2, this.debugLogEffector))
			{
				return false;
			}
			if (ReactorConEffector<ICalculoDeEstimuloTactil>.TiposEstanEnCoolDown(ref tipo, ref tipo2, this.coolDownPorTipo, this.debugLogEffector))
			{
				return false;
			}
			int num = ReactorSegundario.PrioridadParcer(calculo, (double)this.prioridadParaControlladorMod);
			if (!ReactorConEffector<ICalculoDeEstimuloTactil>.ControlladorEstaLibre(ref tipo, ref tipo2, num, this.dependencias.effectorsController, false, this.debugLogEffector))
			{
				return false;
			}
			UmbralBasico.Estado estado;
			calculo.GetSingleEstado(out estado);
			this.m_lastSeveridad = estado.severidadConPost;
			this.m_lastOffsetMod = estado.offsetMod;
			float num2 = base.ObtenerDistanciaDeEffector(this.m_lastSeveridad, this.m_lastOffsetMod);
			if (this.m_IFemaleCharacterIdleable.enAutoInteraccionCoital)
			{
				if (this.m_IFemaleCharacterIdleable.enAutoInteraccionCoitalHead)
				{
					if (tipo != EffectorsController.Tipo.leftShoulder)
					{
						EffectorsController.Tipo? tipo3 = tipo2;
						EffectorsController.Tipo tipo4 = EffectorsController.Tipo.rightShoulder;
						if (!((tipo3.GetValueOrDefault() == tipo4) & (tipo3 != null)))
						{
							goto IL_0100;
						}
					}
					return false;
				}
				IL_0100:
				if (this.m_IFemaleCharacterIdleable.enAutoInteraccionCoitalHips)
				{
					if (tipo != EffectorsController.Tipo.leftThigh)
					{
						EffectorsController.Tipo? tipo3 = tipo2;
						EffectorsController.Tipo tipo4 = EffectorsController.Tipo.rightThigh;
						if (!((tipo3.GetValueOrDefault() == tipo4) & (tipo3 != null)))
						{
							goto IL_012E;
						}
					}
					return false;
				}
				IL_012E:
				num2 *= 0.333f;
			}
			num2 *= this.modDeDistancia;
			num2 *= base.ObtenerModDistanciaSegunEstimulante(calculo);
			num2 *= base.ObtenerModDistanciaSegunEstimulo(calculo);
			num2 *= this.dependencias.character.escala;
			num2 *= base.ObtenerDistanciaModPorOxigeno(ReactorConEffector<ICalculoDeEstimuloTactil>.TipoDeOxigeno.cansamiento);
			if (flag || (tipo2 != null && flag2))
			{
				num2 *= 0.75f;
			}
			num2 *= base.ModDeDistanciaPorInteracionEjecutandose();
			Vector3 vector = base.ObtenerNormalDelEstimulo(calculo.estimulo, tipo, tipo2, true, false, 1f, 1f).normalized;
			if (this.effectorConfig.invertirNormales)
			{
				vector *= -1f;
			}
			AnimationCurve animationCurve = Singleton<CollecionDeCurvasParaEmocionesReacciones>.instance.ObtenerCurva(calculo.emocion.reaccion);
			float num3 = base.ObtenerTiempoDeEffector(this.m_lastSeveridad, this.m_lastOffsetMod);
			num3 *= this.modDeDuracion;
			num3 *= base.ObtenerDuracionModPorOxigeno(ReactorConEffector<ICalculoDeEstimuloTactil>.TipoDeOxigeno.cansamiento);
			num3 *= base.ObtenerModDuracionSegunEstimulo(calculo);
			num2 *= base.ModDeDistanciaPorResponsividad();
			num3 *= base.ModDeDuracionPorResponsividad();
			num2 *= this.ModDeDistanciaPorResponsividadTactil(calculo);
			num3 *= this.ModDeDuracionPorResponsividadTactil(calculo);
			if (calculo.emocion.reaccion == ReaccionHumana.rabia && this.m_ConsentForzado.EsCorrupted(calculo))
			{
				num2 *= 0.1f;
			}
			if (this.debugDraw)
			{
				this.dependencias.effectorsController.ObtenerBoneDeTipo(tipo);
				if (tipo2 != null)
				{
					this.dependencias.effectorsController.ObtenerBoneDeTipo(tipo2.Value);
				}
			}
			bool flag3 = this.dependencias.effectorsController.TryMove(tipo, vector.normalized * num2, num3, num, animationCurve, tipo2);
			if (flag3)
			{
				this.coolDownPorTipo.Apply(tipo);
				if (tipo2 != null)
				{
					this.coolDownPorTipo.Apply(tipo2.Value);
				}
			}
			return flag3;
		}

		// Token: 0x06001284 RID: 4740 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			return 1f;
		}

		// Token: 0x06001285 RID: 4741 RVA: 0x000584F0 File Offset: 0x000566F0
		private float ModDeDistanciaPorResponsividadTactil(ICalculoDeEstimuloTactil calculo)
		{
			TraitHumano trait = this.GetTrait(ReactorSegundario.PartePrincipalEstimulada(calculo, false));
			HumanTraitScore traitScore = this.dependencias.personalidad.GetTraitScore(trait);
			switch (traitScore)
			{
			case HumanTraitScore.normal:
				return 1f;
			case HumanTraitScore.alto:
				return 1.05f;
			case HumanTraitScore.muyAlto:
				return 1.1f;
			case HumanTraitScore.bajo:
				return 0.8f;
			case HumanTraitScore.muyBajo:
				return 0.6f;
			default:
				throw new ArgumentOutOfRangeException(traitScore.ToString());
			}
		}

		// Token: 0x06001286 RID: 4742 RVA: 0x0005856C File Offset: 0x0005676C
		private float ModDeDuracionPorResponsividadTactil(ICalculoDeEstimuloTactil calculo)
		{
			TraitHumano trait = this.GetTrait(ReactorSegundario.PartePrincipalEstimulada(calculo, false));
			HumanTraitScore traitScore = this.dependencias.personalidad.GetTraitScore(trait);
			switch (traitScore)
			{
			case HumanTraitScore.normal:
				return 1f;
			case HumanTraitScore.alto:
				return 1.05f;
			case HumanTraitScore.muyAlto:
				return 1.1f;
			case HumanTraitScore.bajo:
				return 0.95f;
			case HumanTraitScore.muyBajo:
				return 0.9f;
			default:
				throw new ArgumentOutOfRangeException(traitScore.ToString());
			}
		}

		// Token: 0x06001287 RID: 4743 RVA: 0x000585E5 File Offset: 0x000567E5
		private TraitHumano GetTrait(ParteDelCuerpoHumano parte)
		{
			if (parte <= ParteDelCuerpoHumano.hombros)
			{
				switch (parte)
				{
				case ParteDelCuerpoHumano.espalda:
				case ParteDelCuerpoHumano.cintura:
				case ParteDelCuerpoHumano.cabeza:
					break;
				case ParteDelCuerpoHumano.abdomen:
				case ParteDelCuerpoHumano.caderas:
					return TraitHumano.responcibidadPrivada;
				default:
					if (parte - ParteDelCuerpoHumano.cienes > 2)
					{
						return TraitHumano.responcibidadPrivada;
					}
					break;
				}
			}
			else if (parte - ParteDelCuerpoHumano.brazos > 2 && parte - ParteDelCuerpoHumano.rodillas > 2)
			{
				return TraitHumano.responcibidadPrivada;
			}
			return TraitHumano.responcibidadPublica;
		}

		// Token: 0x06001288 RID: 4744 RVA: 0x00058624 File Offset: 0x00056824
		private void ConvertirParteEnumEnEffectorTypeSide(out EffectorsController.Tipo a, out EffectorsController.Tipo? b, ReactorConEffector<ICalculoDeEstimuloTactil>.EffectorsControllerTipo tipo, Side side)
		{
			switch (tipo)
			{
			case ReactorConEffector<ICalculoDeEstimuloTactil>.EffectorsControllerTipo.shoulder:
				switch (side)
				{
				case Side.none:
				case Side.F:
				case Side.B:
					a = EffectorsController.Tipo.leftShoulder;
					b = new EffectorsController.Tipo?(EffectorsController.Tipo.rightShoulder);
					return;
				case Side.L:
					a = EffectorsController.Tipo.leftShoulder;
					b = null;
					return;
				case Side.R:
					a = EffectorsController.Tipo.rightShoulder;
					b = null;
					return;
				default:
					throw new ArgumentOutOfRangeException(side.ToString());
				}
				break;
			case ReactorConEffector<ICalculoDeEstimuloTactil>.EffectorsControllerTipo.thigh:
				switch (side)
				{
				case Side.none:
				case Side.F:
				case Side.B:
					a = EffectorsController.Tipo.leftThigh;
					b = new EffectorsController.Tipo?(EffectorsController.Tipo.rightThigh);
					return;
				case Side.L:
					a = EffectorsController.Tipo.leftThigh;
					b = null;
					return;
				case Side.R:
					a = EffectorsController.Tipo.rightThigh;
					b = null;
					return;
				default:
					throw new ArgumentOutOfRangeException(side.ToString());
				}
				break;
			case ReactorConEffector<ICalculoDeEstimuloTactil>.EffectorsControllerTipo.hand:
				switch (side)
				{
				case Side.none:
				case Side.F:
				case Side.B:
					a = EffectorsController.Tipo.leftHand;
					b = new EffectorsController.Tipo?(EffectorsController.Tipo.rightHand);
					return;
				case Side.L:
					a = EffectorsController.Tipo.leftHand;
					b = null;
					return;
				case Side.R:
					a = EffectorsController.Tipo.rightHand;
					b = null;
					return;
				default:
					throw new ArgumentOutOfRangeException(side.ToString());
				}
				break;
			case ReactorConEffector<ICalculoDeEstimuloTactil>.EffectorsControllerTipo.foot:
				switch (side)
				{
				case Side.none:
				case Side.F:
				case Side.B:
					a = EffectorsController.Tipo.leftFoot;
					b = new EffectorsController.Tipo?(EffectorsController.Tipo.rightFoot);
					return;
				case Side.L:
					a = EffectorsController.Tipo.leftFoot;
					b = null;
					return;
				case Side.R:
					a = EffectorsController.Tipo.rightFoot;
					b = null;
					return;
				default:
					throw new ArgumentOutOfRangeException(side.ToString());
				}
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06001289 RID: 4745 RVA: 0x000587B8 File Offset: 0x000569B8
		private ReactorConEffector<ICalculoDeEstimuloTactil>.EffectorsControllerTipo ConvertirParteEnumEnEffectorType(ParteDelCuerpoHumano parte)
		{
			switch (parte)
			{
			case ParteDelCuerpoHumano.pecho:
			case ParteDelCuerpoHumano.espalda:
			case ParteDelCuerpoHumano.hombros:
			case ParteDelCuerpoHumano.axilas:
			case ParteDelCuerpoHumano.senos:
			case ParteDelCuerpoHumano.pezones:
				return ReactorConEffector<ICalculoDeEstimuloTactil>.EffectorsControllerTipo.shoulder;
			case ParteDelCuerpoHumano.abdomen:
			case ParteDelCuerpoHumano.cintura:
			case ParteDelCuerpoHumano.caderas:
			case ParteDelCuerpoHumano.coxis:
			case ParteDelCuerpoHumano.vientre:
			case ParteDelCuerpoHumano.vientreBajo:
			case ParteDelCuerpoHumano.labiosVaginales:
			case ParteDelCuerpoHumano.clitoris:
			case ParteDelCuerpoHumano.perineo:
			case ParteDelCuerpoHumano.ano:
			case ParteDelCuerpoHumano.vag:
			case ParteDelCuerpoHumano.hombligo:
			case ParteDelCuerpoHumano.pene:
			case ParteDelCuerpoHumano.testiculos:
				return ReactorConEffector<ICalculoDeEstimuloTactil>.EffectorsControllerTipo.thigh;
			case ParteDelCuerpoHumano.cabeza:
			case ParteDelCuerpoHumano.cuello:
			case ParteDelCuerpoHumano.mandibula:
			case ParteDelCuerpoHumano.labios:
			case ParteDelCuerpoHumano.bocaInterno:
			case ParteDelCuerpoHumano.nariz:
			case ParteDelCuerpoHumano.mejillas:
			case ParteDelCuerpoHumano.ojos:
			case ParteDelCuerpoHumano.globosOculares:
			case ParteDelCuerpoHumano.cejas:
			case ParteDelCuerpoHumano.cienes:
			case ParteDelCuerpoHumano.frente:
			case ParteDelCuerpoHumano.lengua:
			case ParteDelCuerpoHumano.orejas:
				return ReactorConEffector<ICalculoDeEstimuloTactil>.EffectorsControllerTipo.shoulder;
			case ParteDelCuerpoHumano.brazos:
			case ParteDelCuerpoHumano.anteBrazos:
			case ParteDelCuerpoHumano.manos:
				return ReactorConEffector<ICalculoDeEstimuloTactil>.EffectorsControllerTipo.hand;
			case ParteDelCuerpoHumano.nalgas:
				return ReactorConEffector<ICalculoDeEstimuloTactil>.EffectorsControllerTipo.thigh;
			case ParteDelCuerpoHumano.piernas:
				return ReactorConEffector<ICalculoDeEstimuloTactil>.EffectorsControllerTipo.thigh;
			case ParteDelCuerpoHumano.rodillas:
			case ParteDelCuerpoHumano.canillas:
			case ParteDelCuerpoHumano.pies:
				return ReactorConEffector<ICalculoDeEstimuloTactil>.EffectorsControllerTipo.foot;
			default:
				throw new ArgumentOutOfRangeException(parte.ToString());
			}
		}

		// Token: 0x0600128A RID: 4746 RVA: 0x00058898 File Offset: 0x00056A98
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloTactil calculo)
		{
			bool flag = calculo.estimuloBasico.ContineParte(ParteDelCuerpoHumano.globosOculares);
			float num = 1f;
			if (flag)
			{
				num *= 0.001f;
			}
			return num;
		}

		// Token: 0x04000D86 RID: 3462
		public float prioridadParaControlladorMod = 1f;

		// Token: 0x04000D87 RID: 3463
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastSeveridad;

		// Token: 0x04000D88 RID: 3464
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastOffsetMod;

		// Token: 0x04000D89 RID: 3465
		private ConsentCorrupted m_ConsentForzado;
	}
}
