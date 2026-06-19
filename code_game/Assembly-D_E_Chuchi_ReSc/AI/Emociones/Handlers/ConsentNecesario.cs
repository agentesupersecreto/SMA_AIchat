using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x0200046E RID: 1134
	[RequireComponent(typeof(Personalidad))]
	public class ConsentNecesario : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x1700063F RID: 1599
		// (get) Token: 0x060018BA RID: 6330 RVA: 0x00064BE4 File Offset: 0x00062DE4
		public Personalidad personalidad
		{
			get
			{
				return this.m_Personalidad;
			}
		}

		// Token: 0x17000640 RID: 1600
		// (get) Token: 0x060018BB RID: 6331 RVA: 0x00064BEC File Offset: 0x00062DEC
		public float consentActual
		{
			get
			{
				return this.m_emos.consentToHero.value.total;
			}
		}

		// Token: 0x17000641 RID: 1601
		// (get) Token: 0x060018BC RID: 6332 RVA: 0x00064C11 File Offset: 0x00062E11
		public ConsentToHero consentToHero
		{
			get
			{
				return this.m_emos.consentToHero;
			}
		}

		// Token: 0x17000642 RID: 1602
		// (get) Token: 0x060018BD RID: 6333 RVA: 0x00064C1E File Offset: 0x00062E1E
		public EmocionesFemeninas emociones
		{
			get
			{
				return this.m_emos;
			}
		}

		// Token: 0x060018BE RID: 6334 RVA: 0x00064C26 File Offset: 0x00062E26
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetManualStart();
			this.GetComponentEnRoot(false).loadedAI += this.ConcentNecesario_loadedAI;
		}

		// Token: 0x060018BF RID: 6335 RVA: 0x00064C4C File Offset: 0x00062E4C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_emos = this.GetComponentEnRoot(false);
			if (this.m_emos == null)
			{
				throw new ArgumentNullException("m_emos", "m_emos null reference.");
			}
		}

		// Token: 0x060018C0 RID: 6336 RVA: 0x00064C7F File Offset: 0x00062E7F
		private void ConcentNecesario_loadedAI(Character obj)
		{
			this.m_Personalidad = base.GetComponent<Personalidad>();
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			base.ManualStart();
		}

		// Token: 0x060018C1 RID: 6337 RVA: 0x00064CB4 File Offset: 0x00062EB4
		public ConsentNecesario.Modificables GetModificador(TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano parteDelCuerpoHumano, ParteQuePuedeEstimular? parteQuePuedeEstimular, DireccionDeEstimulo direccionDeEstimulo)
		{
			ValueTuple<TipoDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, DireccionDeEstimulo> valueTuple = new ValueTuple<TipoDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, DireccionDeEstimulo>(tipoDeEstimulo, parteDelCuerpoHumano, (parteQuePuedeEstimular == null) ? ParteQuePuedeEstimular.None : parteQuePuedeEstimular.Value, direccionDeEstimulo);
			ConsentNecesario.Modificables modificables;
			if (!this.m_modificablesDeInteraccion.TryGetValue(valueTuple, out modificables))
			{
				return null;
			}
			return modificables;
		}

		// Token: 0x060018C2 RID: 6338 RVA: 0x00064CF4 File Offset: 0x00062EF4
		public ConsentNecesario.Modificables GetModificadorNotNull(TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano parteDelCuerpoHumano, ParteQuePuedeEstimular? parteQuePuedeEstimular, DireccionDeEstimulo direccionDeEstimulo)
		{
			ValueTuple<TipoDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, DireccionDeEstimulo> valueTuple = new ValueTuple<TipoDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, DireccionDeEstimulo>(tipoDeEstimulo, parteDelCuerpoHumano, (parteQuePuedeEstimular == null) ? ParteQuePuedeEstimular.None : parteQuePuedeEstimular.Value, direccionDeEstimulo);
			ConsentNecesario.Modificables modificables;
			if (!this.m_modificablesDeInteraccion.TryGetValue(valueTuple, out modificables))
			{
				modificables = new ConsentNecesario.Modificables(tipoDeEstimulo, parteDelCuerpoHumano, valueTuple.Item3, direccionDeEstimulo);
				this.m_modificablesDeInteraccion.Add(valueTuple, modificables);
			}
			return modificables;
		}

		// Token: 0x060018C3 RID: 6339 RVA: 0x0005E464 File Offset: 0x0005C664
		public static float MinConcentPorSemenTocando()
		{
			return 10f;
		}

		// Token: 0x060018C4 RID: 6340 RVA: 0x00064D50 File Offset: 0x00062F50
		private static float ParaVisual(DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ref EmocionesFemeninasValues emocionesValoresMods, ParteQuePuedeEstimular? estimulante, Personalidad m_Personalidad, float modVisualRecibido = 1f, float modVisualDada = 1f)
		{
			if (direccion == DireccionDeEstimulo.recibida)
			{
				return ConsentNecesario.NecesarioVisualRecibida(estimulada, m_Personalidad, ref emocionesValoresMods, 0f, estimulante) * modVisualRecibido;
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			return ConsentNecesario.NecesarioVisualDada(estimulada, m_Personalidad, ref emocionesValoresMods, 0f, estimulante) * modVisualDada;
		}

		// Token: 0x060018C5 RID: 6341 RVA: 0x00064DA0 File Offset: 0x00062FA0
		private static float ParaTactil(DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular? estimulante, bool esGolpe, ref EmocionesFemeninasValues emocionesValoresMods, Personalidad m_Personalidad, float modTactilRecibido = 1f)
		{
			if (direccion == DireccionDeEstimulo.dada)
			{
				return 0f;
			}
			if (esGolpe)
			{
				throw new NotSupportedException();
			}
			float num = 0f;
			ParteQuePuedeEstimular? parteQuePuedeEstimular = estimulante;
			ParteQuePuedeEstimular parteQuePuedeEstimular2 = ParteQuePuedeEstimular.semen;
			if ((parteQuePuedeEstimular.GetValueOrDefault() == parteQuePuedeEstimular2) & (parteQuePuedeEstimular != null))
			{
				num = ConsentNecesario.MinConcentPorSemenTocando();
			}
			return ConsentNecesario.NecesarioTactilRecibida(estimulada, estimulante, m_Personalidad, ref emocionesValoresMods, num) * modTactilRecibido;
		}

		// Token: 0x060018C6 RID: 6342 RVA: 0x00064DF8 File Offset: 0x00062FF8
		[Obsolete("no admite modificadores", true)]
		private float MenorParaTactil(DireccionDeEstimulo direccion, bool esGolpe, ParteQuePuedeEstimular? parteEstimulante, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			if (esGolpe)
			{
				throw new NotSupportedException();
			}
			float num = 0f;
			if (parteEstimulante != null && parteEstimulante.Value == ParteQuePuedeEstimular.semen)
			{
				num = ConsentNecesario.MinConcentPorSemenTocando();
			}
			if (direccion == DireccionDeEstimulo.recibida)
			{
				return ConsentNecesario.MenorNecesarioTactilRecibida(this.m_Personalidad, ref emocionesValoresMods, num, parteEstimulante);
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			throw new NotSupportedException();
		}

		// Token: 0x060018C7 RID: 6343 RVA: 0x00064E64 File Offset: 0x00063064
		[Obsolete("no admite modificadores", true)]
		private float MayorParaTactil(DireccionDeEstimulo direccion, bool esGolpe, ParteQuePuedeEstimular? parteEstimulante, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			if (esGolpe)
			{
				throw new NotSupportedException();
			}
			float num = 0f;
			if (parteEstimulante != null && parteEstimulante.Value == ParteQuePuedeEstimular.semen)
			{
				num = ConsentNecesario.MinConcentPorSemenTocando();
			}
			if (direccion == DireccionDeEstimulo.recibida)
			{
				return ConsentNecesario.MayorNecesarioTactilRecibida(this.m_Personalidad, ref emocionesValoresMods, num, parteEstimulante);
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			throw new NotSupportedException();
		}

		// Token: 0x060018C8 RID: 6344 RVA: 0x00064ECE File Offset: 0x000630CE
		private static float ParaCoital(DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular? estimulante, ref EmocionesFemeninasValues emocionesValoresMods, Personalidad m_Personalidad, float modCoitalRecibido = 1f)
		{
			if (direccion == DireccionDeEstimulo.dada)
			{
				return 0f;
			}
			return ConsentNecesario.NecesarioCoitalRecibida(estimulada, estimulante, m_Personalidad, ref emocionesValoresMods, 0f) * modCoitalRecibido;
		}

		// Token: 0x060018C9 RID: 6345 RVA: 0x00064EEC File Offset: 0x000630EC
		public static float NecesarioVisualRecibida(ParteDelCuerpoHumano parteEstimulada, Personalidad personalidad, ref EmocionesFemeninasValues emos, float minConcent, ParteQuePuedeEstimular? parteEstimulante)
		{
			if (parteEstimulante == null && parteEstimulante.Value != ParteQuePuedeEstimular.ojos)
			{
				Debug.LogError("por ahora solo es compatible ver con los ojos, TODO: camara");
			}
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			FloatPorGrupoDicc concentRequeridoPorGrupo = emociones.modificadoresDeIntervalosSegunEmocion.rage.porSiendoVisto.concentRequeridoPorGrupo;
			ModifcadorDeIntervalo concentVsArousal = emociones.modificadoresDeIntervalosSegunEmocion.rage.porSiendoVisto.concentVsArousal;
			return ConsentNecesario.NecesarioPorMapas(parteEstimulada, parteEstimulante, concentRequeridoPorGrupo, emociones.gruposDePartesHumanas.privacidadVisual, minConcent, concentVsArousal, new float?(emos.arousal), emociones.gruposDePartesEstimulantes.privacidad, emociones.modificadoresDeIntervalosSegunEmocion.rage.porSiendoVisto.modificadorDeConcentRequeridoPorGrupoEstimulante);
		}

		// Token: 0x060018CA RID: 6346 RVA: 0x00064F94 File Offset: 0x00063194
		public static float NecesarioVisualDada(ParteDelCuerpoHumano parteEstimulada, Personalidad personalidad, ref EmocionesFemeninasValues emos, float minConcent, ParteQuePuedeEstimular? parteEstimulante)
		{
			if (parteEstimulada != ParteDelCuerpoHumano.ojos)
			{
				Debug.LogError("aun no se puede ver con algo direfente a ojos (DADA)");
				return 0f;
			}
			if (parteEstimulante == null)
			{
				Debug.LogError("debe tener parte estimulante (DADA)");
				return 0f;
			}
			ParteQuePuedeEstimular value = parteEstimulante.Value;
			if (value <= ParteQuePuedeEstimular.ojos)
			{
				if (value == ParteQuePuedeEstimular.pene)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano = ParteDelCuerpoHumano.pene;
					goto IL_009E;
				}
				if (value == ParteQuePuedeEstimular.ojos)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano = ParteDelCuerpoHumano.ojos;
					goto IL_009E;
				}
			}
			else
			{
				if (value == ParteQuePuedeEstimular.semen)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano = ParteDelCuerpoHumano.pene;
					goto IL_009E;
				}
				if (value == ParteQuePuedeEstimular.dedo)
				{
					ParteDelCuerpoHumano parteDelCuerpoHumano = ParteDelCuerpoHumano.manos;
					goto IL_009E;
				}
			}
			throw new ArgumentOutOfRangeException(parteEstimulante.Value.ToString() + ", solo se puede ver partes de male... ojos,pene,dedo,semen");
			IL_009E:
			if (parteEstimulada == ParteDelCuerpoHumano.ojos)
			{
				ParteQuePuedeEstimular parteQuePuedeEstimular = ParteQuePuedeEstimular.ojos;
				MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
				FloatPorGrupoDicc concentRequeridoPorGrupo = emociones.modificadoresDeIntervalosSegunEmocion.rage.porVer.concentRequeridoPorGrupo;
				ModifcadorDeIntervalo concentVsArousal = emociones.modificadoresDeIntervalosSegunEmocion.rage.porVer.concentVsArousal;
				ParteDelCuerpoHumano parteDelCuerpoHumano;
				return ConsentNecesario.NecesarioPorMapas(parteDelCuerpoHumano, new ParteQuePuedeEstimular?(parteQuePuedeEstimular), concentRequeridoPorGrupo, emociones.gruposDePartesHumanas.privacidadVisual, minConcent, concentVsArousal, new float?(emos.arousal), emociones.gruposDePartesEstimulantes.privacidad, emociones.modificadoresDeIntervalosSegunEmocion.rage.porSiendoVisto.modificadorDeConcentRequeridoPorGrupoEstimulante);
			}
			throw new ArgumentOutOfRangeException(parteEstimulada.ToString());
		}

		// Token: 0x060018CB RID: 6347 RVA: 0x000650E0 File Offset: 0x000632E0
		public static float NecesarioVisualBaseRecibida(ParteDelCuerpoHumano parteEstimulada, Personalidad personalidad)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			return ConsentNecesario.NecesarioVisualBaseRecibida(parteEstimulada, emociones);
		}

		// Token: 0x060018CC RID: 6348 RVA: 0x00065100 File Offset: 0x00063300
		public static float NecesarioVisualBaseRecibida(ParteDelCuerpoHumano parteEstimulada, MapaDeEmociones mapaDeEmociones)
		{
			FloatPorGrupoDicc concentRequeridoPorGrupo = mapaDeEmociones.modificadoresDeIntervalosSegunEmocion.rage.porSiendoVisto.concentRequeridoPorGrupo;
			return ConsentNecesario.NecesarioPorMapas(parteEstimulada, null, concentRequeridoPorGrupo, mapaDeEmociones.gruposDePartesHumanas.privacidadVisual, float.MinValue, null, null, null, null);
		}

		// Token: 0x060018CD RID: 6349 RVA: 0x00065150 File Offset: 0x00063350
		public static float NecesarioTactilRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular? parteEstimulante, Personalidad personalidad, ref EmocionesFemeninasValues emos, float minConcent)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			FloatPorGrupoDicc concentRequeridoPorGrupo = emociones.modificadoresDeIntervalosSegunEmocion.rage.porCaricias.concentRequeridoPorGrupo;
			FloatPorGrupoDicc modificadorDeConcentRequeridoPorGrupoEstimulante = emociones.modificadoresDeIntervalosSegunEmocion.rage.porCaricias.modificadorDeConcentRequeridoPorGrupoEstimulante;
			ModifcadorDeIntervalo concentVsArousal = emociones.modificadoresDeIntervalosSegunEmocion.rage.porCaricias.concentVsArousal;
			PartesHumanasPorGrupo privacidad = emociones.gruposDePartesHumanas.privacidad;
			PartesEstimulantePorGrupo privacidad2 = emociones.gruposDePartesEstimulantes.privacidad;
			return ConsentNecesario.NecesarioPorMapas(parteEstimulada, parteEstimulante, concentRequeridoPorGrupo, privacidad, minConcent, concentVsArousal, new float?(emos.arousal), privacidad2, modificadorDeConcentRequeridoPorGrupoEstimulante);
		}

		// Token: 0x060018CE RID: 6350 RVA: 0x000651DC File Offset: 0x000633DC
		public static float NecesarioTactilBaseRecibida(ParteDelCuerpoHumano parteEstimulada, Personalidad personalidad)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			return ConsentNecesario.NecesarioTactilBaseRecibida(parteEstimulada, emociones);
		}

		// Token: 0x060018CF RID: 6351 RVA: 0x000651FC File Offset: 0x000633FC
		public static float NecesarioTactilBaseRecibida(ParteDelCuerpoHumano parteEstimulada, MapaDeEmociones mapaDeEmociones)
		{
			FloatPorGrupoDicc concentRequeridoPorGrupo = mapaDeEmociones.modificadoresDeIntervalosSegunEmocion.rage.porCaricias.concentRequeridoPorGrupo;
			return ConsentNecesario.NecesarioPorMapas(parteEstimulada, null, concentRequeridoPorGrupo, mapaDeEmociones.gruposDePartesHumanas.privacidad, float.MinValue, null, null, null, null);
		}

		// Token: 0x060018D0 RID: 6352 RVA: 0x0006524C File Offset: 0x0006344C
		[Obsolete("no admite modificadores", true)]
		public static float MenorNecesarioTactilRecibida(Personalidad personalidad, ref EmocionesFemeninasValues emos, float minConcent, ParteQuePuedeEstimular? parteEstimulante)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			FloatPorGrupoDicc concentRequeridoPorGrupo = emociones.modificadoresDeIntervalosSegunEmocion.rage.porCaricias.concentRequeridoPorGrupo;
			FloatPorGrupoDicc modificadorDeConcentRequeridoPorGrupoEstimulante = emociones.modificadoresDeIntervalosSegunEmocion.rage.porCaricias.modificadorDeConcentRequeridoPorGrupoEstimulante;
			ModifcadorDeIntervalo concentVsArousal = emociones.modificadoresDeIntervalosSegunEmocion.rage.porCaricias.concentVsArousal;
			PartesEstimulantePorGrupo privacidad = emociones.gruposDePartesEstimulantes.privacidad;
			return ConsentNecesario.MenorNecesarioPorMapas(concentRequeridoPorGrupo, minConcent, concentVsArousal, new float?(emos.arousal), privacidad, modificadorDeConcentRequeridoPorGrupoEstimulante, parteEstimulante);
		}

		// Token: 0x060018D1 RID: 6353 RVA: 0x000652C8 File Offset: 0x000634C8
		[Obsolete("no admite modificadores", true)]
		public static float MayorNecesarioTactilRecibida(Personalidad personalidad, ref EmocionesFemeninasValues emos, float minConcent, ParteQuePuedeEstimular? parteEstimulante)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			FloatPorGrupoDicc concentRequeridoPorGrupo = emociones.modificadoresDeIntervalosSegunEmocion.rage.porCaricias.concentRequeridoPorGrupo;
			FloatPorGrupoDicc modificadorDeConcentRequeridoPorGrupoEstimulante = emociones.modificadoresDeIntervalosSegunEmocion.rage.porCaricias.modificadorDeConcentRequeridoPorGrupoEstimulante;
			ModifcadorDeIntervalo concentVsArousal = emociones.modificadoresDeIntervalosSegunEmocion.rage.porCaricias.concentVsArousal;
			PartesEstimulantePorGrupo privacidad = emociones.gruposDePartesEstimulantes.privacidad;
			return ConsentNecesario.MayorNecesarioPorMapas(concentRequeridoPorGrupo, minConcent, concentVsArousal, new float?(emos.arousal), privacidad, modificadorDeConcentRequeridoPorGrupoEstimulante, parteEstimulante);
		}

		// Token: 0x060018D2 RID: 6354 RVA: 0x00065344 File Offset: 0x00063544
		public static float NecesarioCoitalRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular? parteEstimulante, Personalidad personalidad, ref EmocionesFemeninasValues emos, float minConcent)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			FloatPorGrupoDicc concentRequeridoPorGrupo = emociones.modificadoresDeIntervalosSegunEmocion.rage.porPenetracion.concentRequeridoPorGrupo;
			FloatPorGrupoDicc modificadorDeConcentRequeridoPorGrupoEstimulante = emociones.modificadoresDeIntervalosSegunEmocion.rage.porPenetracion.modificadorDeConcentRequeridoPorGrupoEstimulante;
			ModifcadorDeIntervalo concentVsArousal = emociones.modificadoresDeIntervalosSegunEmocion.rage.porPenetracion.concentVsArousal;
			PartesHumanasPorGrupo privacidad = emociones.gruposDePartesHumanas.privacidad;
			PartesEstimulantePorGrupo privacidad2 = emociones.gruposDePartesEstimulantes.privacidad;
			return ConsentNecesario.NecesarioPorMapas(parteEstimulada, parteEstimulante, concentRequeridoPorGrupo, privacidad, minConcent, concentVsArousal, new float?(emos.arousal), privacidad2, modificadorDeConcentRequeridoPorGrupoEstimulante);
		}

		// Token: 0x060018D3 RID: 6355 RVA: 0x000653D0 File Offset: 0x000635D0
		public static float NecesarioCoitalBaseRecibida(ParteDelCuerpoHumano parteEstimulada, Personalidad personalidad)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			return ConsentNecesario.NecesarioCoitalBaseRecibida(parteEstimulada, emociones);
		}

		// Token: 0x060018D4 RID: 6356 RVA: 0x000653F0 File Offset: 0x000635F0
		public static float NecesarioCoitalBaseRecibida(ParteDelCuerpoHumano parteEstimulada, MapaDeEmociones mapaDeEmociones)
		{
			FloatPorGrupoDicc concentRequeridoPorGrupo = mapaDeEmociones.modificadoresDeIntervalosSegunEmocion.rage.porPenetracion.concentRequeridoPorGrupo;
			return ConsentNecesario.NecesarioPorMapas(parteEstimulada, null, concentRequeridoPorGrupo, mapaDeEmociones.gruposDePartesHumanas.privacidad, float.MinValue, null, null, null, null);
		}

		// Token: 0x060018D5 RID: 6357 RVA: 0x00065440 File Offset: 0x00063640
		[Obsolete("no admite modificadores", true)]
		public static float MenorNecesarioCoitalRecibida(Personalidad personalidad, ref EmocionesFemeninasValues emos, float minConcent, ParteQuePuedeEstimular? parteEstimulante)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			FloatPorGrupoDicc concentRequeridoPorGrupo = emociones.modificadoresDeIntervalosSegunEmocion.rage.porPenetracion.concentRequeridoPorGrupo;
			FloatPorGrupoDicc modificadorDeConcentRequeridoPorGrupoEstimulante = emociones.modificadoresDeIntervalosSegunEmocion.rage.porPenetracion.modificadorDeConcentRequeridoPorGrupoEstimulante;
			ModifcadorDeIntervalo concentVsArousal = emociones.modificadoresDeIntervalosSegunEmocion.rage.porPenetracion.concentVsArousal;
			PartesEstimulantePorGrupo privacidad = emociones.gruposDePartesEstimulantes.privacidad;
			return ConsentNecesario.MenorNecesarioPorMapas(concentRequeridoPorGrupo, minConcent, concentVsArousal, new float?(emos.arousal), privacidad, modificadorDeConcentRequeridoPorGrupoEstimulante, parteEstimulante);
		}

		// Token: 0x060018D6 RID: 6358 RVA: 0x000654BB File Offset: 0x000636BB
		[Obsolete("no admite modificadores", true)]
		private float MenorParaPeticionDesvestir(DireccionDeEstimulo direccion, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			if (direccion == DireccionDeEstimulo.recibida)
			{
				return ConsentNecesario.MenorNecesarioPeticionDesvestirRecibida(this.m_Personalidad, ref emocionesValoresMods, 0f) * this.modPeticionDesvestirRecibido;
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			throw new NotSupportedException();
		}

		// Token: 0x060018D7 RID: 6359 RVA: 0x000654F7 File Offset: 0x000636F7
		[Obsolete("no admite modificadores", true)]
		private float MayorParaPeticionDesvestir(DireccionDeEstimulo direccion, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			if (direccion == DireccionDeEstimulo.recibida)
			{
				return ConsentNecesario.MayorNecesarioPeticionDesvestirRecibida(this.m_Personalidad, ref emocionesValoresMods, 0f) * this.modPeticionDesvestirRecibido;
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			throw new NotSupportedException();
		}

		// Token: 0x060018D8 RID: 6360 RVA: 0x00065533 File Offset: 0x00063733
		private static float ParaDesvestir(DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular? estimulante, ref EmocionesFemeninasValues emocionesValoresMods, Personalidad m_Personalidad, float modDesvestirRecibido = 1f)
		{
			if (direccion == DireccionDeEstimulo.recibida)
			{
				return ConsentNecesario.NecesarioDesvestirRecibida(estimulada, estimulante, m_Personalidad, ref emocionesValoresMods, 0f) * modDesvestirRecibido;
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			throw new NotSupportedException();
		}

		// Token: 0x060018D9 RID: 6361 RVA: 0x00065569 File Offset: 0x00063769
		private static float ParaPeticionDesvestir(DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular? estimulante, ref EmocionesFemeninasValues emocionesValoresMods, Personalidad m_Personalidad, float modPeticionDesvestirRecibido = 1f)
		{
			if (direccion == DireccionDeEstimulo.recibida)
			{
				return ConsentNecesario.NecesarioPeticionDesvestirRecibida(estimulada, estimulante, m_Personalidad, ref emocionesValoresMods, 0f) * modPeticionDesvestirRecibido;
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			throw new NotSupportedException();
		}

		// Token: 0x060018DA RID: 6362 RVA: 0x000655A0 File Offset: 0x000637A0
		public static float NecesarioDesvestirRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular? parteEstimulante, Personalidad personalidad, ref EmocionesFemeninasValues emos, float minConcent)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			FloatPorGrupoDicc concentRequeridoPorGrupo = emociones.modificadoresDeIntervalosSegunEmocion.rage.porSerDesvestidoPorOtro.concentRequeridoPorGrupo;
			ModifcadorDeIntervalo concentVsArousal = emociones.modificadoresDeIntervalosSegunEmocion.rage.porSerDesvestidoPorOtro.concentVsArousal;
			return ConsentNecesario.NecesarioPorMapas(parteEstimulada, parteEstimulante, concentRequeridoPorGrupo, emociones.gruposDePartesHumanas.privacidadVisual, minConcent, concentVsArousal, new float?(emos.arousal), null, null);
		}

		// Token: 0x060018DB RID: 6363 RVA: 0x00065608 File Offset: 0x00063808
		public static float NecesarioPeticionDesvestirRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular? parteEstimulante, Personalidad personalidad, ref EmocionesFemeninasValues emos, float minConcent)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			FloatPorGrupoDicc concentRequeridoPorGrupo = emociones.modificadoresDeIntervalosSegunEmocion.rage.porSerDesvestidoPorSiMismo.concentRequeridoPorGrupo;
			ModifcadorDeIntervalo concentVsArousal = emociones.modificadoresDeIntervalosSegunEmocion.rage.porSerDesvestidoPorSiMismo.concentVsArousal;
			return ConsentNecesario.NecesarioPorMapas(parteEstimulada, parteEstimulante, concentRequeridoPorGrupo, emociones.gruposDePartesHumanas.privacidadVisual, minConcent, concentVsArousal, new float?(emos.arousal), null, null);
		}

		// Token: 0x060018DC RID: 6364 RVA: 0x00065670 File Offset: 0x00063870
		[Obsolete("no admite modificadores", true)]
		public static float MenorNecesarioPeticionDesvestirRecibida(Personalidad personalidad, ref EmocionesFemeninasValues emos, float minConcent)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			FloatPorGrupoDicc concentRequeridoPorGrupo = emociones.modificadoresDeIntervalosSegunEmocion.rage.porSerDesvestidoPorSiMismo.concentRequeridoPorGrupo;
			ModifcadorDeIntervalo concentVsArousal = emociones.modificadoresDeIntervalosSegunEmocion.rage.porSerDesvestidoPorSiMismo.concentVsArousal;
			return ConsentNecesario.MenorNecesarioPorMapas(concentRequeridoPorGrupo, minConcent, concentVsArousal, new float?(emos.arousal), null, null, null);
		}

		// Token: 0x060018DD RID: 6365 RVA: 0x000656D4 File Offset: 0x000638D4
		[Obsolete("no admite modificadores", true)]
		public static float MayorNecesarioPeticionDesvestirRecibida(Personalidad personalidad, ref EmocionesFemeninasValues emos, float minConcent)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			FloatPorGrupoDicc concentRequeridoPorGrupo = emociones.modificadoresDeIntervalosSegunEmocion.rage.porSerDesvestidoPorSiMismo.concentRequeridoPorGrupo;
			ModifcadorDeIntervalo concentVsArousal = emociones.modificadoresDeIntervalosSegunEmocion.rage.porSerDesvestidoPorSiMismo.concentVsArousal;
			return ConsentNecesario.MayorNecesarioPorMapas(concentRequeridoPorGrupo, minConcent, concentVsArousal, new float?(emos.arousal), null, null, null);
		}

		// Token: 0x060018DE RID: 6366 RVA: 0x00065735 File Offset: 0x00063935
		[Obsolete("no admite modificadores", true)]
		private float MenorParaPeticionEjecucionCambioDePose(DireccionDeEstimulo direccion, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			if (direccion == DireccionDeEstimulo.recibida)
			{
				return ConsentNecesario.MenorNecesarioPeticionEjecucionDePoseRecibida(this.m_Personalidad, ref emocionesValoresMods, 0f) * this.modPeticionEjecucionDePoseRecibido;
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			throw new NotSupportedException();
		}

		// Token: 0x060018DF RID: 6367 RVA: 0x00065771 File Offset: 0x00063971
		[Obsolete("no admite modificadores", true)]
		private float MayorParaPeticionEjecucionCambioDePose(DireccionDeEstimulo direccion, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			if (direccion == DireccionDeEstimulo.recibida)
			{
				return ConsentNecesario.MayorNecesarioPeticionEjecucionDePoseRecibida(this.m_Personalidad, ref emocionesValoresMods, 0f) * this.modPeticionEjecucionDePoseRecibido;
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			throw new NotSupportedException();
		}

		// Token: 0x060018E0 RID: 6368 RVA: 0x000657AD File Offset: 0x000639AD
		private static float ParaEjecutarPose(DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular? estimulante, ref EmocionesFemeninasValues emocionesValoresMods, Personalidad m_Personalidad, float modEjecucionDePoseRecibido = 1f)
		{
			if (direccion == DireccionDeEstimulo.recibida)
			{
				return ConsentNecesario.NecesarioEjecutarPoseRecibida(estimulada, estimulante, m_Personalidad, ref emocionesValoresMods, 0f) * modEjecucionDePoseRecibido;
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			throw new NotSupportedException();
		}

		// Token: 0x060018E1 RID: 6369 RVA: 0x000657E3 File Offset: 0x000639E3
		private static float ParaPeticionEjecutarPose(DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular? estimulante, ref EmocionesFemeninasValues emocionesValoresMods, Personalidad m_Personalidad, float modPeticionEjecucionDePoseRecibido = 1f)
		{
			if (direccion == DireccionDeEstimulo.recibida)
			{
				return ConsentNecesario.NecesarioPeticionEjecutarPoseRecibida(estimulada, estimulante, m_Personalidad, ref emocionesValoresMods, 0f) * modPeticionEjecucionDePoseRecibido;
			}
			if (direccion != DireccionDeEstimulo.dada)
			{
				throw new ArgumentOutOfRangeException(direccion.ToString());
			}
			throw new NotSupportedException();
		}

		// Token: 0x060018E2 RID: 6370 RVA: 0x0006581C File Offset: 0x00063A1C
		public static float NecesarioEjecutarPoseRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular? parteEstimulante, Personalidad personalidad, ref EmocionesFemeninasValues emos, float minConcent)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			FloatPorGrupoDicc concentRequeridoPorGrupo = emociones.modificadoresDeIntervalosSegunEmocion.rage.porEjecucionDePosePorOtro.concentRequeridoPorGrupo;
			ModifcadorDeIntervalo concentVsArousal = emociones.modificadoresDeIntervalosSegunEmocion.rage.porEjecucionDePosePorOtro.concentVsArousal;
			return ConsentNecesario.NecesarioPorMapas(parteEstimulada, parteEstimulante, concentRequeridoPorGrupo, emociones.gruposDePartesHumanas.privacidadVisual, minConcent, concentVsArousal, new float?(emos.arousal), null, null);
		}

		// Token: 0x060018E3 RID: 6371 RVA: 0x00065884 File Offset: 0x00063A84
		public static float NecesarioPeticionEjecutarPoseRecibida(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular? parteEstimulante, Personalidad personalidad, ref EmocionesFemeninasValues emos, float minConcent)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			FloatPorGrupoDicc concentRequeridoPorGrupo = emociones.modificadoresDeIntervalosSegunEmocion.rage.porEjecucionDePosePorSiMismo.concentRequeridoPorGrupo;
			ModifcadorDeIntervalo concentVsArousal = emociones.modificadoresDeIntervalosSegunEmocion.rage.porEjecucionDePosePorSiMismo.concentVsArousal;
			return ConsentNecesario.NecesarioPorMapas(parteEstimulada, parteEstimulante, concentRequeridoPorGrupo, emociones.gruposDePartesHumanas.privacidadVisual, minConcent, concentVsArousal, new float?(emos.arousal), null, null);
		}

		// Token: 0x060018E4 RID: 6372 RVA: 0x000658EC File Offset: 0x00063AEC
		[Obsolete("no admite modificadores", true)]
		public static float MenorNecesarioPeticionEjecucionDePoseRecibida(Personalidad personalidad, ref EmocionesFemeninasValues emos, float minConcent)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			FloatPorGrupoDicc concentRequeridoPorGrupo = emociones.modificadoresDeIntervalosSegunEmocion.rage.porEjecucionDePosePorSiMismo.concentRequeridoPorGrupo;
			ModifcadorDeIntervalo concentVsArousal = emociones.modificadoresDeIntervalosSegunEmocion.rage.porEjecucionDePosePorSiMismo.concentVsArousal;
			return ConsentNecesario.MenorNecesarioPorMapas(concentRequeridoPorGrupo, minConcent, concentVsArousal, new float?(emos.arousal), null, null, null);
		}

		// Token: 0x060018E5 RID: 6373 RVA: 0x00065950 File Offset: 0x00063B50
		[Obsolete("no admite modificadores", true)]
		public static float MayorNecesarioPeticionEjecucionDePoseRecibida(Personalidad personalidad, ref EmocionesFemeninasValues emos, float minConcent)
		{
			MapaDeEmociones emociones = personalidad.currentPersonalidad.emociones;
			FloatPorGrupoDicc concentRequeridoPorGrupo = emociones.modificadoresDeIntervalosSegunEmocion.rage.porEjecucionDePosePorSiMismo.concentRequeridoPorGrupo;
			ModifcadorDeIntervalo concentVsArousal = emociones.modificadoresDeIntervalosSegunEmocion.rage.porEjecucionDePosePorSiMismo.concentVsArousal;
			return ConsentNecesario.MayorNecesarioPorMapas(concentRequeridoPorGrupo, minConcent, concentVsArousal, new float?(emos.arousal), null, null, null);
		}

		// Token: 0x060018E6 RID: 6374 RVA: 0x000659B4 File Offset: 0x00063BB4
		public static float ParaSinJerarquia(ConsentNecesario instancia, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, ref EmocionesFemeninasValues emocionesValoresMods, Personalidad Personalidad, string tag = null)
		{
			float num = ConsentNecesario.ParaSinJerarquiaSinMods(tipo, direccion, estimulada, estimulante, ref emocionesValoresMods, Personalidad, tag);
			ConsentNecesario.Modificables modificador = instancia.GetModificador(tipo, estimulada, new ParteQuePuedeEstimular?(estimulante), direccion);
			if (modificador != null)
			{
				float num2 = modificador.modificable.ModificarValor(num);
				num2 = modificador.minimo.MaximoValorIncluyendo(num2);
				return modificador.maximo.MinimoValorIncluyendo(num2);
			}
			return num;
		}

		// Token: 0x060018E7 RID: 6375 RVA: 0x00065A10 File Offset: 0x00063C10
		public static float ParaSinJerarquiaSinMods(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, ref EmocionesFemeninasValues emocionesValoresMods, Personalidad Personalidad, string tag = null)
		{
			switch (tipo)
			{
			case TipoDeEstimulo.tactil:
			{
				bool flag = tag == "golpe";
				return ConsentNecesario.ParaTactil(direccion, estimulada, new ParteQuePuedeEstimular?(estimulante), flag, ref emocionesValoresMods, Personalidad, 1f);
			}
			case TipoDeEstimulo.visual:
				return ConsentNecesario.ParaVisual(direccion, estimulada, ref emocionesValoresMods, new ParteQuePuedeEstimular?(estimulante), Personalidad, 1f, 1f);
			case TipoDeEstimulo.coital:
				return ConsentNecesario.ParaCoital(direccion, estimulada, new ParteQuePuedeEstimular?(estimulante), ref emocionesValoresMods, Personalidad, 1f);
			case TipoDeEstimulo.desvestidura:
				return ConsentNecesario.ParaDesvestir(direccion, estimulada, new ParteQuePuedeEstimular?(estimulante), ref emocionesValoresMods, Personalidad, 1f);
			case TipoDeEstimulo.peticionDesvestidura:
				return ConsentNecesario.ParaPeticionDesvestir(direccion, estimulada, new ParteQuePuedeEstimular?(estimulante), ref emocionesValoresMods, Personalidad, 1f);
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.manipulandoBone:
				return ConsentNecesario.ParaEjecutarPose(direccion, estimulada, new ParteQuePuedeEstimular?(estimulante), ref emocionesValoresMods, Personalidad, 1f);
			case TipoDeEstimulo.peticionEjecucionDePose:
			case TipoDeEstimulo.guiandoBone:
				return ConsentNecesario.ParaPeticionEjecutarPose(direccion, estimulada, new ParteQuePuedeEstimular?(estimulante), ref emocionesValoresMods, Personalidad, 1f);
			}
			throw new NotSupportedException(tipo.ToString());
		}

		// Token: 0x060018E8 RID: 6376 RVA: 0x00065B30 File Offset: 0x00063D30
		public float ParaSinJerarquia(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null, string tag = null)
		{
			Personalidad personalidad = Personalidad ?? this.m_Personalidad;
			EmocionesFemeninasValues emocionesFemeninasValues = emocionesValoresMods ?? this.m_emos.ObtenerModsFemeninos();
			return ConsentNecesario.ParaSinJerarquia(this, tipo, direccion, estimulada, estimulante, ref emocionesFemeninasValues, personalidad, tag);
		}

		// Token: 0x060018E9 RID: 6377 RVA: 0x00065B7C File Offset: 0x00063D7C
		public static float ParaConJerarquia(ConsentNecesario instancia, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, ref EmocionesFemeninasValues emocionesValoresMods, Personalidad Personalidad, string tag = null)
		{
			float num = ConsentNecesario.ParaSinJerarquia(instancia, tipo, direccion, estimulada, estimulante, ref emocionesValoresMods, Personalidad, tag);
			IReadOnlyList<ConsensualTree.Data> readOnlyList = ConsensualTree.Overrides(tipo, direccion, estimulada, estimulante, tag);
			for (int i = 0; i < readOnlyList.Count; i++)
			{
				ConsensualTree.Data data = readOnlyList[i];
				float num2 = ConsentNecesario.ParaSinJerarquia(instancia, data.tipoDeEstimulo, data.direccion, data.parteEstimulada, data.parteEstimulante, ref emocionesValoresMods, Personalidad, data.tag);
				num = Mathf.Min(num, num2);
			}
			return num;
		}

		// Token: 0x060018EA RID: 6378 RVA: 0x00065BF8 File Offset: 0x00063DF8
		public float ParaConJerarquia(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null, string tag = null)
		{
			Personalidad personalidad = Personalidad ?? this.m_Personalidad;
			EmocionesFemeninasValues emocionesFemeninasValues = emocionesValoresMods ?? this.m_emos.ObtenerModsFemeninos();
			return ConsentNecesario.ParaConJerarquia(this, tipo, direccion, estimulada, estimulante, ref emocionesFemeninasValues, personalidad, tag);
		}

		// Token: 0x060018EB RID: 6379 RVA: 0x00065C44 File Offset: 0x00063E44
		public float MenorParaSinJerarquia(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular? parteEstimulante, ref EmocionesFemeninasValues emocionesValoresMods, Personalidad Personalidad, out ParteDelCuerpoHumano menorRequerimiento, string tag = null)
		{
			IReadOnlyList<int> enumValoresInt = typeof(ParteDelCuerpoHumano).GetEnumValoresInt();
			ParteQuePuedeEstimular parteQuePuedeEstimular = ((parteEstimulante == null) ? ParteQuePuedeEstimular.None : parteEstimulante.Value);
			ParteDelCuerpoHumano parteDelCuerpoHumano = ParteDelCuerpoHumano.pecho;
			float num = float.MaxValue;
			for (int i = 0; i < enumValoresInt.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = (ParteDelCuerpoHumano)enumValoresInt[i];
				float num2 = ConsentNecesario.ParaSinJerarquia(this, tipo, direccion, parteDelCuerpoHumano2, parteQuePuedeEstimular, ref emocionesValoresMods, Personalidad, tag);
				if (i == 0 || num > num2)
				{
					parteDelCuerpoHumano = parteDelCuerpoHumano2;
					num = num2;
				}
			}
			menorRequerimiento = parteDelCuerpoHumano;
			return num;
		}

		// Token: 0x060018EC RID: 6380 RVA: 0x00065CC4 File Offset: 0x00063EC4
		public float MayorParaSinJerarquia(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular? parteEstimulante, ref EmocionesFemeninasValues emocionesValoresMods, Personalidad Personalidad, out ParteDelCuerpoHumano mayorRequerimiento, string tag = null)
		{
			IReadOnlyList<int> enumValoresInt = typeof(ParteDelCuerpoHumano).GetEnumValoresInt();
			ParteQuePuedeEstimular parteQuePuedeEstimular = ((parteEstimulante == null) ? ParteQuePuedeEstimular.None : parteEstimulante.Value);
			ParteDelCuerpoHumano parteDelCuerpoHumano = ParteDelCuerpoHumano.pecho;
			float num = float.MinValue;
			for (int i = 0; i < enumValoresInt.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano2 = (ParteDelCuerpoHumano)enumValoresInt[i];
				float num2 = ConsentNecesario.ParaSinJerarquia(this, tipo, direccion, parteDelCuerpoHumano2, parteQuePuedeEstimular, ref emocionesValoresMods, Personalidad, tag);
				if (i == 0 || num < num2)
				{
					parteDelCuerpoHumano = parteDelCuerpoHumano2;
					num = num2;
				}
			}
			mayorRequerimiento = parteDelCuerpoHumano;
			return num;
		}

		// Token: 0x060018ED RID: 6381 RVA: 0x00065D44 File Offset: 0x00063F44
		public float MenorParaSinJerarquia(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular? parteEstimulante, out ParteDelCuerpoHumano menorRequerimiento, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null, string tag = null)
		{
			Personalidad personalidad = Personalidad ?? this.m_Personalidad;
			EmocionesFemeninasValues emocionesFemeninasValues = emocionesValoresMods ?? this.m_emos.ObtenerModsFemeninos();
			return this.MenorParaSinJerarquia(tipo, direccion, parteEstimulante, ref emocionesFemeninasValues, personalidad, out menorRequerimiento, tag);
		}

		// Token: 0x060018EE RID: 6382 RVA: 0x00065D90 File Offset: 0x00063F90
		public float MayorParaSinJerarquia(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular? parteEstimulante, out ParteDelCuerpoHumano mayorRequerimiento, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null, string tag = null)
		{
			Personalidad personalidad = Personalidad ?? this.m_Personalidad;
			EmocionesFemeninasValues emocionesFemeninasValues = emocionesValoresMods ?? this.m_emos.ObtenerModsFemeninos();
			return this.MayorParaSinJerarquia(tipo, direccion, parteEstimulante, ref emocionesFemeninasValues, personalidad, out mayorRequerimiento, tag);
		}

		// Token: 0x060018EF RID: 6383 RVA: 0x00065DDC File Offset: 0x00063FDC
		public bool EsConsentidoConJerarquia(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, out float offsetMod, out float necesario, float consentRequeridoMod = 1f, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null, string tag = null)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = emocionesValoresMods ?? this.m_emos.ObtenerModsFemeninos();
			Personalidad personalidad = Personalidad ?? this.m_Personalidad;
			return this.EsConsentidoConJerarquia(ref emocionesFemeninasValues, personalidad, tipo, direccion, estimulada, estimulante, out offsetMod, out necesario, consentRequeridoMod, tag);
		}

		// Token: 0x060018F0 RID: 6384 RVA: 0x00065E30 File Offset: 0x00064030
		public bool EsConsentidoConJerarquia(ref EmocionesFemeninasValues emocionesValoresMods, Personalidad Personalidad, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, out float offsetMod, out float necesario, float consentRequeridoMod = 1f, string tag = null)
		{
			necesario = Mathf.Clamp(ConsentNecesario.ParaConJerarquia(this, tipo, direccion, estimulada, estimulante, ref emocionesValoresMods, Personalidad, tag) * consentRequeridoMod, 0f, float.MaxValue);
			float num = Mathf.Clamp(emocionesValoresMods.consentToHero * 100f, 0f, float.MaxValue);
			offsetMod = ConsentNecesario.CalcularOffset(num, necesario);
			return num >= necesario;
		}

		// Token: 0x060018F1 RID: 6385 RVA: 0x00065E94 File Offset: 0x00064094
		public bool EsConsentidoConJerarquia(ICalculoDeInteracionEstimulanteDeParteEstimulante calculo, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null)
		{
			float num;
			float num2;
			return this.EsConsentidoConJerarquia(calculo.estimuloBasico.tipoDeEstimulo, calculo.estimuloBasico.tipo, calculo.estimuloBasico.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor), calculo.estimulanteParte, out num, out num2, 1f, emocionesValoresMods, Personalidad, calculo.tag);
		}

		// Token: 0x060018F2 RID: 6386 RVA: 0x00065EE0 File Offset: 0x000640E0
		public bool EsConsentidoConJerarquia(ICalculoDeInteracionEstimulanteDeParteEstimulante calculo, out float offsetMod, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null)
		{
			float num;
			return this.EsConsentidoConJerarquia(calculo.estimuloBasico.tipoDeEstimulo, calculo.estimuloBasico.tipo, calculo.estimuloBasico.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor), calculo.estimulanteParte, out offsetMod, out num, 1f, emocionesValoresMods, Personalidad, calculo.tag);
		}

		// Token: 0x060018F3 RID: 6387 RVA: 0x00065F2C File Offset: 0x0006412C
		public bool EsConsentidoMaximoConJerarquia(ICalculoDeInteracionEstimulanteDeParteEstimulante calculo, out float offsetMod, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = emocionesValoresMods ?? this.m_emos.ObtenerModsFemeninos();
			Personalidad personalidad = Personalidad ?? this.m_Personalidad;
			return this.EsConsentidoMaximoConJerarquia(ref emocionesFemeninasValues, personalidad, calculo, out offsetMod);
		}

		// Token: 0x060018F4 RID: 6388 RVA: 0x00065F74 File Offset: 0x00064174
		public bool EsConsentidoMaximoConJerarquia(ref EmocionesFemeninasValues emocionesValoresMods, Personalidad Personalidad, ICalculoDeInteracionEstimulanteDeParteEstimulante calculo, out float offsetMod)
		{
			float num = 0f;
			for (int i = 0; i < calculo.estimuloBasico.partesDelCuerpoHumanoEstimuladas.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = calculo.estimuloBasico.partesDelCuerpoHumanoEstimuladas[i];
				float num2;
				float num3;
				if (this.EsConsentidoConJerarquia(ref emocionesValoresMods, Personalidad, calculo.estimuloBasico.tipoDeEstimulo, calculo.estimuloBasico.tipo, parteDelCuerpoHumano, calculo.estimulanteParte, out num2, out num3, 1f, calculo.tag) && num2 > num)
				{
					num = num2;
				}
			}
			offsetMod = num;
			return offsetMod >= 1f;
		}

		// Token: 0x060018F5 RID: 6389 RVA: 0x00066004 File Offset: 0x00064204
		public void ObtenerConsentidosConJerarquia(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulante, IList<ParteDelCuerpoHumano> resultado, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null, string tag = null)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = emocionesValoresMods ?? this.m_emos.ObtenerModsFemeninos();
			Personalidad personalidad = Personalidad ?? this.m_Personalidad;
			IReadOnlyList<int> enumValoresInt = typeof(ParteDelCuerpoHumano).GetEnumValoresInt();
			for (int i = 0; i < enumValoresInt.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = (ParteDelCuerpoHumano)enumValoresInt[i];
				float num;
				float num2;
				if (this.EsConsentidoConJerarquia(ref emocionesFemeninasValues, personalidad, tipo, direccion, parteDelCuerpoHumano, estimulante, out num, out num2, 1f, tag))
				{
					resultado.Add(parteDelCuerpoHumano);
				}
			}
		}

		// Token: 0x060018F6 RID: 6390 RVA: 0x00066094 File Offset: 0x00064294
		public void ObtenerConsentidosConJerarquia(IReadOnlyList<ParteDelCuerpoHumano> aEvaluar, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulante, IList<ParteDelCuerpoHumano> resultado, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null, string tag = null)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = emocionesValoresMods ?? this.m_emos.ObtenerModsFemeninos();
			Personalidad personalidad = Personalidad ?? this.m_Personalidad;
			for (int i = 0; i < aEvaluar.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = aEvaluar[i];
				float num;
				float num2;
				if (this.EsConsentidoConJerarquia(ref emocionesFemeninasValues, personalidad, tipo, direccion, parteDelCuerpoHumano, estimulante, out num, out num2, 1f, tag))
				{
					resultado.Add(parteDelCuerpoHumano);
				}
			}
		}

		// Token: 0x060018F7 RID: 6391 RVA: 0x00066118 File Offset: 0x00064318
		public bool AlgunoConsentidoSinJerarquia(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulante, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null, string tag = null)
		{
			float num;
			return this.AlgunoConsentidoSinJerarquia(tipo, direccion, estimulante, out num, emocionesValoresMods, Personalidad, tag);
		}

		// Token: 0x060018F8 RID: 6392 RVA: 0x00066138 File Offset: 0x00064338
		public bool AlgunoConsentidoSinJerarquia(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null, string tag = null)
		{
			float num;
			return this.AlgunoConsentidoSinJerarquia(tipo, direccion, out num, emocionesValoresMods, Personalidad, tag);
		}

		// Token: 0x060018F9 RID: 6393 RVA: 0x00066154 File Offset: 0x00064354
		public bool AlgunoConsentidoSinJerarquia(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulante, out float menorConsentNecesario, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null, string tag = null)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = emocionesValoresMods ?? this.m_emos.ObtenerModsFemeninos();
			Personalidad personalidad = Personalidad ?? this.m_Personalidad;
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			menorConsentNecesario = this.MenorParaSinJerarquia(tipo, direccion, new ParteQuePuedeEstimular?(estimulante), ref emocionesFemeninasValues, personalidad, out parteDelCuerpoHumano, tag);
			return emocionesFemeninasValues.consentToHero * 100f >= menorConsentNecesario;
		}

		// Token: 0x060018FA RID: 6394 RVA: 0x000661BC File Offset: 0x000643BC
		public bool AlgunoConsentidoSinJerarquia(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, out float menorConsentNecesario, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null, string tag = null)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = emocionesValoresMods ?? this.m_emos.ObtenerModsFemeninos();
			Personalidad personalidad = Personalidad ?? this.m_Personalidad;
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			menorConsentNecesario = this.MenorParaSinJerarquia(tipo, direccion, null, ref emocionesFemeninasValues, personalidad, out parteDelCuerpoHumano, tag);
			return emocionesFemeninasValues.consentToHero * 100f >= menorConsentNecesario;
		}

		// Token: 0x060018FB RID: 6395 RVA: 0x00066228 File Offset: 0x00064428
		public bool TodosConsentidosSinJerarquia(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null, string tag = null)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = emocionesValoresMods ?? this.m_emos.ObtenerModsFemeninos();
			Personalidad personalidad = Personalidad ?? this.m_Personalidad;
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			float num = this.MayorParaSinJerarquia(tipo, direccion, null, ref emocionesFemeninasValues, personalidad, out parteDelCuerpoHumano, tag);
			return emocionesFemeninasValues.consentToHero * 100f >= num;
		}

		// Token: 0x060018FC RID: 6396 RVA: 0x00066290 File Offset: 0x00064490
		public bool TodosConsentidosSinJerarquia(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulante, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null, string tag = null)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = emocionesValoresMods ?? this.m_emos.ObtenerModsFemeninos();
			Personalidad personalidad = Personalidad ?? this.m_Personalidad;
			ParteDelCuerpoHumano parteDelCuerpoHumano;
			float num = this.MayorParaSinJerarquia(tipo, direccion, new ParteQuePuedeEstimular?(estimulante), ref emocionesFemeninasValues, personalidad, out parteDelCuerpoHumano, tag);
			return emocionesFemeninasValues.consentToHero * 100f >= num;
		}

		// Token: 0x060018FD RID: 6397 RVA: 0x000662F4 File Offset: 0x000644F4
		public bool TodosConsentidosConJerarquia(IReadOnlyList<ParteDelCuerpoHumano> estimuladas, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulante, out float menosOffsetMod, out ParteDelCuerpoHumano menosConsentidaParte, out float? masNoConsentidaOffsetMod, out ParteDelCuerpoHumano? masNoConsentida, float consentRequeridoMod = 1f, EmocionesFemeninasValues? emocionesValoresMods = null, Personalidad Personalidad = null, string tag = null)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = emocionesValoresMods ?? this.m_emos.ObtenerModsFemeninos();
			Personalidad personalidad = Personalidad ?? this.m_Personalidad;
			menosOffsetMod = 0f;
			menosConsentidaParte = ParteDelCuerpoHumano.pecho;
			masNoConsentidaOffsetMod = null;
			masNoConsentida = null;
			if (estimuladas.Count == 0)
			{
				Debug.LogError("cantidad de partes estimuladas deben ser mayor a zero", this);
				return true;
			}
			menosOffsetMod = float.MaxValue;
			for (int i = 0; i < estimuladas.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = estimuladas[i];
				float num;
				float num2;
				this.EsConsentidoConJerarquia(ref emocionesFemeninasValues, personalidad, tipo, direccion, estimuladas[i], estimulante, out num, out num2, consentRequeridoMod, tag);
				if (num < menosOffsetMod)
				{
					menosOffsetMod = num;
					menosConsentidaParte = parteDelCuerpoHumano;
				}
				if (num < 1f && (masNoConsentidaOffsetMod == null || num > masNoConsentidaOffsetMod.Value))
				{
					masNoConsentidaOffsetMod = new float?(num);
					masNoConsentida = new ParteDelCuerpoHumano?(parteDelCuerpoHumano);
				}
			}
			bool flag = menosOffsetMod >= 1f;
			if (!flag && masNoConsentida == null)
			{
				throw new InvalidOperationException("si no es consentido, DEBE haber masNoConsentido");
			}
			return flag;
		}

		// Token: 0x060018FE RID: 6398 RVA: 0x00066410 File Offset: 0x00064610
		public static float CalcularOffset(float current, float necesario)
		{
			if (current < 0f)
			{
				current = 0f;
			}
			if (necesario < 0f)
			{
				necesario = 0f;
			}
			float num;
			if (current == 0f && necesario == 0f)
			{
				num = 1f;
			}
			else if (necesario == 0f)
			{
				num = current / 0.01f;
			}
			else
			{
				num = current / necesario;
			}
			return num;
		}

		// Token: 0x060018FF RID: 6399 RVA: 0x0006646C File Offset: 0x0006466C
		public static float NecesarioPorMapas(ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular? parteEstimulante, FloatPorGrupoDicc concentNecesarioPorGrupo, PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo, float minConcent, ModifcadorDeIntervalo concentVsArousal = null, float? arousalMod = null, PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo = null, FloatPorGrupoDicc modConcentNecesarioPorGrupoPorParteEstimulante = null)
		{
			GrupoQueCompartenValores grupoDeParte = mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteEstimulada);
			float num = concentNecesarioPorGrupo[grupoDeParte].valor;
			float num2 = 1f;
			if (mapaDeParteEstimulanteGrupo != null && parteEstimulante != null)
			{
				GrupoQueCompartenValores grupoDeParte2 = mapaDeParteEstimulanteGrupo.GetGrupoDeParte(parteEstimulante.Value);
				if (modConcentNecesarioPorGrupoPorParteEstimulante != null)
				{
					num2 = modConcentNecesarioPorGrupoPorParteEstimulante[grupoDeParte2].valor;
				}
			}
			if (concentVsArousal != null && arousalMod != null)
			{
				num = concentVsArousal.ModificarSingle(num, arousalMod.Value);
				if (minConcent > 0f)
				{
					minConcent = concentVsArousal.ModificarSingle(minConcent, arousalMod.Value);
				}
			}
			num *= num2;
			return Mathf.Max(minConcent, num);
		}

		// Token: 0x06001900 RID: 6400 RVA: 0x0006651C File Offset: 0x0006471C
		[Obsolete("no admite modificadores", true)]
		public static float MenorNecesarioPorMapas(FloatPorGrupoDicc concentNecesarioPorGrupo, float minConcent, ModifcadorDeIntervalo concentVsArousal = null, float? arousalMod = null, PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo = null, FloatPorGrupoDicc modConcentNecesarioPorGrupoPorParteEstimulante = null, ParteQuePuedeEstimular? parteEstimulante = null)
		{
			float num = concentNecesarioPorGrupo.ObtenerMenorValor(1f);
			float num2 = 1f;
			if (mapaDeParteEstimulanteGrupo != null)
			{
				if (parteEstimulante != null)
				{
					GrupoQueCompartenValores grupoDeParte = mapaDeParteEstimulanteGrupo.GetGrupoDeParte(parteEstimulante.Value);
					if (modConcentNecesarioPorGrupoPorParteEstimulante != null)
					{
						num2 = modConcentNecesarioPorGrupoPorParteEstimulante[grupoDeParte].valor;
					}
				}
				else if (modConcentNecesarioPorGrupoPorParteEstimulante != null)
				{
					num2 = modConcentNecesarioPorGrupoPorParteEstimulante.ObtenerMenorValor(1f);
				}
			}
			if (concentVsArousal != null && arousalMod != null)
			{
				num = concentVsArousal.ModificarSingle(num, arousalMod.Value);
			}
			num *= num2;
			return Mathf.Max(minConcent, num);
		}

		// Token: 0x06001901 RID: 6401 RVA: 0x000665BC File Offset: 0x000647BC
		[Obsolete("no admite modificadores", true)]
		public static float MayorNecesarioPorMapas(FloatPorGrupoDicc concentNecesarioPorGrupo, float minConcent, ModifcadorDeIntervalo concentVsArousal = null, float? arousalMod = null, PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo = null, FloatPorGrupoDicc modConcentNecesarioPorGrupoPorParteEstimulante = null, ParteQuePuedeEstimular? parteEstimulante = null)
		{
			float num = concentNecesarioPorGrupo.ObtenerMayorValor(1f);
			float num2 = 1f;
			if (mapaDeParteEstimulanteGrupo != null)
			{
				if (parteEstimulante != null)
				{
					GrupoQueCompartenValores grupoDeParte = mapaDeParteEstimulanteGrupo.GetGrupoDeParte(parteEstimulante.Value);
					if (modConcentNecesarioPorGrupoPorParteEstimulante != null)
					{
						num2 = modConcentNecesarioPorGrupoPorParteEstimulante[grupoDeParte].valor;
					}
				}
				else if (modConcentNecesarioPorGrupoPorParteEstimulante != null)
				{
					num2 = modConcentNecesarioPorGrupoPorParteEstimulante.ObtenerMayorValor(1f);
				}
			}
			if (concentVsArousal != null && arousalMod != null)
			{
				num = concentVsArousal.ModificarSingle(num, arousalMod.Value);
			}
			num *= num2;
			return Mathf.Max(minConcent, num);
		}

		// Token: 0x040012DC RID: 4828
		private Personalidad m_Personalidad;

		// Token: 0x040012DD RID: 4829
		private EmocionesFemeninas m_emos;

		// Token: 0x040012DE RID: 4830
		[Obsolete("", true)]
		[NonSerialized]
		public float modTactilRecibido = 1f;

		// Token: 0x040012DF RID: 4831
		[Obsolete("", true)]
		[NonSerialized]
		public float modCoitalRecibido = 1f;

		// Token: 0x040012E0 RID: 4832
		[Obsolete("", true)]
		[NonSerialized]
		public float modVisualRecibido = 1f;

		// Token: 0x040012E1 RID: 4833
		[Obsolete("", true)]
		[NonSerialized]
		public float modVisualDada = 1f;

		// Token: 0x040012E2 RID: 4834
		private Dictionary<ValueTuple<TipoDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, DireccionDeEstimulo>, ConsentNecesario.Modificables> m_modificablesDeInteraccion = new Dictionary<ValueTuple<TipoDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular, DireccionDeEstimulo>, ConsentNecesario.Modificables>();

		// Token: 0x040012E3 RID: 4835
		[SerializeField]
		private List<ConsentNecesario.Modificables> m_modificablesDeInteraccionDEBUG = new List<ConsentNecesario.Modificables>();

		// Token: 0x040012E4 RID: 4836
		[Header("Desvestir")]
		public float modDesvestirRecibido = 1f;

		// Token: 0x040012E5 RID: 4837
		public float modPeticionDesvestirRecibido = 1f;

		// Token: 0x040012E6 RID: 4838
		[Header("Ejecutar Pose")]
		public float modEjecucionDePoseRecibido = 1f;

		// Token: 0x040012E7 RID: 4839
		public float modPeticionEjecucionDePoseRecibido = 1f;

		// Token: 0x0200046F RID: 1135
		[Serializable]
		public class Modificables
		{
			// Token: 0x06001903 RID: 6403 RVA: 0x000666E0 File Offset: 0x000648E0
			public Modificables(TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano parteDelCuerpoHumano, ParteQuePuedeEstimular parteQuePuedeEstimular, DireccionDeEstimulo direccionDeEstimulo)
			{
				this.tipoDeEstimulo = tipoDeEstimulo;
				this.parteDelCuerpoHumano = parteDelCuerpoHumano;
				this.parteQuePuedeEstimular = parteQuePuedeEstimular;
				this.direccionDeEstimulo = direccionDeEstimulo;
			}

			// Token: 0x17000643 RID: 1603
			// (get) Token: 0x06001904 RID: 6404 RVA: 0x00066740 File Offset: 0x00064940
			public ModificableDeFloat modificable
			{
				get
				{
					return this.m_modificable;
				}
			}

			// Token: 0x17000644 RID: 1604
			// (get) Token: 0x06001905 RID: 6405 RVA: 0x00066748 File Offset: 0x00064948
			public ModificableDeFloat minimo
			{
				get
				{
					return this.m_minimo;
				}
			}

			// Token: 0x17000645 RID: 1605
			// (get) Token: 0x06001906 RID: 6406 RVA: 0x00066750 File Offset: 0x00064950
			public ModificableDeFloat maximo
			{
				get
				{
					return this.m_maximo;
				}
			}

			// Token: 0x040012E8 RID: 4840
			public TipoDeEstimulo tipoDeEstimulo;

			// Token: 0x040012E9 RID: 4841
			public ParteDelCuerpoHumano parteDelCuerpoHumano;

			// Token: 0x040012EA RID: 4842
			public ParteQuePuedeEstimular parteQuePuedeEstimular;

			// Token: 0x040012EB RID: 4843
			public DireccionDeEstimulo direccionDeEstimulo;

			// Token: 0x040012EC RID: 4844
			[SerializeField]
			private ModificableDeFloat m_modificable = new ModificableDeFloat(1f);

			// Token: 0x040012ED RID: 4845
			[SerializeField]
			private ModificableDeFloat m_minimo = new ModificableDeFloat(float.MinValue);

			// Token: 0x040012EE RID: 4846
			[SerializeField]
			private ModificableDeFloat m_maximo = new ModificableDeFloat(float.MaxValue);
		}
	}
}
