using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x0200051C RID: 1308
	public class PlacerPorSerVistoPorMain : CalculoDeEmocionesPorSerVisto
	{
		// Token: 0x17000869 RID: 2153
		// (get) Token: 0x06001FAC RID: 8108 RVA: 0x00005F51 File Offset: 0x00004151
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
			}
		}

		// Token: 0x06001FAD RID: 8109 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x06001FAE RID: 8110 RVA: 0x00077E7E File Offset: 0x0007607E
		protected sealed override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfiguracion.cambiarValorDeEmocionDespuesDeTiempo = 1.5f;
		}

		// Token: 0x1700086A RID: 2154
		// (get) Token: 0x06001FAF RID: 8111 RVA: 0x0005F8CC File Offset: 0x0005DACC
		protected sealed override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.placer_Vision.siendoMirado;
			}
		}

		// Token: 0x1700086B RID: 2155
		// (get) Token: 0x06001FB0 RID: 8112 RVA: 0x0005F8E8 File Offset: 0x0005DAE8
		protected sealed override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.erogenoVisual;
			}
		}

		// Token: 0x1700086C RID: 2156
		// (get) Token: 0x06001FB1 RID: 8113 RVA: 0x0006E079 File Offset: 0x0006C279
		protected sealed override PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesEstimulantes.erogeno;
			}
		}

		// Token: 0x1700086D RID: 2157
		// (get) Token: 0x06001FB2 RID: 8114 RVA: 0x0005F8FF File Offset: 0x0005DAFF
		protected sealed override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.maxEmocionValuePorGrupo.placer;
			}
		}

		// Token: 0x1700086E RID: 2158
		// (get) Token: 0x06001FB3 RID: 8115 RVA: 0x00077E96 File Offset: 0x00076096
		protected sealed override float maxEmocionValuePorGrupoMod
		{
			get
			{
				return 0.25f;
			}
		}

		// Token: 0x1700086F RID: 2159
		// (get) Token: 0x06001FB4 RID: 8116 RVA: 0x0005F916 File Offset: 0x0005DB16
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.erogenoVisualEstimulados;
			}
		}

		// Token: 0x17000870 RID: 2160
		// (get) Token: 0x06001FB5 RID: 8117 RVA: 0x0006E090 File Offset: 0x0006C290
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulante
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.erogenoEstimulantes;
			}
		}

		// Token: 0x17000871 RID: 2161
		// (get) Token: 0x06001FB6 RID: 8118 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float bufferParaGenerarEstimulo
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x06001FB7 RID: 8119 RVA: 0x00077EA0 File Offset: 0x000760A0
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

		// Token: 0x06001FB8 RID: 8120 RVA: 0x0005F92D File Offset: 0x0005DB2D
		protected sealed override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Placer;
		}

		// Token: 0x06001FB9 RID: 8121 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloVisual estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001FBA RID: 8122 RVA: 0x00077EF4 File Offset: 0x000760F4
		protected sealed override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, GrupoQueCompartenValores estimulante, ParteQuePuedeEstimular parteEstimulante, EstimuloVisual estimulo, ref float maxEmotionValue)
		{
			FloatPorGrupoDicc placerModificacionAlArousalMaximo = this.m_emocionesDeOwner.mapas.maxEmocionValuePorGrupo.placerModificacionAlArousalMaximo;
			if (placerModificacionAlArousalMaximo == null)
			{
				return;
			}
			float valor = placerModificacionAlArousalMaximo[grupoEstimulado].valor;
			maxEmotionValue = Mathf.Lerp(maxEmotionValue, maxEmotionValue * valor, this.m_arousalV2.value.mod);
		}

		// Token: 0x06001FBB RID: 8123 RVA: 0x00077F54 File Offset: 0x00076154
		protected sealed override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloVisual estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues? emocionesValoresMods)
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

		// Token: 0x040014F5 RID: 5365
		private Arousal m_arousalV2;

		// Token: 0x040014F6 RID: 5366
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
