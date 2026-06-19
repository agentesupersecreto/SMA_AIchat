using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x0200048E RID: 1166
	public sealed class DolorPorGolpes : CalculoDeEstimuloPorTactilesRecibidos
	{
		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x06001B05 RID: 6917 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool estimuloEsValidoSiEsEstimuloDado
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x06001B06 RID: 6918 RVA: 0x00005F51 File Offset: 0x00004151
		public override bool esGolpe
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170006EC RID: 1772
		// (get) Token: 0x06001B07 RID: 6919 RVA: 0x00006318 File Offset: 0x00004518
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor;
			}
		}

		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x06001B08 RID: 6920 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool removerDataSiEstaNoTieneEstimulo
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170006EE RID: 1774
		// (get) Token: 0x06001B09 RID: 6921 RVA: 0x0006C5F6 File Offset: 0x0006A7F6
		protected sealed override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.dolor_Caricias.porGolpes;
			}
		}

		// Token: 0x170006EF RID: 1775
		// (get) Token: 0x06001B0A RID: 6922 RVA: 0x0006C612 File Offset: 0x0006A812
		protected sealed override PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesEstimulantes.seinsibilidad;
			}
		}

		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x06001B0B RID: 6923 RVA: 0x0006C629 File Offset: 0x0006A829
		protected sealed override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.seinsibilidad;
			}
		}

		// Token: 0x170006F1 RID: 1777
		// (get) Token: 0x06001B0C RID: 6924 RVA: 0x00006060 File Offset: 0x00004260
		protected sealed override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006F2 RID: 1778
		// (get) Token: 0x06001B0D RID: 6925 RVA: 0x0006C640 File Offset: 0x0006A840
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.seinsibilidadEstimulados;
			}
		}

		// Token: 0x170006F3 RID: 1779
		// (get) Token: 0x06001B0E RID: 6926 RVA: 0x00006060 File Offset: 0x00004260
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulante
		{
			get
			{
				return null;
			}
		}

		// Token: 0x170006F4 RID: 1780
		// (get) Token: 0x06001B0F RID: 6927 RVA: 0x0006C657 File Offset: 0x0006A857
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.sensibilidad.porCaricias.expancion;
			}
		}

		// Token: 0x170006F5 RID: 1781
		// (get) Token: 0x06001B10 RID: 6928 RVA: 0x0006C678 File Offset: 0x0006A878
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.sensibilidad.porCaricias.incremento;
			}
		}

		// Token: 0x170006F6 RID: 1782
		// (get) Token: 0x06001B11 RID: 6929 RVA: 0x0006C699 File Offset: 0x0006A899
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulante_Expancion
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupoEstimulante.sensibilidad.porCaricias.expancion;
			}
		}

		// Token: 0x170006F7 RID: 1783
		// (get) Token: 0x06001B12 RID: 6930 RVA: 0x0006C6BA File Offset: 0x0006A8BA
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulante_Incremento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupoEstimulante.sensibilidad.porCaricias.incremento;
			}
		}

		// Token: 0x170006F8 RID: 1784
		// (get) Token: 0x06001B13 RID: 6931 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float bufferParaGenerarEstimulo
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x06001B14 RID: 6932 RVA: 0x0006C6DB File Offset: 0x0006A8DB
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Dolor;
		}

		// Token: 0x06001B15 RID: 6933 RVA: 0x0006C6E6 File Offset: 0x0006A8E6
		protected override bool EstimuloEsValidoV2(ParteQuePuedeEstimular estimulanteParte, [TupleElementNames(new string[] { "original", null, "invertido", "estimulanteInvertido" })] ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> par)
		{
			return base.EstimuloEsValidoV2(estimulanteParte, par) && (estimulanteParte != ParteQuePuedeEstimular.semen || par.Item1.ContineParte(ParteDelCuerpoHumano.globosOculares));
		}

		// Token: 0x06001B16 RID: 6934 RVA: 0x0006C710 File Offset: 0x0006A910
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
			this.suavizar = false;
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
		}

		// Token: 0x06001B17 RID: 6935 RVA: 0x0006C799 File Offset: 0x0006A999
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_emocionesDeOwner.GetComponentsInChildren<IModDeInterDeGenTactil>(this.m_modificadoresDeIntervaloVel);
		}

		// Token: 0x06001B18 RID: 6936 RVA: 0x0006C7B4 File Offset: 0x0006A9B4
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

		// Token: 0x06001B19 RID: 6937 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloTactil estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001B1A RID: 6938 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, GrupoQueCompartenValores estimulante, ParteQuePuedeEstimular parteEstimulante, EstimuloTactil estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x06001B1B RID: 6939 RVA: 0x0006C82C File Offset: 0x0006AA2C
		protected sealed override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloTactil estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues? emocionesValoresMods)
		{
			emocionesValoresMods = new EmocionesFemeninasValues?(emocionesValoresMods ?? this.m_emocionesDeOwner.ObtenerModsFemeninos());
			MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porCaricias = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.dolor.porCaricias;
			intervalo = porCaricias.vsArousal.Modificar(intervalo, emocionesValoresMods.Value.arousal);
			intervalo = porCaricias.vsPlacer.Modificar(intervalo, emocionesValoresMods.Value.humanasValues.placer);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesMix modificador = this.m_modificablesDeInteraccio.GetModificador(estimulo, parteEstimulada, parteEstimulante, true, null);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced advanced = modificador.advanced;
			if (advanced != null)
			{
				estimulacionGenerada.moded *= advanced.gainModificable.ModificarValor(1f);
				intervalo.Expandir(advanced.interExpandModificable.ModificarValor(1f), 0.0001f);
				intervalo.Increase(advanced.interPositionMinMaxModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMinAndKeepLenght(advanced.interPositionMinModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMaxAndKeepLenght(advanced.interPositionMaxModificable.ModificarValor(1f), 0.0001f);
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional tradicional = modificador.tradicional;
			if (tradicional != null)
			{
				estimulacionGenerada.moded *= tradicional.gainModificable.ModificarValor(1f);
				intervalo.Expandir(tradicional.interExpandModificable.ModificarValor(1f), 0.0001f);
				intervalo.Increase(tradicional.interPositionMinMaxModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMinAndKeepLenght(tradicional.interPositionMinModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMaxAndKeepLenght(tradicional.interPositionMaxModificable.ModificarValor(1f), 0.0001f);
			}
			for (int i = 0; i < this.m_modificadoresDeIntervaloVel.Count; i++)
			{
				this.m_modificadoresDeIntervaloVel[i].StackIfGreater(this.m_Emo.reaccion, parteEstimulada, parteEstimulante, ref intervalo);
			}
		}

		// Token: 0x06001B1C RID: 6940 RVA: 0x00004252 File Offset: 0x00002452
		protected override UmbralBasico.TipoDeCambio ObtenerTipoDeCambio()
		{
			return UmbralBasico.TipoDeCambio.unico;
		}

		// Token: 0x06001B1D RID: 6941 RVA: 0x0005F8C5 File Offset: 0x0005DAC5
		protected override float GetNextCoolDown()
		{
			return 0.5f;
		}

		// Token: 0x04001385 RID: 4997
		private Arousal m_arousalV2;

		// Token: 0x04001386 RID: 4998
		private Placer m_PlacerV2;

		// Token: 0x04001387 RID: 4999
		private List<IModDeInterDeGenTactil> m_modificadoresDeIntervaloVel = new List<IModDeInterDeGenTactil>();

		// Token: 0x04001388 RID: 5000
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
