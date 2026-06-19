using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Interpretadores
{
	// Token: 0x02000468 RID: 1128
	[Obsolete("devidir en varios", true)]
	public class InterpretadorDePersonalidadDataHandler : CustomMonobehaviour, IPersonalidadInterpretadorHelperOLD
	{
		// Token: 0x0600186F RID: 6255 RVA: 0x00061844 File Offset: 0x0005FA44
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_consentNecesario = this.GetComponentEnRoot(false);
			this.m_DolorPorPenetracion = this.GetComponentEnRoot(false);
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_consentNecesario == null)
			{
				throw new ArgumentNullException("m_consentNecesario", "m_consentNecesario null reference.");
			}
			if (this.m_DolorPorPenetracion == null)
			{
				throw new ArgumentNullException("m_DolorPorPenetracion", "m_DolorPorPenetracion null reference.");
			}
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
		}

		// Token: 0x06001870 RID: 6256 RVA: 0x000618D8 File Offset: 0x0005FAD8
		[Obsolete("devidir en varios", true)]
		public void VaginalProfundidadOffset(float aceptanceMod, IReadOnlyList<float> penetrationDistances, IList<float> offsetResult)
		{
			this.ProfundidadOffsetMany(FemalePenetracionTipo.vag, penetrationDistances, offsetResult, aceptanceMod, this.ModDeMod(TraitHumano.gustoPorTratoExplicitoDeClientes));
		}

		// Token: 0x06001871 RID: 6257 RVA: 0x000618EC File Offset: 0x0005FAEC
		[Obsolete("devidir en varios", true)]
		public void AnalProfundidadOffset(float aceptanceMod, IReadOnlyList<float> penetrationDistances, IList<float> offsetResult)
		{
			this.ProfundidadOffsetMany(FemalePenetracionTipo.anus, penetrationDistances, offsetResult, aceptanceMod, this.ModDeMod(TraitHumano.gustoPorTratoExplicitoDeClientes));
		}

		// Token: 0x06001872 RID: 6258 RVA: 0x00061900 File Offset: 0x0005FB00
		[Obsolete("devidir en varios", true)]
		public void OralProfundidadOffset(float aceptanceMod, IReadOnlyList<float> penetrationDistances, IList<float> offsetResult)
		{
			this.ProfundidadOffsetMany(FemalePenetracionTipo.facial, penetrationDistances, offsetResult, aceptanceMod, this.ModDeMod(TraitHumano.gustoPorTratoExplicitoDeClientes));
		}

		// Token: 0x06001873 RID: 6259 RVA: 0x00061914 File Offset: 0x0005FB14
		[Obsolete("devidir en varios", true)]
		public void VaginalAnchuraOffset(float aceptanceMod, IReadOnlyList<float> penetrationDistances, IList<float> offsetResult)
		{
			this.AnchuraOffsetMany(FemalePenetracionTipo.vag, penetrationDistances, offsetResult, aceptanceMod, this.ModDeMod(TraitHumano.gustoPorTratoExplicitoDeClientes));
		}

		// Token: 0x06001874 RID: 6260 RVA: 0x00061928 File Offset: 0x0005FB28
		[Obsolete("devidir en varios", true)]
		public void AnalAnchuraOffset(float aceptanceMod, IReadOnlyList<float> penetrationDistances, IList<float> offsetResult)
		{
			this.AnchuraOffsetMany(FemalePenetracionTipo.anus, penetrationDistances, offsetResult, aceptanceMod, this.ModDeMod(TraitHumano.gustoPorTratoExplicitoDeClientes));
		}

		// Token: 0x06001875 RID: 6261 RVA: 0x0006193C File Offset: 0x0005FB3C
		[Obsolete("devidir en varios", true)]
		public void OralAnchuraOffset(float aceptanceMod, IReadOnlyList<float> penetrationDistances, IList<float> offsetResult)
		{
			this.AnchuraOffsetMany(FemalePenetracionTipo.facial, penetrationDistances, offsetResult, aceptanceMod, this.ModDeMod(TraitHumano.gustoPorTratoExplicitoDeClientes));
		}

		// Token: 0x06001876 RID: 6262 RVA: 0x00061950 File Offset: 0x0005FB50
		private void ProfundidadOffsetMany(FemalePenetracionTipo peneTipo, IReadOnlyList<float> penetrationDistances, IList<float> offsetResult, float aceptanceMod, float aceptanceModMod)
		{
			EmocionesFemeninasValues emptyValid = EmocionesFemeninasValues.emptyValid;
			emptyValid.humanasValues.placer = aceptanceMod * aceptanceModMod;
			InterpretadorDePersonalidadDataHandler.OffsetMany(this.m_DolorPorPenetracion.ObtenerRangoDeProfundidad(peneTipo, ref emptyValid, true), penetrationDistances, offsetResult);
		}

		// Token: 0x06001877 RID: 6263 RVA: 0x0006198C File Offset: 0x0005FB8C
		private void AnchuraOffsetMany(FemalePenetracionTipo peneTipo, IReadOnlyList<float> penetrationDistances, IList<float> offsetResult, float aceptanceMod, float aceptanceModMod)
		{
			EmocionesFemeninasValues emptyValid = EmocionesFemeninasValues.emptyValid;
			emptyValid.humanasValues.placer = aceptanceMod * aceptanceModMod;
			InterpretadorDePersonalidadDataHandler.OffsetMany(this.m_DolorPorPenetracion.ObtenerRangoDeAnchura(peneTipo, ref emptyValid), penetrationDistances, offsetResult);
		}

		// Token: 0x06001878 RID: 6264 RVA: 0x000619C8 File Offset: 0x0005FBC8
		private static void OffsetMany(RangeValueV2 range, IReadOnlyList<float> penetrationDistances, IList<float> offsetResult)
		{
			if (penetrationDistances == null)
			{
				throw new ArgumentNullException("penetrationDistances", "penetrationDistances null reference.");
			}
			if (offsetResult == null)
			{
				throw new ArgumentNullException("offsetResult", "offsetResult null reference.");
			}
			while (offsetResult.Count < penetrationDistances.Count)
			{
				offsetResult.Add(0f);
			}
			for (int i = 0; i < penetrationDistances.Count; i++)
			{
				UmbralBasico.Estado estado = UmbralBasico.Calcular(penetrationDistances[i], range, 1f, SpotBonuses.@default, 0.5f, 1f, 0f);
				offsetResult[i] = estado.offsetMod;
			}
		}

		// Token: 0x06001879 RID: 6265 RVA: 0x00061A5C File Offset: 0x0005FC5C
		private float ConsentOffset(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, float aceptanceMod, float aceptanceModMod)
		{
			EmocionesFemeninasValues emptyValid = EmocionesFemeninasValues.emptyValid;
			emptyValid.consentToHero = aceptanceMod * aceptanceModMod;
			float num = this.m_consentNecesario.ParaSinJerarquia(tipo, direccion, estimulada, estimulante, new EmocionesFemeninasValues?(emptyValid), null, null);
			return ConsentNecesario.CalcularOffset(emptyValid.consentToHero * 100f, num);
		}

		// Token: 0x0600187A RID: 6266 RVA: 0x00061AA8 File Offset: 0x0005FCA8
		private float ModDeMod(TraitHumano trait)
		{
			HumanTraitScore traitScore = this.m_personalidad.GetTraitScore(trait);
			switch (traitScore)
			{
			case HumanTraitScore.normal:
				return 1f;
			case HumanTraitScore.alto:
				return 1.25f;
			case HumanTraitScore.muyAlto:
				return 1.5f;
			case HumanTraitScore.bajo:
				return 0.8f;
			case HumanTraitScore.muyBajo:
				return 0.6666667f;
			default:
				throw new ArgumentOutOfRangeException(traitScore.ToString());
			}
		}

		// Token: 0x0600187B RID: 6267 RVA: 0x00061B0E File Offset: 0x0005FD0E
		[Obsolete("devidir en varios", true)]
		public float VaginalConsentOffset(float aceptanceMod)
		{
			return this.ConsentOffset(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.pene, aceptanceMod, this.ModDeMod(TraitHumano.gustoPorTratoExplicitoDeClientes));
		}

		// Token: 0x0600187C RID: 6268 RVA: 0x00061B24 File Offset: 0x0005FD24
		[Obsolete("devidir en varios", true)]
		public float AnalConsentOffset(float aceptanceMod)
		{
			return this.ConsentOffset(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.pene, aceptanceMod, this.ModDeMod(TraitHumano.gustoPorTratoExplicitoDeClientes));
		}

		// Token: 0x0600187D RID: 6269 RVA: 0x00061B3A File Offset: 0x0005FD3A
		[Obsolete("devidir en varios", true)]
		public float OralConsentOffset(float aceptanceMod)
		{
			return this.ConsentOffset(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.pene, aceptanceMod, this.ModDeMod(TraitHumano.gustoPorTratoExplicitoDeClientes));
		}

		// Token: 0x0600187E RID: 6270 RVA: 0x00061B50 File Offset: 0x0005FD50
		[Obsolete("devidir en varios", true)]
		public float BeingTouchedInPrivatesConsentOffset(float aceptanceMod)
		{
			float num = float.MaxValue;
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				if (parteDelCuerpoHumano.EsPrivadaSocialmenteTactil())
				{
					float num2 = this.ConsentOffset(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.manos, aceptanceMod, this.ModDeMod(TraitHumano.gustoPorTratoEspecialDeClientes));
					if (num2 < num)
					{
						num = num2;
					}
				}
			}
			return num;
		}

		// Token: 0x0600187F RID: 6271 RVA: 0x00061BD8 File Offset: 0x0005FDD8
		[Obsolete("devidir en varios", true)]
		public float BeingTouchedConsentOffset(float aceptanceMod)
		{
			float num = float.MaxValue;
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				if (parteDelCuerpoHumano.EsSemiPrivadaSocialmenteTactil())
				{
					float num2 = this.ConsentOffset(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.manos, aceptanceMod, this.ModDeMod(TraitHumano.gustoPorTratoDeClientes));
					if (num2 < num)
					{
						num = num2;
					}
				}
			}
			return num;
		}

		// Token: 0x06001880 RID: 6272 RVA: 0x00061C60 File Offset: 0x0005FE60
		[Obsolete("devidir en varios", true)]
		public float UndressPrivatesConsentOffset(float aceptanceMod)
		{
			float num = float.MaxValue;
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				if (parteDelCuerpoHumano.EsPrivadaSocialmenteVisual())
				{
					float num2 = this.ConsentOffset(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.boca, aceptanceMod, this.ModDeMod(TraitHumano.gustoPorModelajeHerotico));
					if (num2 < num)
					{
						num = num2;
					}
				}
			}
			return num;
		}

		// Token: 0x06001881 RID: 6273 RVA: 0x00061CEC File Offset: 0x0005FEEC
		[Obsolete("devidir en varios", true)]
		public float UndressConsentOffset(float aceptanceMod)
		{
			float num = float.MaxValue;
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				if (parteDelCuerpoHumano.EsSemiPrivadaSocialmenteVisual())
				{
					float num2 = this.ConsentOffset(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.boca, aceptanceMod, this.ModDeMod(TraitHumano.gustoPorModelajeUnderwear));
					if (num2 < num)
					{
						num = num2;
					}
				}
			}
			return num;
		}

		// Token: 0x06001882 RID: 6274 RVA: 0x00061D78 File Offset: 0x0005FF78
		[Obsolete("devidir en varios", true)]
		public float BeingWatchedInPrivatesConsentOffset(float aceptanceMod)
		{
			float num = float.MaxValue;
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				if (parteDelCuerpoHumano.EsPrivadaSocialmenteVisual())
				{
					float num2 = this.ConsentOffset(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.ojos, aceptanceMod, this.ModDeMod(TraitHumano.gustoPorModelajeHerotico));
					if (num2 < num)
					{
						num = num2;
					}
				}
			}
			return num;
		}

		// Token: 0x06001883 RID: 6275 RVA: 0x00061E04 File Offset: 0x00060004
		[Obsolete("devidir en varios", true)]
		public float BeingWatchedConsentOffset(float aceptanceMod)
		{
			float num = float.MaxValue;
			foreach (object obj in typeof(ParteDelCuerpoHumano).GetEnumValoresObject())
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)obj;
				if (parteDelCuerpoHumano.EsSemiPrivadaSocialmenteVisual())
				{
					float num2 = this.ConsentOffset(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, ParteQuePuedeEstimular.ojos, aceptanceMod, this.ModDeMod(TraitHumano.gustoPorModelajeUnderwear));
					if (num2 < num)
					{
						num = num2;
					}
				}
			}
			return num;
		}

		// Token: 0x040012C3 RID: 4803
		private ConsentNecesario m_consentNecesario;

		// Token: 0x040012C4 RID: 4804
		private DolorPorPenetracion m_DolorPorPenetracion;

		// Token: 0x040012C5 RID: 4805
		private Personalidad m_personalidad;
	}
}
