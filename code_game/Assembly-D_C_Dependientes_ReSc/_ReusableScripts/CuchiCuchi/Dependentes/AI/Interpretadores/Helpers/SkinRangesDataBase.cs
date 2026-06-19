using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Helpers
{
	// Token: 0x0200039A RID: 922
	public abstract class SkinRangesDataBase : IRangesParaInterpretadores
	{
		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x0600171C RID: 5916
		protected abstract IReadOnlyList<ParteDelCuerpoHumano> partesDeInteraccion { get; }

		// Token: 0x0600171D RID: 5917 RVA: 0x0006E404 File Offset: 0x0006C604
		public virtual void Generate(HelperDeInterpretadorBase helper)
		{
			SkinRangesDataBase.Data data = new SkinRangesDataBase.Data();
			EmocionesFemeninasValues emptyValid = EmocionesFemeninasValues.emptyValid;
			emptyValid.humanasValues.placer = 0.25f;
			SkinRangesDataBase.Load(this.partesDeInteraccion, helper, data, ref emptyValid);
			this.painSensibilidad_MinWorldRango_Tactil = data.intervalosPainTactiles.Average((RangeValueV2 inter) => inter.min);
			this.pleasureSensibilidad_MinWorldRango_Tactil = data.intervalosPleasureTactiles.Average((RangeValueV2 inter) => inter.min);
			this.pleasureSensibilidad_MinMaxWorldDistanceRango_Tactil = data.intervalosPleasureTactiles.Average((RangeValueV2 inter) => Mathf.Abs(inter.max - inter.min));
			this.painGain_MaxGeneracion = data.minMaxPain.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.pleasureGain_MaxGeneracion = data.minMaxPleasure.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.rageGain_MaxGeneracion = data.minMaxRage.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.visualFavoravility = data.favorabilidadesVisual.Average();
			this.tactilFavoravility = data.favorabilidadesTactil.Average();
			this.exposureFavoravility = data.favorabilidadesExposure.Average();
			this.pleasureMaxValue_Tactil = data.pleasureMaxValuesTactiles.Average();
			this.OnGenerated(helper, data);
		}

		// Token: 0x0600171E RID: 5918 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected virtual void OnGenerated(HelperDeInterpretadorBase helper, SkinRangesDataBase.Data data)
		{
		}

		// Token: 0x0600171F RID: 5919 RVA: 0x0006E5AC File Offset: 0x0006C7AC
		private static void Load(IReadOnlyList<ParteDelCuerpoHumano> partes, HelperDeInterpretadorBase helper, SkinRangesDataBase.Data data, ref EmocionesFemeninasValues aceptanceValores)
		{
			foreach (ParteDelCuerpoHumano parteDelCuerpoHumano in partes)
			{
				SkinRangesDataBase.LoadParte(parteDelCuerpoHumano, ref aceptanceValores, helper, ParteQuePuedeEstimularHelper.puedenVer, ParteQuePuedeEstimularHelper.puedenTocar, ParteQuePuedeEstimularHelper.puedenDesvestir, data);
			}
		}

		// Token: 0x06001720 RID: 5920 RVA: 0x0006E604 File Offset: 0x0006C804
		private static void LoadParte(ParteDelCuerpoHumano estimulada, ref EmocionesFemeninasValues aceptanceValores, HelperDeInterpretadorBase helper, IReadOnlyList<ParteQuePuedeEstimular> puedenVer, IReadOnlyList<ParteQuePuedeEstimular> puedenTocar, IReadOnlyList<ParteQuePuedeEstimular> puedenDesvestir, SkinRangesDataBase.Data data)
		{
			foreach (ParteQuePuedeEstimular parteQuePuedeEstimular in puedenVer)
			{
				float num = ConsentNecesario.ParaSinJerarquia(helper.consentNecesario, TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, estimulada, parteQuePuedeEstimular, ref aceptanceValores, helper.personalidad, null);
				data.favorabilidadesVisual.Add(num);
			}
			foreach (ParteQuePuedeEstimular parteQuePuedeEstimular2 in puedenTocar)
			{
				float num2 = ConsentNecesario.ParaSinJerarquia(helper.consentNecesario, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, estimulada, parteQuePuedeEstimular2, ref aceptanceValores, helper.personalidad, null);
				data.favorabilidadesTactil.Add(num2);
				RangeValueV2 rangeValueV;
				UmbralBasico.Estado estado;
				UmbralBasico.Estado estado2;
				float num3;
				UmbralBasico.TipoDeCambio tipoDeCambio;
				helper.dolorPorToques.SimularGlobal(parteQuePuedeEstimular2, estimulada, 1f, out rangeValueV, out estado, out estado2, out num3, out tipoDeCambio, new EmocionesFemeninasValues?(aceptanceValores));
				data.intervalosPainTactiles.Add(rangeValueV);
				data.minMaxPain.Add(new ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>(estado, estado2));
				RangeValueV2 rangeValueV2;
				UmbralBasico.Estado estado3;
				UmbralBasico.Estado estado4;
				float num4;
				UmbralBasico.TipoDeCambio tipoDeCambio2;
				helper.dolorPorGolpes.SimularGlobal(parteQuePuedeEstimular2, estimulada, 1f, out rangeValueV2, out estado3, out estado4, out num4, out tipoDeCambio2, new EmocionesFemeninasValues?(aceptanceValores));
				data.intervalosPainTactiles.Add(rangeValueV2);
				data.minMaxPain.Add(new ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>(estado3, estado4));
				RangeValueV2 rangeValueV3;
				UmbralBasico.Estado estado5;
				UmbralBasico.Estado estado6;
				float num5;
				UmbralBasico.TipoDeCambio tipoDeCambio3;
				helper.placerPorToques.SimularGlobal(parteQuePuedeEstimular2, estimulada, 1f, out rangeValueV3, out estado5, out estado6, out num5, out tipoDeCambio3, new EmocionesFemeninasValues?(aceptanceValores));
				data.intervalosPleasureTactiles.Add(rangeValueV3);
				data.minMaxPleasure.Add(new ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>(estado5, estado6));
				data.pleasureMaxValuesTactiles.Add(num5);
				RangeValueV2 rangeValueV4;
				UmbralBasico.Estado estado7;
				UmbralBasico.Estado estado8;
				float num6;
				UmbralBasico.TipoDeCambio tipoDeCambio4;
				helper.ragePorToques.SimularGlobal(parteQuePuedeEstimular2, estimulada, 1f, out rangeValueV4, out estado7, out estado8, out num6, out tipoDeCambio4, new EmocionesFemeninasValues?(aceptanceValores));
				data.minMaxRage.Add(new ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>(estado7, estado8));
				RangeValueV2 rangeValueV5;
				UmbralBasico.Estado estado9;
				UmbralBasico.Estado estado10;
				float num7;
				UmbralBasico.TipoDeCambio tipoDeCambio5;
				helper.ragePorGolpes.SimularGlobal(parteQuePuedeEstimular2, estimulada, 1f, out rangeValueV5, out estado9, out estado10, out num7, out tipoDeCambio5, new EmocionesFemeninasValues?(aceptanceValores));
				data.minMaxRage.Add(new ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>(estado9, estado10));
			}
			foreach (ParteQuePuedeEstimular parteQuePuedeEstimular3 in puedenDesvestir)
			{
				float num8 = ConsentNecesario.ParaSinJerarquia(helper.consentNecesario, TipoDeEstimulo.desvestidura, DireccionDeEstimulo.recibida, estimulada, parteQuePuedeEstimular3, ref aceptanceValores, helper.personalidad, null);
				float num9 = ConsentNecesario.ParaSinJerarquia(helper.consentNecesario, TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, estimulada, parteQuePuedeEstimular3, ref aceptanceValores, helper.personalidad, null);
				data.favorabilidadesExposure.Add(num8);
				data.favorabilidadesExposure.Add(num9);
			}
		}

		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x06001721 RID: 5921 RVA: 0x0006E8D4 File Offset: 0x0006CAD4
		float IRangesParaInterpretadores.painSensibilidad_MinWorldRango_Tactil
		{
			get
			{
				return this.painSensibilidad_MinWorldRango_Tactil;
			}
		}

		// Token: 0x17000536 RID: 1334
		// (get) Token: 0x06001722 RID: 5922 RVA: 0x0006E8DC File Offset: 0x0006CADC
		float IRangesParaInterpretadores.pleasureSensibilidad_MinWorldRango_Tactil
		{
			get
			{
				return this.pleasureSensibilidad_MinWorldRango_Tactil;
			}
		}

		// Token: 0x17000537 RID: 1335
		// (get) Token: 0x06001723 RID: 5923 RVA: 0x0006E8E4 File Offset: 0x0006CAE4
		float IRangesParaInterpretadores.painGain_MaxGeneracion
		{
			get
			{
				return this.painGain_MaxGeneracion;
			}
		}

		// Token: 0x17000538 RID: 1336
		// (get) Token: 0x06001724 RID: 5924 RVA: 0x0006E8EC File Offset: 0x0006CAEC
		float IRangesParaInterpretadores.pleasureGain_MaxGeneracion
		{
			get
			{
				return this.pleasureGain_MaxGeneracion;
			}
		}

		// Token: 0x17000539 RID: 1337
		// (get) Token: 0x06001725 RID: 5925 RVA: 0x0006E8F4 File Offset: 0x0006CAF4
		float IRangesParaInterpretadores.rageGain_MaxGeneracion
		{
			get
			{
				return this.rageGain_MaxGeneracion;
			}
		}

		// Token: 0x1700053A RID: 1338
		// (get) Token: 0x06001726 RID: 5926 RVA: 0x0006E8FC File Offset: 0x0006CAFC
		float IRangesParaInterpretadores.visualFavoravility
		{
			get
			{
				return this.visualFavoravility;
			}
		}

		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x06001727 RID: 5927 RVA: 0x0006E904 File Offset: 0x0006CB04
		float IRangesParaInterpretadores.tactilFavoravility
		{
			get
			{
				return this.tactilFavoravility;
			}
		}

		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x06001728 RID: 5928 RVA: 0x0006E90C File Offset: 0x0006CB0C
		float IRangesParaInterpretadores.exposureFavoravility
		{
			get
			{
				return this.exposureFavoravility;
			}
		}

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x06001729 RID: 5929 RVA: 0x0006E914 File Offset: 0x0006CB14
		float IRangesParaInterpretadores.pleasureSensibilidad_MinMaxWorldDistanceRango_Tactil
		{
			get
			{
				return this.pleasureSensibilidad_MinMaxWorldDistanceRango_Tactil;
			}
		}

		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x0600172A RID: 5930 RVA: 0x0006E91C File Offset: 0x0006CB1C
		float IRangesParaInterpretadores.pleasure_MaxValue
		{
			get
			{
				return this.pleasureMaxValue_Tactil;
			}
		}

		// Token: 0x040010D9 RID: 4313
		[Header("Sensibilidad")]
		public float painSensibilidad_MinWorldRango_Tactil;

		// Token: 0x040010DA RID: 4314
		public float pleasureSensibilidad_MinWorldRango_Tactil;

		// Token: 0x040010DB RID: 4315
		public float pleasureSensibilidad_MinMaxWorldDistanceRango_Tactil;

		// Token: 0x040010DC RID: 4316
		[Header("Max Values")]
		public float pleasureMaxValue_Tactil;

		// Token: 0x040010DD RID: 4317
		[Header("Gain")]
		public float painGain_MaxGeneracion;

		// Token: 0x040010DE RID: 4318
		public float pleasureGain_MaxGeneracion;

		// Token: 0x040010DF RID: 4319
		public float rageGain_MaxGeneracion;

		// Token: 0x040010E0 RID: 4320
		[Header("Favorabilidad")]
		public float visualFavoravility;

		// Token: 0x040010E1 RID: 4321
		public float tactilFavoravility;

		// Token: 0x040010E2 RID: 4322
		public float exposureFavoravility;

		// Token: 0x0200039B RID: 923
		protected class Data
		{
			// Token: 0x040010E3 RID: 4323
			public List<RangeValueV2> intervalosPainTactiles = new List<RangeValueV2>();

			// Token: 0x040010E4 RID: 4324
			public List<RangeValueV2> intervalosPleasureTactiles = new List<RangeValueV2>();

			// Token: 0x040010E5 RID: 4325
			public List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>> minMaxPain = new List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>>();

			// Token: 0x040010E6 RID: 4326
			public List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>> minMaxPleasure = new List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>>();

			// Token: 0x040010E7 RID: 4327
			public List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>> minMaxRage = new List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>>();

			// Token: 0x040010E8 RID: 4328
			public List<float> pleasureMaxValuesTactiles = new List<float>();

			// Token: 0x040010E9 RID: 4329
			public List<float> favorabilidadesVisual = new List<float>();

			// Token: 0x040010EA RID: 4330
			public List<float> favorabilidadesTactil = new List<float>();

			// Token: 0x040010EB RID: 4331
			public List<float> favorabilidadesExposure = new List<float>();
		}
	}
}
