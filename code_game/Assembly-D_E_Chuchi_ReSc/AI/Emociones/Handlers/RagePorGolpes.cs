using System;
using System.Runtime.CompilerServices;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000494 RID: 1172
	public sealed class RagePorGolpes : CalculoDeEstimuloPorTactilesRecibidos
	{
		// Token: 0x17000754 RID: 1876
		// (get) Token: 0x06001BB7 RID: 7095 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool estimuloEsValidoSiEsEstimuloDado
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000755 RID: 1877
		// (get) Token: 0x06001BB8 RID: 7096 RVA: 0x00005F51 File Offset: 0x00004151
		public override bool esGolpe
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000756 RID: 1878
		// (get) Token: 0x06001BB9 RID: 7097 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool removerDataSiEstaNoTieneEstimulo
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000757 RID: 1879
		// (get) Token: 0x06001BBA RID: 7098 RVA: 0x0000D704 File Offset: 0x0000B904
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor;
			}
		}

		// Token: 0x17000758 RID: 1880
		// (get) Token: 0x06001BBB RID: 7099 RVA: 0x0006F263 File Offset: 0x0006D463
		protected sealed override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.rage_Caricias.porGolpes;
			}
		}

		// Token: 0x17000759 RID: 1881
		// (get) Token: 0x06001BBC RID: 7100 RVA: 0x0006C612 File Offset: 0x0006A812
		protected sealed override PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesEstimulantes.seinsibilidad;
			}
		}

		// Token: 0x1700075A RID: 1882
		// (get) Token: 0x06001BBD RID: 7101 RVA: 0x0006C629 File Offset: 0x0006A829
		protected sealed override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.seinsibilidad;
			}
		}

		// Token: 0x1700075B RID: 1883
		// (get) Token: 0x06001BBE RID: 7102 RVA: 0x00006060 File Offset: 0x00004260
		protected sealed override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700075C RID: 1884
		// (get) Token: 0x06001BBF RID: 7103 RVA: 0x00006060 File Offset: 0x00004260
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700075D RID: 1885
		// (get) Token: 0x06001BC0 RID: 7104 RVA: 0x00006060 File Offset: 0x00004260
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulante
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700075E RID: 1886
		// (get) Token: 0x06001BC1 RID: 7105 RVA: 0x00006060 File Offset: 0x00004260
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700075F RID: 1887
		// (get) Token: 0x06001BC2 RID: 7106 RVA: 0x0006C678 File Offset: 0x0006A878
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.sensibilidad.porCaricias.incremento;
			}
		}

		// Token: 0x17000760 RID: 1888
		// (get) Token: 0x06001BC3 RID: 7107 RVA: 0x00006060 File Offset: 0x00004260
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulante_Expancion
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000761 RID: 1889
		// (get) Token: 0x06001BC4 RID: 7108 RVA: 0x0006C6BA File Offset: 0x0006A8BA
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulante_Incremento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupoEstimulante.sensibilidad.porCaricias.incremento;
			}
		}

		// Token: 0x17000762 RID: 1890
		// (get) Token: 0x06001BC5 RID: 7109 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float bufferParaGenerarEstimulo
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x06001BC6 RID: 7110 RVA: 0x0006F27F File Offset: 0x0006D47F
		protected override void OnDataAdded(CalculoDeEstimuloPorCariciasResultado data)
		{
			base.OnDataAdded(data);
		}

		// Token: 0x06001BC7 RID: 7111 RVA: 0x0005FEE1 File Offset: 0x0005E0E1
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Rage;
		}

		// Token: 0x06001BC8 RID: 7112 RVA: 0x0006F288 File Offset: 0x0006D488
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_arousalV2 = this.m_emocionesDeOwner.GetComponentInChildren<Arousal>();
			if (this.m_arousalV2 == null)
			{
				throw new ArgumentNullException("m_arousal", "m_arousal null reference.");
			}
			this.m_PlacerV2 = this.m_emocionesDeOwner.GetComponentInChildren<Placer>();
			if (this.m_PlacerV2 == null)
			{
				throw new ArgumentNullException("Placer", "Placer null reference.");
			}
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
			this.suavizar = false;
		}

		// Token: 0x06001BC9 RID: 7113 RVA: 0x0006C6E6 File Offset: 0x0006A8E6
		protected override bool EstimuloEsValidoV2(ParteQuePuedeEstimular estimulanteParte, [TupleElementNames(new string[] { "original", null, "invertido", "estimulanteInvertido" })] ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> par)
		{
			return base.EstimuloEsValidoV2(estimulanteParte, par) && (estimulanteParte != ParteQuePuedeEstimular.semen || par.Item1.ContineParte(ParteDelCuerpoHumano.globosOculares));
		}

		// Token: 0x06001BCA RID: 7114 RVA: 0x0006F314 File Offset: 0x0006D514
		protected override void AlterarDataGenerada(CalculoDeEstimuloPorCariciasResultado data)
		{
			base.AlterarDataGenerada(data);
			data.estimulo.SetTipoDeEstimuloTactil(data.estimulo.ObtenerTipoDeEstimuloTactil(this.contextoDePrioridadDeParteHumana, data.data.estimulanteParte, true));
			if (data.estimulo.tieneCopiaInvertida && data.estimuloInvertido != null)
			{
				data.estimuloInvertido.SetTipoDeEstimuloTactil(data.estimulo.tipoDeEstimuloTactil);
			}
			data.data.tag = "golpe";
		}

		// Token: 0x06001BCB RID: 7115 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloTactil estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001BCC RID: 7116 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, GrupoQueCompartenValores estimulante, ParteQuePuedeEstimular parteEstimulante, EstimuloTactil estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x06001BCD RID: 7117 RVA: 0x0006F38C File Offset: 0x0006D58C
		protected sealed override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloTactil estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues? emocionesValoresMods)
		{
			if (parteEstimulante == ParteQuePuedeEstimular.semen)
			{
				estimulacionGenerada.moded *= 8f;
			}
			emocionesValoresMods = new EmocionesFemeninasValues?(emocionesValoresMods ?? this.m_emocionesDeOwner.ObtenerModsFemeninos());
			MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porCaricias = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.rage_Golpes.porCaricias;
			intervalo = porCaricias.vsArousal.Modificar(intervalo, emocionesValoresMods.Value.arousal);
			intervalo = porCaricias.vsPlacer.Modificar(intervalo, emocionesValoresMods.Value.humanasValues.placer);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesMix modificador = this.m_modificablesDeInteraccio.GetModificador(estimulo, parteEstimulada, parteEstimulante, true, null);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced advanced = modificador.advanced;
			if (advanced != null)
			{
				estimulacionGenerada.moded *= advanced.gainModificable.ModificarValor(1f);
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional tradicional = modificador.tradicional;
			if (tradicional != null)
			{
				estimulacionGenerada.moded *= tradicional.gainModificable.ModificarValor(1f);
			}
		}

		// Token: 0x06001BCE RID: 7118 RVA: 0x00004252 File Offset: 0x00002452
		protected override UmbralBasico.TipoDeCambio ObtenerTipoDeCambio()
		{
			return UmbralBasico.TipoDeCambio.unico;
		}

		// Token: 0x06001BCF RID: 7119 RVA: 0x0005F8C5 File Offset: 0x0005DAC5
		protected override float GetNextCoolDown()
		{
			return 0.5f;
		}

		// Token: 0x040013AC RID: 5036
		private Arousal m_arousalV2;

		// Token: 0x040013AD RID: 5037
		private Placer m_PlacerV2;

		// Token: 0x040013AE RID: 5038
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
