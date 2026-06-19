using System;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers
{
	// Token: 0x020001F0 RID: 496
	public class PlacerPorManipulacionDeBones : CalculoDeEmocionesPorManipulacionDeBones
	{
		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06000C0B RID: 3083 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
			}
		}

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06000C0C RID: 3084 RVA: 0x000392B6 File Offset: 0x000374B6
		protected override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.erogeno;
			}
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06000C0D RID: 3085 RVA: 0x000392CD File Offset: 0x000374CD
		protected override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.erogenoEstimulados;
			}
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000C0E RID: 3086 RVA: 0x000392E4 File Offset: 0x000374E4
		protected override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.placer_Caricias.porCaricias;
			}
		}

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000C0F RID: 3087 RVA: 0x00039300 File Offset: 0x00037500
		protected override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.maxEmocionValuePorGrupo.placer;
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000C10 RID: 3088 RVA: 0x000392AF File Offset: 0x000374AF
		protected override float maxEmocionValuePorGrupoMod
		{
			get
			{
				return 0.75f;
			}
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x00039850 File Offset: 0x00037A50
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

		// Token: 0x06000C12 RID: 3090 RVA: 0x0003936B File Offset: 0x0003756B
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Placer;
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x000380AB File Offset: 0x000362AB
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x06000C14 RID: 3092 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloPorManipulacionDeBone estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x000398A4 File Offset: 0x00037AA4
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, ParteQuePuedeEstimular parteEstimulante, EstimuloPorManipulacionDeBone estimulo, ref float maxEmotionValue)
		{
			FloatPorGrupoDicc placerModificacionAlArousalMaximo = this.m_emocionesDeOwner.mapas.maxEmocionValuePorGrupo.placerModificacionAlArousalMaximo;
			if (placerModificacionAlArousalMaximo == null)
			{
				return;
			}
			float valor = placerModificacionAlArousalMaximo[grupoEstimulado].valor;
			maxEmotionValue = Mathf.Lerp(maxEmotionValue, maxEmotionValue * valor, this.m_arousalV2.value.mod);
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x00039904 File Offset: 0x00037B04
		protected override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloPorManipulacionDeBone estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
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

		// Token: 0x040008BA RID: 2234
		private Arousal m_arousalV2;

		// Token: 0x040008BB RID: 2235
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
