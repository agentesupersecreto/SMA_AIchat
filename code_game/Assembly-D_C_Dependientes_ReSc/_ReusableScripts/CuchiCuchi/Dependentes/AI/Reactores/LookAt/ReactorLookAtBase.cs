using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.AI.Reactores.LookAt
{
	// Token: 0x020002CB RID: 715
	public abstract class ReactorLookAtBase<TCalculo> : ReactorACalculoDeEstimulo<TCalculo> where TCalculo : class, ICalculoDeEstimulo
	{
		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x0600122E RID: 4654 RVA: 0x0005559C File Offset: 0x0005379C
		public float verPosicionWeightOjos
		{
			get
			{
				HumanTraitScore traitScore = this.dependencias.personalidad.GetTraitScore(TraitHumano.fijacion);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 0.98f;
				case HumanTraitScore.alto:
					return 0.99f;
				case HumanTraitScore.muyAlto:
					return 1f;
				case HumanTraitScore.bajo:
					return 0.95f;
				case HumanTraitScore.muyBajo:
					return 0.9f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x0600122F RID: 4655 RVA: 0x00055608 File Offset: 0x00053808
		public float verPosicionWeight
		{
			get
			{
				HumanTraitScore traitScore = this.dependencias.personalidad.GetTraitScore(TraitHumano.fijacion);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 0.8f;
				case HumanTraitScore.alto:
					return 0.9f;
				case HumanTraitScore.muyAlto:
					return 1f;
				case HumanTraitScore.bajo:
					return 0.75f;
				case HumanTraitScore.muyBajo:
					return 0.7f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06001230 RID: 4656 RVA: 0x00055674 File Offset: 0x00053874
		public float chanceDeVerPosicionDelEstimulo
		{
			get
			{
				HumanTraitScore traitScore = this.dependencias.personalidad.GetTraitScore(TraitHumano.curiosidad);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 35f * this.config.chancesMods.lookAtEstimulePosition;
				case HumanTraitScore.alto:
					return 65f * this.config.chancesMods.lookAtEstimulePosition;
				case HumanTraitScore.muyAlto:
					return 85f * this.config.chancesMods.lookAtEstimulePosition;
				case HumanTraitScore.bajo:
					return 25f * this.config.chancesMods.lookAtEstimulePosition;
				case HumanTraitScore.muyBajo:
					return 15f * this.config.chancesMods.lookAtEstimulePosition;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06001231 RID: 4657 RVA: 0x00055734 File Offset: 0x00053934
		public float verProductornWeightOjos
		{
			get
			{
				HumanTraitScore traitScore = this.dependencias.personalidad.GetTraitScore(TraitHumano.fijacion);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 0.98f;
				case HumanTraitScore.alto:
					return 0.99f;
				case HumanTraitScore.muyAlto:
					return 1f;
				case HumanTraitScore.bajo:
					return 0.97f;
				case HumanTraitScore.muyBajo:
					return 0.96f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x06001232 RID: 4658 RVA: 0x000557A0 File Offset: 0x000539A0
		public float verProductornWeight
		{
			get
			{
				HumanTraitScore traitScore = this.dependencias.personalidad.GetTraitScore(TraitHumano.fijacion);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 0.95f;
				case HumanTraitScore.alto:
					return 0.975f;
				case HumanTraitScore.muyAlto:
					return 1f;
				case HumanTraitScore.bajo:
					return 0.9f;
				case HumanTraitScore.muyBajo:
					return 0.8f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06001233 RID: 4659 RVA: 0x0005580C File Offset: 0x00053A0C
		public float chanceDeEvadirMirada
		{
			get
			{
				return MathfExtension.LerpConMedio(2f * this.config.chancesMods.chanceToEvade, 10f * this.config.chancesMods.chanceToEvade, 30f * this.config.chancesMods.chanceToEvade, this.dependencias.personalidad.timidez);
			}
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06001234 RID: 4660 RVA: 0x00055870 File Offset: 0x00053A70
		public float duracionSegunTrait
		{
			get
			{
				HumanTraitScore traitScore = this.dependencias.personalidad.GetTraitScore(TraitHumano.abstraccion);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 3f * this.baseConfig.coolDownGeneral;
				case HumanTraitScore.alto:
					return 2f * this.baseConfig.coolDownGeneral;
				case HumanTraitScore.muyAlto:
					return 1f * this.baseConfig.coolDownGeneral;
				case HumanTraitScore.bajo:
					return 4f * this.baseConfig.coolDownGeneral;
				case HumanTraitScore.muyBajo:
					return 5f * this.baseConfig.coolDownGeneral;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06001235 RID: 4661 RVA: 0x00055918 File Offset: 0x00053B18
		public float coolDownModDadaOjos
		{
			get
			{
				float num = 1f;
				HumanTraitScore traitScore = this.dependencias.personalidad.GetTraitScore(TraitHumano.abstraccion);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					num *= 1f;
					break;
				case HumanTraitScore.alto:
					num *= 1.5f;
					break;
				case HumanTraitScore.muyAlto:
					num *= 2f;
					break;
				case HumanTraitScore.bajo:
					num *= 0.6666667f;
					break;
				case HumanTraitScore.muyBajo:
					num *= 0.5f;
					break;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
				HumanTraitScore traitScore2 = this.dependencias.personalidad.GetTraitScore(TraitHumano.curiosidad);
				switch (traitScore2)
				{
				case HumanTraitScore.normal:
					num *= 1f;
					break;
				case HumanTraitScore.alto:
					num *= 0.6666667f;
					break;
				case HumanTraitScore.muyAlto:
					num *= 0.5f;
					break;
				case HumanTraitScore.bajo:
					num *= 1.5f;
					break;
				case HumanTraitScore.muyBajo:
					num *= 2f;
					break;
				default:
					throw new ArgumentOutOfRangeException(traitScore2.ToString());
				}
				return num;
			}
		}

		// Token: 0x06001236 RID: 4662 RVA: 0x00055A14 File Offset: 0x00053C14
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_evadeCoolDown = new CoolDown(this.config.coolDownTimes.evade);
			this.m_evadeCoolDownOjos = new CoolDown(this.config.coolDownTimes.evade * 0.333f);
			this.m_CambiarDeMirarPosicionAProductorCoolDown = new CoolDown(this.baseConfig.coolDownGeneral * 2f);
			this.dependencias.Init(this);
		}

		// Token: 0x06001237 RID: 4663 RVA: 0x00055A8C File Offset: 0x00053C8C
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.unIntentoDeReaccionPorFrame = true;
			this.baseConfig.coolDownGeneral = 2f;
			this.baseConfig.probabilidadPorSegundo = 100f;
			this.config.coolDownTimes.evade = this.baseConfig.coolDownGeneral * 4f;
		}

		// Token: 0x06001238 RID: 4664 RVA: 0x00055AEC File Offset: 0x00053CEC
		protected float ObtenerLookAtMod(ICalculoDeEstimulo calculo)
		{
			float num = 1f;
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			if (reaccion <= ReaccionHumana.rabia)
			{
				if (reaccion == ReaccionHumana.dolor)
				{
					num *= 0.666f;
					goto IL_004B;
				}
				if (reaccion != ReaccionHumana.rabia)
				{
					goto IL_004B;
				}
			}
			else
			{
				if (reaccion == ReaccionHumana.placer)
				{
					num *= 0.333f;
					goto IL_004B;
				}
				if (reaccion != ReaccionHumana.miedo)
				{
					goto IL_004B;
				}
			}
			num *= 1f;
			IL_004B:
			HumanTraitScore traitScore = this.dependencias.personalidad.GetTraitScore(TraitHumano.responcibidad);
			switch (traitScore)
			{
			case HumanTraitScore.normal:
				return num;
			case HumanTraitScore.alto:
				return num * 1.05f;
			case HumanTraitScore.muyAlto:
				return num * 1.1f;
			case HumanTraitScore.bajo:
				return num * 0.95f;
			case HumanTraitScore.muyBajo:
				return num * 0.9f;
			default:
				throw new ArgumentOutOfRangeException(traitScore.ToString());
			}
		}

		// Token: 0x06001239 RID: 4665 RVA: 0x00055BA8 File Offset: 0x00053DA8
		protected bool PuedeMirarPosicionSegunCharacter(ICalculoDeEstimulo calculo, LookAtControllerV2 controller, Transform TransformParaObservarCharacter, Vector3 posicionDelEstimulo)
		{
			if (TransformParaObservarCharacter == null)
			{
				return true;
			}
			Vector3 postUpdateCenterPosition = controller.lookAtOjos.postUpdateCenterPosition;
			Vector3 vector = posicionDelEstimulo - postUpdateCenterPosition;
			Vector3 vector2 = TransformParaObservarCharacter.position - postUpdateCenterPosition;
			bool flag = vector.magnitude < vector2.magnitude * 2f;
			if (flag && Vector3.Distance(postUpdateCenterPosition, posicionDelEstimulo) < this.dependencias.character.escala * 0.2f)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600123A RID: 4666 RVA: 0x00055C20 File Offset: 0x00053E20
		protected bool PuedeMirarPosicion(ICalculoDeEstimulo calculo)
		{
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			return calculoDeInteracionEstimulante == null || calculoDeInteracionEstimulante.estimuloBasico.tipoDeEstimulo != TipoDeEstimulo.visual || calculoDeInteracionEstimulante.estimuloBasico.tipo != DireccionDeEstimulo.recibida;
		}

		// Token: 0x0600123B RID: 4667 RVA: 0x00055C58 File Offset: 0x00053E58
		protected bool PuedeMirarPosicionSegunVelocidad(ICalculoDeEstimulo calculo, float maxVel = 1.2f)
		{
			ICalculoDeEstimuloTactil calculoDeEstimuloTactil = calculo as ICalculoDeEstimuloTactil;
			if (calculoDeEstimuloTactil == null)
			{
				return true;
			}
			float velocidadRelativaEmuladaMaxima = calculoDeEstimuloTactil.estimulo.velocidadRelativaEmuladaMaxima;
			bool flag = !(Mathf.InverseLerp(maxVel * 0.666f, maxVel, velocidadRelativaEmuladaMaxima).InPow(5f) * 100f).ProcPorcentaje(1f);
			if (this.debugLog)
			{
				MonoBehaviour.print("-vel : " + velocidadRelativaEmuladaMaxima.ToString() + " r: " + flag.ToString());
			}
			return flag;
		}

		// Token: 0x0600123C RID: 4668 RVA: 0x00055CD4 File Offset: 0x00053ED4
		protected bool ExisteCambioDeTipoDeMirar(bool esMirarPosicion)
		{
			return esMirarPosicion != this.m_lastIsMirarPosicion;
		}

		// Token: 0x0600123D RID: 4669 RVA: 0x00055CE2 File Offset: 0x00053EE2
		protected void ResetCambioDeTipoDeMirarEnCoolDown()
		{
			this.m_CambiarDeMirarPosicionAProductorCoolDown.Reset();
		}

		// Token: 0x0600123E RID: 4670 RVA: 0x00055CF0 File Offset: 0x00053EF0
		protected bool CambioDeTipoDeMirarEnCoolDown(bool esMirarPosicion, bool puedeCambiar, ICalculoDeEstimulo calculo, float severidadMod)
		{
			if (!puedeCambiar)
			{
				return false;
			}
			if (esMirarPosicion == this.m_lastIsMirarPosicion)
			{
				return false;
			}
			if (this.m_CambiarDeMirarPosicionAProductorCoolDown.IsOn(this.config.coolDownTimes.cambioDeMiradaMod * severidadMod))
			{
				return true;
			}
			this.m_CambiarDeMirarPosicionAProductorCoolDown.ApplyRandomMod(0.75f);
			this.m_lastIsMirarPosicion = esMirarPosicion;
			return false;
		}

		// Token: 0x0600123F RID: 4671 RVA: 0x00055D48 File Offset: 0x00053F48
		protected void ObtenerTipoDeLookAt(ICalculoDeEstimulo calculo, out LookAtControllerV2.LookAtType head, out LookAtControllerV2.LookAtType ojos, float severidadMod)
		{
			float num = 1f;
			float num2 = 1f;
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			if (reaccion <= ReaccionHumana.rabia)
			{
				if (reaccion != ReaccionHumana.concentToHero)
				{
					if (reaccion != ReaccionHumana.dolor)
					{
						if (reaccion == ReaccionHumana.rabia)
						{
							num *= 0.33f;
							if (this.dependencias.consentForzado.EsCorrupted(calculo))
							{
								num2 *= 3f;
							}
							else
							{
								num2 *= 0.10890001f;
							}
						}
					}
					else
					{
						num *= 0.85f;
						num2 *= 0.7225f;
					}
				}
				else
				{
					num *= 1.2f;
					num2 *= 1.44f;
				}
			}
			else if (reaccion != ReaccionHumana.placer)
			{
				if (reaccion != ReaccionHumana.arousal)
				{
					if (reaccion == ReaccionHumana.miedo)
					{
						num *= 0.25f;
						num2 *= 1.5f;
					}
				}
				else
				{
					num *= 1.31f;
					num2 *= 1.7160999f;
				}
			}
			else
			{
				num *= 1.25f;
				num2 *= 1.5625f;
			}
			float num3 = Mathf.Lerp(0.25f, 1.5f, Mathf.InverseLerp(2f, 0f, Mathf.Min(num2, num)));
			num3 *= Mathf.Max(0.001f, severidadMod.OutPow(2f));
			num *= Mathf.Lerp(1f, 3f, severidadMod);
			num2 *= Mathf.Lerp(1f, 3f, severidadMod);
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			if (calculoDeInteracionEstimulante != null)
			{
				if (calculoDeInteracionEstimulante.estimuloBasico.tipoDeEstimulo == TipoDeEstimulo.visual)
				{
					if (!calculo.emocion.reaccion.EsPositiva())
					{
						if (calculoDeInteracionEstimulante.estimuloBasico.tipo == DireccionDeEstimulo.dada)
						{
							num *= Mathf.Lerp(40f, 10f, severidadMod);
							num2 *= Mathf.Lerp(40f, 10f, severidadMod);
							if (this.m_lastEvadeType == LookAtControllerV2.LookAtType.fijamente)
							{
								num3 *= Mathf.Lerp(0f, 0.25f, severidadMod);
							}
						}
						else if (calculoDeInteracionEstimulante.estimuloBasico.tipo == DireccionDeEstimulo.recibida)
						{
							num *= Mathf.Lerp(0.2f, 0.1f, severidadMod);
							num2 *= Mathf.Lerp(0.2f, 0.1f, severidadMod);
						}
					}
					else if (calculoDeInteracionEstimulante.estimuloBasico.tipo == DireccionDeEstimulo.dada)
					{
						num *= Mathf.Lerp(0.55f, 0.1f, severidadMod);
						num2 *= Mathf.Lerp(0.55f, 0.1f, severidadMod);
					}
					else if (calculoDeInteracionEstimulante.estimuloBasico.tipo == DireccionDeEstimulo.recibida)
					{
						num *= Mathf.Lerp(5f, 1.1f, severidadMod);
						num2 *= Mathf.Lerp(5f, 1.1f, severidadMod);
					}
				}
				if (calculoDeInteracionEstimulante.estimuloBasico.tipoDeEstimulo == TipoDeEstimulo.tactil && calculoDeInteracionEstimulante.estimuloBasico.ContineParte(ParteDelCuerpoHumano.globosOculares))
				{
					num3 = 0f;
					num = 100f;
				}
			}
			if (this.m_evadeCoolDown.IsOn(num3))
			{
				head = this.m_lastEvadeType;
			}
			else
			{
				this.m_evadeCoolDown.Apply();
				if (this.chanceDeEvadirMirada.ProcPorcentaje(num))
				{
					head = (this.m_lastEvadeType = ReactorLookAtBase<TCalculo>.ObtenerEvadeType(this.dependencias.controller, false));
				}
				else
				{
					head = (this.m_lastEvadeType = LookAtControllerV2.LookAtType.fijamente);
				}
			}
			num3 *= 0.666f;
			if (this.m_evadeCoolDownOjos.IsOn(num3))
			{
				ojos = this.m_lastEvadeTypeOjos;
				return;
			}
			this.m_evadeCoolDownOjos.Apply();
			if (this.chanceDeEvadirMirada.ProcPorcentaje(num2))
			{
				ojos = (this.m_lastEvadeTypeOjos = this.ObtenerTipoDeLookAtOjos(head));
				return;
			}
			ojos = (this.m_lastEvadeTypeOjos = LookAtControllerV2.LookAtType.fijamente);
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x000560AC File Offset: 0x000542AC
		protected LookAtControllerV2.LookAtType ObtenerTipoDeLookAtOjos(LookAtControllerV2.LookAtType headlookType)
		{
			switch (headlookType)
			{
			case LookAtControllerV2.LookAtType.fijamente:
				break;
			case LookAtControllerV2.LookAtType.evadirCercaL:
			case LookAtControllerV2.LookAtType.evadirL:
				return LookAtControllerV2.LookAtType.evadirCercaL;
			case LookAtControllerV2.LookAtType.evadirCercaR:
			case LookAtControllerV2.LookAtType.evadirR:
				return LookAtControllerV2.LookAtType.evadirCercaR;
			default:
				if (headlookType != LookAtControllerV2.LookAtType.evadirUp)
				{
					throw new ArgumentOutOfRangeException(headlookType.ToString());
				}
				break;
			}
			return ReactorLookAtBase<TCalculo>.ObtenerEvadeType(this.dependencias.controller, true);
		}

		// Token: 0x06001241 RID: 4673 RVA: 0x00056100 File Offset: 0x00054300
		private static LookAtControllerV2.LookAtType ObtenerEvadeType(LookAtControllerV2 controller, bool soloCerca = false)
		{
			float anguloHorizontal = controller.lookAt.estadisticasHaciaTarget.anguloHorizontal;
			bool flag = anguloHorizontal >= 0f;
			float num = Mathf.Abs(anguloHorizontal);
			if (num > 60f)
			{
				flag = !flag;
				soloCerca = true;
			}
			bool flag2 = num > 20f;
			LookAtControllerV2.LookAtType lookAtType;
			if (flag)
			{
				if (flag2 && !soloCerca)
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirR;
				}
				else
				{
					lookAtType = LookAtControllerV2.LookAtType.evadirCercaR;
				}
			}
			else if (flag2 && !soloCerca)
			{
				lookAtType = LookAtControllerV2.LookAtType.evadirL;
			}
			else
			{
				lookAtType = LookAtControllerV2.LookAtType.evadirCercaL;
			}
			return lookAtType;
		}

		// Token: 0x04000D48 RID: 3400
		private bool m_lastIsMirarPosicion;

		// Token: 0x04000D49 RID: 3401
		private LookAtControllerV2.LookAtType m_lastEvadeType;

		// Token: 0x04000D4A RID: 3402
		private LookAtControllerV2.LookAtType m_lastEvadeTypeOjos;

		// Token: 0x04000D4B RID: 3403
		public DependenciasReactorLookAtBase dependencias = new DependenciasReactorLookAtBase();

		// Token: 0x04000D4C RID: 3404
		public ConfigReactorLookAtBase config = new ConfigReactorLookAtBase();

		// Token: 0x04000D4D RID: 3405
		private CoolDown m_CambiarDeMirarPosicionAProductorCoolDown;

		// Token: 0x04000D4E RID: 3406
		private CoolDown m_evadeCoolDown;

		// Token: 0x04000D4F RID: 3407
		private CoolDown m_evadeCoolDownOjos;
	}
}
