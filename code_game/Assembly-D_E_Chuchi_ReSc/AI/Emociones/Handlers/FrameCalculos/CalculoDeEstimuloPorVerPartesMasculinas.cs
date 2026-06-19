using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x020004F5 RID: 1269
	public abstract class CalculoDeEstimuloPorVerPartesMasculinas<TData> : CalculoDeEstimuloPor<TData, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual>, KeyValuePair<int, EstimuloVisual>, CalculoPorVerPartesMasculinasConfiguracion, VisionHaciaMainInFrame>, ICalculadorDeEstimuloVisual, ICalculadorDeEstimulo<ICalculoDeEstimuloVisual>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorDeEstimuloIgnoradorEnPartesHumanas, ICalculadorSimulable, ICalculadorDeEstimuloClasificable where TData : CalculoDeEstimuloVisualResultado, IClearable, new()
	{
		// Token: 0x06001DF6 RID: 7670 RVA: 0x00073753 File Offset: 0x00071953
		ICalculoDeEstimuloVisual ICalculadorDeEstimulo<ICalculoDeEstimuloVisual>.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index)
		{
			return base.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(index);
		}

		// Token: 0x06001DF7 RID: 7671 RVA: 0x00073761 File Offset: 0x00071961
		ICalculoDeEstimuloVisual ICalculadorDeEstimulo<ICalculoDeEstimuloVisual>.GetCalculoEnFrame(int index)
		{
			return base.GetCalculoEnFrame(index);
		}

		// Token: 0x170007EC RID: 2028
		// (get) Token: 0x06001DF8 RID: 7672
		protected abstract PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana { get; }

		// Token: 0x06001DF9 RID: 7673 RVA: 0x0007376F File Offset: 0x0007196F
		public void IgnorarParteHumana(ParteDelCuerpoHumano parte, bool ignorar)
		{
			if (ignorar)
			{
				if (!this.ignorarSiEstaViendo.Contains(parte))
				{
					this.ignorarSiEstaViendo.Add(parte);
					return;
				}
			}
			else
			{
				while (this.ignorarSiEstaViendo.Contains(parte))
				{
					this.ignorarSiEstaViendo.Remove(parte);
				}
			}
		}

		// Token: 0x06001DFA RID: 7674 RVA: 0x000737AC File Offset: 0x000719AC
		protected sealed override bool ItemEsValido(KeyValuePair<int, EstimuloVisual> item, int index)
		{
			EstimuloVisual value = item.Value;
			return !this.ignorarSiEstaViendo.Contains(value.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana));
		}

		// Token: 0x170007ED RID: 2029
		// (get) Token: 0x06001DFB RID: 7675 RVA: 0x00005F51 File Offset: 0x00004151
		public sealed override DireccionDeEstimulo direccionDeEstimulo
		{
			get
			{
				return DireccionDeEstimulo.dada;
			}
		}

		// Token: 0x170007EE RID: 2030
		// (get) Token: 0x06001DFC RID: 7676 RVA: 0x0000D704 File Offset: 0x0000B904
		public sealed override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.visual;
			}
		}

		// Token: 0x170007EF RID: 2031
		// (get) Token: 0x06001DFD RID: 7677
		protected abstract float maxEmocionValuePorGrupoMod { get; }

		// Token: 0x170007F0 RID: 2032
		// (get) Token: 0x06001DFE RID: 7678
		protected abstract PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo { get; }

		// Token: 0x170007F1 RID: 2033
		// (get) Token: 0x06001DFF RID: 7679
		protected abstract FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada { get; }

		// Token: 0x170007F2 RID: 2034
		// (get) Token: 0x06001E00 RID: 7680
		protected abstract DatosDeUmbral datosDeUmbral { get; }

		// Token: 0x170007F3 RID: 2035
		// (get) Token: 0x06001E01 RID: 7681
		protected abstract FloatPorGrupoDicc maxEmocionValuePorGrupo { get; }

		// Token: 0x170007F4 RID: 2036
		// (get) Token: 0x06001E02 RID: 7682 RVA: 0x000737DD File Offset: 0x000719DD
		[Obsolete("", true)]
		public ICalculoDeEstimuloVisual calculoMasFuerte
		{
			get
			{
				return this.m_masFuerteGenerada;
			}
		}

		// Token: 0x06001E03 RID: 7683 RVA: 0x000737EC File Offset: 0x000719EC
		[Obsolete("", true)]
		public void GetCalculosDelMasFuerteAlMasDebil(IList<ICalculoDeEstimuloVisual> resultado)
		{
			for (int i = 0; i < this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil.Count; i++)
			{
				resultado.Add(this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil[i]);
			}
		}

		// Token: 0x06001E04 RID: 7684 RVA: 0x00073826 File Offset: 0x00071A26
		protected sealed override void SortMasFuerteAlMasDebil(List<TData> calculos)
		{
			if (CalculoDeEstimuloPorVerPartesMasculinas<TData>.comparison == null)
			{
				CalculoDeEstimuloPorVerPartesMasculinas<TData>.comparison = (TData a, TData b) => -1 * a.data.estado.estimulacionGeneradaEnFrame.CompareTo(b.data.estado.estimulacionGeneradaEnFrame);
			}
			calculos.Sort(CalculoDeEstimuloPorVerPartesMasculinas<TData>.comparison);
		}

		// Token: 0x06001E05 RID: 7685 RVA: 0x0007385E File Offset: 0x00071A5E
		protected sealed override DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual> GetEstimulosEnFrame(VisionHaciaMainInFrame collecor)
		{
			return this.m_EstimuloByMainInFrame.frameVistas;
		}

		// Token: 0x06001E06 RID: 7686 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnOldDataCleared()
		{
		}

		// Token: 0x06001E07 RID: 7687 RVA: 0x0007386C File Offset: 0x00071A6C
		public void SimularGlobal(ParteQuePuedeEstimular estimulante, ParteDelCuerpoHumano estimulada, float deltaTime, out RangeValueV2 intervalo, out UmbralBasico.Estado minGenerado, out UmbralBasico.Estado maxGenerado, EmocionesFemeninasValues? emocionesValoresMods)
		{
			ICalculoDeEstimuloCompleto calculoDeEstimuloCompleto;
			this.SimularGlobal(estimulante, estimulada, deltaTime, out intervalo, out minGenerado, out maxGenerado, emocionesValoresMods, out calculoDeEstimuloCompleto);
		}

		// Token: 0x06001E08 RID: 7688 RVA: 0x0007388C File Offset: 0x00071A8C
		public void SimularGlobal(ParteQuePuedeEstimular estimulante, ParteDelCuerpoHumano estimulada, float deltaTime, out RangeValueV2 intervalo, out UmbralBasico.Estado minGenerado, out UmbralBasico.Estado maxGenerado, EmocionesFemeninasValues? emocionesValoresMods, out ICalculoDeEstimuloCompleto faseTres)
		{
			TData tdata = new TData();
			tdata.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
			EstimuloVisual estimuloVisual = new EstimuloVisual();
			estimuloVisual.tipoDeEstimulo = TipoDeEstimulo.visual;
			estimuloVisual.tipo = DireccionDeEstimulo.dada;
			estimuloVisual.EstimuloSoloUsaPrioridadesFixed();
			estimuloVisual.AddParteEstimulada(estimulada);
			KeyValuePair<int, EstimuloVisual> keyValuePair = new KeyValuePair<int, EstimuloVisual>((int)estimulante, estimuloVisual);
			this.PoblarConData(tdata, keyValuePair, this.datosDeUmbral, deltaTime, out intervalo, emocionesValoresMods, new float?((float)1), new float?((float)1), true);
			TData tdata2 = new TData();
			tdata2.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
			EstimuloVisual estimuloVisual2 = new EstimuloVisual();
			estimuloVisual2.tipoDeEstimulo = TipoDeEstimulo.visual;
			estimuloVisual2.tipo = DireccionDeEstimulo.dada;
			estimuloVisual2.EstimuloSoloUsaPrioridadesFixed();
			estimuloVisual2.AddParteEstimulada(estimulada);
			KeyValuePair<int, EstimuloVisual> keyValuePair2 = new KeyValuePair<int, EstimuloVisual>((int)estimulante, estimuloVisual2);
			RangeValueV2 rangeValueV;
			this.PoblarConData(tdata2, keyValuePair2, this.datosDeUmbral, deltaTime, out rangeValueV, emocionesValoresMods, new float?(0f), new float?(0f), true);
			this.PostCalculoDeEstimulo(tdata2);
			minGenerado = tdata2.data.estado;
			TData tdata3 = new TData();
			faseTres = tdata3;
			tdata3.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
			EstimuloVisual estimuloVisual3 = new EstimuloVisual();
			estimuloVisual3.tipoDeEstimulo = TipoDeEstimulo.visual;
			estimuloVisual3.tipo = DireccionDeEstimulo.dada;
			estimuloVisual3.EstimuloSoloUsaPrioridadesFixed();
			estimuloVisual3.AddParteEstimulada(estimulada);
			KeyValuePair<int, EstimuloVisual> keyValuePair3 = new KeyValuePair<int, EstimuloVisual>((int)estimulante, estimuloVisual3);
			RangeValueV2 rangeValueV2;
			this.PoblarConData(tdata3, keyValuePair3, this.datosDeUmbral, deltaTime, out rangeValueV2, emocionesValoresMods, new float?((float)1), new float?((float)1), true);
			this.PostCalculoDeEstimulo(tdata3);
			maxGenerado = tdata3.data.estado;
		}

		// Token: 0x06001E09 RID: 7689 RVA: 0x00073A2C File Offset: 0x00071C2C
		private void PoblarConData(TData data, KeyValuePair<int, EstimuloVisual> item, DatosDeUmbral datos, float deltaTime, out RangeValueV2 intervalo, EmocionesFemeninasValues? emocionesValoresMods, float? angleMod = null, float? distanceMod = null, bool reusarEstimuloInstance = false)
		{
			EstimuloVisual value = item.Value;
			ParteDelCuerpoHumano parteDelCuerpoHumano = value.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
			ParteQuePuedeEstimular key = (ParteQuePuedeEstimular)item.Key;
			if (value == null)
			{
				throw new ArgumentNullException("estimulo", "estimulo null reference.");
			}
			if (datos == null)
			{
				throw new ArgumentNullException("datos", "datos null reference.");
			}
			float num = angleMod ?? Mathf.InverseLerp(90f, 20f, value.angleDesdePuntoVisual);
			float num2 = distanceMod ?? Mathf.InverseLerp(15f, 0.2f, value.distancia);
			num = Mathf.Lerp(0.333f, 1f, num);
			num2 = Mathf.Lerp(0.333f, 1f, num2);
			float num3 = num * num2;
			intervalo = datos.intervaloDeGeneracion;
			ValorModificable estimulacionQueGenera = datos.estimulacionQueGenera;
			this.OnPreUmbralCalculo(key, parteDelCuerpoHumano, value, ref num3, ref intervalo, ref estimulacionQueGenera, ref emocionesValoresMods);
			UmbralBasico.Estado estado = default(UmbralBasico.Estado);
			try
			{
				estado = UmbralBasico.Calcular(num3, deltaTime, UmbralBasico.TipoDeCambio.porSegundo, intervalo, estimulacionQueGenera.total, datos.spotBonuses, datos.promedioMod, datos.modPorEncima, datos.modPorDebajo);
				float estimulacionGeneradaEnFrame = estado.estimulacionGeneradaEnFrame;
				this.OnPostUmbralCalculo(value, ref estimulacionGeneradaEnFrame);
				estado.SetEstimulacionGeneradaEnFrame(estimulacionGeneradaEnFrame);
				estado.SetEstimulacionGeneradaTotal(estimulacionGeneradaEnFrame);
			}
			catch (Exception)
			{
				Debug.LogWarning("Error calculando UmbralBasico de caricias de emocion " + this.m_Emo.GetType().Name);
				throw;
			}
			if (!reusarEstimuloInstance)
			{
				value.CopiarA(data.estimulo, false);
			}
			else
			{
				data.SetEstimuloInstance(value, null);
			}
			data.data.estimulanteParte = key;
			data.data.estado = estado;
			if (this.config.debugPrint)
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					" su:",
					num3.ToString("0.0000"),
					" min:",
					intervalo.min.ToString("0.0000"),
					" max:",
					intervalo.max.ToString("0.0000"),
					" lada: ",
					parteDelCuerpoHumano.ToString(),
					" ",
					estado.PrintStr()
				}));
			}
		}

		// Token: 0x06001E0A RID: 7690 RVA: 0x00073CB0 File Offset: 0x00071EB0
		protected sealed override void PoblarDataConItem(TData data, KeyValuePair<int, EstimuloVisual> item, int index, float deltaTime, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual> allitems)
		{
			data.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
			RangeValueV2 rangeValueV;
			this.PoblarConData(data, item, this.datosDeUmbral, deltaTime, out rangeValueV, null, null, null, false);
		}

		// Token: 0x06001E0B RID: 7691 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnDataGenerada(TData data)
		{
		}

		// Token: 0x06001E0C RID: 7692 RVA: 0x00073D00 File Offset: 0x00071F00
		protected sealed override void PostPoblarDataConItem(TData data, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual> allData)
		{
			TipoDeEstimuloVisual tipoDeEstimuloVisual = data.estimulanteParte.ObtenerTipoDeEstimuloVisual();
			data.estimulo.SetTipoDeEstimuloVisual(tipoDeEstimuloVisual);
			this.AlterarDataGenerada(data);
		}

		// Token: 0x06001E0D RID: 7693 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void AlterarDataGenerada(TData data)
		{
		}

		// Token: 0x06001E0E RID: 7694 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool DataGeneradaEsValida(TData data, int index)
		{
			return true;
		}

		// Token: 0x06001E0F RID: 7695 RVA: 0x00073D36 File Offset: 0x00071F36
		protected sealed override float PreCalculoDeEstimulo(TData data)
		{
			return data.data.estado.estimulacionGeneradaEnFrame;
		}

		// Token: 0x06001E10 RID: 7696 RVA: 0x00073D50 File Offset: 0x00071F50
		protected override bool MaximoAlcanzado(TData data, float valorDeEmovionActual, out float maxEmoValueDeGrupo)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = data.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
			GrupoQueCompartenValores grupoQueCompartenValores = GrupoQueCompartenValores.f;
			if (this.mapaDeParteHumanaEstimuladaGrupo)
			{
				grupoQueCompartenValores = this.mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteDelCuerpoHumano);
			}
			this.m_lastMaxEmocionValue = 120f;
			if (this.maxEmocionValuePorGrupo)
			{
				this.m_lastMaxEmocionValue = this.maxEmocionValuePorGrupo[grupoQueCompartenValores].valor;
			}
			this.m_lastMaxEmocionValue *= this.maxEmocionValuePorGrupoMod;
			this.OnPreLimitarMaxEmocionValue(grupoQueCompartenValores, data.estimulo, ref this.m_lastMaxEmocionValue);
			maxEmoValueDeGrupo = (this.m_lastMaxEmocionValue = Mathf.Clamp(this.m_lastMaxEmocionValue, 0f, 120f));
			return valorDeEmovionActual > this.m_lastMaxEmocionValue;
		}

		// Token: 0x06001E11 RID: 7697 RVA: 0x00073E18 File Offset: 0x00072018
		protected sealed override float PostCalculoDeEstimulo(TData data)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = data.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
			GrupoQueCompartenValores grupoQueCompartenValores = GrupoQueCompartenValores.f;
			if (this.mapaDeParteHumanaEstimuladaGrupo)
			{
				grupoQueCompartenValores = this.mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteDelCuerpoHumano);
			}
			this.AplicarModificadoresDeGeneracion(data, grupoQueCompartenValores);
			return data.data.estado.estimulacionGeneradaEnFrame;
		}

		// Token: 0x06001E12 RID: 7698 RVA: 0x00073E78 File Offset: 0x00072078
		private void AplicarModificadoresDeGeneracion(TData data, GrupoQueCompartenValores parteEstimulada)
		{
			if (this.modEstimuloGeneradoPorGrupoDeParteEstimulada)
			{
				float valor = this.modEstimuloGeneradoPorGrupoDeParteEstimulada[parteEstimulada].valor;
				data.data.estado.ModificarGenerado(valor);
			}
		}

		// Token: 0x06001E13 RID: 7699 RVA: 0x00073EBC File Offset: 0x000720BC
		protected override void AplicarMaxValueEmoMods(TData data, bool maximoAlcanzado, float currentEmoValue, float maxEmoValueDeGrupo, out float modificadorDEmocionChange)
		{
			if (maximoAlcanzado)
			{
				modificadorDEmocionChange = 0f;
			}
			else
			{
				modificadorDEmocionChange = Mathf.InverseLerp(maxEmoValueDeGrupo, maxEmoValueDeGrupo * 0.9f, currentEmoValue).OutPow(3f);
			}
			data.data.estado.SetPostModificador(modificadorDEmocionChange);
		}

		// Token: 0x06001E14 RID: 7700
		protected abstract void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloVisual estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues? emocionesValoresMods);

		// Token: 0x06001E15 RID: 7701
		protected abstract void OnPostUmbralCalculo(EstimuloVisual estimulo, ref float estimulacionGenerada);

		// Token: 0x06001E16 RID: 7702
		protected abstract void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, EstimuloVisual estimulo, ref float maxEmotionValue);

		// Token: 0x06001E17 RID: 7703 RVA: 0x00073F0C File Offset: 0x0007210C
		public bool TryInstantiateCalculo(out ICalculoDeEstimuloVisual calculo)
		{
			TData tdata;
			bool flag = base.TryInstantiateCalculo(out tdata);
			calculo = tdata;
			return flag;
		}

		// Token: 0x06001E19 RID: 7705 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001E1A RID: 7706 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001E1B RID: 7707 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001E1C RID: 7708 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001E1D RID: 7709 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001E1E RID: 7710 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x04001455 RID: 5205
		[SerializeField]
		private List<ParteDelCuerpoHumano> ignorarSiEstaViendo = new List<ParteDelCuerpoHumano>();

		// Token: 0x04001456 RID: 5206
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastMaxEmocionValue;

		// Token: 0x04001457 RID: 5207
		private static Comparison<TData> comparison;
	}
}
