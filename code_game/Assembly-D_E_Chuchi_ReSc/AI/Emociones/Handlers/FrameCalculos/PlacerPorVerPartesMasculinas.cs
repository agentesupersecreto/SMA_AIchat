using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x0200051D RID: 1309
	public class PlacerPorVerPartesMasculinas : CalculoDeEstimuloPorVerPartesMasculinas<CalculoDeEstimuloVisualResultado>
	{
		// Token: 0x17000872 RID: 2162
		// (get) Token: 0x06001FBD RID: 8125 RVA: 0x00005F51 File Offset: 0x00004151
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
			}
		}

		// Token: 0x06001FBE RID: 8126 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x17000873 RID: 2163
		// (get) Token: 0x06001FBF RID: 8127 RVA: 0x00078158 File Offset: 0x00076358
		protected override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.placer_Vision.mirando;
			}
		}

		// Token: 0x17000874 RID: 2164
		// (get) Token: 0x06001FC0 RID: 8128 RVA: 0x0005F8E8 File Offset: 0x0005DAE8
		protected override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.erogenoVisual;
			}
		}

		// Token: 0x17000875 RID: 2165
		// (get) Token: 0x06001FC1 RID: 8129 RVA: 0x0005F8FF File Offset: 0x0005DAFF
		protected override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.maxEmocionValuePorGrupo.placer;
			}
		}

		// Token: 0x17000876 RID: 2166
		// (get) Token: 0x06001FC2 RID: 8130 RVA: 0x0005F916 File Offset: 0x0005DB16
		protected override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.erogenoVisualEstimulados;
			}
		}

		// Token: 0x17000877 RID: 2167
		// (get) Token: 0x06001FC3 RID: 8131 RVA: 0x00077E96 File Offset: 0x00076096
		protected sealed override float maxEmocionValuePorGrupoMod
		{
			get
			{
				return 0.25f;
			}
		}

		// Token: 0x06001FC4 RID: 8132 RVA: 0x00078174 File Offset: 0x00076374
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_arousalV2 = this.m_emocionesDeOwner.GetComponentInChildren<Arousal>();
			if (this.m_arousalV2 == null)
			{
				throw new ArgumentNullException("m_arousal", "m_arousal null reference.");
			}
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
		}

		// Token: 0x06001FC5 RID: 8133 RVA: 0x0005F92D File Offset: 0x0005DB2D
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Placer;
		}

		// Token: 0x06001FC6 RID: 8134 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPostUmbralCalculo(EstimuloVisual estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001FC7 RID: 8135 RVA: 0x000781C8 File Offset: 0x000763C8
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, EstimuloVisual estimulo, ref float maxEmotionValue)
		{
			FloatPorGrupoDicc placerModificacionAlArousalMaximo = this.m_emocionesDeOwner.mapas.maxEmocionValuePorGrupo.placerModificacionAlArousalMaximo;
			if (placerModificacionAlArousalMaximo == null)
			{
				return;
			}
			float valor = placerModificacionAlArousalMaximo[grupoEstimulado].valor;
			maxEmotionValue = Mathf.Lerp(maxEmotionValue, maxEmotionValue * valor, this.m_arousalV2.value.mod);
		}

		// Token: 0x06001FC8 RID: 8136 RVA: 0x00078224 File Offset: 0x00076424
		protected override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloVisual estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues? emocionesValoresMods)
		{
			emocionesValoresMods = new EmocionesFemeninasValues?(emocionesValoresMods ?? this.m_emocionesDeOwner.ObtenerModsFemeninos());
			MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porSiendoVisto = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.placer.porSiendoVisto;
			intervalo = porSiendoVisto.vsArousal.Modificar(intervalo, emocionesValoresMods.Value.arousal);
			intervalo = porSiendoVisto.vsPlacer.Modificar(intervalo, emocionesValoresMods.Value.humanasValues.placer);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesMix modificador = this.m_modificablesDeInteraccio.GetModificador(estimulo, parteEstimulada, parteEstimulante, false, null);
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
		}

		// Token: 0x040014F7 RID: 5367
		private Arousal m_arousalV2;

		// Token: 0x040014F8 RID: 5368
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
