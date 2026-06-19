using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x020004F0 RID: 1264
	public abstract class CalculoDeEmocionesPorSerVisto : CalculoDeEstimuloPor<CalculoDeEstimuloVisualResultado, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual>, KeyValuePair<int, EstimuloVisual>, CalculoDeEmocionesPorSerVistoConfiguracion, VisionDesdeMainInFrame>, ICalculadorDeEstimuloVisual, ICalculadorDeEstimulo<ICalculoDeEstimuloVisual>, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorDeEstimulo<CalculoDeEstimuloVisualResultado>, ICalculadorDeEstimuloIgnoradorEnPartesHumanas, ICalculadorSimulable, ICalculadorDeEstimuloClasificable
	{
		// Token: 0x170007C6 RID: 1990
		// (get) Token: 0x06001D8D RID: 7565
		protected abstract float bufferParaGenerarEstimulo { get; }

		// Token: 0x170007C7 RID: 1991
		// (get) Token: 0x06001D8E RID: 7566
		protected abstract PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana { get; }

		// Token: 0x06001D8F RID: 7567 RVA: 0x00072936 File Offset: 0x00070B36
		public void IgnorarParteHumana(ParteDelCuerpoHumano parte, bool ignorar)
		{
			if (ignorar)
			{
				if (!this.ignorarSiEstaSiendoVistoEn.Contains(parte))
				{
					this.ignorarSiEstaSiendoVistoEn.Add(parte);
					return;
				}
			}
			else
			{
				while (this.ignorarSiEstaSiendoVistoEn.Contains(parte))
				{
					this.ignorarSiEstaSiendoVistoEn.Remove(parte);
				}
			}
		}

		// Token: 0x06001D90 RID: 7568 RVA: 0x00072971 File Offset: 0x00070B71
		protected sealed override bool ItemEsValido(KeyValuePair<int, EstimuloVisual> item, int index)
		{
			return !this.ignorarSiEstaSiendoVistoEn.Contains(item.Value.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana));
		}

		// Token: 0x170007C8 RID: 1992
		// (get) Token: 0x06001D91 RID: 7569 RVA: 0x00004252 File Offset: 0x00002452
		public sealed override DireccionDeEstimulo direccionDeEstimulo
		{
			get
			{
				return DireccionDeEstimulo.recibida;
			}
		}

		// Token: 0x170007C9 RID: 1993
		// (get) Token: 0x06001D92 RID: 7570 RVA: 0x0000D704 File Offset: 0x0000B904
		public sealed override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.visual;
			}
		}

		// Token: 0x170007CA RID: 1994
		// (get) Token: 0x06001D93 RID: 7571
		protected abstract float maxEmocionValuePorGrupoMod { get; }

		// Token: 0x170007CB RID: 1995
		// (get) Token: 0x06001D94 RID: 7572
		protected abstract PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo { get; }

		// Token: 0x170007CC RID: 1996
		// (get) Token: 0x06001D95 RID: 7573
		protected abstract PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo { get; }

		// Token: 0x170007CD RID: 1997
		// (get) Token: 0x06001D96 RID: 7574
		protected abstract FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada { get; }

		// Token: 0x170007CE RID: 1998
		// (get) Token: 0x06001D97 RID: 7575
		protected abstract FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulante { get; }

		// Token: 0x170007CF RID: 1999
		// (get) Token: 0x06001D98 RID: 7576
		protected abstract DatosDeUmbral datosDeUmbral { get; }

		// Token: 0x170007D0 RID: 2000
		// (get) Token: 0x06001D99 RID: 7577
		protected abstract FloatPorGrupoDicc maxEmocionValuePorGrupo { get; }

		// Token: 0x170007D1 RID: 2001
		// (get) Token: 0x06001D9A RID: 7578 RVA: 0x00072995 File Offset: 0x00070B95
		[Obsolete("", true)]
		public ICalculoDeEstimuloVisual calculoMasFuerte
		{
			get
			{
				return this.m_masFuerteGenerada;
			}
		}

		// Token: 0x170007D2 RID: 2002
		// (get) Token: 0x06001D9B RID: 7579 RVA: 0x00072995 File Offset: 0x00070B95
		[Obsolete("", true)]
		CalculoDeEstimuloVisualResultado ICalculadorDeEstimulo<CalculoDeEstimuloVisualResultado>.calculoMasFuerte
		{
			get
			{
				return this.m_masFuerteGenerada;
			}
		}

		// Token: 0x06001D9C RID: 7580 RVA: 0x0007299D File Offset: 0x00070B9D
		ICalculoDeEstimuloVisual ICalculadorDeEstimulo<ICalculoDeEstimuloVisual>.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(int index)
		{
			return base.GetCalculoConEstimulosEnFrameMasFuerteAMasDebil(index);
		}

		// Token: 0x06001D9D RID: 7581 RVA: 0x000729A6 File Offset: 0x00070BA6
		ICalculoDeEstimuloVisual ICalculadorDeEstimulo<ICalculoDeEstimuloVisual>.GetCalculoEnFrame(int index)
		{
			return base.GetCalculoEnFrame(index);
		}

		// Token: 0x06001D9E RID: 7582 RVA: 0x000729B0 File Offset: 0x00070BB0
		[Obsolete("", true)]
		public void GetCalculosDelMasFuerteAlMasDebil(IList<ICalculoDeEstimuloVisual> resultado)
		{
			for (int i = 0; i < this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil.Count; i++)
			{
				resultado.Add(this.m_dataGeneradaConEstimuloMasFuerteAlMasDebil[i]);
			}
		}

		// Token: 0x06001D9F RID: 7583 RVA: 0x000729E5 File Offset: 0x00070BE5
		protected sealed override void SortMasFuerteAlMasDebil(List<CalculoDeEstimuloVisualResultado> calculos)
		{
			if (CalculoDeEmocionesPorSerVisto.comparison == null)
			{
				CalculoDeEmocionesPorSerVisto.comparison = (CalculoDeEstimuloVisualResultado a, CalculoDeEstimuloVisualResultado b) => -1 * a.data.estado.estimulacionGeneradaEnFrame.CompareTo(b.data.estado.estimulacionGeneradaEnFrame);
			}
			calculos.Sort(CalculoDeEmocionesPorSerVisto.comparison);
		}

		// Token: 0x06001DA0 RID: 7584 RVA: 0x00072A1D File Offset: 0x00070C1D
		protected sealed override DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual> GetEstimulosEnFrame(VisionDesdeMainInFrame collecor)
		{
			return this.m_EstimuloByMainInFrame.frameVistas;
		}

		// Token: 0x06001DA1 RID: 7585 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnOldDataCleared()
		{
		}

		// Token: 0x06001DA2 RID: 7586 RVA: 0x00072A2C File Offset: 0x00070C2C
		public void SimularGlobal(ParteQuePuedeEstimular estimulante, ParteDelCuerpoHumano estimulada, float deltaTime, out RangeValueV2 intervalo, out UmbralBasico.Estado minGenerado, out UmbralBasico.Estado maxGenerado, EmocionesFemeninasValues? emocionesValoresMods)
		{
			ICalculoDeEstimuloCompleto calculoDeEstimuloCompleto;
			this.SimularGlobal(estimulante, estimulada, deltaTime, out intervalo, out minGenerado, out maxGenerado, emocionesValoresMods, out calculoDeEstimuloCompleto);
		}

		// Token: 0x06001DA3 RID: 7587 RVA: 0x00072A4C File Offset: 0x00070C4C
		public void SimularGlobal(ParteQuePuedeEstimular estimulante, ParteDelCuerpoHumano estimulada, float deltaTime, out RangeValueV2 intervalo, out UmbralBasico.Estado minGenerado, out UmbralBasico.Estado maxGenerado, EmocionesFemeninasValues? emocionesValoresMods, out ICalculoDeEstimuloCompleto faseTres)
		{
			CalculoDeEstimuloVisualResultado calculoDeEstimuloVisualResultado = new CalculoDeEstimuloVisualResultado();
			calculoDeEstimuloVisualResultado.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
			EstimuloVisual estimuloVisual = new EstimuloVisual();
			estimuloVisual.tipoDeEstimulo = TipoDeEstimulo.visual;
			estimuloVisual.EstimuloSoloUsaPrioridadesFixed();
			estimuloVisual.AddParteEstimulada(estimulada);
			KeyValuePair<int, EstimuloVisual> keyValuePair = new KeyValuePair<int, EstimuloVisual>((int)estimulante, estimuloVisual);
			this.PoblarConData(calculoDeEstimuloVisualResultado, keyValuePair, this.datosDeUmbral, deltaTime, out intervalo, emocionesValoresMods, new float?((float)1), new float?((float)1), true);
			CalculoDeEstimuloVisualResultado calculoDeEstimuloVisualResultado2 = new CalculoDeEstimuloVisualResultado();
			calculoDeEstimuloVisualResultado2.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
			EstimuloVisual estimuloVisual2 = new EstimuloVisual();
			estimuloVisual2.tipoDeEstimulo = TipoDeEstimulo.visual;
			estimuloVisual2.EstimuloSoloUsaPrioridadesFixed();
			estimuloVisual2.AddParteEstimulada(estimulada);
			KeyValuePair<int, EstimuloVisual> keyValuePair2 = new KeyValuePair<int, EstimuloVisual>((int)estimulante, estimuloVisual2);
			RangeValueV2 rangeValueV;
			this.PoblarConData(calculoDeEstimuloVisualResultado2, keyValuePair2, this.datosDeUmbral, deltaTime, out rangeValueV, emocionesValoresMods, new float?(0f), new float?(0f), true);
			this.PostCalculoDeEstimulo(calculoDeEstimuloVisualResultado2);
			minGenerado = calculoDeEstimuloVisualResultado2.data.estado;
			CalculoDeEstimuloVisualResultado calculoDeEstimuloVisualResultado3 = new CalculoDeEstimuloVisualResultado();
			faseTres = calculoDeEstimuloVisualResultado3;
			calculoDeEstimuloVisualResultado3.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
			EstimuloVisual estimuloVisual3 = new EstimuloVisual();
			estimuloVisual3.tipoDeEstimulo = TipoDeEstimulo.visual;
			estimuloVisual3.EstimuloSoloUsaPrioridadesFixed();
			estimuloVisual3.AddParteEstimulada(estimulada);
			KeyValuePair<int, EstimuloVisual> keyValuePair3 = new KeyValuePair<int, EstimuloVisual>((int)estimulante, estimuloVisual3);
			RangeValueV2 rangeValueV2;
			this.PoblarConData(calculoDeEstimuloVisualResultado3, keyValuePair3, this.datosDeUmbral, deltaTime, out rangeValueV2, emocionesValoresMods, new float?((float)1), new float?((float)1), true);
			this.PostCalculoDeEstimulo(calculoDeEstimuloVisualResultado3);
			maxGenerado = calculoDeEstimuloVisualResultado3.data.estado;
		}

		// Token: 0x06001DA4 RID: 7588 RVA: 0x00072BB8 File Offset: 0x00070DB8
		private void PoblarConData(CalculoDeEstimuloVisualResultado data, KeyValuePair<int, EstimuloVisual> item, DatosDeUmbral datos, float deltaTime, out RangeValueV2 intervalo, EmocionesFemeninasValues? emocionesValoresMods, float? angleMod = null, float? distanceMod = null, bool reusarEstimuloInstance = false)
		{
			ParteQuePuedeEstimular key = (ParteQuePuedeEstimular)item.Key;
			EstimuloVisual value = item.Value;
			ParteDelCuerpoHumano parteDelCuerpoHumano = value.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
			if (value == null)
			{
				throw new ArgumentNullException("estimulo", "estimulo null reference.");
			}
			if (datos == null)
			{
				throw new ArgumentNullException("datos", "datos null reference.");
			}
			float num = angleMod ?? Mathf.InverseLerp(90f, 20f, value.angleDesdePuntoVisual).OutPow(3f);
			float num2 = distanceMod ?? Mathf.InverseLerp(4f, 0.1f, value.distancia).OutPow(3f);
			float num3 = num * num2 * (value.outOfRange ? 0f : 1f);
			intervalo = datos.intervaloDeGeneracion;
			ValorModificable estimulacionQueGenera = datos.estimulacionQueGenera;
			this.OnPreUmbralCalculo(key, parteDelCuerpoHumano, value, ref num3, ref intervalo, ref estimulacionQueGenera, ref emocionesValoresMods);
			UmbralBasico.Estado estado = default(UmbralBasico.Estado);
			try
			{
				UmbralBasico.TipoDeCambio tipoDeCambio = this.TipoDeCambioParaCalculo(data, key, parteDelCuerpoHumano);
				estado = UmbralBasico.Calcular(num3, deltaTime, tipoDeCambio, intervalo, estimulacionQueGenera.total, datos.spotBonuses, datos.promedioMod, datos.modPorEncima, datos.modPorDebajo);
				float estimulacionGeneradaEnFrame = estado.estimulacionGeneradaEnFrame;
				this.OnPostUmbralCalculo(key, value, ref estimulacionGeneradaEnFrame);
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

		// Token: 0x06001DA5 RID: 7589 RVA: 0x00072E34 File Offset: 0x00071034
		protected virtual UmbralBasico.TipoDeCambio TipoDeCambioParaCalculo(CalculoDeEstimuloVisualResultado data, ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada)
		{
			data.estimulo.SetTipoDeEstimuloVisual(parteEstimulante.ObtenerTipoDeEstimuloVisual());
			TipoDeEstimuloVisual tipoDeEstimuloVisual = data.estimulo.tipoDeEstimuloVisual;
			if (tipoDeEstimuloVisual == TipoDeEstimuloVisual.normal)
			{
				return UmbralBasico.TipoDeCambio.porSegundo;
			}
			if (tipoDeEstimuloVisual != TipoDeEstimuloVisual.fotografiada)
			{
				throw new ArgumentOutOfRangeException(data.estimulo.tipoDeEstimuloVisual.ToString());
			}
			return UmbralBasico.TipoDeCambio.unico;
		}

		// Token: 0x06001DA6 RID: 7590 RVA: 0x00072E8C File Offset: 0x0007108C
		protected sealed override void PoblarDataConItem(CalculoDeEstimuloVisualResultado data, KeyValuePair<int, EstimuloVisual> item, int index, float deltaTime, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual> alldata)
		{
			data.Poblar(this.m_Emo, this, TipoDeCalculoDeEstimulo.frame);
			RangeValueV2 rangeValueV;
			this.PoblarConData(data, item, this.datosDeUmbral, deltaTime, out rangeValueV, null, null, null, false);
			bool flag = data.data.estado.estimulacionGeneradaEnFrame > 0f;
			float num = ((data.estimulanteParte != ParteQuePuedeEstimular.propSexToy) ? (this.bufferParaGenerarEstimulo * 2f) : 0f);
			if (num > 0f)
			{
				CalculoDeEstimuloEnFrame.ApplyBufferToEstimulado(ref flag, num, this.m_BufferedCoolDown, ref data.data.estado);
			}
		}

		// Token: 0x06001DA7 RID: 7591 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnDataGenerada(CalculoDeEstimuloVisualResultado data)
		{
		}

		// Token: 0x06001DA8 RID: 7592 RVA: 0x00072F30 File Offset: 0x00071130
		protected sealed override void PostPoblarDataConItem(CalculoDeEstimuloVisualResultado data, DiccionaryEnum<ParteQuePuedeEstimular, EstimuloVisual> allData)
		{
			TipoDeEstimuloVisual tipoDeEstimuloVisual = data.estimulanteParte.ObtenerTipoDeEstimuloVisual();
			data.estimulo.SetTipoDeEstimuloVisual(tipoDeEstimuloVisual);
			this.AlterarDataGenerada(data);
		}

		// Token: 0x06001DA9 RID: 7593 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void AlterarDataGenerada(CalculoDeEstimuloVisualResultado data)
		{
		}

		// Token: 0x06001DAA RID: 7594 RVA: 0x00005F51 File Offset: 0x00004151
		protected sealed override bool DataGeneradaEsValida(CalculoDeEstimuloVisualResultado data, int index)
		{
			return true;
		}

		// Token: 0x06001DAB RID: 7595 RVA: 0x00072F5C File Offset: 0x0007115C
		protected sealed override float PreCalculoDeEstimulo(CalculoDeEstimuloVisualResultado data)
		{
			return data.data.estado.estimulacionGeneradaEnFrame;
		}

		// Token: 0x06001DAC RID: 7596 RVA: 0x00072F70 File Offset: 0x00071170
		protected override bool MaximoAlcanzado(CalculoDeEstimuloVisualResultado data, float valorDeEmovionActual, out float maxEmoValueDeGrupo)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = data.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
			ParteQuePuedeEstimular estimulanteParte = data.data.estimulanteParte;
			GrupoQueCompartenValores grupoQueCompartenValores = GrupoQueCompartenValores.f;
			GrupoQueCompartenValores grupoQueCompartenValores2 = GrupoQueCompartenValores.f;
			if (this.mapaDeParteHumanaEstimuladaGrupo)
			{
				grupoQueCompartenValores = this.mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteDelCuerpoHumano);
			}
			if (this.mapaDeParteEstimulanteGrupo)
			{
				grupoQueCompartenValores2 = this.mapaDeParteEstimulanteGrupo.GetGrupoDeParte(estimulanteParte);
			}
			maxEmoValueDeGrupo = 120f;
			if (this.maxEmocionValuePorGrupo)
			{
				maxEmoValueDeGrupo = this.maxEmocionValuePorGrupo[grupoQueCompartenValores].valor;
			}
			maxEmoValueDeGrupo *= this.maxEmocionValuePorGrupoMod;
			this.OnPreLimitarMaxEmocionValue(grupoQueCompartenValores, grupoQueCompartenValores2, estimulanteParte, data.estimulo, ref maxEmoValueDeGrupo);
			maxEmoValueDeGrupo = Mathf.Clamp(maxEmoValueDeGrupo, 0f, 120f);
			return valorDeEmovionActual > maxEmoValueDeGrupo;
		}

		// Token: 0x06001DAD RID: 7597 RVA: 0x00073034 File Offset: 0x00071234
		protected sealed override float PostCalculoDeEstimulo(CalculoDeEstimuloVisualResultado data)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = data.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
			ParteQuePuedeEstimular estimulanteParte = data.data.estimulanteParte;
			GrupoQueCompartenValores grupoQueCompartenValores = GrupoQueCompartenValores.f;
			GrupoQueCompartenValores grupoQueCompartenValores2 = GrupoQueCompartenValores.f;
			if (this.mapaDeParteHumanaEstimuladaGrupo)
			{
				grupoQueCompartenValores = this.mapaDeParteHumanaEstimuladaGrupo.GetGrupoDeParte(parteDelCuerpoHumano);
			}
			if (this.mapaDeParteEstimulanteGrupo)
			{
				grupoQueCompartenValores2 = this.mapaDeParteEstimulanteGrupo.GetGrupoDeParte(estimulanteParte);
			}
			this.AplicarModificadoresDeGeneracion(data, grupoQueCompartenValores, grupoQueCompartenValores2);
			return data.data.estado.estimulacionGeneradaEnFrame;
		}

		// Token: 0x06001DAE RID: 7598 RVA: 0x000730B8 File Offset: 0x000712B8
		private void AplicarModificadoresDeGeneracion(CalculoDeEstimuloVisualResultado data, GrupoQueCompartenValores parteEstimulada, GrupoQueCompartenValores parteEstimulante)
		{
			if (this.modEstimuloGeneradoPorGrupoDeParteEstimulante)
			{
				float valor = this.modEstimuloGeneradoPorGrupoDeParteEstimulante[parteEstimulante].valor;
				data.data.estado.ModificarGenerado(valor);
			}
			if (this.modEstimuloGeneradoPorGrupoDeParteEstimulada)
			{
				float valor2 = this.modEstimuloGeneradoPorGrupoDeParteEstimulada[parteEstimulada].valor;
				data.data.estado.ModificarGenerado(valor2);
			}
		}

		// Token: 0x06001DAF RID: 7599 RVA: 0x00073128 File Offset: 0x00071328
		protected sealed override float ModParaCambiarValorDeEmocionDespuesDeTiempo(CalculoDeEstimuloVisualResultado data)
		{
			ParteQuePuedeEstimular estimulanteParte = data.estimulanteParte;
			if (estimulanteParte <= ParteQuePuedeEstimular.lengua)
			{
				if (estimulanteParte <= ParteQuePuedeEstimular.propSexToy)
				{
					switch (estimulanteParte)
					{
					case ParteQuePuedeEstimular.None:
					case ParteQuePuedeEstimular.noEspecificada:
					case ParteQuePuedeEstimular.piernas:
					case ParteQuePuedeEstimular.manos:
					case ParteQuePuedeEstimular.pene:
						break;
					case (ParteQuePuedeEstimular)3:
					case (ParteQuePuedeEstimular)5:
					case (ParteQuePuedeEstimular)6:
					case (ParteQuePuedeEstimular)7:
						goto IL_0084;
					default:
						if (estimulanteParte != ParteQuePuedeEstimular.propSexToy)
						{
							goto IL_0084;
						}
						return 0f;
					}
				}
				else if (estimulanteParte != ParteQuePuedeEstimular.torzo && estimulanteParte != ParteQuePuedeEstimular.lengua)
				{
					goto IL_0084;
				}
			}
			else if (estimulanteParte <= ParteQuePuedeEstimular.ojos)
			{
				if (estimulanteParte != ParteQuePuedeEstimular.boca && estimulanteParte != ParteQuePuedeEstimular.ojos)
				{
					goto IL_0084;
				}
			}
			else if (estimulanteParte != ParteQuePuedeEstimular.semen && estimulanteParte != ParteQuePuedeEstimular.dedo)
			{
				goto IL_0084;
			}
			return 1f;
			IL_0084:
			throw new ArgumentOutOfRangeException(data.estimulanteParte.ToString());
		}

		// Token: 0x06001DB0 RID: 7600 RVA: 0x000731D2 File Offset: 0x000713D2
		protected override void AplicarMaxValueEmoMods(CalculoDeEstimuloVisualResultado data, bool maximoAlcanzado, float currentEmoValue, float maxEmoValueDeGrupo, out float modificadorDEmocionChange)
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

		// Token: 0x06001DB1 RID: 7601
		protected abstract void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloVisual estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues? emocionesValoresMods);

		// Token: 0x06001DB2 RID: 7602
		protected abstract void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloVisual estimulo, ref float estimulacionGenerada);

		// Token: 0x06001DB3 RID: 7603
		protected abstract void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, GrupoQueCompartenValores estimulante, ParteQuePuedeEstimular parteEstimulante, EstimuloVisual estimulo, ref float maxEmotionValue);

		// Token: 0x06001DB4 RID: 7604 RVA: 0x00073214 File Offset: 0x00071414
		public bool TryInstantiateCalculo(out ICalculoDeEstimuloVisual calculo)
		{
			CalculoDeEstimuloVisualResultado calculoDeEstimuloVisualResultado;
			bool flag = base.TryInstantiateCalculo(out calculoDeEstimuloVisualResultado);
			calculo = calculoDeEstimuloVisualResultado;
			return flag;
		}

		// Token: 0x06001DB6 RID: 7606 RVA: 0x0005848D File Offset: 0x0005668D
		bool ICalculadorDeEstimulo.get_isActiveAndEnabled()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x06001DB7 RID: 7607 RVA: 0x00005AA2 File Offset: 0x00003CA2
		bool ICalculadorDeEstimulo.get_enabled()
		{
			return base.enabled;
		}

		// Token: 0x06001DB8 RID: 7608 RVA: 0x00005AAA File Offset: 0x00003CAA
		void ICalculadorDeEstimulo.set_enabled(bool value)
		{
			base.enabled = value;
		}

		// Token: 0x06001DB9 RID: 7609 RVA: 0x0001ED7C File Offset: 0x0001CF7C
		string ICalculadorDeEstimulo.get_name()
		{
			return base.name;
		}

		// Token: 0x06001DBA RID: 7610 RVA: 0x00058495 File Offset: 0x00056695
		bool IComponentAwakeable.get_isAwaken()
		{
			return base.isAwaken;
		}

		// Token: 0x06001DBB RID: 7611 RVA: 0x0005849D File Offset: 0x0005669D
		void IComponentAwakeable.ManualAwake()
		{
			base.ManualAwake();
		}

		// Token: 0x0400143F RID: 5183
		[SerializeField]
		private BufferedCoolDown m_BufferedCoolDown = new BufferedCoolDown();

		// Token: 0x04001440 RID: 5184
		[SerializeField]
		private List<ParteDelCuerpoHumano> ignorarSiEstaSiendoVistoEn = new List<ParteDelCuerpoHumano>();

		// Token: 0x04001441 RID: 5185
		private static Comparison<CalculoDeEstimuloVisualResultado> comparison;
	}
}
