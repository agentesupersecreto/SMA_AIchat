using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Personalidades.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Textos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x02000359 RID: 857
	public class Personalidad : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06001275 RID: 4725 RVA: 0x00050131 File Offset: 0x0004E331
		public bool mapaSonClones
		{
			get
			{
				return !Application.isEditor || this.clonarMapasDePersonalidad;
			}
		}

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06001276 RID: 4726 RVA: 0x00050142 File Offset: 0x0004E342
		public EmocionesFemeninas emos
		{
			get
			{
				return this.m_emos;
			}
		}

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06001277 RID: 4727 RVA: 0x0005014A File Offset: 0x0004E34A
		public Deseos deseos
		{
			get
			{
				return this.m_Deseos;
			}
		}

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06001278 RID: 4728 RVA: 0x00050154 File Offset: 0x0004E354
		private List<Personalidad.Trait> m_traits
		{
			get
			{
				List<Personalidad.Trait> traits;
				try
				{
					traits = this.m_currentPersonalidad.personalidad.traits;
				}
				catch (Exception)
				{
					throw;
				}
				return traits;
			}
		}

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06001279 RID: 4729 RVA: 0x00050188 File Offset: 0x0004E388
		public CollecionDeMapasDePersonalidad.PersonalidadCompleta currentPersonalidad
		{
			get
			{
				return this.m_currentPersonalidad;
			}
		}

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x0600127A RID: 4730 RVA: 0x00050190 File Offset: 0x0004E390
		public Character character
		{
			get
			{
				return this.m_character;
			}
		}

		// Token: 0x0600127B RID: 4731 RVA: 0x00050198 File Offset: 0x0004E398
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (!Application.isEditor)
			{
				this.clonarMapasDePersonalidad = true;
			}
			this.m_character = this.GetComponentEnRoot(false);
			this.m_emos = this.GetComponentEnCharacter(false);
			if (this.m_emos == null)
			{
				throw new ArgumentNullException("m_emos", "m_emos null reference.");
			}
			this.m_Deseos = this.GetComponentEnCharacter(false);
			if (this.m_Deseos == null)
			{
				throw new ArgumentNullException("m_Deseos", "m_Deseos null reference.");
			}
			this.m_character.loadingAI += this.M_character_loadingAI;
			base.SetManualStart();
			this.m_emos.SetManualStart();
		}

		// Token: 0x0600127C RID: 4732 RVA: 0x00050244 File Offset: 0x0004E444
		private void M_character_loadingAI(Character obj)
		{
			base.ManualStart();
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x0005024C File Offset: 0x0004E44C
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.ReconstruirPersonalidad();
			this.m_emos.ManualStart();
		}

		// Token: 0x0600127E RID: 4734 RVA: 0x00050268 File Offset: 0x0004E468
		public void ReconstruirPersonalidad()
		{
			if (this.m_currentPersonalidad.emociones == null)
			{
				Personalidad.SetMapa<MapaDeEmociones>(ref this.m_currentPersonalidad.emociones, Singleton<CollecionDeMapasDePersonalidad>.instance.@default.emociones, this.clonarMapasDePersonalidad);
			}
			else
			{
				Personalidad.SetMapa<MapaDeEmociones>(ref this.m_currentPersonalidad.emociones, this.m_currentPersonalidad.emociones, this.clonarMapasDePersonalidad);
			}
			if (this.m_currentPersonalidad.personalidad == null)
			{
				Personalidad.SetMapa<MapaDePersonalidad>(ref this.m_currentPersonalidad.personalidad, Singleton<CollecionDeMapasDePersonalidad>.instance.@default.personalidad, this.clonarMapasDePersonalidad);
			}
			else
			{
				Personalidad.SetMapa<MapaDePersonalidad>(ref this.m_currentPersonalidad.personalidad, this.m_currentPersonalidad.personalidad, this.clonarMapasDePersonalidad);
			}
			if (this.m_currentPersonalidad.deseos == null)
			{
				Personalidad.SetMapa<MapaDeDeseos>(ref this.m_currentPersonalidad.deseos, Singleton<CollecionDeMapasDePersonalidad>.instance.@default.deseos, this.clonarMapasDePersonalidad);
			}
			else
			{
				Personalidad.SetMapa<MapaDeDeseos>(ref this.m_currentPersonalidad.deseos, this.m_currentPersonalidad.deseos, this.clonarMapasDePersonalidad);
			}
			this.m_emos.mapas = this.m_currentPersonalidad.emociones;
			this.UpdateTraitsList();
		}

		// Token: 0x0600127F RID: 4735 RVA: 0x000503A4 File Offset: 0x0004E5A4
		private void UpdateTraitsList()
		{
			this.m_traitsDic = new DiccionaryEnum<TraitHumano, Personalidad.Trait>((TraitHumano h) => (int)h);
			foreach (Personalidad.Trait trait in this.m_traits)
			{
				if (this.m_traitsDic.ContainsKey(trait.trait))
				{
					Debug.LogWarning("Trait repetido: " + trait.ToString(), base.gameObject);
				}
				else
				{
					this.m_traitsDic.Add(trait.trait, trait.Copia());
				}
			}
		}

		// Token: 0x06001280 RID: 4736 RVA: 0x00050464 File Offset: 0x0004E664
		private static void SetMapa<T>(ref T targetRef, T source, bool clonar) where T : ICloneable
		{
			if (clonar || (!Application.isEditor && !Debug.isDebugBuild))
			{
				targetRef = (T)((object)source.Clone());
			}
			else
			{
				targetRef = source;
			}
			if (!Application.isEditor && !Debug.isDebugBuild && !clonar)
			{
				Debug.LogWarning("Clonar Mapas de tipo " + typeof(T).Name + " debe ser true para builds");
			}
		}

		// Token: 0x06001281 RID: 4737 RVA: 0x000504D8 File Offset: 0x0004E6D8
		public void SetGrupoDePrivadaEstimulable(GrupoQueCompartenValores grupoEnum, ParteDelCuerpoHumano parte, TipoDeEstimulo tipo)
		{
			if (tipo == TipoDeEstimulo.tactil)
			{
				Personalidad.SetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesHumanas.privacidad, grupoEnum, parte);
				return;
			}
			if (tipo == TipoDeEstimulo.visual)
			{
				Personalidad.SetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesHumanas.privacidadVisual, grupoEnum, parte);
				return;
			}
			throw new ArgumentOutOfRangeException(tipo.ToString() + " solo se an desarrollado grupos normales y visuales");
		}

		// Token: 0x06001282 RID: 4738 RVA: 0x00050544 File Offset: 0x0004E744
		public void SetGrupoDeErogenaEstimulable(GrupoQueCompartenValores grupoEnum, ParteDelCuerpoHumano parte, TipoDeEstimulo tipo)
		{
			if (tipo == TipoDeEstimulo.tactil)
			{
				Personalidad.SetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesHumanas.erogeno, grupoEnum, parte);
				return;
			}
			if (tipo == TipoDeEstimulo.visual)
			{
				Personalidad.SetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesHumanas.erogenoVisual, grupoEnum, parte);
				return;
			}
			throw new ArgumentOutOfRangeException(tipo.ToString() + " solo se an desarrollado grupos normales y visuales");
		}

		// Token: 0x06001283 RID: 4739 RVA: 0x000505AF File Offset: 0x0004E7AF
		public void SetGrupoDeSensibilidadEstimulable(GrupoQueCompartenValores grupoEnum, ParteDelCuerpoHumano parte, TipoDeEstimulo tipo)
		{
			if (tipo == TipoDeEstimulo.tactil)
			{
				Personalidad.SetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesHumanas.seinsibilidad, grupoEnum, parte);
				return;
			}
			throw new ArgumentOutOfRangeException(tipo.ToString() + " solo se an desarrollado grupos normales y visuales, sensibilidad NO puede ser visual, solo alguna tactil");
		}

		// Token: 0x06001284 RID: 4740 RVA: 0x000505EE File Offset: 0x0004E7EE
		public void SetGrupoDePrivadaEstimulante(GrupoQueCompartenValores grupoEnum, ParteQuePuedeEstimular parteEstimualnte)
		{
			Personalidad.SetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesEstimulantes.privacidad, grupoEnum, parteEstimualnte);
		}

		// Token: 0x06001285 RID: 4741 RVA: 0x0005060C File Offset: 0x0004E80C
		public void SetGrupoDeErogenaEstimulante(GrupoQueCompartenValores grupoEnum, ParteQuePuedeEstimular parteEstimualnte)
		{
			Personalidad.SetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesEstimulantes.erogeno, grupoEnum, parteEstimualnte);
		}

		// Token: 0x06001286 RID: 4742 RVA: 0x0005062A File Offset: 0x0004E82A
		public void SetGrupoDeSensibilidadEstimulante(GrupoQueCompartenValores grupoEnum, ParteQuePuedeEstimular parteEstimualnte)
		{
			Personalidad.SetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesEstimulantes.seinsibilidad, grupoEnum, parteEstimualnte);
		}

		// Token: 0x06001287 RID: 4743 RVA: 0x00050648 File Offset: 0x0004E848
		public GrupoQueCompartenValores GetGrupoDePrivadaEstimulable(ParteDelCuerpoHumano parte, TipoDeEstimulo tipo)
		{
			switch (tipo)
			{
			case TipoDeEstimulo.tactil:
				return Personalidad.GetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesHumanas.privacidad, parte);
			case TipoDeEstimulo.visual:
				return Personalidad.GetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesHumanas.privacidadVisual, parte);
			}
			throw new ArgumentOutOfRangeException(tipo.ToString() + " solo se an desarrollado grupos normales y visuales");
		}

		// Token: 0x06001288 RID: 4744 RVA: 0x000506C4 File Offset: 0x0004E8C4
		public GrupoQueCompartenValores GetGrupoDeErogenaEstimulable(ParteDelCuerpoHumano parte, TipoDeEstimulo tipo)
		{
			switch (tipo)
			{
			case TipoDeEstimulo.tactil:
				return Personalidad.GetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesHumanas.erogeno, parte);
			case TipoDeEstimulo.visual:
				return Personalidad.GetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesHumanas.erogenoVisual, parte);
			}
			throw new ArgumentOutOfRangeException(tipo.ToString() + " solo se an desarrollado grupos normales y visuales");
		}

		// Token: 0x06001289 RID: 4745 RVA: 0x0005073D File Offset: 0x0004E93D
		public GrupoQueCompartenValores GetGrupoDeSensibilidadEstimulable(ParteDelCuerpoHumano parte, TipoDeEstimulo tipo)
		{
			if (tipo == TipoDeEstimulo.tactil)
			{
				return Personalidad.GetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesHumanas.seinsibilidad, parte);
			}
			throw new ArgumentOutOfRangeException(tipo.ToString() + " solo se an desarrollado grupos normales y visuales, sensibilidad NO puede ser visual, solo alguna tactil");
		}

		// Token: 0x0600128A RID: 4746 RVA: 0x0005077B File Offset: 0x0004E97B
		public GrupoQueCompartenValores GetGrupoDePrivadaEstimulante(ParteQuePuedeEstimular parteEstimualnte)
		{
			return Personalidad.GetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesEstimulantes.privacidad, parteEstimualnte);
		}

		// Token: 0x0600128B RID: 4747 RVA: 0x00050798 File Offset: 0x0004E998
		public GrupoQueCompartenValores GetGrupoDeErogenaEstimulante(ParteQuePuedeEstimular parteEstimualnte)
		{
			return Personalidad.GetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesEstimulantes.erogeno, parteEstimualnte);
		}

		// Token: 0x0600128C RID: 4748 RVA: 0x000507B5 File Offset: 0x0004E9B5
		public GrupoQueCompartenValores GetGrupoDeSensibilidadEstimulante(ParteQuePuedeEstimular parteEstimualnte)
		{
			return Personalidad.GetGrupo(this.m_currentPersonalidad.emociones.gruposDePartesEstimulantes.seinsibilidad, parteEstimualnte);
		}

		// Token: 0x0600128D RID: 4749 RVA: 0x000507D2 File Offset: 0x0004E9D2
		private static GrupoQueCompartenValores GetGrupo(PartesHumanasPorGrupo grupo, ParteDelCuerpoHumano parte)
		{
			return grupo.GetGrupoDeParte(parte);
		}

		// Token: 0x0600128E RID: 4750 RVA: 0x000507DB File Offset: 0x0004E9DB
		private static GrupoQueCompartenValores GetGrupo(PartesEstimulantePorGrupo grupo, ParteQuePuedeEstimular parte)
		{
			return grupo.GetGrupoDeParte(parte);
		}

		// Token: 0x0600128F RID: 4751 RVA: 0x000507E4 File Offset: 0x0004E9E4
		private static void SetGrupo(PartesHumanasPorGrupo grupo, GrupoQueCompartenValores grupoEnum, ParteDelCuerpoHumano parte)
		{
			grupo.SetGrupoDeParte(parte, grupoEnum);
		}

		// Token: 0x06001290 RID: 4752 RVA: 0x000507EE File Offset: 0x0004E9EE
		private static void SetGrupo(PartesEstimulantePorGrupo grupo, GrupoQueCompartenValores grupoEnum, ParteQuePuedeEstimular parte)
		{
			grupo.SetGrupoDeParte(parte, grupoEnum);
		}

		// Token: 0x06001291 RID: 4753 RVA: 0x000507F8 File Offset: 0x0004E9F8
		public HumanTraitScore GetTraitScore(TraitHumano trait)
		{
			if (this.m_traitsDic == null)
			{
				this.UpdateTraitsList();
			}
			Personalidad.Trait trait2;
			if (this.m_traitsDic.TryGetValue(trait, out trait2))
			{
				return trait2.score;
			}
			Personalidad.Trait trait3 = new Personalidad.Trait();
			trait3.score = HumanTraitScore.normal;
			trait3.trait = trait;
			this.m_traitsDic.Add(trait, trait3);
			return trait3.score;
		}

		// Token: 0x06001292 RID: 4754 RVA: 0x00050854 File Offset: 0x0004EA54
		public float GetModPorTraitHumano(TraitHumano trait, float normalValue = 1f, float distancePerLevel = 0.1f, float mod = 1f)
		{
			HumanTraitScore traitScore = this.GetTraitScore(trait);
			switch (traitScore)
			{
			case HumanTraitScore.normal:
				return normalValue * mod;
			case HumanTraitScore.alto:
				return (normalValue + distancePerLevel) * mod;
			case HumanTraitScore.muyAlto:
				return (normalValue + distancePerLevel * 2f) * mod;
			case HumanTraitScore.bajo:
				return 1f / (normalValue + distancePerLevel) * mod;
			case HumanTraitScore.muyBajo:
				return 1f / (normalValue + distancePerLevel * 2f) * mod;
			default:
				throw new ArgumentOutOfRangeException(traitScore.ToString());
			}
		}

		// Token: 0x06001293 RID: 4755 RVA: 0x000508D0 File Offset: 0x0004EAD0
		public void SetTraitScore(TraitHumano trait, HumanTraitScore score)
		{
			if (this.m_traitsDic == null)
			{
				this.UpdateTraitsList();
			}
			Personalidad.Trait trait2;
			if (this.m_traitsDic.TryGetValue(trait, out trait2))
			{
				trait2.score = score;
				return;
			}
			Personalidad.Trait trait3 = new Personalidad.Trait();
			trait3.score = score;
			trait3.trait = trait;
			this.m_traitsDic.Add(trait, trait3);
		}

		// Token: 0x06001294 RID: 4756 RVA: 0x00050924 File Offset: 0x0004EB24
		public int IntensidadSpot(ref UmbralBasico.Estado estado)
		{
			if (estado.rango == UmbralBasico.RangoEstado.sinEstimulo)
			{
				return 0;
			}
			float deshonestidad = this.deshonestidad;
			int num;
			switch (estado.spotRango)
			{
			case UmbralBasico.RangoEstado.sinEstimulo:
				if (estado.rango == UmbralBasico.RangoEstado.porEncima)
				{
					num = 1;
				}
				else
				{
					num = -1;
				}
				break;
			case UmbralBasico.RangoEstado.enRango:
				num = 0;
				break;
			case UmbralBasico.RangoEstado.porDebajo:
				num = -1;
				break;
			case UmbralBasico.RangoEstado.porEncima:
				num = 1;
				break;
			default:
				throw new ArgumentOutOfRangeException(estado.spotRango.ToString());
			}
			if (deshonestidad <= 0.3333333f)
			{
				return num;
			}
			if (!Mathf.InverseLerp(0.3333333f, 1f, deshonestidad).ProcMod(1f))
			{
				return num;
			}
			return 1;
		}

		// Token: 0x06001295 RID: 4757 RVA: 0x000509BE File Offset: 0x0004EBBE
		public bool InterestedInModeling(out float modelingScore)
		{
			modelingScore = this.GetTraitScore(TraitHumano.gustoPorModelaje).GetWeigthDeScore();
			return modelingScore >= 0.75f;
		}

		// Token: 0x06001296 RID: 4758 RVA: 0x000509DB File Offset: 0x0004EBDB
		public bool InterestedInLingerieModeling(out float lingerieModelingScore)
		{
			lingerieModelingScore = this.GetTraitScore(TraitHumano.gustoPorModelajeUnderwear).GetWeigthDeScore() * this.GetTraitScore(TraitHumano.gustoPorModelaje).GetWeigthDeScore();
			return lingerieModelingScore >= 0.75f;
		}

		// Token: 0x06001297 RID: 4759 RVA: 0x00050A06 File Offset: 0x0004EC06
		public bool InterestedInEroticModeling(out float eroticModelingScore)
		{
			eroticModelingScore = this.GetTraitScore(TraitHumano.gustoPorModelajeHerotico).GetWeigthDeScore() * this.GetTraitScore(TraitHumano.gustoPorModelajeUnderwear).GetWeigthDeScore() * this.GetTraitScore(TraitHumano.gustoPorModelaje).GetWeigthDeScore();
			return eroticModelingScore >= 0.75f;
		}

		// Token: 0x06001298 RID: 4760 RVA: 0x00050A40 File Offset: 0x0004EC40
		public static void GetPreferredTreatmentForClientsWeights(HumanTraitScore nonSexualScoreEnum, HumanTraitScore softCoreScoreEnum, HumanTraitScore hardcoreScoreEnum, out float nonSexual, out float softCore, out float hardcore)
		{
			float weigthDeScore = nonSexualScoreEnum.GetWeigthDeScore();
			float weigthDeScore2 = softCoreScoreEnum.GetWeigthDeScore();
			float weigthDeScore3 = hardcoreScoreEnum.GetWeigthDeScore();
			nonSexual = MathfExtension.LerpConMedio(-1f, 0.0001f, 1f, weigthDeScore);
			softCore = MathfExtension.LerpConMedio(-1f, 0.0001f, 1f, weigthDeScore2);
			hardcore = MathfExtension.LerpConMedio(-1f, 0.0001f, 1f, weigthDeScore3);
			softCore = ((hardcore > 0f) ? Mathf.Clamp(softCore, 0.0001f, 1f) : softCore);
			nonSexual = ((softCore > 0f) ? Mathf.Clamp(nonSexual, 0.0001f, 1f) : nonSexual);
			nonSexual = Mathf.Clamp01(nonSexual);
			softCore = Mathf.Clamp01(softCore);
			hardcore = Mathf.Clamp01(hardcore);
		}

		// Token: 0x06001299 RID: 4761 RVA: 0x00050B0D File Offset: 0x0004ED0D
		public void GetPreferredTreatmentForClientsWeights(out float nonSexual, out float softCore, out float hardcore)
		{
			Personalidad.GetPreferredTreatmentForClientsWeights(this.GetTraitScore(TraitHumano.gustoPorTratoDeClientes), this.GetTraitScore(TraitHumano.gustoPorTratoEspecialDeClientes), this.GetTraitScore(TraitHumano.gustoPorTratoExplicitoDeClientes), out nonSexual, out softCore, out hardcore);
		}

		// Token: 0x0600129A RID: 4762 RVA: 0x00050B2F File Offset: 0x0004ED2F
		[Obsolete("debe implementarse de una forma mas profunda, no como post procesado, ej: cambiar los calculos generados de placer a rage", true)]
		public bool EsNegativo(ReaccionHumana reaccion)
		{
			return !reaccion.EsPositiva();
		}

		// Token: 0x0600129B RID: 4763 RVA: 0x00050B3C File Offset: 0x0004ED3C
		public bool EsPrivada(ParteDelCuerpoHumano parte, TipoDeEstimulo tipo)
		{
			bool flag;
			switch (tipo)
			{
			case TipoDeEstimulo.tactil:
			case TipoDeEstimulo.agarrante:
				flag = parte.EsPrivadaSocialmenteTactil();
				goto IL_0074;
			case TipoDeEstimulo.visual:
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.peticionDesvestidura:
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
			case TipoDeEstimulo.manipulandoBone:
				flag = parte.EsPrivadaSocialmenteVisual();
				goto IL_0074;
			case TipoDeEstimulo.coital:
				flag = parte.EsPrivadaSocialmenteCoital();
				goto IL_0074;
			}
			throw new ArgumentOutOfRangeException(tipo.ToString());
			IL_0074:
			float num = Mathf.Max(this.exhibicionismo, this.perverticidad);
			if (num > 0.3333333f)
			{
				return !Mathf.InverseLerp(0.3333333f, 1f, num).ProcMod(1f) && flag;
			}
			return flag;
		}

		// Token: 0x0600129C RID: 4764 RVA: 0x00050BF8 File Offset: 0x0004EDF8
		public RestriccionDeEdad ObtenerRestriccion()
		{
			PersonalidadDinamica rasgos = this.currentPersonalidad.personalidad.rasgos;
			float num = rasgos.Get(PersonalidadRasgo.concienciaNormativa) / 100f;
			float num2 = rasgos.Get(PersonalidadRasgo.aperturaAlCambio) / 100f - num;
			num2 = Mathf.Clamp(num2, -1f, 1f);
			float num3 = Mathf.InverseLerp(-1f, 1f, num2).OutPow(1.2f);
			switch (Mathf.RoundToInt(Mathf.Lerp(0.51f, 3.49f, num3)))
			{
			case 1:
				return RestriccionDeEdad.pelados;
			case 2:
				return RestriccionDeEdad.adolecentes;
			case 3:
				return RestriccionDeEdad.adultos;
			default:
				return RestriccionDeEdad.None;
			}
		}

		// Token: 0x0600129D RID: 4765 RVA: 0x00050C98 File Offset: 0x0004EE98
		public float CalcularModificadorDeRespuesta(out float overFlowMod, Personalidad.TipoDeRespuestaDeDialogoDePlayer tipo, float puntajeDeTipo, float modExpancion = 1f)
		{
			if (tipo == Personalidad.TipoDeRespuestaDeDialogoDePlayer.None)
			{
				throw new NotSupportedException();
			}
			puntajeDeTipo = Mathf.Clamp(puntajeDeTipo, 0f, 100f);
			HumanTraitScore humanTraitScore;
			switch (tipo)
			{
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.normal:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorNormales);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.timida:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorTimidos);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.intelectual:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorIntelectuales);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.pedante:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorPatanes);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.confiada:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorConfiados);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.pervertida:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorPervertidos);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.mLady:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorAutistas);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.lujosa:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorDinero);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.humilde:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorHumildad);
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			RangeValueV2 rangeValueV;
			switch (humanTraitScore)
			{
			case HumanTraitScore.normal:
				rangeValueV = new RangeValueV2(0.0001f, 30f);
				break;
			case HumanTraitScore.alto:
				rangeValueV = new RangeValueV2(0.0001f, 65f);
				break;
			case HumanTraitScore.muyAlto:
				rangeValueV = new RangeValueV2(0.0001f, 100f);
				break;
			case HumanTraitScore.bajo:
				rangeValueV = new RangeValueV2(0.0001f, 15f);
				break;
			case HumanTraitScore.muyBajo:
				rangeValueV = new RangeValueV2(0.0001f, 2f);
				break;
			default:
				throw new ArgumentOutOfRangeException(humanTraitScore.ToString());
			}
			rangeValueV.Expandir(modExpancion, 0.0001f);
			UmbralBasico.Estado estado = UmbralBasico.Calcular(puntajeDeTipo, Time.deltaTime, UmbralBasico.TipoDeCambio.unico, rangeValueV, 1f, SpotBonuses.none, 0.99f, 0f, 0f);
			if (estado.rango == UmbralBasico.RangoEstado.enRango)
			{
				overFlowMod = 0f;
			}
			else
			{
				overFlowMod = estado.offsetMod;
			}
			return estado.estimulacionGeneradaEnFrame.OutPow(3f);
		}

		// Token: 0x0600129E RID: 4766 RVA: 0x00050E54 File Offset: 0x0004F054
		public void CalcularModificadorDeRespuestaV2(out float mod, out float overFlowMod, Personalidad.TipoDeRespuestaDeDialogoDePlayer tipo, float puntajeDeTipo, float modExpancion = 1f)
		{
			if (tipo == Personalidad.TipoDeRespuestaDeDialogoDePlayer.None)
			{
				throw new NotSupportedException();
			}
			float num = MathfExtension.LerpConMedio(0.8333333f, 1f, 1.2f, this.sumicion);
			puntajeDeTipo = Mathf.Clamp(puntajeDeTipo, 0f, 100f);
			HumanTraitScore humanTraitScore;
			switch (tipo)
			{
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.normal:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorNormales);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.timida:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorTimidos);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.intelectual:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorIntelectuales);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.pedante:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorPatanes);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.confiada:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorConfiados);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.pervertida:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorPervertidos);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.mLady:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorAutistas);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.lujosa:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorDinero);
				break;
			case Personalidad.TipoDeRespuestaDeDialogoDePlayer.humilde:
				humanTraitScore = this.GetTraitScore(TraitHumano.gustoPorHumildad);
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			RangeValueV2 rangeValueV;
			switch (humanTraitScore)
			{
			case HumanTraitScore.normal:
				rangeValueV = new RangeValueV2(0.0001f, 25f);
				break;
			case HumanTraitScore.alto:
				rangeValueV = new RangeValueV2(0.0001f, 55f);
				break;
			case HumanTraitScore.muyAlto:
				rangeValueV = new RangeValueV2(0.0001f, 100f);
				break;
			case HumanTraitScore.bajo:
				rangeValueV = new RangeValueV2(0.0001f, 12f);
				break;
			case HumanTraitScore.muyBajo:
				rangeValueV = new RangeValueV2(0.0001f, 5f);
				break;
			default:
				throw new ArgumentOutOfRangeException(humanTraitScore.ToString());
			}
			rangeValueV.Expandir(modExpancion * num, 0.0001f);
			UmbralBasico.Estado estado = UmbralBasico.Calcular(puntajeDeTipo, Time.deltaTime, UmbralBasico.TipoDeCambio.unico, rangeValueV, 1f, SpotBonuses.none, 1f, 0f, 0f);
			if (estado.rango == UmbralBasico.RangoEstado.porEncima && estado.offsetMod >= 1f)
			{
				overFlowMod = estado.offsetMod - 1f;
			}
			else
			{
				overFlowMod = 0f;
			}
			mod = estado.estimulacionGeneradaEnFrame.OutPow(2f);
		}

		// Token: 0x0600129F RID: 4767 RVA: 0x00051044 File Offset: 0x0004F244
		public Personalidad.TipoDeRespuestaDeDialogoDeHeroina ObtenerTipoDeRespuestaSegunPersonalidadYEmociones()
		{
			float num = 0.3333333f;
			float perverticidad = this.perverticidad;
			float iRespeto = this.iRespeto;
			float timidez = this.timidez;
			Personalidad.m_ArrayTempTipoDeRespuesta[0] = new ValueTuple<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, float>(Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable, num);
			Personalidad.m_ArrayTempTipoDeRespuesta[1] = new ValueTuple<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, float>(Personalidad.TipoDeRespuestaDeDialogoDeHeroina.pervertida, perverticidad);
			Personalidad.m_ArrayTempTipoDeRespuesta[2] = new ValueTuple<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, float>(Personalidad.TipoDeRespuestaDeDialogoDeHeroina.grosera, iRespeto);
			Personalidad.m_ArrayTempTipoDeRespuesta[3] = new ValueTuple<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, float>(Personalidad.TipoDeRespuestaDeDialogoDeHeroina.timida, timidez);
			return Personalidad.m_ArrayTempTipoDeRespuesta.MaxByOrDefault((ValueTuple<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, float> par) => par.Item2).Item1;
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x060012A0 RID: 4768 RVA: 0x000510E2 File Offset: 0x0004F2E2
		public float alegriaGananciaPorPersonalidad
		{
			get
			{
				return Personalidad.GetEmoGain(this.currentPersonalidad.personalidad.rasgos.Get(PersonalidadRasgo.vivacidad) / 100f, 0.5f, 2f);
			}
		}

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x060012A1 RID: 4769 RVA: 0x00051110 File Offset: 0x0004F310
		public float alivioGananciaPorPersonalidad
		{
			get
			{
				return Personalidad.GetEmoGain(this.currentPersonalidad.personalidad.rasgos.GetInvert(PersonalidadRasgo.tension) / 100f, 0.5f, 2f);
			}
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x060012A2 RID: 4770 RVA: 0x00051141 File Offset: 0x0004F341
		public float arousalGananciaPorPersonalidad
		{
			get
			{
				return Personalidad.GetEmoGain(this.currentPersonalidad.personalidad.rasgos.GetInvert(PersonalidadRasgo.concienciaNormativa) / 100f, 0.5f, 2f);
			}
		}

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x060012A3 RID: 4771 RVA: 0x00051172 File Offset: 0x0004F372
		public float consentGananciaPorPersonalidad
		{
			get
			{
				return Personalidad.GetEmoGain(this.currentPersonalidad.personalidad.rasgos.Get(PersonalidadRasgo.atrevimientoSocial) / 100f, 0.75f, 1.3333334f);
			}
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x060012A4 RID: 4772 RVA: 0x000511A3 File Offset: 0x0004F3A3
		public float decepcionGananciaPorPersonalidad
		{
			get
			{
				return Personalidad.GetEmoGain(this.currentPersonalidad.personalidad.rasgos.Get(PersonalidadRasgo.perfectionismo) / 100f, 0.5f, 2f);
			}
		}

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x060012A5 RID: 4773 RVA: 0x000511D1 File Offset: 0x0004F3D1
		public float desHieloGananciaPorPersonalidad
		{
			get
			{
				return Personalidad.GetEmoGain(this.currentPersonalidad.personalidad.rasgos.Get(PersonalidadRasgo.aperturaAlCambio) / 100f, 0.5f, 2f);
			}
		}

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x060012A6 RID: 4774 RVA: 0x000511FF File Offset: 0x0004F3FF
		public float dolorGananciaPorPersonalidad
		{
			get
			{
				return Personalidad.GetEmoGain(this.currentPersonalidad.personalidad.rasgos.GetInvert(PersonalidadRasgo.resilianza) / 100f, 0.5f, 2f);
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x060012A7 RID: 4775 RVA: 0x00051230 File Offset: 0x0004F430
		public float miedoGananciaPorPersonalidad
		{
			get
			{
				return Personalidad.GetEmoGain(this.currentPersonalidad.personalidad.rasgos.Get(PersonalidadRasgo.preocupacion) / 100f, 0.5f, 2f);
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x060012A8 RID: 4776 RVA: 0x0005125D File Offset: 0x0004F45D
		public float placerGananciaPorPersonalidad
		{
			get
			{
				return Personalidad.GetEmoGain(this.currentPersonalidad.personalidad.rasgos.Get(PersonalidadRasgo.abstraccion) / 100f, 0.6666667f, 1.5f);
			}
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x060012A9 RID: 4777 RVA: 0x0005128A File Offset: 0x0004F48A
		public float rageGananciaPorPersonalidad
		{
			get
			{
				return Personalidad.GetEmoGain(this.currentPersonalidad.personalidad.rasgos.Get(PersonalidadRasgo.dominancia) / 100f, 0.5f, 2f);
			}
		}

		// Token: 0x060012AA RID: 4778 RVA: 0x000512B7 File Offset: 0x0004F4B7
		private static float GetEmoGain(float w, float min = 0.5f, float max = 2f)
		{
			w = w.OutInPow(2f, 2f, 0.5f);
			return MathfExtension.LerpConMedio(min, 1f, max, w);
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x060012AB RID: 4779 RVA: 0x000512E0 File Offset: 0x0004F4E0
		public bool actuaComoDominante
		{
			get
			{
				float num;
				return this.ObtenerMayorSexual(out num) == Personalidad.TipoSexual.dominante && num >= 0.5f;
			}
		}

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x060012AC RID: 4780 RVA: 0x00051308 File Offset: 0x0004F508
		public bool actuaComoMasoquista
		{
			get
			{
				float num;
				return this.ObtenerMayorSexual(out num) == Personalidad.TipoSexual.masoquista && num >= 0.5f;
			}
		}

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x060012AD RID: 4781 RVA: 0x00051330 File Offset: 0x0004F530
		public bool actuaComoHibristofilica
		{
			get
			{
				float num;
				return this.ObtenerMayorSexual(out num) == Personalidad.TipoSexual.hibristofilia && num >= 0.5f;
			}
		}

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x060012AE RID: 4782 RVA: 0x00051358 File Offset: 0x0004F558
		public bool actuaComoSumisa
		{
			get
			{
				float num;
				return this.ObtenerMayorSexual(out num) == Personalidad.TipoSexual.sumisa && num >= 0.5f;
			}
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x060012AF RID: 4783 RVA: 0x0005137D File Offset: 0x0004F57D
		public float dominanciaPorPersonalidad
		{
			get
			{
				return this.currentPersonalidad.personalidad.rasgos.Dominante;
			}
		}

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x060012B0 RID: 4784 RVA: 0x00051394 File Offset: 0x0004F594
		public float masoquismoPorPersonalidad
		{
			get
			{
				return this.currentPersonalidad.personalidad.rasgos.Sensible;
			}
		}

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x060012B1 RID: 4785 RVA: 0x000513AB File Offset: 0x0004F5AB
		public float hibristofiliaPorPersonalidad
		{
			get
			{
				return this.currentPersonalidad.personalidad.rasgos.Preocupacion;
			}
		}

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x060012B2 RID: 4786 RVA: 0x000513C2 File Offset: 0x0004F5C2
		public float sumicionPorPersonalidad
		{
			get
			{
				return this.currentPersonalidad.personalidad.rasgos.Sumiso;
			}
		}

		// Token: 0x060012B3 RID: 4787 RVA: 0x000513DC File Offset: 0x0004F5DC
		public Personalidad.TipoSexual ObtenerMayorSexual(out float w)
		{
			float dominanciaPorPersonalidad = this.dominanciaPorPersonalidad;
			float masoquismoPorPersonalidad = this.masoquismoPorPersonalidad;
			float hibristofiliaPorPersonalidad = this.hibristofiliaPorPersonalidad;
			float sumicionPorPersonalidad = this.sumicionPorPersonalidad;
			MathfExtension.ExagerarWeigths(ref dominanciaPorPersonalidad, ref masoquismoPorPersonalidad, ref hibristofiliaPorPersonalidad, ref sumicionPorPersonalidad, 3f);
			float num = dominanciaPorPersonalidad - (masoquismoPorPersonalidad + hibristofiliaPorPersonalidad + sumicionPorPersonalidad);
			float num2 = masoquismoPorPersonalidad - (dominanciaPorPersonalidad + hibristofiliaPorPersonalidad + sumicionPorPersonalidad);
			float num3 = hibristofiliaPorPersonalidad - (masoquismoPorPersonalidad + dominanciaPorPersonalidad + sumicionPorPersonalidad);
			float num4 = sumicionPorPersonalidad - (masoquismoPorPersonalidad + hibristofiliaPorPersonalidad + dominanciaPorPersonalidad);
			Personalidad.m_ArrayTempTiposSexual[0] = new ValueTuple<Personalidad.TipoSexual, float>(Personalidad.TipoSexual.dominante, num);
			Personalidad.m_ArrayTempTiposSexual[1] = new ValueTuple<Personalidad.TipoSexual, float>(Personalidad.TipoSexual.masoquista, num2);
			Personalidad.m_ArrayTempTiposSexual[2] = new ValueTuple<Personalidad.TipoSexual, float>(Personalidad.TipoSexual.hibristofilia, num3);
			Personalidad.m_ArrayTempTiposSexual[3] = new ValueTuple<Personalidad.TipoSexual, float>(Personalidad.TipoSexual.sumisa, num4);
			ValueTuple<Personalidad.TipoSexual, float> valueTuple = Personalidad.m_ArrayTempTiposSexual.MaxByOrDefault((ValueTuple<Personalidad.TipoSexual, float> par) => par.Item2);
			if (valueTuple.Item2 < 0.3333333f)
			{
				w = 0f;
				return Personalidad.TipoSexual.None;
			}
			w = Mathf.InverseLerp(0.3333333f, 1f, valueTuple.Item2);
			return valueTuple.Item1;
		}

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x060012B4 RID: 4788 RVA: 0x000514E9 File Offset: 0x0004F6E9
		public float perverticidadPorPersonalidad
		{
			get
			{
				return this.currentPersonalidad.personalidad.rasgos.Abierto;
			}
		}

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x060012B5 RID: 4789 RVA: 0x00051500 File Offset: 0x0004F700
		public float desHonestidadPorPersonalidad
		{
			get
			{
				return this.currentPersonalidad.personalidad.rasgos.Desconfiado;
			}
		}

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x060012B6 RID: 4790 RVA: 0x00051517 File Offset: 0x0004F717
		public float honestidadPorPersonalidad
		{
			get
			{
				return this.currentPersonalidad.personalidad.rasgos.Confiado;
			}
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x060012B7 RID: 4791 RVA: 0x0005152E File Offset: 0x0004F72E
		public float timidezPorPersonalidad
		{
			get
			{
				return this.currentPersonalidad.personalidad.rasgos.Timido;
			}
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x060012B8 RID: 4792 RVA: 0x0005137D File Offset: 0x0004F57D
		[Obsolete("reemplazado por dominante", true)]
		public float iRespetoPorPersonalidad
		{
			get
			{
				return this.currentPersonalidad.personalidad.rasgos.Dominante;
			}
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x060012B9 RID: 4793 RVA: 0x00051545 File Offset: 0x0004F745
		public float exhibicionismoPorPersonalidad
		{
			get
			{
				return this.currentPersonalidad.personalidad.rasgos.Desinhibido;
			}
		}

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x060012BA RID: 4794 RVA: 0x0005155C File Offset: 0x0004F75C
		public float extroversionPorPersonalidad
		{
			get
			{
				return this.currentPersonalidad.personalidad.rasgos.Extrovertido;
			}
		}

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x060012BB RID: 4795 RVA: 0x00051573 File Offset: 0x0004F773
		public float optimismoPorPersonalidad
		{
			get
			{
				return this.currentPersonalidad.personalidad.rasgos.Autosuficiencia;
			}
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x060012BC RID: 4796 RVA: 0x0005158A File Offset: 0x0004F78A
		public float amabilidadPorPersonalidad
		{
			get
			{
				return this.currentPersonalidad.personalidad.rasgos.Calidez;
			}
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x060012BD RID: 4797 RVA: 0x000515A1 File Offset: 0x0004F7A1
		public float respetoPorPersonalidad
		{
			get
			{
				return this.currentPersonalidad.personalidad.rasgos.Contenido;
			}
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x060012BE RID: 4798 RVA: 0x000513AB File Offset: 0x0004F5AB
		[Obsolete("reemplazado por pasividad", true)]
		public float terrorPorPersonalidad
		{
			get
			{
				return this.currentPersonalidad.personalidad.rasgos.Preocupacion;
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x060012BF RID: 4799 RVA: 0x000515B8 File Offset: 0x0004F7B8
		public float terrorExgeradoPorEmociones
		{
			get
			{
				float hibristofiliaPorPersonalidad = this.hibristofiliaPorPersonalidad;
				float mod = this.m_emos.fear.value.mod;
				return Mathf.Clamp01(hibristofiliaPorPersonalidad + mod);
			}
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x060012C0 RID: 4800 RVA: 0x000515EC File Offset: 0x0004F7EC
		public float perverticidad
		{
			get
			{
				float perverticidadPorPersonalidad = this.perverticidadPorPersonalidad;
				float num = this.m_emos.arousal.value.mod.InPow(2f);
				return Mathf.Clamp01(perverticidadPorPersonalidad + num * 0.3333333f * 0.5f);
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x060012C1 RID: 4801 RVA: 0x00051638 File Offset: 0x0004F838
		public float perverticidadExgeradoPorEmociones
		{
			get
			{
				float perverticidadPorPersonalidad = this.perverticidadPorPersonalidad;
				float mod = this.m_emos.arousal.value.mod;
				float mod2 = this.m_emos.placer.value.mod;
				return Mathf.Clamp01(perverticidadPorPersonalidad + mod + mod2 * 0.5f);
			}
		}

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x060012C2 RID: 4802 RVA: 0x0005168C File Offset: 0x0004F88C
		public float deshonestidad
		{
			get
			{
				float desHonestidadPorPersonalidad = this.desHonestidadPorPersonalidad;
				float num = this.m_emos.decepcion.value.mod.InPow(2f);
				return Mathf.Clamp01(desHonestidadPorPersonalidad + num * 0.3333333f * 0.666f);
			}
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x060012C3 RID: 4803 RVA: 0x000516D8 File Offset: 0x0004F8D8
		public float honestidad
		{
			get
			{
				float honestidadPorPersonalidad = this.honestidadPorPersonalidad;
				float num = this.m_emos.desHielo.value.mod.InPow(3f);
				float num2 = 1f - this.m_emos.decepcion.value.mod.OutPow(3f);
				return Mathf.Clamp01(honestidadPorPersonalidad + num * 0.3333333f * 0.2f + num2 * 0.3333333f * 0.2f);
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x060012C4 RID: 4804 RVA: 0x00051758 File Offset: 0x0004F958
		public float honestidadScore
		{
			get
			{
				return Mathf.InverseLerp(0.3333333f, 1f, this.honestidad);
			}
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x060012C5 RID: 4805 RVA: 0x0005176F File Offset: 0x0004F96F
		public float deshonestidadScore
		{
			get
			{
				return Mathf.InverseLerp(0.3333333f, 0f, this.honestidad);
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x060012C6 RID: 4806 RVA: 0x00051788 File Offset: 0x0004F988
		public float sumicion
		{
			get
			{
				float sumicionPorPersonalidad = this.sumicionPorPersonalidad;
				float num = this.m_emos.dolor.value.mod.InPow(2f);
				return Mathf.Clamp01(sumicionPorPersonalidad + num * 0.3333333f * 0.666f);
			}
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x060012C7 RID: 4807 RVA: 0x000517D4 File Offset: 0x0004F9D4
		public float sumicionExgeradoPorEmociones
		{
			get
			{
				float sumicionPorPersonalidad = this.sumicionPorPersonalidad;
				float mod = this.m_emos.dolor.value.mod;
				return Mathf.Clamp01(sumicionPorPersonalidad + mod);
			}
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x060012C8 RID: 4808 RVA: 0x00051808 File Offset: 0x0004FA08
		public float timidez
		{
			get
			{
				float timidezPorPersonalidad = this.timidezPorPersonalidad;
				float num = this.m_emos.fear.value.mod.InPow(2f);
				return Mathf.Clamp01(timidezPorPersonalidad + num * 0.3333333f * 0.666f);
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x060012C9 RID: 4809 RVA: 0x00051854 File Offset: 0x0004FA54
		public float timidezExgeradoPorEmociones
		{
			get
			{
				float timidezPorPersonalidad = this.timidezPorPersonalidad;
				float mod = this.m_emos.dolor.value.mod;
				return Mathf.Clamp01(timidezPorPersonalidad + mod);
			}
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x060012CA RID: 4810 RVA: 0x00051888 File Offset: 0x0004FA88
		public float iRespeto
		{
			get
			{
				float dominanciaPorPersonalidad = this.dominanciaPorPersonalidad;
				float num = this.m_emos.rage.value.mod.InPow(2f);
				return Mathf.Clamp01(dominanciaPorPersonalidad + num * 0.3333333f * 0.666f);
			}
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x060012CB RID: 4811 RVA: 0x000518D4 File Offset: 0x0004FAD4
		public float iRespetoExgeradoPorEmociones
		{
			get
			{
				float dominanciaPorPersonalidad = this.dominanciaPorPersonalidad;
				float mod = this.m_emos.rage.value.mod;
				return Mathf.Clamp01(dominanciaPorPersonalidad + mod);
			}
		}

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x060012CC RID: 4812 RVA: 0x00051908 File Offset: 0x0004FB08
		public float exhibicionismo
		{
			get
			{
				float exhibicionismoPorPersonalidad = this.exhibicionismoPorPersonalidad;
				float num = this.m_emos.arousal.value.mod.InPow(3f);
				return Mathf.Clamp01(exhibicionismoPorPersonalidad + num * 0.3333333f * 0.5f);
			}
		}

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x060012CD RID: 4813 RVA: 0x00051954 File Offset: 0x0004FB54
		public float exhibicionismoExgeradoPorEmociones
		{
			get
			{
				float exhibicionismoPorPersonalidad = this.exhibicionismoPorPersonalidad;
				float mod = this.m_emos.arousal.value.mod;
				return Mathf.Clamp01(exhibicionismoPorPersonalidad + mod);
			}
		}

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x060012CE RID: 4814 RVA: 0x00051988 File Offset: 0x0004FB88
		public float extroversion
		{
			get
			{
				float extroversionPorPersonalidad = this.extroversionPorPersonalidad;
				float num = this.m_emos.alegria.value.mod.InPow(2f);
				return Mathf.Clamp01(extroversionPorPersonalidad + num * 0.3333333f * 0.333f);
			}
		}

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x060012CF RID: 4815 RVA: 0x000519D4 File Offset: 0x0004FBD4
		public float extroversionExgeradoPorEmociones
		{
			get
			{
				float extroversionPorPersonalidad = this.extroversionPorPersonalidad;
				float mod = this.m_emos.alegria.value.mod;
				return Mathf.Clamp01(extroversionPorPersonalidad + mod);
			}
		}

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x060012D0 RID: 4816 RVA: 0x00051A08 File Offset: 0x0004FC08
		public float optimismo
		{
			get
			{
				float optimismoPorPersonalidad = this.optimismoPorPersonalidad;
				float num = this.m_emos.alegria.value.mod.InPow(2f);
				return Mathf.Clamp01(optimismoPorPersonalidad + num * 0.3333333f * 0.333f);
			}
		}

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x060012D1 RID: 4817 RVA: 0x00005A42 File Offset: 0x00003C42
		[Obsolete("dividido en respeto y amabilidad", true)]
		public float amabilidadRespeto
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x060012D2 RID: 4818 RVA: 0x00051A54 File Offset: 0x0004FC54
		public float respeto
		{
			get
			{
				float respetoPorPersonalidad = this.respetoPorPersonalidad;
				float num = this.m_emos.desHielo.value.mod.InPow(4f);
				float num2 = 1f - this.m_emos.decepcion.value.mod.OutPow(4f);
				float num3 = 1f - this.m_emos.rage.value.mod.OutPow(4f);
				return Mathf.Clamp01(respetoPorPersonalidad + num * 0.3333333f * 0.25f + num2 * 0.3333333f * 0.25f + num3 * 0.3333333f * 0.25f);
			}
		}

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x060012D3 RID: 4819 RVA: 0x00051B0B File Offset: 0x0004FD0B
		public bool optimista
		{
			get
			{
				return this.optimismo >= 0.3333333f;
			}
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x060012D4 RID: 4820 RVA: 0x00051B1D File Offset: 0x0004FD1D
		public bool timido
		{
			get
			{
				return this.timidez >= 0.3333333f;
			}
		}

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x060012D5 RID: 4821 RVA: 0x00051B2F File Offset: 0x0004FD2F
		public bool extrovertido
		{
			get
			{
				return this.extroversion >= 0.3333333f;
			}
		}

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x060012D6 RID: 4822 RVA: 0x00051B41 File Offset: 0x0004FD41
		public bool sumiso
		{
			get
			{
				return this.sumicion >= 0.3333333f;
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x060012D7 RID: 4823 RVA: 0x00051B53 File Offset: 0x0004FD53
		public bool pervertido
		{
			get
			{
				return this.perverticidad >= 0.3333333f;
			}
		}

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x060012D8 RID: 4824 RVA: 0x00051B65 File Offset: 0x0004FD65
		public bool exhibicionista
		{
			get
			{
				return this.exhibicionismo >= 0.3333333f;
			}
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x060012D9 RID: 4825 RVA: 0x00051B77 File Offset: 0x0004FD77
		public bool respetuoso
		{
			get
			{
				return this.respeto >= 0.3333333f;
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x060012DA RID: 4826 RVA: 0x00051B89 File Offset: 0x0004FD89
		public bool grosero
		{
			get
			{
				return this.iRespeto >= 0.3333333f;
			}
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x060012DB RID: 4827 RVA: 0x00051B9B File Offset: 0x0004FD9B
		public bool honesto
		{
			get
			{
				return this.honestidad >= 0.3333333f;
			}
		}

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x060012DC RID: 4828 RVA: 0x00051BAD File Offset: 0x0004FDAD
		public bool deshonesto
		{
			get
			{
				return this.deshonestidad >= 0.3333333f;
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x060012DD RID: 4829 RVA: 0x00051BBF File Offset: 0x0004FDBF
		public bool amable
		{
			get
			{
				return this.amabilidadPorPersonalidad >= 0.3333333f;
			}
		}

		// Token: 0x060012DE RID: 4830 RVA: 0x00051BD4 File Offset: 0x0004FDD4
		public TraitHumano? ObtenerMayorTrait(IReadOnlyList<TraitHumano> seleccion, float minScore = 0f)
		{
			TraitHumano? traitHumano2;
			try
			{
				for (int i = 1; i < seleccion.Count; i++)
				{
					TraitHumano traitHumano = seleccion[i];
					float weigthDeScore = this.GetTraitScore(traitHumano).GetWeigthDeScore();
					if (weigthDeScore >= minScore)
					{
						this.m_TempTraitHumanoScores.Add(new ValueTuple<TraitHumano, float>(traitHumano, weigthDeScore));
					}
				}
				if (this.m_TempTraitHumanoScores.Count == 0)
				{
					traitHumano2 = null;
					traitHumano2 = traitHumano2;
				}
				else
				{
					ValueTuple<TraitHumano, float> valueTuple = this.m_TempTraitHumanoScores[0];
					TraitHumano traitHumano3 = valueTuple.Item1;
					float num = valueTuple.Item2;
					for (int j = 1; j < this.m_TempTraitHumanoScores.Count; j++)
					{
						ValueTuple<TraitHumano, float> valueTuple2 = this.m_TempTraitHumanoScores[j];
						if (valueTuple2.Item2 > num)
						{
							traitHumano3 = valueTuple2.Item1;
							num = valueTuple2.Item2;
						}
					}
					traitHumano2 = new TraitHumano?(traitHumano3);
				}
			}
			finally
			{
				this.m_TempTraitHumanoScores.Clear();
			}
			return traitHumano2;
		}

		// Token: 0x060012DF RID: 4831 RVA: 0x00051CC0 File Offset: 0x0004FEC0
		public Personalidad.Tipo ObtenerTipoMayor(bool IgnorarEmociones, ICollection<int> seleccion = null, bool seleccionEsParaIgnorar = true)
		{
			Personalidad.Tipo tipo3;
			try
			{
				IReadOnlyList<int> enumValoresInt = typeof(Personalidad.Tipo).GetEnumValoresInt();
				for (int i = 0; i < enumValoresInt.Count; i++)
				{
					Personalidad.Tipo tipo = (Personalidad.Tipo)enumValoresInt[i];
					if (tipo != Personalidad.Tipo.All)
					{
						if (seleccion != null)
						{
							bool flag = seleccion.Contains(enumValoresInt[i]);
							if ((seleccionEsParaIgnorar && flag) || (!seleccionEsParaIgnorar && !flag))
							{
								goto IL_018C;
							}
						}
						float num;
						if (tipo <= Personalidad.Tipo.exhibicionista)
						{
							switch (tipo)
							{
							case Personalidad.Tipo.None:
							case Personalidad.Tipo.neutral:
								num = 0f;
								break;
							case Personalidad.Tipo.timido:
								num = (IgnorarEmociones ? this.timidezPorPersonalidad : this.timidez);
								break;
							case Personalidad.Tipo.neutral | Personalidad.Tipo.timido:
							case Personalidad.Tipo.neutral | Personalidad.Tipo.extrovertido:
							case Personalidad.Tipo.timido | Personalidad.Tipo.extrovertido:
							case Personalidad.Tipo.neutral | Personalidad.Tipo.timido | Personalidad.Tipo.extrovertido:
								goto IL_0166;
							case Personalidad.Tipo.extrovertido:
								num = (IgnorarEmociones ? this.extroversionPorPersonalidad : this.extroversion);
								break;
							case Personalidad.Tipo.sumiso:
								num = (IgnorarEmociones ? this.sumicionPorPersonalidad : this.sumicion);
								break;
							default:
								if (tipo != Personalidad.Tipo.pervertido)
								{
									if (tipo != Personalidad.Tipo.exhibicionista)
									{
										goto IL_0166;
									}
									num = (IgnorarEmociones ? this.exhibicionismoPorPersonalidad : this.exhibicionismo);
								}
								else
								{
									num = (IgnorarEmociones ? this.perverticidadPorPersonalidad : this.perverticidad);
								}
								break;
							}
						}
						else if (tipo != Personalidad.Tipo.respetuoso)
						{
							if (tipo != Personalidad.Tipo.grosero)
							{
								if (tipo != Personalidad.Tipo.honesto)
								{
									goto IL_0166;
								}
								num = (IgnorarEmociones ? this.honestidadPorPersonalidad : this.honestidad);
							}
							else
							{
								num = (IgnorarEmociones ? this.dominanciaPorPersonalidad : this.iRespeto);
							}
						}
						else
						{
							num = (IgnorarEmociones ? this.respetoPorPersonalidad : this.respeto);
						}
						this.m_TempTipos.Add(new ValueTuple<Personalidad.Tipo, float>(tipo, num));
						goto IL_018C;
						IL_0166:
						throw new ArgumentOutOfRangeException(tipo.ToString());
					}
					IL_018C:;
				}
				Personalidad.Tipo tipo2;
				if (this.m_TempTipos.Count == 0)
				{
					tipo2 = Personalidad.Tipo.neutral;
				}
				else
				{
					ValueTuple<Personalidad.Tipo, float> valueTuple = this.m_TempTipos.MaxByOrDefault((ValueTuple<Personalidad.Tipo, float> it) => it.Item2);
					if (valueTuple.Item2 < 0.3333333f)
					{
						tipo2 = Personalidad.Tipo.neutral;
					}
					else
					{
						tipo2 = valueTuple.Item1;
					}
				}
				if (tipo2 != Personalidad.Tipo.neutral)
				{
					tipo3 = tipo2;
				}
				else if (seleccion == null || (!seleccionEsParaIgnorar && seleccion.Contains(1)) || (seleccionEsParaIgnorar && !seleccion.Contains(1)))
				{
					tipo3 = tipo2;
				}
				else
				{
					tipo2 = Personalidad.Tipo.None;
					tipo3 = tipo2;
				}
			}
			finally
			{
				this.m_TempTipos.Clear();
			}
			return tipo3;
		}

		// Token: 0x060012E0 RID: 4832 RVA: 0x00051F24 File Offset: 0x00050124
		public Personalidad.Tipo ObtenerTipoMayorDeCurrentFrame(bool IgnorarEmociones, IList<int> seleccion = null, bool seleccionEsParaIgnorar = true, bool forzarActualizacion = false)
		{
			ValueTuple<bool, Personalidad.Tipo, bool> valueTuple = new ValueTuple<bool, Personalidad.Tipo, bool>(IgnorarEmociones, (seleccion == null) ? Personalidad.Tipo.All : seleccion.ToFlags<Personalidad.Tipo>(), seleccionEsParaIgnorar);
			ForcedUpdateId forcedUpdateId;
			if (!this.m_updateDeSeleccionDeFlags.TryGetValue(valueTuple, out forcedUpdateId))
			{
				forcedUpdateId = ForcedUpdateId.Create(-1);
				this.m_updateDeSeleccionDeFlags.Add(valueTuple, forcedUpdateId);
			}
			Personalidad.Tipo tipo;
			if (!this.m_mayorTipoDeSeleccionDeFlags.TryGetValue(valueTuple, out tipo))
			{
				tipo = Personalidad.Tipo.None;
				this.m_mayorTipoDeSeleccionDeFlags.Add(valueTuple, tipo);
			}
			if (forzarActualizacion || !forcedUpdateId.IsCurrent())
			{
				tipo = this.ObtenerTipoMayor(IgnorarEmociones, seleccion, seleccionEsParaIgnorar);
				this.m_updateDeSeleccionDeFlags[valueTuple] = ForcedUpdateId.current;
				this.m_mayorTipoDeSeleccionDeFlags[valueTuple] = tipo;
			}
			return tipo;
		}

		// Token: 0x04000F91 RID: 3985
		public const float breakPoint = 0.3333333f;

		// Token: 0x04000F92 RID: 3986
		[Obsolete("reemplazado por dic", true)]
		private ForcedUpdateId m_lastTipoCalculadoID;

		// Token: 0x04000F93 RID: 3987
		[Obsolete("reemplazado por dic", true)]
		private ForcedUpdateId m_lastTipoCalculadoIgnorandoEmocionesID;

		// Token: 0x04000F94 RID: 3988
		private Dictionary<ValueTuple<bool, Personalidad.Tipo, bool>, Personalidad.Tipo> m_mayorTipoDeSeleccionDeFlags = new Dictionary<ValueTuple<bool, Personalidad.Tipo, bool>, Personalidad.Tipo>();

		// Token: 0x04000F95 RID: 3989
		private Dictionary<ValueTuple<bool, Personalidad.Tipo, bool>, ForcedUpdateId> m_updateDeSeleccionDeFlags = new Dictionary<ValueTuple<bool, Personalidad.Tipo, bool>, ForcedUpdateId>();

		// Token: 0x04000F96 RID: 3990
		[Obsolete("reemplazado por dic", true)]
		[SerializeField]
		private Personalidad.Tipo m_lastTipoCalculado;

		// Token: 0x04000F97 RID: 3991
		[Obsolete("reemplazado por dic", true)]
		[SerializeField]
		private Personalidad.Tipo m_lastTipoCalculadoIgnorandoEmociones;

		// Token: 0x04000F98 RID: 3992
		[SerializeField]
		private bool clonarMapasDePersonalidad = true;

		// Token: 0x04000F99 RID: 3993
		private EmocionesFemeninas m_emos;

		// Token: 0x04000F9A RID: 3994
		private Deseos m_Deseos;

		// Token: 0x04000F9B RID: 3995
		private DiccionaryEnum<TraitHumano, Personalidad.Trait> m_traitsDic;

		// Token: 0x04000F9C RID: 3996
		[SerializeField]
		private CollecionDeMapasDePersonalidad.PersonalidadCompleta m_currentPersonalidad = new CollecionDeMapasDePersonalidad.PersonalidadCompleta();

		// Token: 0x04000F9D RID: 3997
		private Character m_character;

		// Token: 0x04000F9E RID: 3998
		private static ValueTuple<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, float>[] m_ArrayTempTipoDeRespuesta = new ValueTuple<Personalidad.TipoDeRespuestaDeDialogoDeHeroina, float>[4];

		// Token: 0x04000F9F RID: 3999
		private static ValueTuple<Personalidad.TipoSexual, float>[] m_ArrayTempTiposSexual = new ValueTuple<Personalidad.TipoSexual, float>[4];

		// Token: 0x04000FA0 RID: 4000
		private List<ValueTuple<TraitHumano, float>> m_TempTraitHumanoScores = new List<ValueTuple<TraitHumano, float>>();

		// Token: 0x04000FA1 RID: 4001
		private List<ValueTuple<Personalidad.Tipo, float>> m_TempTipos = new List<ValueTuple<Personalidad.Tipo, float>>();

		// Token: 0x0200035A RID: 858
		[Serializable]
		public class Trait
		{
			// Token: 0x060012E3 RID: 4835 RVA: 0x00052029 File Offset: 0x00050229
			public Personalidad.Trait Copia()
			{
				return (Personalidad.Trait)base.MemberwiseClone();
			}

			// Token: 0x04000FA2 RID: 4002
			public TraitHumano trait;

			// Token: 0x04000FA3 RID: 4003
			public HumanTraitScore score;
		}

		// Token: 0x0200035B RID: 859
		private class DistinctItemComparer : IEqualityComparer<Personalidad.Trait>
		{
			// Token: 0x060012E5 RID: 4837 RVA: 0x00052036 File Offset: 0x00050236
			public bool Equals(Personalidad.Trait x, Personalidad.Trait y)
			{
				return x.trait == y.trait;
			}

			// Token: 0x060012E6 RID: 4838 RVA: 0x00052046 File Offset: 0x00050246
			public int GetHashCode(Personalidad.Trait obj)
			{
				return obj.trait.GetHashCode();
			}
		}

		// Token: 0x0200035C RID: 860
		[Flags]
		public enum Tipo
		{
			// Token: 0x04000FA5 RID: 4005
			None = 0,
			// Token: 0x04000FA6 RID: 4006
			[LabelLocalizado("average", "US")]
			neutral = 1,
			// Token: 0x04000FA7 RID: 4007
			[LabelLocalizado("shy", "US")]
			timido = 2,
			// Token: 0x04000FA8 RID: 4008
			[LabelLocalizado("extroverted", "US")]
			extrovertido = 4,
			// Token: 0x04000FA9 RID: 4009
			[LabelLocalizado("submissive", "US")]
			sumiso = 8,
			// Token: 0x04000FAA RID: 4010
			[LabelLocalizado("perverted", "US")]
			pervertido = 16,
			// Token: 0x04000FAB RID: 4011
			[LabelLocalizado("exhibitionist", "US")]
			exhibicionista = 32,
			// Token: 0x04000FAC RID: 4012
			[LabelLocalizado("respectful", "US")]
			respetuoso = 64,
			// Token: 0x04000FAD RID: 4013
			[LabelLocalizado("rude", "US")]
			grosero = 128,
			// Token: 0x04000FAE RID: 4014
			[LabelLocalizado("honest", "US")]
			honesto = 256,
			// Token: 0x04000FAF RID: 4015
			All = -1
		}

		// Token: 0x0200035D RID: 861
		[Flags]
		public enum TipoSexual
		{
			// Token: 0x04000FB1 RID: 4017
			[LabelLocalizado("None", "US")]
			None = 0,
			// Token: 0x04000FB2 RID: 4018
			[LabelLocalizado("Dominant", "US")]
			dominante = 1,
			// Token: 0x04000FB3 RID: 4019
			[LabelLocalizado("Masochist", "US")]
			masoquista = 2,
			// Token: 0x04000FB4 RID: 4020
			[LabelLocalizado("Hybristophilia", "US")]
			hibristofilia = 3,
			// Token: 0x04000FB5 RID: 4021
			[LabelLocalizado("Submissive", "US")]
			sumisa = 4
		}

		// Token: 0x0200035E RID: 862
		[Flags]
		public enum TipoDeRespuestaDeDialogoDeHeroina
		{
			// Token: 0x04000FB7 RID: 4023
			None = 0,
			// Token: 0x04000FB8 RID: 4024
			amable = 1,
			// Token: 0x04000FB9 RID: 4025
			grosera = 2,
			// Token: 0x04000FBA RID: 4026
			timida = 4,
			// Token: 0x04000FBB RID: 4027
			pervertida = 8
		}

		// Token: 0x0200035F RID: 863
		public enum TipoDeRespuestaDeDialogoDePlayer
		{
			// Token: 0x04000FBD RID: 4029
			None,
			// Token: 0x04000FBE RID: 4030
			normal,
			// Token: 0x04000FBF RID: 4031
			timida,
			// Token: 0x04000FC0 RID: 4032
			intelectual,
			// Token: 0x04000FC1 RID: 4033
			pedante,
			// Token: 0x04000FC2 RID: 4034
			confiada,
			// Token: 0x04000FC3 RID: 4035
			pervertida,
			// Token: 0x04000FC4 RID: 4036
			mLady,
			// Token: 0x04000FC5 RID: 4037
			lujosa,
			// Token: 0x04000FC6 RID: 4038
			humilde
		}
	}
}
