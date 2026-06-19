using System;
using Assets.Base.Behaviours.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.AI.Reactores.Effector
{
	// Token: 0x020002D1 RID: 721
	public abstract class ReactorConEffector<TCalculo> : ReactorACalculoDeEstimulo<TCalculo> where TCalculo : class, ICalculoDeEstimulo
	{
		// Token: 0x0600124F RID: 4687 RVA: 0x00056A6C File Offset: 0x00054C6C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_IFemaleCharacterIdleable = this.GetComponentEnRoot(false);
			if (this.m_IFemaleCharacterIdleable == null)
			{
				throw new ArgumentNullException("m_IFemaleCharacterIdleable", "m_IFemaleCharacterIdleable null reference.");
			}
			this.m_characterRespirador = this.GetComponentEnRoot(false);
			if (this.m_characterRespirador == null)
			{
				throw new ArgumentNullException("m_characterRespirador", "m_characterRespirador null reference.");
			}
			this.m_manipulable = this.GetComponentEnRoot(false);
			if (this.m_manipulable == null)
			{
				throw new ArgumentNullException("m_manipulable", "m_manipulable null reference.");
			}
			this.m_updater = this.GetComponentEnRoot(false);
			if (this.m_updater == null)
			{
				throw new ArgumentNullException("m_updater", "m_updater null reference.");
			}
			this.coolDownPorTipo = new CoolDownPorTipo(() => this.effectorConfig.effectorsTipoCoolDownTime);
			this.dependencias.Init(this);
		}

		// Token: 0x06001250 RID: 4688 RVA: 0x00056B38 File Offset: 0x00054D38
		protected Vector3 ObtenerNormalDelEstimulo(InteracionEstimulanteBasica estimulo, EffectorsController.Tipo a, EffectorsController.Tipo? b, bool corregirUpPlane, bool corregirRightPlane, float tUpMod, float tRightMod)
		{
			if (b == null)
			{
				return this.ObtenerNormalDelEstimulo(estimulo, a, corregirUpPlane, corregirRightPlane, tUpMod, tRightMod).normalized;
			}
			return (this.ObtenerNormalDelEstimulo(estimulo, a, corregirUpPlane, corregirRightPlane, tUpMod, tRightMod) + this.ObtenerNormalDelEstimulo(estimulo, b.Value, corregirUpPlane, corregirRightPlane, tUpMod, tRightMod)).normalized;
		}

		// Token: 0x06001251 RID: 4689 RVA: 0x00056B9C File Offset: 0x00054D9C
		protected Vector3 ObtenerNormalDelEstimulo(Vector3 normalGlobalDelEstimulo, EffectorsController.Tipo a, EffectorsController.Tipo? b, bool corregirUpPlane, bool corregirRightPlane, float tUpMod, float tRightMod)
		{
			if (b == null)
			{
				return this.ObtenerNormalDelEstimulo(normalGlobalDelEstimulo, a, corregirUpPlane, corregirRightPlane, tUpMod, tRightMod).normalized;
			}
			return (this.ObtenerNormalDelEstimulo(normalGlobalDelEstimulo, a, corregirUpPlane, corregirRightPlane, tUpMod, tRightMod) + this.ObtenerNormalDelEstimulo(normalGlobalDelEstimulo, b.Value, corregirUpPlane, corregirRightPlane, tUpMod, tRightMod)).normalized;
		}

		// Token: 0x06001252 RID: 4690 RVA: 0x00056C00 File Offset: 0x00054E00
		protected float ModDeDistanciaPorInteracionEjecutandose()
		{
			if (this.dependencias.interactionEffectorController.InteractuandoEnLayers(FullBodyBipedEffector.LeftHand, 1.IKLayerFromToLast()) || this.dependencias.interactionEffectorController.InteractuandoEnLayers(FullBodyBipedEffector.RightHand, 1.IKLayerFromToLast()))
			{
				return 0.75f;
			}
			if (this.dependencias.interactionEffectorController.InteractuandoEnLayers(FullBodyBipedEffector.LeftFoot, 1.IKLayerFromToLast()) || this.dependencias.interactionEffectorController.InteractuandoEnLayers(FullBodyBipedEffector.RightFoot, 1.IKLayerFromToLast()))
			{
				return 0.75f;
			}
			return 1f;
		}

		// Token: 0x06001253 RID: 4691 RVA: 0x00056C84 File Offset: 0x00054E84
		protected float ModDeDistanciaPorResponsividad()
		{
			HumanTraitScore traitScore = this.dependencias.personalidad.GetTraitScore(TraitHumano.responcibidad);
			switch (traitScore)
			{
			case HumanTraitScore.normal:
				return 1f;
			case HumanTraitScore.alto:
				return 1.1f;
			case HumanTraitScore.muyAlto:
				return 1.2f;
			case HumanTraitScore.bajo:
				return 0.8f;
			case HumanTraitScore.muyBajo:
				return 0.6f;
			default:
				throw new ArgumentOutOfRangeException(traitScore.ToString());
			}
		}

		// Token: 0x06001254 RID: 4692 RVA: 0x00056CF0 File Offset: 0x00054EF0
		protected float ModDeDuracionPorResponsividad()
		{
			HumanTraitScore traitScore = this.dependencias.personalidad.GetTraitScore(TraitHumano.responcibidad);
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

		// Token: 0x06001255 RID: 4693 RVA: 0x00056D5C File Offset: 0x00054F5C
		protected Vector3 ObtenerNormalDelEstimulo(InteracionEstimulanteBasica estimulo, EffectorsController.Tipo tipo, bool corregirUpPlane, bool corregirRightPlane, float tUpMod, float tRightMod)
		{
			return this.ObtenerNormalDelEstimulo(estimulo.normalGlobalDelEstimulo, tipo, corregirUpPlane, corregirRightPlane, tUpMod, tRightMod);
		}

		// Token: 0x06001256 RID: 4694 RVA: 0x00056D74 File Offset: 0x00054F74
		protected Vector3 ObtenerNormalDelEstimulo(Vector3 normalGlobalDelEstimulo, EffectorsController.Tipo tipo, bool corregirUpPlane, bool corregirRightPlane, float tUpMod, float tRightMod)
		{
			Transform transform = this.dependencias.effectorsController.ObtenerBoneDeTipo(tipo);
			if (transform == null)
			{
				throw new ArgumentNullException("bone", "bone null reference.");
			}
			bool flag = this.debugDraw;
			Vector3 vector;
			if (this.TryObtenerNormalDelDeteccionDePuntosDeApoyo(normalGlobalDelEstimulo, transform, out vector, 0.9f))
			{
				return vector;
			}
			vector = normalGlobalDelEstimulo;
			bool flag2 = this.debugDraw;
			switch (tipo)
			{
			case EffectorsController.Tipo.body:
				this.TransformadorDeNormalSegunPlane(ref vector, HumanBodyBones.Spine, corregirUpPlane, corregirRightPlane, tUpMod, tRightMod, 0.9f);
				break;
			case EffectorsController.Tipo.leftShoulder:
			case EffectorsController.Tipo.rightShoulder:
				this.TransformadorDeNormalSegunPlane(ref vector, HumanBodyBones.Chest, corregirUpPlane, corregirRightPlane, tUpMod, tRightMod, 0.5f);
				break;
			case EffectorsController.Tipo.leftThigh:
				this.TransformadorDeNormalSegunPlane(ref vector, HumanBodyBones.LeftUpperLeg, corregirUpPlane, corregirRightPlane, tUpMod, tRightMod, 0.9f);
				break;
			case EffectorsController.Tipo.rightThigh:
				this.TransformadorDeNormalSegunPlane(ref vector, HumanBodyBones.RightUpperLeg, corregirUpPlane, corregirRightPlane, tUpMod, tRightMod, 0.9f);
				break;
			case EffectorsController.Tipo.leftHand:
				this.InvertorDeNormalSegunDown(ref vector, HumanBodyBones.LeftHand);
				break;
			case EffectorsController.Tipo.rightHand:
				this.InvertorDeNormalSegunDown(ref vector, HumanBodyBones.RightHand);
				break;
			case EffectorsController.Tipo.leftFoot:
				this.InvertorDeNormalSegunDown(ref vector, HumanBodyBones.LeftFoot);
				break;
			case EffectorsController.Tipo.rightFoot:
				this.InvertorDeNormalSegunDown(ref vector, HumanBodyBones.RightFoot);
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			return vector;
		}

		// Token: 0x06001257 RID: 4695 RVA: 0x00056EA0 File Offset: 0x000550A0
		private void InvertorDeNormalSegunDown(ref Vector3 normal, HumanBodyBones enumBone)
		{
			DatosDeBoneBase datosDeBoneBase = this.dependencias.character.bones.Obtener(enumBone);
			if (datosDeBoneBase == null)
			{
				return;
			}
			Vector3 vector = -datosDeBoneBase.currentUp;
			if (Vector3.Dot(vector.normalized, normal.normalized) >= 0f)
			{
				return;
			}
			normal = -Vector3.Reflect(-normal, vector);
		}

		// Token: 0x06001258 RID: 4696 RVA: 0x00056F0C File Offset: 0x0005510C
		private void TransformadorDeNormalSegunPlane(ref Vector3 normal, HumanBodyBones enumBone, bool usarUpPlane, bool usarRightPlane, float tUpMod, float tRightMod, float t = 0.9f)
		{
			DatosDeBoneBase datosDeBoneBase = this.dependencias.character.bones.Obtener(enumBone);
			if (datosDeBoneBase == null)
			{
				throw new ArgumentNullException("data", "data null reference.");
			}
			Vector3 vector = normal;
			if (usarUpPlane)
			{
				bool flag = this.debugDraw;
				if (!this.RemovePlaneToNormal(vector, datosDeBoneBase.currentUp, out vector, t * tUpMod))
				{
					return;
				}
				bool flag2 = this.debugDraw;
			}
			if (usarRightPlane)
			{
				bool flag3 = this.debugDraw;
				if (!this.RemovePlaneToNormal(vector, datosDeBoneBase.currentRight, out vector, t * tRightMod))
				{
					return;
				}
				bool flag4 = this.debugDraw;
			}
			normal = vector;
		}

		// Token: 0x06001259 RID: 4697 RVA: 0x00056FA4 File Offset: 0x000551A4
		private bool RemovePlaneToNormal(Vector3 normal, Vector3 worldPlane, out Vector3 result, float w = 0.9f)
		{
			result = normal;
			if (w <= 0f)
			{
				return true;
			}
			result = Math3d.ProjectVectorOnPlane(worldPlane, normal);
			if (result == Vector3.zero)
			{
				return false;
			}
			result = result.normalized * normal.magnitude;
			result = Vector3.Lerp(normal, result, w);
			return true;
		}

		// Token: 0x0600125A RID: 4698 RVA: 0x00057014 File Offset: 0x00055214
		private bool TryObtenerNormalDelDeteccionDePuntosDeApoyo(Vector3 normalGlobalDelEstimulo, Transform bone, out Vector3 normal, float t = 0.9f)
		{
			normal = default(Vector3);
			if (bone == null)
			{
				throw new ArgumentNullException("bone", "bone null reference.");
			}
			DeteccionDePuntosDeApoyoBase.PuntoMedio puntoMedio = this.dependencias.deteccionDePuntosDeApoyoDePuppet.BoneAPunto(bone);
			if (puntoMedio == null)
			{
				return false;
			}
			if (!puntoMedio.tocandoAlgo)
			{
				return false;
			}
			if (puntoMedio.tocandoNormal == Vector3.zero)
			{
				return false;
			}
			if (this.debugLog)
			{
				MonoBehaviour.print("-normal del calculo tactil sera desviada segun normal del contacto del detector de puntos de apoyo");
			}
			Vector3 vector = -puntoMedio.tocandoNormal;
			bool flag = Vector3.Dot(vector, normalGlobalDelEstimulo) < 0f;
			normal = normalGlobalDelEstimulo;
			if (flag)
			{
				normal = Math3d.ProjectVectorOnPlane(vector, normalGlobalDelEstimulo);
			}
			return true;
		}

		// Token: 0x0600125B RID: 4699 RVA: 0x000570BC File Offset: 0x000552BC
		protected float ObtenerTiempoDeEffector()
		{
			float num = Mathf.Abs(this.effectorConfig.effectorDefaultDuration * this.effectorConfig.effectorDefaultDurationRandomRangeModV2);
			if (num >= this.effectorConfig.effectorDefaultDuration)
			{
				throw new InvalidOperationException();
			}
			float num2 = Random.Range(-num, num);
			return this.effectorConfig.effectorDefaultDuration + num2;
		}

		// Token: 0x0600125C RID: 4700 RVA: 0x00057110 File Offset: 0x00055310
		protected float ObtenerTiempoDeEffector(float severidad, float offsetMod)
		{
			float num = this.ObtenerTiempoDeEffector();
			float num2 = Mathf.Lerp(1.1f, 0.9f, severidad) * Mathf.Clamp(1f / offsetMod, 0.9f, 1.1f);
			return (this.effectorConfig.effectorDefaultDuration + num) * num2;
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x0005715C File Offset: 0x0005535C
		protected float ObtenerDistanciaDeEffector(float severidad, float offsetMod)
		{
			float num = this.ObtenerDistanciaDeEffector();
			float num2 = Mathf.Lerp(0.8f, 1.2f, severidad) * Mathf.Clamp(offsetMod, 0.8f, 1.2f);
			return num * num2;
		}

		// Token: 0x0600125E RID: 4702 RVA: 0x00057194 File Offset: 0x00055394
		protected float ObtenerDistanciaDeEffector()
		{
			float num = Mathf.Abs(this.effectorConfig.effectorDefaultLocalDistance * this.effectorConfig.effectorDefaultLocalDistanceRandomRangeModV2);
			if (num >= this.effectorConfig.effectorDefaultLocalDistance)
			{
				throw new InvalidOperationException();
			}
			float num2 = Random.Range(-num, num);
			return this.effectorConfig.effectorDefaultLocalDistance + num2;
		}

		// Token: 0x0600125F RID: 4703 RVA: 0x000571E8 File Offset: 0x000553E8
		protected bool PuedeReaccinarPorOxigeno(ReactorConEffector<TCalculo>.TipoDeOxigeno tipo)
		{
			switch (tipo)
			{
			case ReactorConEffector<TCalculo>.TipoDeOxigeno.saturacion:
				return this.m_characterRespirador.saturacionDeOxigenoWeigth > 0f;
			case ReactorConEffector<TCalculo>.TipoDeOxigeno.cansamiento:
				return this.m_characterRespirador.cansamientoWeight < 1f;
			case ReactorConEffector<TCalculo>.TipoDeOxigeno.ahogamiento:
				return this.m_characterRespirador.ahogadoWeight < 1f;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06001260 RID: 4704 RVA: 0x00057254 File Offset: 0x00055454
		protected float ObtenerDistanciaModPorOxigeno(ReactorConEffector<TCalculo>.TipoDeOxigeno tipo)
		{
			switch (tipo)
			{
			case ReactorConEffector<TCalculo>.TipoDeOxigeno.saturacion:
				return Mathf.Lerp(0.01f, 1f, this.m_characterRespirador.saturacionDeOxigenoWeigth);
			case ReactorConEffector<TCalculo>.TipoDeOxigeno.cansamiento:
				return Mathf.Lerp(1f, 0.01f, this.m_characterRespirador.cansamientoWeight);
			case ReactorConEffector<TCalculo>.TipoDeOxigeno.ahogamiento:
				return Mathf.Lerp(1f, 0.01f, this.m_characterRespirador.ahogadoWeight);
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06001261 RID: 4705 RVA: 0x000572D8 File Offset: 0x000554D8
		protected float ObtenerDuracionModPorOxigeno(ReactorConEffector<TCalculo>.TipoDeOxigeno tipo)
		{
			switch (tipo)
			{
			case ReactorConEffector<TCalculo>.TipoDeOxigeno.saturacion:
				return Mathf.Lerp(2f, 1f, this.m_characterRespirador.saturacionDeOxigenoWeigth);
			case ReactorConEffector<TCalculo>.TipoDeOxigeno.cansamiento:
				return Mathf.Lerp(1f, 2f, this.m_characterRespirador.cansamientoWeight);
			case ReactorConEffector<TCalculo>.TipoDeOxigeno.ahogamiento:
				return Mathf.Lerp(1f, 2f, this.m_characterRespirador.ahogadoWeight);
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x06001262 RID: 4706 RVA: 0x0005735C File Offset: 0x0005555C
		protected bool PuedeReaccionPorManipulacion()
		{
			return !this.m_manipulable.siendoManipulado;
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x0005736C File Offset: 0x0005556C
		[Obsolete("", true)]
		protected float ObtenerModTiempoSegunEmocion(ICalculoDeEstimulo calculo)
		{
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			if (reaccion <= ReaccionHumana.rabia)
			{
				if (reaccion == ReaccionHumana.dolor)
				{
					return 1.1f;
				}
				if (reaccion == ReaccionHumana.rabia)
				{
					return 0.85f;
				}
			}
			else
			{
				if (reaccion == ReaccionHumana.placer)
				{
					return 1.15f;
				}
				if (reaccion == ReaccionHumana.arousal)
				{
					return 1.2f;
				}
			}
			return 1f;
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x000573BC File Offset: 0x000555BC
		[Obsolete("", true)]
		protected float ObtenerModDistanciaSegunEmocion(ICalculoDeEstimulo calculo)
		{
			ReaccionHumana reaccion = calculo.emocion.reaccion;
			if (reaccion <= ReaccionHumana.tristeza)
			{
				if (reaccion <= ReaccionHumana.asco)
				{
					switch (reaccion)
					{
					case ReaccionHumana.None:
						return 1f;
					case ReaccionHumana.concentToHero:
						goto IL_00D3;
					case ReaccionHumana.asombro:
						return 1.05f;
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro:
					case ReaccionHumana.concentToHero | ReaccionHumana.dolor:
					case ReaccionHumana.asombro | ReaccionHumana.dolor:
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro | ReaccionHumana.dolor:
						goto IL_00D9;
					case ReaccionHumana.dolor:
						return 1.1f;
					case ReaccionHumana.rabia:
						return 1.3f;
					default:
						if (reaccion != ReaccionHumana.asco)
						{
							goto IL_00D9;
						}
						return 1.05f;
					}
				}
				else
				{
					if (reaccion == ReaccionHumana.placer)
					{
						return 0.85f;
					}
					if (reaccion == ReaccionHumana.arousal)
					{
						return 0.95f;
					}
					if (reaccion != ReaccionHumana.tristeza)
					{
						goto IL_00D9;
					}
				}
			}
			else if (reaccion <= ReaccionHumana.felicidad)
			{
				if (reaccion == ReaccionHumana.miedo)
				{
					return 1.2f;
				}
				if (reaccion != ReaccionHumana.alegria && reaccion != ReaccionHumana.felicidad)
				{
					goto IL_00D9;
				}
				goto IL_00D3;
			}
			else if (reaccion != ReaccionHumana.decepcion)
			{
				if (reaccion == ReaccionHumana.alivio)
				{
					goto IL_00D3;
				}
				if (reaccion != ReaccionHumana.aburrimiento)
				{
					goto IL_00D9;
				}
			}
			return 1f;
			IL_00D3:
			return 0.75f;
			IL_00D9:
			throw new ArgumentOutOfRangeException(calculo.emocion.reaccion.ToString());
		}

		// Token: 0x06001265 RID: 4709 RVA: 0x000574C0 File Offset: 0x000556C0
		protected float ObtenerModDuracionSegunEstimulo(ICalculoDeInteracionEstimulante calculo)
		{
			if (calculo == null)
			{
				return 1f;
			}
			float num = 1f;
			if (calculo.estimuloBasico.ContineParte(ParteDelCuerpoHumano.globosOculares))
			{
				num *= 0.75f;
			}
			return num;
		}

		// Token: 0x06001266 RID: 4710 RVA: 0x000574F4 File Offset: 0x000556F4
		protected float ObtenerModDistanciaSegunEstimulo(ICalculoDeInteracionEstimulante calculo)
		{
			if (calculo == null)
			{
				return 1f;
			}
			float num = 1f;
			if (calculo.estimuloBasico.ContineParte(ParteDelCuerpoHumano.globosOculares))
			{
				num *= 1.2f;
			}
			return num;
		}

		// Token: 0x06001267 RID: 4711 RVA: 0x00057528 File Offset: 0x00055728
		protected float ObtenerModDistanciaSegunEstimulante(ICalculoDeEstimuloDeParteEstimulante calculo)
		{
			ParteQuePuedeEstimular estimulanteParte = calculo.estimulanteParte;
			if (estimulanteParte <= ParteQuePuedeEstimular.lengua)
			{
				if (estimulanteParte <= ParteQuePuedeEstimular.propSexToy)
				{
					switch (estimulanteParte)
					{
					case ParteQuePuedeEstimular.None:
						return 1f;
					case ParteQuePuedeEstimular.noEspecificada:
						return 0.5f;
					case ParteQuePuedeEstimular.piernas:
						return 0.75f;
					case (ParteQuePuedeEstimular)3:
					case (ParteQuePuedeEstimular)5:
					case (ParteQuePuedeEstimular)6:
					case (ParteQuePuedeEstimular)7:
						break;
					case ParteQuePuedeEstimular.manos:
						return 1f;
					case ParteQuePuedeEstimular.pene:
						return 1.05f;
					default:
						if (estimulanteParte == ParteQuePuedeEstimular.propSexToy)
						{
							return 1.055f;
						}
						break;
					}
				}
				else
				{
					if (estimulanteParte == ParteQuePuedeEstimular.torzo)
					{
						return 0.75f;
					}
					if (estimulanteParte == ParteQuePuedeEstimular.lengua)
					{
						return 1f;
					}
				}
			}
			else if (estimulanteParte <= ParteQuePuedeEstimular.ojos)
			{
				if (estimulanteParte == ParteQuePuedeEstimular.boca)
				{
					return 1f;
				}
				if (estimulanteParte == ParteQuePuedeEstimular.ojos)
				{
					return 0.5f;
				}
			}
			else
			{
				if (estimulanteParte == ParteQuePuedeEstimular.semen)
				{
					return 0.333f;
				}
				if (estimulanteParte == ParteQuePuedeEstimular.dedo)
				{
					return 0.75f;
				}
			}
			throw new ArgumentOutOfRangeException(calculo.estimulanteParte.ToString());
		}

		// Token: 0x06001268 RID: 4712 RVA: 0x00057613 File Offset: 0x00055813
		public static bool TiposEstanAtados(ref EffectorsController.Tipo a, IInteractionController interactionEffectorController, out bool aCambiado, bool debugLog)
		{
			bool flag = !ReactorConEffector<TCalculo>.EffectorsTipoNoEstaAtadoYPuedeUsarse(ref a, interactionEffectorController, out aCambiado);
			if (flag && debugLog)
			{
				MonoBehaviour.print("-reactor de tipo " + a.ToString() + " esta atado.");
			}
			return flag;
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x00057648 File Offset: 0x00055848
		public static bool TiposEstanAtados(ref EffectorsController.Tipo a, ref EffectorsController.Tipo? b, IInteractionController interactionEffectorController, out bool aCambiado, out bool bCambiado, bool debugLog)
		{
			if (b == null)
			{
				bCambiado = false;
				return ReactorConEffector<TCalculo>.TiposEstanAtados(ref a, interactionEffectorController, out aCambiado, debugLog);
			}
			EffectorsController.Tipo value = b.Value;
			bool flag = !ReactorConEffector<TCalculo>.EffectorsTipoNoEstaAtadoYPuedeUsarse(ref a, interactionEffectorController, out aCambiado);
			bool flag2 = !ReactorConEffector<TCalculo>.EffectorsTipoNoEstaAtadoYPuedeUsarse(ref value, interactionEffectorController, out bCambiado);
			if (!flag && !flag2)
			{
				return false;
			}
			if (flag && !flag2)
			{
				if (debugLog)
				{
					MonoBehaviour.print("-reactor de tipo " + a.ToString() + " esta atado.");
				}
				a = value;
				b = null;
				return false;
			}
			if (!flag && flag2)
			{
				if (debugLog)
				{
					MonoBehaviour.print("-reactor de tipo " + value.ToString() + " esta atado.");
				}
				b = null;
				return false;
			}
			if (debugLog)
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					"-reactor de tipo ",
					a.ToString(),
					" y ",
					value.ToString(),
					" estan atados."
				}));
			}
			return true;
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x00057750 File Offset: 0x00055950
		private static bool EffectorsTipoNoEstaAtadoYPuedeUsarse(ref EffectorsController.Tipo tipo, IInteractionController interactionEffectorController, out bool cambiado)
		{
			FullBodyBipedEffector fullBodyBipedEffector = EffectorsController.ParceTipoAFullBodyBipedEffector(tipo);
			if (interactionEffectorController.PuedeTrasladarse(fullBodyBipedEffector))
			{
				cambiado = false;
				return true;
			}
			cambiado = true;
			switch (tipo)
			{
			case EffectorsController.Tipo.leftHand:
			{
				tipo = EffectorsController.Tipo.leftShoulder;
				bool flag;
				return ReactorConEffector<TCalculo>.EffectorsTipoNoEstaAtadoYPuedeUsarse(ref tipo, interactionEffectorController, out flag);
			}
			case EffectorsController.Tipo.rightHand:
			{
				tipo = EffectorsController.Tipo.rightShoulder;
				bool flag;
				return ReactorConEffector<TCalculo>.EffectorsTipoNoEstaAtadoYPuedeUsarse(ref tipo, interactionEffectorController, out flag);
			}
			case EffectorsController.Tipo.leftFoot:
			{
				tipo = EffectorsController.Tipo.leftThigh;
				bool flag;
				return ReactorConEffector<TCalculo>.EffectorsTipoNoEstaAtadoYPuedeUsarse(ref tipo, interactionEffectorController, out flag);
			}
			case EffectorsController.Tipo.rightFoot:
			{
				tipo = EffectorsController.Tipo.rightThigh;
				bool flag;
				return ReactorConEffector<TCalculo>.EffectorsTipoNoEstaAtadoYPuedeUsarse(ref tipo, interactionEffectorController, out flag);
			}
			default:
				return false;
			}
		}

		// Token: 0x0600126B RID: 4715 RVA: 0x000577C8 File Offset: 0x000559C8
		private static bool EffectorsTipoAAtaduraTipo(EffectorsController.Tipo tipo, out TipoDeAtaduraDePuppet r)
		{
			r = TipoDeAtaduraDePuppet.hombroL;
			switch (tipo)
			{
			case EffectorsController.Tipo.body:
				return false;
			case EffectorsController.Tipo.leftShoulder:
				r = TipoDeAtaduraDePuppet.hombroL;
				return true;
			case EffectorsController.Tipo.rightShoulder:
				r = TipoDeAtaduraDePuppet.hombroR;
				return true;
			case EffectorsController.Tipo.leftThigh:
				r = TipoDeAtaduraDePuppet.caderaL;
				return true;
			case EffectorsController.Tipo.rightThigh:
				r = TipoDeAtaduraDePuppet.caderaR;
				return true;
			case EffectorsController.Tipo.leftHand:
				r = TipoDeAtaduraDePuppet.manoL;
				return true;
			case EffectorsController.Tipo.rightHand:
				r = TipoDeAtaduraDePuppet.manoR;
				return true;
			case EffectorsController.Tipo.leftFoot:
				r = TipoDeAtaduraDePuppet.pieL;
				return true;
			case EffectorsController.Tipo.rightFoot:
				r = TipoDeAtaduraDePuppet.pieR;
				return true;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
		}

		// Token: 0x0600126C RID: 4716 RVA: 0x00057844 File Offset: 0x00055A44
		public static bool TiposEstanEnCoolDown(ref EffectorsController.Tipo a, ref EffectorsController.Tipo? b, CoolDownPorTipo cooldowns, bool debugLog)
		{
			if (b == null)
			{
				return ReactorConEffector<TCalculo>.TipoEstaEnCoolDown(a, cooldowns, debugLog);
			}
			EffectorsController.Tipo value = b.Value;
			bool flag = ReactorConEffector<TCalculo>.TipoEstaEnCoolDown(a, cooldowns, debugLog);
			bool flag2 = ReactorConEffector<TCalculo>.TipoEstaEnCoolDown(value, cooldowns, debugLog);
			if (!flag && !flag2)
			{
				return false;
			}
			if (flag && !flag2)
			{
				if (debugLog)
				{
					MonoBehaviour.print("-reactor de tipo " + a.ToString() + " esta cooldown.");
				}
				a = value;
				b = null;
				return false;
			}
			if (!flag && flag2)
			{
				if (debugLog)
				{
					MonoBehaviour.print("-reactor de tipo " + value.ToString() + " esta cooldown.");
				}
				b = null;
				return false;
			}
			if (debugLog)
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					"-reactor de tipo ",
					a.ToString(),
					" esta cooldown. - reactor de tipo ",
					value.ToString(),
					" esta cooldown."
				}));
			}
			return true;
		}

		// Token: 0x0600126D RID: 4717 RVA: 0x0005793A File Offset: 0x00055B3A
		private static bool TipoEstaEnCoolDown(EffectorsController.Tipo tipo, CoolDownPorTipo cooldowns, bool debugLog)
		{
			bool flag = cooldowns.IsOn(tipo, 1f);
			if (flag && debugLog)
			{
				MonoBehaviour.print("-reactor de tipo " + tipo.ToString() + " esta en cooldown.");
			}
			return flag;
		}

		// Token: 0x0600126E RID: 4718 RVA: 0x00057970 File Offset: 0x00055B70
		public static bool ControlladorEstaLibre(ref EffectorsController.Tipo a, ref EffectorsController.Tipo? b, int prioridad, EffectorsController effectorsController, bool inclusive, bool debugLog)
		{
			if (b == null)
			{
				return ReactorConEffector<TCalculo>.ControlladorEstaLibre(a, prioridad, effectorsController, inclusive, debugLog);
			}
			EffectorsController.Tipo value = b.Value;
			bool flag = ReactorConEffector<TCalculo>.ControlladorEstaLibre(a, prioridad, effectorsController, inclusive, debugLog);
			bool flag2 = ReactorConEffector<TCalculo>.ControlladorEstaLibre(value, prioridad, effectorsController, inclusive, debugLog);
			if (flag && flag2)
			{
				return true;
			}
			if (flag && !flag2)
			{
				if (debugLog)
				{
					MonoBehaviour.print("-reactor de tipo " + value.ToString() + " esta Ocupado.");
				}
				b = null;
				return true;
			}
			if (!flag && flag2)
			{
				if (debugLog)
				{
					MonoBehaviour.print("-reactor de tipo " + a.ToString() + " esta Ocupado.");
				}
				a = value;
				b = null;
				return true;
			}
			if (debugLog)
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					"-reactor de tipo ",
					a.ToString(),
					" esta Ocupado. - reactor de tipo ",
					value.ToString(),
					" esta Ocupado."
				}));
			}
			return false;
		}

		// Token: 0x0600126F RID: 4719 RVA: 0x00057A74 File Offset: 0x00055C74
		private static bool ControlladorEstaLibre(EffectorsController.Tipo tipo, int prioridad, EffectorsController effectorsController, bool inclusive, bool debugLog)
		{
			bool flag = effectorsController.TipoDeOrdenEstaLibrePrioridad(tipo, prioridad, inclusive);
			if (!flag && debugLog)
			{
				MonoBehaviour.print("-reactor de tipo " + tipo.ToString() + " esta ocupado.");
			}
			return flag;
		}

		// Token: 0x04000D62 RID: 3426
		public bool debugLogEffector;

		// Token: 0x04000D63 RID: 3427
		public bool debugDraw;

		// Token: 0x04000D64 RID: 3428
		public float modDeDistancia = 1f;

		// Token: 0x04000D65 RID: 3429
		public float modDeDuracion = 1f;

		// Token: 0x04000D66 RID: 3430
		protected IFemaleCharacterIdleable m_IFemaleCharacterIdleable;

		// Token: 0x04000D67 RID: 3431
		protected IIKUpdater m_updater;

		// Token: 0x04000D68 RID: 3432
		protected ICharacterRespirador m_characterRespirador;

		// Token: 0x04000D69 RID: 3433
		protected IPuppetManipulable m_manipulable;

		// Token: 0x04000D6A RID: 3434
		[Header("Como Effector")]
		public ConfigDeReacctorConEffector effectorConfig = new ConfigDeReacctorConEffector();

		// Token: 0x04000D6B RID: 3435
		public CoolDownPorTipo coolDownPorTipo;

		// Token: 0x04000D6C RID: 3436
		public DependenciasGetter dependencias = new DependenciasGetter();

		// Token: 0x020002D2 RID: 722
		protected enum TipoDeOxigeno
		{
			// Token: 0x04000D6E RID: 3438
			saturacion,
			// Token: 0x04000D6F RID: 3439
			cansamiento,
			// Token: 0x04000D70 RID: 3440
			ahogamiento
		}

		// Token: 0x020002D3 RID: 723
		public enum EffectorsControllerTipo
		{
			// Token: 0x04000D72 RID: 3442
			shoulder,
			// Token: 0x04000D73 RID: 3443
			thigh,
			// Token: 0x04000D74 RID: 3444
			hand,
			// Token: 0x04000D75 RID: 3445
			foot
		}
	}
}
