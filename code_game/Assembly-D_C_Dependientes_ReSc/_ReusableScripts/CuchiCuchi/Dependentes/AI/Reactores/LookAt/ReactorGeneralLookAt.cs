using System;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Scenas;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.AI.Reactores.LookAt
{
	// Token: 0x020002D0 RID: 720
	public sealed class ReactorGeneralLookAt : ReactorLookAtBase<ICalculoDeInteracionEstimulanteDeParteEstimulante>
	{
		// Token: 0x06001248 RID: 4680 RVA: 0x00056278 File Offset: 0x00054478
		protected sealed override bool CalculoEsValido(ICalculoDeInteracionEstimulanteDeParteEstimulante calculo)
		{
			ICalculoDeEstimuloVisual calculoDeEstimuloVisual = calculo as ICalculoDeEstimuloVisual;
			if (calculoDeEstimuloVisual != null && calculoDeEstimuloVisual.estimuloBasico.tipo == DireccionDeEstimulo.dada && calculoDeEstimuloVisual.estimulanteParte == ParteQuePuedeEstimular.ojos && this.m_coolDownVisualDadaOjos.isOn)
			{
				return false;
			}
			if (calculo.estimuloBasico.tipoDeEstimulo == TipoDeEstimulo.coital && calculo.estimuloBasico.partesDelCuerpoHumanoEstimuladasSet.Contains(9))
			{
				this.flagOnlyUseEyes = true;
			}
			return calculo.estimuloBasico.transformEstimulante != null && calculo.estimuloBasico.transformEstimulado != null && (calculo.estimuloBasico.estimulante != null || (calculo.estimuloBasico.posicionDefinida && calculo.estimuloBasico.posicionGlobalDelEstimulo != Vector3.zero));
		}

		// Token: 0x06001249 RID: 4681 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeInteracionEstimulanteDeParteEstimulante calculo)
		{
			return 1f;
		}

		// Token: 0x0600124A RID: 4682 RVA: 0x00056344 File Offset: 0x00054544
		protected sealed override float CoolDownModificadorParaCalculo(ICalculoDeInteracionEstimulanteDeParteEstimulante calculo)
		{
			this.viendoSemen = false;
			this.tocandoOjos = false;
			bool flag = calculo is ICalculoDeEstimuloCoitalHole;
			this.modPorSeveridad = 1f;
			UmbralBasico.Estado estado;
			ReactorSegundario.GetEstadoConMasEstimuloTotal(calculo, out estado);
			this.modPorSeveridad = Mathf.Lerp(1f, 0.75f, estado.severidadConPost);
			if (flag)
			{
				this.modPorSeveridad = this.modPorSeveridad.InPow(4f);
			}
			if (calculo.estimuloBasico.tipoDeEstimulo == TipoDeEstimulo.tactil && calculo.estimuloBasico.ContineParte(ParteDelCuerpoHumano.globosOculares))
			{
				this.tocandoOjos = true;
				this.modPorSeveridad = this.modPorSeveridad.InPow(8f);
				base.ResetCambioDeTipoDeMirarEnCoolDown();
			}
			if (calculo.estimuloBasico.tipoDeEstimulo == TipoDeEstimulo.visual && calculo.estimuloBasico.tipo == DireccionDeEstimulo.dada && calculo.estimulanteParte == ParteQuePuedeEstimular.semen)
			{
				this.viendoSemen = true;
				this.modPorSeveridad = this.modPorSeveridad.InPow(8f);
				base.ResetCambioDeTipoDeMirarEnCoolDown();
			}
			return this.modPorSeveridad;
		}

		// Token: 0x0600124B RID: 4683 RVA: 0x00056440 File Offset: 0x00054640
		protected sealed override bool ReaccionarCalculo(ICalculoDeInteracionEstimulanteDeParteEstimulante calculo)
		{
			bool flag = this.flagOnlyUseEyes;
			this.flagOnlyUseEyes = false;
			if (!flag)
			{
				ICharactersSceneInteractions charactersSceneInteractions = (Singleton<InteraccionesEnScena>.IsInScene ? Singleton<InteraccionesEnScena>.instance.GetTakingPlaceInteractions(CurrentMainCharacter<CurrentMainChar, MainChar>.current.character, CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character) : null);
				if (charactersSceneInteractions != null)
				{
					flag = charactersSceneInteractions.PeekIsValid(TriggeringBodyPart.penis, SensitiveBodyPart.throat, InterationReceivedType.penetration, Emotion.All, false);
				}
			}
			int num = ReactorSegundario.PrioridadParcer(calculo, (double)((calculo is ICalculoDeEstimuloCoitalHole) ? 2 : 1)) * (this.tocandoOjos ? 2 : 1) * (this.viendoSemen ? 2 : 1);
			LookAtControllerV2.Orden orden;
			bool flag2;
			if (!this.dependencias.controller.TipoDeOrdenEstaLibrePrioridad(0, num, false, out orden, out flag2) && (!orden.stared || orden.currentTimeMod < 0.75f))
			{
				if (this.debugLog)
				{
					MonoBehaviour.print("-controllador de lookat esta ocupado.");
				}
				return false;
			}
			Character character = null;
			IPertenecibleDeCharacter pertenecibleDeCharacter = calculo.estimuloBasico.estimulante as IPertenecibleDeCharacter;
			if (pertenecibleDeCharacter == null)
			{
				character = calculo.estimuloBasico.estimulante as Character;
			}
			else
			{
				try
				{
					character = (Character)pertenecibleDeCharacter.GetRootOwner();
				}
				catch (Exception ex)
				{
					Debug.LogError("TODO: Para ahorrar tiempo no se implemento icharacter sino character directamente");
					throw ex;
				}
			}
			if (character == null)
			{
				character = calculo.estimuloBasico.estimulante.GetComponentInParent<Character>();
			}
			Transform transform = null;
			bool flag3 = character != null;
			if (flag3)
			{
				transform = ((character.cameraAtadaTransform != null) ? character.cameraAtadaTransform : character.trasnformParaObservar);
			}
			Vector3 posicionGlobalDelEstimulo = calculo.estimuloBasico.posicionGlobalDelEstimulo;
			bool flag4 = base.PuedeMirarPosicion(calculo) && base.PuedeMirarPosicionSegunCharacter(calculo, this.dependencias.controller, transform, posicionGlobalDelEstimulo) && calculo.estimuloBasico.transformEstimulado != null && calculo.estimuloBasico.posicionDefinida && posicionGlobalDelEstimulo != Vector3.zero;
			flag4 = flag4 && base.PuedeMirarPosicionSegunVelocidad(calculo, 1.2f);
			if (!flag3 && !flag4)
			{
				if (this.debugLog)
				{
					MonoBehaviour.print("-no se puede mirar productor ni posicion.");
				}
				return false;
			}
			bool flag5 = (flag4 && base.chanceDeVerPosicionDelEstimulo.ProcPorcentaje(this.modPorSeveridad)) || (flag4 && !flag3) || (flag4 && this.tocandoOjos) || (flag4 && this.viendoSemen);
			bool flag6 = calculo.estimuloBasico.tieneCopiaInvertida && calculo.estimuloInvertidoBasico != null && 85f.ProcPorcentaje(this.modPorSeveridad);
			flag5 = flag5 || flag6;
			if (base.ExisteCambioDeTipoDeMirar(flag5) && base.CambioDeTipoDeMirarEnCoolDown(flag5, flag4 && flag3, calculo, this.modPorSeveridad))
			{
				if (this.debugLog)
				{
					MonoBehaviour.print("-cambio negado. mirar posicion era: " + flag5.ToString());
				}
				flag5 = !flag5;
			}
			Transform transform2 = calculo.estimuloBasico.transformEstimulante;
			bool flag7 = false;
			bool flag8 = false;
			bool flag9 = false;
			bool flag10 = false;
			if (flag5 && character)
			{
				flag7 = character.ObjetoEsMiMano(transform2);
				flag8 = character.ObjetoEsMiPene(transform2);
				flag9 = character.ObjetoEsMiDedo(transform2);
				flag10 = calculo.estimulanteParte == ParteQuePuedeEstimular.semen;
				if (!flag7 && !flag8 && !flag9 && !flag10 && Vector3.Distance(character.worldFirstPersonViewPoint, posicionGlobalDelEstimulo) < character.escala * 0.25f)
				{
					flag5 = false;
				}
			}
			if (!flag5 && !flag3)
			{
				if (this.debugLog)
				{
					MonoBehaviour.print("-no se puede mirar productor ni posicion.");
				}
				return false;
			}
			Transform transform3 = null;
			Vector3 vector = Vector3.zero;
			if (flag5)
			{
				if (flag3 && (flag7 || flag8 || flag9 || flag10))
				{
					MaleChar maleChar = character as MaleChar;
					bool flag11 = maleChar != null;
					if (flag8 && flag11)
					{
						transform2 = (maleChar.peneDeCharacter.isPenetrating ? maleChar.peneDeCharacter.parteBase : transform2);
					}
					if (flag9 && flag11)
					{
						transform2 = (maleChar.dedoPeneDeCharacter.isPenetrating ? maleChar.dedoPeneDeCharacter.parteBase : transform2);
					}
					transform3 = transform2;
					vector = Vector3.zero;
				}
				else if (calculo.estimuloBasico.tipo == DireccionDeEstimulo.recibida)
				{
					transform3 = calculo.estimuloBasico.transformEstimulado;
					vector = transform3.InverseTransformPoint(posicionGlobalDelEstimulo);
				}
				else
				{
					transform3 = calculo.estimuloBasico.transformEstimulante;
					vector = transform3.InverseTransformPoint(posicionGlobalDelEstimulo);
				}
			}
			else if (flag3)
			{
				transform3 = transform;
			}
			if (transform3 == null)
			{
				if (this.debugLog)
				{
					MonoBehaviour.print("-no se puede mirar productor por q no tiene transform de referencia para poder ver.");
				}
				return false;
			}
			LookAtControllerV2.LookAtType lookAtType = LookAtControllerV2.LookAtType.fijamente;
			LookAtControllerV2.LookAtType lookAtType2 = LookAtControllerV2.LookAtType.fijamente;
			base.ObtenerTipoDeLookAt(calculo, out lookAtType, out lookAtType2, this.modPorSeveridad);
			float num2 = (flag5 ? base.verPosicionWeight : base.verProductornWeight);
			float num3 = (flag5 ? base.verPosicionWeightOjos : base.verProductornWeightOjos);
			float num4 = this.ObtenerLookAtModDeSeveridad(calculo);
			num4 *= base.ObtenerLookAtMod(calculo);
			num4 = Mathf.Clamp(num4, 0.333f, 1f);
			float num5 = base.duracionSegunTrait;
			if (flag5)
			{
				num5 = Mathf.Max(num5 * 0.75f, this.baseConfig.coolDownGeneral);
			}
			else
			{
				num5 *= this.duracionMirarMaleOjosMod;
			}
			ICalculoDeEstimuloVisual calculoDeEstimuloVisual = calculo as ICalculoDeEstimuloVisual;
			if (calculoDeEstimuloVisual != null && calculoDeEstimuloVisual.estimuloBasico.tipo == DireccionDeEstimulo.dada && calculoDeEstimuloVisual.estimulanteParte == ParteQuePuedeEstimular.ojos)
			{
				num5 *= this.estimuloDadoOjosDuracionMod;
			}
			bool flag12 = this.dependencias.controller.Mirar(flag ? 0.01f : num2, num3, transform3, lookAtType, true, lookAtType2, true, num4, num + 150, num5, ControllerPrioridadConfig.prioridad, vector, true, 5f);
			if (flag12 && calculoDeEstimuloVisual != null && calculoDeEstimuloVisual.estimuloBasico.tipo == DireccionDeEstimulo.dada && calculoDeEstimuloVisual.estimulanteParte == ParteQuePuedeEstimular.ojos)
			{
				float coolDownModDadaOjos = base.coolDownModDadaOjos;
				this.m_coolDownVisualDadaOjos.ApplyNextRandomMod(this.baseConfig.coolDownGeneral * this.estimuloDadoOjosCoolDownMod * coolDownModDadaOjos + num5 * coolDownModDadaOjos, 0.5f);
			}
			return flag12;
		}

		// Token: 0x0600124C RID: 4684 RVA: 0x000569F0 File Offset: 0x00054BF0
		private float ObtenerLookAtModDeSeveridad(ICalculoDeInteracionEstimulante calculo)
		{
			UmbralBasico.Estado estado;
			ReactorSegundario.GetEstadoConMasEstimuloTotal(calculo, out estado);
			float severidadConPost = estado.severidadConPost;
			float num = Mathf.InverseLerp(0f, 0.333f, severidadConPost);
			return Mathf.Lerp(0.666f, 1f, num);
		}

		// Token: 0x0600124D RID: 4685 RVA: 0x00056A2E File Offset: 0x00054C2E
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x04000D5A RID: 3418
		public bool flagOnlyUseEyes;

		// Token: 0x04000D5B RID: 3419
		public float estimuloDadoOjosCoolDownMod = 3f;

		// Token: 0x04000D5C RID: 3420
		public float estimuloDadoOjosDuracionMod = 1.5f;

		// Token: 0x04000D5D RID: 3421
		public float duracionMirarMaleOjosMod = 1f;

		// Token: 0x04000D5E RID: 3422
		private CoolDown m_coolDownVisualDadaOjos = new CoolDown();

		// Token: 0x04000D5F RID: 3423
		private float modPorSeveridad;

		// Token: 0x04000D60 RID: 3424
		private bool tocandoOjos;

		// Token: 0x04000D61 RID: 3425
		private bool viendoSemen;
	}
}
