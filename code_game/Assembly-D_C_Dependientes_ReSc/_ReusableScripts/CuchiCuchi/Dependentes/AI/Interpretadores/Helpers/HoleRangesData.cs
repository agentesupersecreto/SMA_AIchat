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
	// Token: 0x020003A1 RID: 929
	[Serializable]
	public class HoleRangesData : IHoleRangesParaInterpretadores
	{
		// Token: 0x06001756 RID: 5974 RVA: 0x0006ED98 File Offset: 0x0006CF98
		public void Generate(HelperDeInterpretadorBase helper)
		{
			HoleRangesData.Data data = new HoleRangesData.Data();
			HoleRangesData.Data data2 = new HoleRangesData.Data();
			HoleRangesData.Data data3 = new HoleRangesData.Data();
			EmocionesFemeninasValues emptyValid = EmocionesFemeninasValues.emptyValid;
			emptyValid.humanasValues.placer = 0.25f;
			HoleRangesData.Load(ParteDelCuerpoHumanoHelper.partesDeInteraccionOral, helper.boca, ParteDelCuerpoHumano.bocaInterno, FemalePenetracionTipo.facial, helper, data, ref emptyValid);
			HoleRangesData.Load(ParteDelCuerpoHumanoHelper.partesDeInteraccionVaginal, helper.vag, ParteDelCuerpoHumano.vag, FemalePenetracionTipo.vag, helper, data2, ref emptyValid);
			HoleRangesData.Load(ParteDelCuerpoHumanoHelper.partesDeInteraccionAnal, helper.anus, ParteDelCuerpoHumano.ano, FemalePenetracionTipo.anus, helper, data3, ref emptyValid);
			this.oralPainSensibilidad_MinWorldRango_Tactil = data.intervalosPainTactiles.Average((RangeValueV2 inter) => inter.min);
			this.oralPainSensibilidad_MinWorldRango_Coital = data.intervalosPainCoital.Average((RangeValueV2 inter) => inter.min);
			this.vaginalPainSensibilidad_MinWorldRango_Tactil = data2.intervalosPainTactiles.Average((RangeValueV2 inter) => inter.min);
			this.vaginalPainSensibilidad_MinWorldRango_Coital = data2.intervalosPainCoital.Average((RangeValueV2 inter) => inter.min);
			this.analPainSensibilidad_MinWorldRango_Tactil = data3.intervalosPainTactiles.Average((RangeValueV2 inter) => inter.min);
			this.analPainSensibilidad_MinWorldRango_Coital = data3.intervalosPainCoital.Average((RangeValueV2 inter) => inter.min);
			this.oralPleasureSensibilidad_MinWorldRango_Tactil = data.intervalosPleasureTactiles.Average((RangeValueV2 inter) => inter.min);
			this.oralPleasureSensibilidad_MinWorldRango_Coital = data.intervalosPleasureCoital.Average((RangeValueV2 inter) => inter.min);
			this.oralPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil = data.intervalosPleasureTactiles.Average((RangeValueV2 inter) => Mathf.Abs(inter.max - inter.min));
			this.oralPleasureSensibilidad_MinMaxDistanceWorldRango_Coital = data.intervalosPleasureCoital.Average((RangeValueV2 inter) => Mathf.Abs(inter.max - inter.min));
			this.vaginalPleasureSensibilidad_MinWorldRango_Tactil = data2.intervalosPleasureTactiles.Average((RangeValueV2 inter) => inter.min);
			this.vaginalPleasureSensibilidad_MinWorldRango_Coital = data2.intervalosPleasureCoital.Average((RangeValueV2 inter) => inter.min);
			this.vaginalPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil = data2.intervalosPleasureTactiles.Average((RangeValueV2 inter) => Mathf.Abs(inter.max - inter.min));
			this.vaginalPleasureSensibilidad_MinMaxDistanceWorldRango_Coital = data2.intervalosPleasureCoital.Average((RangeValueV2 inter) => Mathf.Abs(inter.max - inter.min));
			this.analPleasureSensibilidad_MinWorldRango_Tactil = data3.intervalosPleasureTactiles.Average((RangeValueV2 inter) => inter.min);
			this.analPleasureSensibilidad_MinWorldRango_Coital = data3.intervalosPleasureCoital.Average((RangeValueV2 inter) => inter.min);
			this.analPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil = data3.intervalosPleasureTactiles.Average((RangeValueV2 inter) => Mathf.Abs(inter.max - inter.min));
			this.analPleasureSensibilidad_MinMaxDistanceWorldRango_Coital = data3.intervalosPleasureCoital.Average((RangeValueV2 inter) => Mathf.Abs(inter.max - inter.min));
			this.oralPainGain_MaxGeneracion_Coital = data.minMaxPainCoital.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.oralPainGain_MaxGeneracion = data.minMaxPain.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.oralPleasureGain_MaxGeneracion_Coital = data.minMaxPleasureCoital.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.oralPleasureGain_MaxGeneracion = data.minMaxPleasure.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.oralRageGain_MaxGeneracion_Coital = data.minMaxRageCoital.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.oralRageGain_MaxGeneracion = data.minMaxRage.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.vaginalPainGain_MaxGeneracion_Coital = data2.minMaxPainCoital.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.vaginalPainGain_MaxGeneracion = data2.minMaxPain.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.vaginalPleasureGain_MaxGeneracion_Coital = data2.minMaxPleasureCoital.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.vaginalPleasureGain_MaxGeneracion = data2.minMaxPleasure.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.vaginalRageGain_MaxGeneracion_Coital = data2.minMaxRageCoital.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.vaginalRageGain_MaxGeneracion = data2.minMaxRage.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.analPainGain_MaxGeneracion_Coital = data3.minMaxPainCoital.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.analPainGain_MaxGeneracion = data3.minMaxPain.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.analPleasureGain_MaxGeneracion_Coital = data3.minMaxPleasureCoital.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.analPleasureGain_MaxGeneracion = data3.minMaxPleasure.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.analRageGain_MaxGeneracion_Coital = data3.minMaxRageCoital.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.analRageGain_MaxGeneracion = data3.minMaxRage.Average((ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado> par) => par.Item2.estimulacionGeneradaEnFrame);
			this.oralVisualFavoravility = data.favorabilidadesVisual.Average();
			this.oralTactilFavoravility = data.favorabilidadesTactil.Average();
			this.oralExposureFavoravility = data.favorabilidadesExposure.Average();
			this.oralCoitalFavoravility = data.favorabilidadesCoital.Average();
			this.vaginalVisualFavoravility = data2.favorabilidadesVisual.Average();
			this.vaginalTactilFavoravility = data2.favorabilidadesTactil.Average();
			this.vaginalExposureFavoravility = data2.favorabilidadesExposure.Average();
			this.vaginalCoitalFavoravility = data2.favorabilidadesCoital.Average();
			this.analVisualFavoravility = data3.favorabilidadesVisual.Average();
			this.analTactilFavoravility = data3.favorabilidadesTactil.Average();
			this.analExposureFavoravility = data3.favorabilidadesExposure.Average();
			this.analCoitalFavoravility = data3.favorabilidadesCoital.Average();
			this.oralPleasureMaxValue_Tactil = data.pleasureMaxValuesTactiles.Average();
			this.oralPleasureMaxValue_Coital = data.pleasureMaxValuesCoitales.Average();
			this.vaginalPleasureMaxValue_Tactil = data2.pleasureMaxValuesTactiles.Average();
			this.vaginalPleasureMaxValue_Coital = data2.pleasureMaxValuesCoitales.Average();
			this.analPleasureMaxValue_Tactil = data3.pleasureMaxValuesTactiles.Average();
			this.analPleasureMaxValue_Coital = data3.pleasureMaxValuesCoitales.Average();
		}

		// Token: 0x06001757 RID: 5975 RVA: 0x0006F608 File Offset: 0x0006D808
		private static void Load(IReadOnlyList<ParteDelCuerpoHumano> partes, IHole hole, ParteDelCuerpoHumano holeEstimulado, FemalePenetracionTipo tipoDeHole, HelperDeInterpretadorBase helper, HoleRangesData.Data data, ref EmocionesFemeninasValues aceptanceValores)
		{
			foreach (ParteDelCuerpoHumano parteDelCuerpoHumano in partes)
			{
				HoleRangesData.LoadParte(parteDelCuerpoHumano, ref aceptanceValores, helper, ParteQuePuedeEstimularHelper.puedenVer, ParteQuePuedeEstimularHelper.puedenTocar, ParteQuePuedeEstimularHelper.puedenDesvestir, data);
			}
			HoleRangesData.LoadParteCoital(hole.worldScaleReal, holeEstimulado, tipoDeHole, ref aceptanceValores, helper, ParteQuePuedeEstimularHelper.puedenPenetrar, data);
		}

		// Token: 0x06001758 RID: 5976 RVA: 0x0006F67C File Offset: 0x0006D87C
		private static void LoadParte(ParteDelCuerpoHumano estimulada, ref EmocionesFemeninasValues aceptanceValores, HelperDeInterpretadorBase helper, IReadOnlyList<ParteQuePuedeEstimular> puedenVer, IReadOnlyList<ParteQuePuedeEstimular> puedenTocar, IReadOnlyList<ParteQuePuedeEstimular> puedenDesvestir, HoleRangesData.Data data)
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

		// Token: 0x06001759 RID: 5977 RVA: 0x0006F94C File Offset: 0x0006DB4C
		private static void LoadParteCoital(float holeScale, ParteDelCuerpoHumano holeEstimulado, FemalePenetracionTipo tipoDeHole, ref EmocionesFemeninasValues aceptanceValores, HelperDeInterpretadorBase helper, IReadOnlyList<ParteQuePuedeEstimular> puedenPenetrar, HoleRangesData.Data data)
		{
			foreach (ParteQuePuedeEstimular parteQuePuedeEstimular in puedenPenetrar)
			{
				float num = ConsentNecesario.ParaSinJerarquia(helper.consentNecesario, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, holeEstimulado, parteQuePuedeEstimular, ref aceptanceValores, helper.personalidad, null);
				data.favorabilidadesCoital.Add(num);
				RangeValueV2 rangeValueV;
				UmbralBasico.Estado estado;
				UmbralBasico.Estado estado2;
				float num2;
				helper.dolorPorPenetracion.SimularPenetracion(parteQuePuedeEstimular, tipoDeHole, 1f, out rangeValueV, out estado, out estado2, out num2, ref aceptanceValores);
				data.intervalosPainCoital.Add(RangeValueV2.Scale(ref rangeValueV, holeScale));
				data.minMaxPainCoital.Add(new ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>(estado, estado2));
				RangeValueV2 rangeValueV2;
				UmbralBasico.Estado estado3;
				UmbralBasico.Estado estado4;
				float num3;
				helper.placerPorPenetraciones.SimularPenetracion(parteQuePuedeEstimular, tipoDeHole, 1f, out rangeValueV2, out estado3, out estado4, out num3, ref aceptanceValores);
				data.intervalosPleasureCoital.Add(RangeValueV2.Scale(ref rangeValueV2, holeScale));
				data.minMaxPleasureCoital.Add(new ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>(estado3, estado4));
				data.pleasureMaxValuesCoitales.Add(num3);
				RangeValueV2 rangeValueV3;
				UmbralBasico.Estado estado5;
				UmbralBasico.Estado estado6;
				float num4;
				helper.ragePorPenetracion.SimularPenetracion(parteQuePuedeEstimular, tipoDeHole, 1f, out rangeValueV3, out estado5, out estado6, out num4, ref aceptanceValores);
				data.minMaxRageCoital.Add(new ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>(estado5, estado6));
			}
		}

		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x0600175A RID: 5978 RVA: 0x0006FA90 File Offset: 0x0006DC90
		float IHoleRangesParaInterpretadores.oralPainSensibilidad_MinWorldRango_Tactil
		{
			get
			{
				return this.oralPainSensibilidad_MinWorldRango_Tactil;
			}
		}

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x0600175B RID: 5979 RVA: 0x0006FA98 File Offset: 0x0006DC98
		float IHoleRangesParaInterpretadores.oralPainSensibilidad_MinWorldRango_Coital
		{
			get
			{
				return this.oralPainSensibilidad_MinWorldRango_Coital;
			}
		}

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x0600175C RID: 5980 RVA: 0x0006FAA0 File Offset: 0x0006DCA0
		float IHoleRangesParaInterpretadores.vaginalPainSensibilidad_MinWorldRango_Tactil
		{
			get
			{
				return this.vaginalPainSensibilidad_MinWorldRango_Tactil;
			}
		}

		// Token: 0x1700055B RID: 1371
		// (get) Token: 0x0600175D RID: 5981 RVA: 0x0006FAA8 File Offset: 0x0006DCA8
		float IHoleRangesParaInterpretadores.vaginalPainSensibilidad_MinWorldRango_Coital
		{
			get
			{
				return this.vaginalPainSensibilidad_MinWorldRango_Coital;
			}
		}

		// Token: 0x1700055C RID: 1372
		// (get) Token: 0x0600175E RID: 5982 RVA: 0x0006FAB0 File Offset: 0x0006DCB0
		float IHoleRangesParaInterpretadores.analPainSensibilidad_MinWorldRango_Tactil
		{
			get
			{
				return this.analPainSensibilidad_MinWorldRango_Tactil;
			}
		}

		// Token: 0x1700055D RID: 1373
		// (get) Token: 0x0600175F RID: 5983 RVA: 0x0006FAB8 File Offset: 0x0006DCB8
		float IHoleRangesParaInterpretadores.analPainSensibilidad_MinWorldRango_Coital
		{
			get
			{
				return this.analPainSensibilidad_MinWorldRango_Coital;
			}
		}

		// Token: 0x1700055E RID: 1374
		// (get) Token: 0x06001760 RID: 5984 RVA: 0x0006FAC0 File Offset: 0x0006DCC0
		float IHoleRangesParaInterpretadores.oralPleasureSensibilidad_MinWorldRango_Tactil
		{
			get
			{
				return this.oralPleasureSensibilidad_MinWorldRango_Tactil;
			}
		}

		// Token: 0x1700055F RID: 1375
		// (get) Token: 0x06001761 RID: 5985 RVA: 0x0006FAC8 File Offset: 0x0006DCC8
		float IHoleRangesParaInterpretadores.oralPleasureSensibilidad_MinWorldRango_Coital
		{
			get
			{
				return this.oralPleasureSensibilidad_MinWorldRango_Coital;
			}
		}

		// Token: 0x17000560 RID: 1376
		// (get) Token: 0x06001762 RID: 5986 RVA: 0x0006FAD0 File Offset: 0x0006DCD0
		float IHoleRangesParaInterpretadores.vaginalPleasureSensibilidad_MinWorldRango_Tactil
		{
			get
			{
				return this.vaginalPleasureSensibilidad_MinWorldRango_Tactil;
			}
		}

		// Token: 0x17000561 RID: 1377
		// (get) Token: 0x06001763 RID: 5987 RVA: 0x0006FAD8 File Offset: 0x0006DCD8
		float IHoleRangesParaInterpretadores.vaginalPleasureSensibilidad_MinWorldRango_Coital
		{
			get
			{
				return this.vaginalPleasureSensibilidad_MinWorldRango_Coital;
			}
		}

		// Token: 0x17000562 RID: 1378
		// (get) Token: 0x06001764 RID: 5988 RVA: 0x0006FAE0 File Offset: 0x0006DCE0
		float IHoleRangesParaInterpretadores.analPleasureSensibilidad_MinWorldRango_Tactil
		{
			get
			{
				return this.analPleasureSensibilidad_MinWorldRango_Tactil;
			}
		}

		// Token: 0x17000563 RID: 1379
		// (get) Token: 0x06001765 RID: 5989 RVA: 0x0006FAE8 File Offset: 0x0006DCE8
		float IHoleRangesParaInterpretadores.analPleasureSensibilidad_MinWorldRango_Coital
		{
			get
			{
				return this.analPleasureSensibilidad_MinWorldRango_Coital;
			}
		}

		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x06001766 RID: 5990 RVA: 0x0006FAF0 File Offset: 0x0006DCF0
		float IHoleRangesParaInterpretadores.oralPainGain_MaxGeneracion_Coital
		{
			get
			{
				return this.oralPainGain_MaxGeneracion_Coital;
			}
		}

		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x06001767 RID: 5991 RVA: 0x0006FAF8 File Offset: 0x0006DCF8
		float IHoleRangesParaInterpretadores.oralPainGain_MaxGeneracion
		{
			get
			{
				return this.oralPainGain_MaxGeneracion;
			}
		}

		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x06001768 RID: 5992 RVA: 0x0006FB00 File Offset: 0x0006DD00
		float IHoleRangesParaInterpretadores.oralPleasureGain_MaxGeneracion_Coital
		{
			get
			{
				return this.oralPleasureGain_MaxGeneracion_Coital;
			}
		}

		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x06001769 RID: 5993 RVA: 0x0006FB08 File Offset: 0x0006DD08
		float IHoleRangesParaInterpretadores.oralPleasureGain_MaxGeneracion
		{
			get
			{
				return this.oralPleasureGain_MaxGeneracion;
			}
		}

		// Token: 0x17000568 RID: 1384
		// (get) Token: 0x0600176A RID: 5994 RVA: 0x0006FB10 File Offset: 0x0006DD10
		float IHoleRangesParaInterpretadores.oralRageGain_MaxGeneracion_Coital
		{
			get
			{
				return this.oralRageGain_MaxGeneracion_Coital;
			}
		}

		// Token: 0x17000569 RID: 1385
		// (get) Token: 0x0600176B RID: 5995 RVA: 0x0006FB18 File Offset: 0x0006DD18
		float IHoleRangesParaInterpretadores.oralRageGain_MaxGeneracion
		{
			get
			{
				return this.oralRageGain_MaxGeneracion;
			}
		}

		// Token: 0x1700056A RID: 1386
		// (get) Token: 0x0600176C RID: 5996 RVA: 0x0006FB20 File Offset: 0x0006DD20
		float IHoleRangesParaInterpretadores.vaginalPainGain_MaxGeneracion_Coital
		{
			get
			{
				return this.vaginalPainGain_MaxGeneracion_Coital;
			}
		}

		// Token: 0x1700056B RID: 1387
		// (get) Token: 0x0600176D RID: 5997 RVA: 0x0006FB28 File Offset: 0x0006DD28
		float IHoleRangesParaInterpretadores.vaginalPainGain_MaxGeneracion
		{
			get
			{
				return this.vaginalPainGain_MaxGeneracion;
			}
		}

		// Token: 0x1700056C RID: 1388
		// (get) Token: 0x0600176E RID: 5998 RVA: 0x0006FB30 File Offset: 0x0006DD30
		float IHoleRangesParaInterpretadores.vaginalPleasureGain_MaxGeneracion_Coital
		{
			get
			{
				return this.vaginalPleasureGain_MaxGeneracion_Coital;
			}
		}

		// Token: 0x1700056D RID: 1389
		// (get) Token: 0x0600176F RID: 5999 RVA: 0x0006FB38 File Offset: 0x0006DD38
		float IHoleRangesParaInterpretadores.vaginalPleasureGain_MaxGeneracion
		{
			get
			{
				return this.vaginalPleasureGain_MaxGeneracion;
			}
		}

		// Token: 0x1700056E RID: 1390
		// (get) Token: 0x06001770 RID: 6000 RVA: 0x0006FB40 File Offset: 0x0006DD40
		float IHoleRangesParaInterpretadores.vaginalRageGain_MaxGeneracion_Coital
		{
			get
			{
				return this.vaginalRageGain_MaxGeneracion_Coital;
			}
		}

		// Token: 0x1700056F RID: 1391
		// (get) Token: 0x06001771 RID: 6001 RVA: 0x0006FB48 File Offset: 0x0006DD48
		float IHoleRangesParaInterpretadores.vaginalRageGain_MaxGeneracion
		{
			get
			{
				return this.vaginalRageGain_MaxGeneracion;
			}
		}

		// Token: 0x17000570 RID: 1392
		// (get) Token: 0x06001772 RID: 6002 RVA: 0x0006FB50 File Offset: 0x0006DD50
		float IHoleRangesParaInterpretadores.analPainGain_MaxGeneracion_Coital
		{
			get
			{
				return this.analPainGain_MaxGeneracion_Coital;
			}
		}

		// Token: 0x17000571 RID: 1393
		// (get) Token: 0x06001773 RID: 6003 RVA: 0x0006FB58 File Offset: 0x0006DD58
		float IHoleRangesParaInterpretadores.analPainGain_MaxGeneracion
		{
			get
			{
				return this.analPainGain_MaxGeneracion;
			}
		}

		// Token: 0x17000572 RID: 1394
		// (get) Token: 0x06001774 RID: 6004 RVA: 0x0006FB60 File Offset: 0x0006DD60
		float IHoleRangesParaInterpretadores.analPleasureGain_MaxGeneracion_Coital
		{
			get
			{
				return this.analPleasureGain_MaxGeneracion_Coital;
			}
		}

		// Token: 0x17000573 RID: 1395
		// (get) Token: 0x06001775 RID: 6005 RVA: 0x0006FB68 File Offset: 0x0006DD68
		float IHoleRangesParaInterpretadores.analPleasureGain_MaxGeneracion
		{
			get
			{
				return this.analPleasureGain_MaxGeneracion;
			}
		}

		// Token: 0x17000574 RID: 1396
		// (get) Token: 0x06001776 RID: 6006 RVA: 0x0006FB70 File Offset: 0x0006DD70
		float IHoleRangesParaInterpretadores.analRageGain_MaxGeneracion_Coital
		{
			get
			{
				return this.analRageGain_MaxGeneracion_Coital;
			}
		}

		// Token: 0x17000575 RID: 1397
		// (get) Token: 0x06001777 RID: 6007 RVA: 0x0006FB78 File Offset: 0x0006DD78
		float IHoleRangesParaInterpretadores.analRageGain_MaxGeneracion
		{
			get
			{
				return this.analRageGain_MaxGeneracion;
			}
		}

		// Token: 0x17000576 RID: 1398
		// (get) Token: 0x06001778 RID: 6008 RVA: 0x0006FB80 File Offset: 0x0006DD80
		float IHoleRangesParaInterpretadores.oralVisualFavoravility
		{
			get
			{
				return this.oralVisualFavoravility;
			}
		}

		// Token: 0x17000577 RID: 1399
		// (get) Token: 0x06001779 RID: 6009 RVA: 0x0006FB88 File Offset: 0x0006DD88
		float IHoleRangesParaInterpretadores.oralTactilFavoravility
		{
			get
			{
				return this.oralTactilFavoravility;
			}
		}

		// Token: 0x17000578 RID: 1400
		// (get) Token: 0x0600177A RID: 6010 RVA: 0x0006FB90 File Offset: 0x0006DD90
		float IHoleRangesParaInterpretadores.oralExposureFavoravility
		{
			get
			{
				return this.oralExposureFavoravility;
			}
		}

		// Token: 0x17000579 RID: 1401
		// (get) Token: 0x0600177B RID: 6011 RVA: 0x0006FB98 File Offset: 0x0006DD98
		float IHoleRangesParaInterpretadores.oralCoitalFavoravility
		{
			get
			{
				return this.oralCoitalFavoravility;
			}
		}

		// Token: 0x1700057A RID: 1402
		// (get) Token: 0x0600177C RID: 6012 RVA: 0x0006FBA0 File Offset: 0x0006DDA0
		float IHoleRangesParaInterpretadores.vaginalVisualFavoravility
		{
			get
			{
				return this.vaginalVisualFavoravility;
			}
		}

		// Token: 0x1700057B RID: 1403
		// (get) Token: 0x0600177D RID: 6013 RVA: 0x0006FBA8 File Offset: 0x0006DDA8
		float IHoleRangesParaInterpretadores.vaginalTactilFavoravility
		{
			get
			{
				return this.vaginalTactilFavoravility;
			}
		}

		// Token: 0x1700057C RID: 1404
		// (get) Token: 0x0600177E RID: 6014 RVA: 0x0006FBB0 File Offset: 0x0006DDB0
		float IHoleRangesParaInterpretadores.vaginalExposureFavoravility
		{
			get
			{
				return this.vaginalExposureFavoravility;
			}
		}

		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x0600177F RID: 6015 RVA: 0x0006FBB8 File Offset: 0x0006DDB8
		float IHoleRangesParaInterpretadores.vaginalCoitalFavoravility
		{
			get
			{
				return this.vaginalCoitalFavoravility;
			}
		}

		// Token: 0x1700057E RID: 1406
		// (get) Token: 0x06001780 RID: 6016 RVA: 0x0006FBC0 File Offset: 0x0006DDC0
		float IHoleRangesParaInterpretadores.analVisualFavoravility
		{
			get
			{
				return this.analVisualFavoravility;
			}
		}

		// Token: 0x1700057F RID: 1407
		// (get) Token: 0x06001781 RID: 6017 RVA: 0x0006FBC8 File Offset: 0x0006DDC8
		float IHoleRangesParaInterpretadores.analTactilFavoravility
		{
			get
			{
				return this.analTactilFavoravility;
			}
		}

		// Token: 0x17000580 RID: 1408
		// (get) Token: 0x06001782 RID: 6018 RVA: 0x0006FBD0 File Offset: 0x0006DDD0
		float IHoleRangesParaInterpretadores.analExposureFavoravility
		{
			get
			{
				return this.analExposureFavoravility;
			}
		}

		// Token: 0x17000581 RID: 1409
		// (get) Token: 0x06001783 RID: 6019 RVA: 0x0006FBD8 File Offset: 0x0006DDD8
		float IHoleRangesParaInterpretadores.analCoitalFavoravility
		{
			get
			{
				return this.analCoitalFavoravility;
			}
		}

		// Token: 0x17000582 RID: 1410
		// (get) Token: 0x06001784 RID: 6020 RVA: 0x0006FBE0 File Offset: 0x0006DDE0
		float IHoleRangesParaInterpretadores.oralPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil
		{
			get
			{
				return this.oralPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil;
			}
		}

		// Token: 0x17000583 RID: 1411
		// (get) Token: 0x06001785 RID: 6021 RVA: 0x0006FBE8 File Offset: 0x0006DDE8
		float IHoleRangesParaInterpretadores.oralPleasureSensibilidad_MinMaxDistanceWorldRango_Coital
		{
			get
			{
				return this.oralPleasureSensibilidad_MinMaxDistanceWorldRango_Coital;
			}
		}

		// Token: 0x17000584 RID: 1412
		// (get) Token: 0x06001786 RID: 6022 RVA: 0x0006FBF0 File Offset: 0x0006DDF0
		float IHoleRangesParaInterpretadores.vaginalPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil
		{
			get
			{
				return this.vaginalPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil;
			}
		}

		// Token: 0x17000585 RID: 1413
		// (get) Token: 0x06001787 RID: 6023 RVA: 0x0006FBF8 File Offset: 0x0006DDF8
		float IHoleRangesParaInterpretadores.vaginalPleasureSensibilidad_MinMaxDistanceWorldRango_Coital
		{
			get
			{
				return this.vaginalPleasureSensibilidad_MinMaxDistanceWorldRango_Coital;
			}
		}

		// Token: 0x17000586 RID: 1414
		// (get) Token: 0x06001788 RID: 6024 RVA: 0x0006FC00 File Offset: 0x0006DE00
		float IHoleRangesParaInterpretadores.analPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil
		{
			get
			{
				return this.analPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil;
			}
		}

		// Token: 0x17000587 RID: 1415
		// (get) Token: 0x06001789 RID: 6025 RVA: 0x0006FC08 File Offset: 0x0006DE08
		float IHoleRangesParaInterpretadores.analPleasureSensibilidad_MinMaxDistanceWorldRango_Coital
		{
			get
			{
				return this.analPleasureSensibilidad_MinMaxDistanceWorldRango_Coital;
			}
		}

		// Token: 0x17000588 RID: 1416
		// (get) Token: 0x0600178A RID: 6026 RVA: 0x0006FC10 File Offset: 0x0006DE10
		float IHoleRangesParaInterpretadores.vaginalPleasure_MaxValue_Tactil
		{
			get
			{
				return this.vaginalPleasureMaxValue_Tactil;
			}
		}

		// Token: 0x17000589 RID: 1417
		// (get) Token: 0x0600178B RID: 6027 RVA: 0x0006FC18 File Offset: 0x0006DE18
		float IHoleRangesParaInterpretadores.vaginalPleasure_MaxValue_Coital
		{
			get
			{
				return this.vaginalPleasureMaxValue_Coital;
			}
		}

		// Token: 0x1700058A RID: 1418
		// (get) Token: 0x0600178C RID: 6028 RVA: 0x0006FC20 File Offset: 0x0006DE20
		float IHoleRangesParaInterpretadores.analPleasure_MaxValue_Tactil
		{
			get
			{
				return this.analPleasureMaxValue_Tactil;
			}
		}

		// Token: 0x1700058B RID: 1419
		// (get) Token: 0x0600178D RID: 6029 RVA: 0x0006FC28 File Offset: 0x0006DE28
		float IHoleRangesParaInterpretadores.analPleasure_MaxValue_Coital
		{
			get
			{
				return this.analPleasureMaxValue_Coital;
			}
		}

		// Token: 0x1700058C RID: 1420
		// (get) Token: 0x0600178E RID: 6030 RVA: 0x0006FC30 File Offset: 0x0006DE30
		float IHoleRangesParaInterpretadores.oralPleasure_MaxValue_Tactil
		{
			get
			{
				return this.oralPleasureMaxValue_Tactil;
			}
		}

		// Token: 0x1700058D RID: 1421
		// (get) Token: 0x0600178F RID: 6031 RVA: 0x0006FC38 File Offset: 0x0006DE38
		float IHoleRangesParaInterpretadores.oralPleasure_MaxValue_Coital
		{
			get
			{
				return this.oralPleasureMaxValue_Coital;
			}
		}

		// Token: 0x0400110A RID: 4362
		[Header("Sensibilidad")]
		public float oralPainSensibilidad_MinWorldRango_Tactil;

		// Token: 0x0400110B RID: 4363
		public float oralPainSensibilidad_MinWorldRango_Coital;

		// Token: 0x0400110C RID: 4364
		public float vaginalPainSensibilidad_MinWorldRango_Tactil;

		// Token: 0x0400110D RID: 4365
		public float vaginalPainSensibilidad_MinWorldRango_Coital;

		// Token: 0x0400110E RID: 4366
		public float analPainSensibilidad_MinWorldRango_Tactil;

		// Token: 0x0400110F RID: 4367
		public float analPainSensibilidad_MinWorldRango_Coital;

		// Token: 0x04001110 RID: 4368
		public float oralPleasureSensibilidad_MinWorldRango_Tactil;

		// Token: 0x04001111 RID: 4369
		public float oralPleasureSensibilidad_MinWorldRango_Coital;

		// Token: 0x04001112 RID: 4370
		public float oralPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil;

		// Token: 0x04001113 RID: 4371
		public float oralPleasureSensibilidad_MinMaxDistanceWorldRango_Coital;

		// Token: 0x04001114 RID: 4372
		public float vaginalPleasureSensibilidad_MinWorldRango_Tactil;

		// Token: 0x04001115 RID: 4373
		public float vaginalPleasureSensibilidad_MinWorldRango_Coital;

		// Token: 0x04001116 RID: 4374
		public float vaginalPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil;

		// Token: 0x04001117 RID: 4375
		public float vaginalPleasureSensibilidad_MinMaxDistanceWorldRango_Coital;

		// Token: 0x04001118 RID: 4376
		public float analPleasureSensibilidad_MinWorldRango_Tactil;

		// Token: 0x04001119 RID: 4377
		public float analPleasureSensibilidad_MinWorldRango_Coital;

		// Token: 0x0400111A RID: 4378
		public float analPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil;

		// Token: 0x0400111B RID: 4379
		public float analPleasureSensibilidad_MinMaxDistanceWorldRango_Coital;

		// Token: 0x0400111C RID: 4380
		[Header("Max Values")]
		public float oralPleasureMaxValue_Tactil;

		// Token: 0x0400111D RID: 4381
		public float oralPleasureMaxValue_Coital;

		// Token: 0x0400111E RID: 4382
		public float vaginalPleasureMaxValue_Tactil;

		// Token: 0x0400111F RID: 4383
		public float vaginalPleasureMaxValue_Coital;

		// Token: 0x04001120 RID: 4384
		public float analPleasureMaxValue_Tactil;

		// Token: 0x04001121 RID: 4385
		public float analPleasureMaxValue_Coital;

		// Token: 0x04001122 RID: 4386
		[Header("Gain")]
		public float oralPainGain_MaxGeneracion_Coital;

		// Token: 0x04001123 RID: 4387
		public float oralPainGain_MaxGeneracion;

		// Token: 0x04001124 RID: 4388
		public float oralPleasureGain_MaxGeneracion_Coital;

		// Token: 0x04001125 RID: 4389
		public float oralPleasureGain_MaxGeneracion;

		// Token: 0x04001126 RID: 4390
		public float oralRageGain_MaxGeneracion_Coital;

		// Token: 0x04001127 RID: 4391
		public float oralRageGain_MaxGeneracion;

		// Token: 0x04001128 RID: 4392
		public float vaginalPainGain_MaxGeneracion_Coital;

		// Token: 0x04001129 RID: 4393
		public float vaginalPainGain_MaxGeneracion;

		// Token: 0x0400112A RID: 4394
		public float vaginalPleasureGain_MaxGeneracion_Coital;

		// Token: 0x0400112B RID: 4395
		public float vaginalPleasureGain_MaxGeneracion;

		// Token: 0x0400112C RID: 4396
		public float vaginalRageGain_MaxGeneracion_Coital;

		// Token: 0x0400112D RID: 4397
		public float vaginalRageGain_MaxGeneracion;

		// Token: 0x0400112E RID: 4398
		public float analPainGain_MaxGeneracion_Coital;

		// Token: 0x0400112F RID: 4399
		public float analPainGain_MaxGeneracion;

		// Token: 0x04001130 RID: 4400
		public float analPleasureGain_MaxGeneracion_Coital;

		// Token: 0x04001131 RID: 4401
		public float analPleasureGain_MaxGeneracion;

		// Token: 0x04001132 RID: 4402
		public float analRageGain_MaxGeneracion_Coital;

		// Token: 0x04001133 RID: 4403
		public float analRageGain_MaxGeneracion;

		// Token: 0x04001134 RID: 4404
		[Header("Favoravilidad")]
		public float oralVisualFavoravility;

		// Token: 0x04001135 RID: 4405
		public float oralTactilFavoravility;

		// Token: 0x04001136 RID: 4406
		public float oralExposureFavoravility;

		// Token: 0x04001137 RID: 4407
		public float oralCoitalFavoravility;

		// Token: 0x04001138 RID: 4408
		public float vaginalVisualFavoravility;

		// Token: 0x04001139 RID: 4409
		public float vaginalTactilFavoravility;

		// Token: 0x0400113A RID: 4410
		public float vaginalExposureFavoravility;

		// Token: 0x0400113B RID: 4411
		public float vaginalCoitalFavoravility;

		// Token: 0x0400113C RID: 4412
		public float analVisualFavoravility;

		// Token: 0x0400113D RID: 4413
		public float analTactilFavoravility;

		// Token: 0x0400113E RID: 4414
		public float analExposureFavoravility;

		// Token: 0x0400113F RID: 4415
		public float analCoitalFavoravility;

		// Token: 0x020003A2 RID: 930
		private class Data
		{
			// Token: 0x04001140 RID: 4416
			public List<RangeValueV2> intervalosPainTactiles = new List<RangeValueV2>();

			// Token: 0x04001141 RID: 4417
			public List<RangeValueV2> intervalosPleasureTactiles = new List<RangeValueV2>();

			// Token: 0x04001142 RID: 4418
			public List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>> minMaxPain = new List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>>();

			// Token: 0x04001143 RID: 4419
			public List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>> minMaxPleasure = new List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>>();

			// Token: 0x04001144 RID: 4420
			public List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>> minMaxRage = new List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>>();

			// Token: 0x04001145 RID: 4421
			public List<RangeValueV2> intervalosPainCoital = new List<RangeValueV2>();

			// Token: 0x04001146 RID: 4422
			public List<RangeValueV2> intervalosPleasureCoital = new List<RangeValueV2>();

			// Token: 0x04001147 RID: 4423
			public List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>> minMaxPainCoital = new List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>>();

			// Token: 0x04001148 RID: 4424
			public List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>> minMaxPleasureCoital = new List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>>();

			// Token: 0x04001149 RID: 4425
			public List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>> minMaxRageCoital = new List<ValueTuple<UmbralBasico.Estado, UmbralBasico.Estado>>();

			// Token: 0x0400114A RID: 4426
			public List<float> pleasureMaxValuesTactiles = new List<float>();

			// Token: 0x0400114B RID: 4427
			public List<float> pleasureMaxValuesCoitales = new List<float>();

			// Token: 0x0400114C RID: 4428
			public List<float> favorabilidadesVisual = new List<float>();

			// Token: 0x0400114D RID: 4429
			public List<float> favorabilidadesTactil = new List<float>();

			// Token: 0x0400114E RID: 4430
			public List<float> favorabilidadesExposure = new List<float>();

			// Token: 0x0400114F RID: 4431
			public List<float> favorabilidadesCoital = new List<float>();
		}
	}
}
