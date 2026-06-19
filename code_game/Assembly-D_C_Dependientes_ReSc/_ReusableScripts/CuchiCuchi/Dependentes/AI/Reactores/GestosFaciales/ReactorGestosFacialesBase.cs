using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.GestosFaciales
{
	// Token: 0x02000319 RID: 793
	public abstract class ReactorGestosFacialesBase<TCalculo> : ReactorACalculoDeEstimuloConParaReactor<TCalculo> where TCalculo : class, ICalculoDeEstimulo
	{
		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06001427 RID: 5159 RVA: 0x0005E444 File Offset: 0x0005C644
		public float weightPorMuecas
		{
			get
			{
				HumanTraitScore traitScore = this.dependencias.personalidad.GetTraitScore(TraitHumano.muecas);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 0.9f;
				case HumanTraitScore.alto:
					return 0.95f;
				case HumanTraitScore.muyAlto:
					return 1f;
				case HumanTraitScore.bajo:
					return 0.85f;
				case HumanTraitScore.muyBajo:
					return 0.8f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06001428 RID: 5160 RVA: 0x0005E4B0 File Offset: 0x0005C6B0
		public float duracionModPorExpresividad
		{
			get
			{
				HumanTraitScore traitScore = this.dependencias.personalidad.GetTraitScore(TraitHumano.expresividad);
				switch (traitScore)
				{
				case HumanTraitScore.normal:
					return 1f;
				case HumanTraitScore.alto:
					return 1.5f;
				case HumanTraitScore.muyAlto:
					return 2f;
				case HumanTraitScore.bajo:
					return 0.66666f;
				case HumanTraitScore.muyBajo:
					return 0.5f;
				default:
					throw new ArgumentOutOfRangeException(traitScore.ToString());
				}
			}
		}

		// Token: 0x06001429 RID: 5161 RVA: 0x0005E51C File Offset: 0x0005C71C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.dependencias.Init(this);
		}

		// Token: 0x0600142A RID: 5162 RVA: 0x0005B4D3 File Offset: 0x000596D3
		protected override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfig.probabilidadPorSegundo = 100f;
		}

		// Token: 0x0600142B RID: 5163 RVA: 0x0005E530 File Offset: 0x0005C730
		protected void WeightPorPartes(ICalculoDeEstimulo calculo, ref float w)
		{
			float num = 1f;
			ICalculoDeInteracionEstimulante calculoDeInteracionEstimulante = calculo as ICalculoDeInteracionEstimulante;
			ICalculoDeEstimuloDeParteEstimulante calculoDeEstimuloDeParteEstimulante = calculo as ICalculoDeEstimuloDeParteEstimulante;
			if (calculoDeInteracionEstimulante != null && calculoDeInteracionEstimulante.estimuloBasico != null)
			{
				switch (ReactorSegundario.PartePrincipalEstimulada(calculoDeInteracionEstimulante, false))
				{
				case ParteDelCuerpoHumano.labios:
				case ParteDelCuerpoHumano.ojos:
				case ParteDelCuerpoHumano.axilas:
				case ParteDelCuerpoHumano.vientre:
				case ParteDelCuerpoHumano.hombligo:
				case ParteDelCuerpoHumano.piernas:
					num *= 1.05f;
					break;
				case ParteDelCuerpoHumano.bocaInterno:
				case ParteDelCuerpoHumano.vag:
				case ParteDelCuerpoHumano.lengua:
					num *= 1.15f;
					break;
				case ParteDelCuerpoHumano.globosOculares:
				case ParteDelCuerpoHumano.labiosVaginales:
				case ParteDelCuerpoHumano.clitoris:
				case ParteDelCuerpoHumano.pene:
				case ParteDelCuerpoHumano.testiculos:
					num *= 1.25f;
					break;
				case ParteDelCuerpoHumano.senos:
				case ParteDelCuerpoHumano.coxis:
				case ParteDelCuerpoHumano.nalgas:
				case ParteDelCuerpoHumano.vientreBajo:
					num *= 1.1f;
					break;
				case ParteDelCuerpoHumano.pezones:
				case ParteDelCuerpoHumano.perineo:
				case ParteDelCuerpoHumano.ano:
					num *= 1.2f;
					break;
				}
			}
			if (calculoDeEstimuloDeParteEstimulante != null)
			{
				ParteQuePuedeEstimular estimulanteParte = calculoDeEstimuloDeParteEstimulante.estimulanteParte;
				if (estimulanteParte <= ParteQuePuedeEstimular.propSexToy)
				{
					if (estimulanteParte == ParteQuePuedeEstimular.pene || estimulanteParte == ParteQuePuedeEstimular.propSexToy)
					{
						num *= 1.1f;
					}
				}
				else if (estimulanteParte == ParteQuePuedeEstimular.lengua || estimulanteParte == ParteQuePuedeEstimular.boca)
				{
					num *= 1.05f;
				}
			}
			w = w.OutPow(num);
		}

		// Token: 0x0600142C RID: 5164 RVA: 0x0005E678 File Offset: 0x0005C878
		protected float WeightPorEmocion(ICalculoDeEstimulo calculo)
		{
			float num = Mathf.Lerp(0.5f, 1f, calculo.emocion.value.mod);
			float weightPorMuecas = this.weightPorMuecas;
			return Mathf.Lerp(0.5f, weightPorMuecas, num);
		}

		// Token: 0x0600142D RID: 5165 RVA: 0x0005E6BC File Offset: 0x0005C8BC
		protected void Parcer(ICalculoDeEstimulo calculo, ReaccionHumana reaccionEnum, List<ControlladorDeGestosFacialesEmocionales.TipoDeExpresion> tiposResult, List<float> modsResult)
		{
			if (reaccionEnum <= ReaccionHumana.miedo)
			{
				if (reaccionEnum <= ReaccionHumana.placer)
				{
					switch (reaccionEnum)
					{
					case ReaccionHumana.None:
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro:
					case ReaccionHumana.concentToHero | ReaccionHumana.dolor:
					case ReaccionHumana.asombro | ReaccionHumana.dolor:
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro | ReaccionHumana.dolor:
						break;
					case ReaccionHumana.concentToHero:
						tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria);
						tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
						modsResult.Add(0.2f);
						modsResult.Add(0.1f);
						return;
					case ReaccionHumana.asombro:
						return;
					case ReaccionHumana.dolor:
						tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor);
						modsResult.Add(1f);
						return;
					case ReaccionHumana.rabia:
						if (this.dependencias.consentForzado.EsCorrupted(calculo))
						{
							tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia);
							tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo);
							tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor);
							modsResult.Add(0.3333f);
							modsResult.Add(0.3333f);
							modsResult.Add(0.3333f);
							return;
						}
						tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia);
						modsResult.Add(1f);
						return;
					default:
						if (reaccionEnum == ReaccionHumana.asco)
						{
							return;
						}
						if (reaccionEnum == ReaccionHumana.placer)
						{
							tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
							modsResult.Add(1f);
							return;
						}
						break;
					}
				}
				else
				{
					if (reaccionEnum == ReaccionHumana.arousal)
					{
						tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
						tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria);
						modsResult.Add(0.35f);
						modsResult.Add(0.15f);
						return;
					}
					if (reaccionEnum == ReaccionHumana.tristeza)
					{
						return;
					}
					if (reaccionEnum == ReaccionHumana.miedo)
					{
						tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo);
						modsResult.Add(1f);
						return;
					}
				}
			}
			else if (reaccionEnum <= ReaccionHumana.decepcion)
			{
				if (reaccionEnum == ReaccionHumana.alegria)
				{
					tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria);
					modsResult.Add(1f);
					return;
				}
				if (reaccionEnum == ReaccionHumana.felicidad)
				{
					tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria);
					modsResult.Add(0.4f);
					tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
					modsResult.Add(0.1f);
					return;
				}
				if (reaccionEnum == ReaccionHumana.decepcion)
				{
					tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor);
					tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia);
					modsResult.Add(0.1f);
					modsResult.Add(0.1f);
					return;
				}
			}
			else
			{
				if (reaccionEnum == ReaccionHumana.alivio || reaccionEnum == ReaccionHumana.aburrimiento)
				{
					return;
				}
				if (reaccionEnum == ReaccionHumana.desHielo)
				{
					tiposResult.Add(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo);
					modsResult.Add(0.3333f);
					return;
				}
			}
			throw new ArgumentOutOfRangeException(reaccionEnum.ToString());
		}

		// Token: 0x04000E79 RID: 3705
		public ReactorGestosFacialesBase<TCalculo>.Config config = new ReactorGestosFacialesBase<TCalculo>.Config();

		// Token: 0x04000E7A RID: 3706
		public DependenciasGestosFaciales dependencias = new DependenciasGestosFaciales();

		// Token: 0x0200031A RID: 794
		[Serializable]
		public class Config
		{
			// Token: 0x04000E7B RID: 3707
			public float duration = 2f;

			// Token: 0x04000E7C RID: 3708
			public float durationRandom = 0.5f;
		}
	}
}
