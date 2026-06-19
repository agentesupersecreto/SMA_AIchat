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
	// Token: 0x020002D7 RID: 727
	public sealed class ReactorConEffectorAEstimulosCoitales : ReactorConEffector<ICalculoDeEstimuloCoitalHole>
	{
		// Token: 0x06001277 RID: 4727 RVA: 0x00057C69 File Offset: 0x00055E69
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
		}

		// Token: 0x06001278 RID: 4728 RVA: 0x00057C9C File Offset: 0x00055E9C
		protected override bool CalculoEsValido(ICalculoDeEstimuloCoitalHole calculo)
		{
			return calculo.estimulo.normalDefinida && !this.m_IFemaleCharacterIdleable.enAutoInteraccionCoital && base.PuedeReaccinarPorOxigeno(ReactorConEffector<ICalculoDeEstimuloCoitalHole>.TipoDeOxigeno.cansamiento) && base.PuedeReaccionPorManipulacion();
		}

		// Token: 0x06001279 RID: 4729 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x0600127A RID: 4730 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			return 1f;
		}

		// Token: 0x0600127B RID: 4731 RVA: 0x00057CCC File Offset: 0x00055ECC
		protected override bool ReaccionarCalculo(ICalculoDeEstimuloCoitalHole calculo)
		{
			EffectorsController effectorsController = this.dependencias.effectorsController;
			ParteDelCuerpoHumano parteDelCuerpoHumano = ReactorSegundario.PartePrincipalEstimulada(calculo, false);
			EffectorsController.Tipo tipo;
			EffectorsController.Tipo? tipo2;
			if (parteDelCuerpoHumano != ParteDelCuerpoHumano.bocaInterno)
			{
				if (parteDelCuerpoHumano - ParteDelCuerpoHumano.ano > 1)
				{
					if (this.debugLogEffector)
					{
						MonoBehaviour.print("- reactor de estimulos coitales no puede reaccionar a parte principal " + parteDelCuerpoHumano.ToString() + ". n oes una parte 'penetrable'.");
					}
					return false;
				}
				tipo = EffectorsController.Tipo.leftThigh;
				tipo2 = new EffectorsController.Tipo?(EffectorsController.Tipo.rightThigh);
			}
			else
			{
				tipo = EffectorsController.Tipo.leftShoulder;
				tipo2 = new EffectorsController.Tipo?(EffectorsController.Tipo.rightShoulder);
			}
			bool flag;
			bool flag2;
			if (ReactorConEffector<ICalculoDeEstimuloCoitalHole>.TiposEstanAtados(ref tipo, ref tipo2, this.dependencias.interactionEffectorController, out flag, out flag2, this.debugLogEffector))
			{
				return false;
			}
			if (ReactorConEffector<ICalculoDeEstimuloCoitalHole>.TiposEstanEnCoolDown(ref tipo, ref tipo2, this.coolDownPorTipo, this.debugLogEffector))
			{
				return false;
			}
			int num = ReactorSegundario.PrioridadParcer(calculo, (double)this.prioridadParaControlladorMod);
			if (!ReactorConEffector<ICalculoDeEstimuloCoitalHole>.ControlladorEstaLibre(ref tipo, ref tipo2, num, this.dependencias.effectorsController, false, this.debugLogEffector))
			{
				return false;
			}
			UmbralBasico.Estado estado;
			ReactorSegundario.GetEstadoConMasEstimuloTotal(calculo, out estado);
			this.m_lastSeveridad = estado.severidadConPost;
			this.m_lastOffsetMod = estado.offsetMod;
			float num2 = base.ObtenerDistanciaDeEffector(this.m_lastSeveridad, this.m_lastOffsetMod);
			num2 *= this.modDeDistancia;
			num2 *= base.ObtenerModDistanciaSegunEstimulante(calculo);
			num2 *= this.dependencias.character.escala;
			num2 *= base.ObtenerDistanciaModPorOxigeno(ReactorConEffector<ICalculoDeEstimuloCoitalHole>.TipoDeOxigeno.cansamiento);
			if (flag || (tipo2 != null && flag2))
			{
				num2 *= 0.75f;
			}
			num2 *= base.ModDeDistanciaPorInteracionEjecutandose();
			Vector3 vector = base.ObtenerNormalDelEstimulo(calculo.estimulo, tipo, tipo2, true, false, 1f, 1f).normalized;
			vector = this.TorcerNormalAleatoriamente(vector);
			if (this.effectorConfig.invertirNormales)
			{
				vector *= -1f;
			}
			AnimationCurve animationCurve = Singleton<CollecionDeCurvasParaEmocionesReacciones>.instance.ObtenerCurva(calculo.emocion.reaccion);
			float num3 = base.ObtenerTiempoDeEffector(this.m_lastSeveridad, this.m_lastOffsetMod);
			num3 *= this.modDeDuracion;
			num3 *= base.ObtenerDuracionModPorOxigeno(ReactorConEffector<ICalculoDeEstimuloCoitalHole>.TipoDeOxigeno.cansamiento);
			num2 *= 1.1f;
			num3 *= 0.9f;
			num2 *= base.ModDeDistanciaPorResponsividad();
			num3 *= base.ModDeDuracionPorResponsividad();
			num2 *= this.ModDeDistanciaPorResponsividadCoital(calculo);
			num3 *= this.ModDeDuracionPorResponsividadCoital(calculo);
			num2 *= ((parteDelCuerpoHumano == ParteDelCuerpoHumano.ano) ? 1.05f : 1f);
			num3 *= ((parteDelCuerpoHumano == ParteDelCuerpoHumano.ano) ? 1.15f : 1f);
			if (calculo.emocion.reaccion == ReaccionHumana.rabia && this.m_ConsentForzado.EsCorrupted(calculo))
			{
				num2 *= 0.05f;
			}
			if (this.debugDraw)
			{
				this.dependencias.effectorsController.ObtenerBoneDeTipo(tipo);
				if (tipo2 != null)
				{
					this.dependencias.effectorsController.ObtenerBoneDeTipo(tipo2.Value);
				}
			}
			bool flag3 = effectorsController.TryMove(tipo, vector.normalized * num2, num3, num, animationCurve, tipo2);
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

		// Token: 0x0600127C RID: 4732 RVA: 0x00057FE0 File Offset: 0x000561E0
		private Vector3 TorcerNormalAleatoriamente(Vector3 normal)
		{
			Vector3 vector = Random.insideUnitSphere.normalized;
			if (Vector3.Dot(normal, vector) < 0f)
			{
				vector *= -1f;
			}
			return (normal * 4f + vector).normalized;
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x00058030 File Offset: 0x00056230
		private float ModDeDistanciaPorResponsividadCoital(ICalculoDeEstimuloCoitalHole calculo)
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

		// Token: 0x0600127E RID: 4734 RVA: 0x000580AC File Offset: 0x000562AC
		private float ModDeDuracionPorResponsividadCoital(ICalculoDeEstimuloCoitalHole calculo)
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

		// Token: 0x0600127F RID: 4735 RVA: 0x00058125 File Offset: 0x00056325
		private TraitHumano GetTrait(ParteDelCuerpoHumano parte)
		{
			if (parte == ParteDelCuerpoHumano.bocaInterno || parte == ParteDelCuerpoHumano.ano)
			{
				return TraitHumano.responcibidadNoNatural;
			}
			if (parte != ParteDelCuerpoHumano.vag)
			{
				throw new InvalidOperationException();
			}
			return TraitHumano.responcibidadNatural;
		}

		// Token: 0x04000D82 RID: 3458
		public float prioridadParaControlladorMod = 1f;

		// Token: 0x04000D83 RID: 3459
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastSeveridad;

		// Token: 0x04000D84 RID: 3460
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastOffsetMod;

		// Token: 0x04000D85 RID: 3461
		private ConsentCorrupted m_ConsentForzado;
	}
}
