using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Ropa.Handlers.FrameCalculos
{
	// Token: 0x02000427 RID: 1063
	public sealed class PlacerPorSerDesvestidoPorMain : CalculoDeEmocionesPorSerDesvestido
	{
		// Token: 0x0600179D RID: 6045 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x17000606 RID: 1542
		// (get) Token: 0x0600179E RID: 6046 RVA: 0x0005FBBF File Offset: 0x0005DDBF
		protected sealed override float maxEmocionValuePorGrupoMod
		{
			get
			{
				return 0.75f;
			}
		}

		// Token: 0x17000607 RID: 1543
		// (get) Token: 0x0600179F RID: 6047 RVA: 0x0005FBC6 File Offset: 0x0005DDC6
		protected override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.erogeno;
			}
		}

		// Token: 0x17000608 RID: 1544
		// (get) Token: 0x060017A0 RID: 6048 RVA: 0x0005FBDD File Offset: 0x0005DDDD
		protected override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.erogenoEstimulados;
			}
		}

		// Token: 0x17000609 RID: 1545
		// (get) Token: 0x060017A1 RID: 6049 RVA: 0x0005FBF4 File Offset: 0x0005DDF4
		protected override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.placer_Caricias.porCaricias;
			}
		}

		// Token: 0x1700060A RID: 1546
		// (get) Token: 0x060017A2 RID: 6050 RVA: 0x0005F8FF File Offset: 0x0005DAFF
		protected sealed override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.maxEmocionValuePorGrupo.placer;
			}
		}

		// Token: 0x1700060B RID: 1547
		// (get) Token: 0x060017A3 RID: 6051 RVA: 0x00005F51 File Offset: 0x00004151
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
			}
		}

		// Token: 0x060017A4 RID: 6052 RVA: 0x0005F92D File Offset: 0x0005DB2D
		protected sealed override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Placer;
		}

		// Token: 0x060017A5 RID: 6053 RVA: 0x0005FC10 File Offset: 0x0005DE10
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_arousal = this.m_emocionesDeOwner.GetComponentInChildren<Arousal>();
			if (this.m_arousal == null)
			{
				throw new ArgumentNullException("m_arousal", "m_arousal null reference.");
			}
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
		}

		// Token: 0x060017A6 RID: 6054 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloPorDesvestir estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x060017A7 RID: 6055 RVA: 0x0005FC64 File Offset: 0x0005DE64
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, ParteQuePuedeEstimular parteEstimulante, EstimuloPorDesvestir estimulo, ref float maxEmotionValue)
		{
			FloatPorGrupoDicc placerModificacionAlArousalMaximo = this.m_emocionesDeOwner.mapas.maxEmocionValuePorGrupo.placerModificacionAlArousalMaximo;
			if (placerModificacionAlArousalMaximo == null)
			{
				return;
			}
			float valor = placerModificacionAlArousalMaximo[grupoEstimulado].valor;
			maxEmotionValue = Mathf.Lerp(maxEmotionValue, maxEmotionValue * valor, this.m_arousal.value.mod);
		}

		// Token: 0x060017A8 RID: 6056 RVA: 0x0005FCC4 File Offset: 0x0005DEC4
		protected override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloPorDesvestir estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
		{
			EmocionesFemeninasValues emocionesFemeninasValues = this.m_emocionesDeOwner.ObtenerModsFemeninos();
			MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porSiendoVisto = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.placer.porSiendoVisto;
			intervalo = porSiendoVisto.vsArousal.Modificar(intervalo, emocionesFemeninasValues.arousal);
			intervalo = porSiendoVisto.vsPlacer.Modificar(intervalo, emocionesFemeninasValues.humanasValues.placer);
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

		// Token: 0x0400121C RID: 4636
		private Arousal m_arousal;

		// Token: 0x0400121D RID: 4637
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
