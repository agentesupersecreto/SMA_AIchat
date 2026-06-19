using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x0200051E RID: 1310
	public sealed class RagePorSerVistoPorMain : CalculoDeEmocionesPorSerVisto
	{
		// Token: 0x17000878 RID: 2168
		// (get) Token: 0x06001FCA RID: 8138 RVA: 0x0000D704 File Offset: 0x0000B904
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor;
			}
		}

		// Token: 0x06001FCB RID: 8139 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x17000879 RID: 2169
		// (get) Token: 0x06001FCC RID: 8140 RVA: 0x00030684 File Offset: 0x0002E884
		protected sealed override float maxEmocionValuePorGrupoMod
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x1700087A RID: 2170
		// (get) Token: 0x06001FCD RID: 8141 RVA: 0x00078428 File Offset: 0x00076628
		protected sealed override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.rage_Vision.siendoMirado;
			}
		}

		// Token: 0x1700087B RID: 2171
		// (get) Token: 0x06001FCE RID: 8142 RVA: 0x0005FEB3 File Offset: 0x0005E0B3
		protected sealed override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.privacidadVisual;
			}
		}

		// Token: 0x1700087C RID: 2172
		// (get) Token: 0x06001FCF RID: 8143 RVA: 0x0006F4DD File Offset: 0x0006D6DD
		protected sealed override PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesEstimulantes.privacidad;
			}
		}

		// Token: 0x1700087D RID: 2173
		// (get) Token: 0x06001FD0 RID: 8144 RVA: 0x00006060 File Offset: 0x00004260
		protected sealed override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700087E RID: 2174
		// (get) Token: 0x06001FD1 RID: 8145 RVA: 0x0005FECA File Offset: 0x0005E0CA
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.privacidadEstimulados;
			}
		}

		// Token: 0x1700087F RID: 2175
		// (get) Token: 0x06001FD2 RID: 8146 RVA: 0x00078444 File Offset: 0x00076644
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulante
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.privacidadVisualEstimulantes;
			}
		}

		// Token: 0x06001FD3 RID: 8147 RVA: 0x00077E7E File Offset: 0x0007607E
		protected sealed override void ResetUnityEvent()
		{
			base.ResetUnityEvent();
			this.baseConfiguracion.cambiarValorDeEmocionDespuesDeTiempo = 1.5f;
		}

		// Token: 0x17000880 RID: 2176
		// (get) Token: 0x06001FD4 RID: 8148 RVA: 0x0007845B File Offset: 0x0007665B
		protected override float bufferParaGenerarEstimulo
		{
			get
			{
				return this.TiempoDeResistenciaDeHoleAtributos();
			}
		}

		// Token: 0x06001FD5 RID: 8149 RVA: 0x00078464 File Offset: 0x00076664
		private float TiempoDeResistenciaDeHoleAtributos()
		{
			float num = this.m_arousalV2.value.mod + 1f;
			float num2 = MathfExtension.InverseLerpConMedio(0f, 0.3333333f, 1f, this.m_personalidad.optimismo);
			num2 = MathfExtension.LerpConMedio(0f, 1f, 4.8f, num2);
			return num2 * num;
		}

		// Token: 0x06001FD6 RID: 8150 RVA: 0x0005FEE1 File Offset: 0x0005E0E1
		protected sealed override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Rage;
		}

		// Token: 0x06001FD7 RID: 8151 RVA: 0x000784C4 File Offset: 0x000766C4
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConcentToHeroV2 = this.m_emocionesDeOwner.GetComponentInChildren<ConsentToHero>();
			if (this.m_ConcentToHeroV2 == null)
			{
				throw new ArgumentNullException("m_ConcentToHero", "m_ConcentToHero null reference.");
			}
			this.m_arousalV2 = this.m_emocionesDeOwner.GetComponentInChildren<Arousal>();
			if (this.m_arousalV2 == null)
			{
				throw new ArgumentNullException("m_arousal", "m_arousal null reference.");
			}
			this.m_ConcentNecesario = this.GetComponentEnRoot(false);
			if (this.m_ConcentNecesario == null)
			{
				throw new ArgumentNullException("m_ConcentNecesario", "m_ConcentNecesario null reference.");
			}
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentCorrupted", "m_ConsentCorrupted null reference.");
			}
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
		}

		// Token: 0x06001FD8 RID: 8152 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloVisual estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001FD9 RID: 8153 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, GrupoQueCompartenValores estimulante, ParteQuePuedeEstimular parteEstimulante, EstimuloVisual estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x06001FDA RID: 8154 RVA: 0x000785C8 File Offset: 0x000767C8
		protected sealed override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloVisual estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues? emocionesValoresMods)
		{
			emocionesValoresMods = new EmocionesFemeninasValues?(emocionesValoresMods ?? this.m_emocionesDeOwner.ObtenerModsFemeninos());
			ModifcadorDeIntervalo cambioVsArousal = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.rage.porSiendoVisto.cambioVsArousal;
			intervalo = cambioVsArousal.Modificar(intervalo, emocionesValoresMods.Value.arousal);
			float num;
			float num2;
			if (this.m_ConcentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana), parteEstimulante, out num, out num2, 1f, emocionesValoresMods, null, null))
			{
				estimulacionGenerada.moded = 0f;
				return;
			}
			float num3 = emocionesValoresMods.Value.consentToHero * 100f;
			float num4 = Mathf.Abs(num2 - num3);
			float num5 = Mathf.InverseLerp(0f, 15f, num4).OutPow(2f);
			estimulacionGenerada.moded *= num5;
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesMix modificador = this.m_modificablesDeInteraccio.GetModificador(estimulo, parteEstimulada, parteEstimulante, false, null);
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

		// Token: 0x06001FDB RID: 8155 RVA: 0x0007873A File Offset: 0x0007693A
		protected override bool MaximoAlcanzado(CalculoDeEstimuloVisualResultado data, float valorDeEmovionActual, out float maxEmoValueDeGrupo)
		{
			if (base.MaximoAlcanzado(data, valorDeEmovionActual, out maxEmoValueDeGrupo))
			{
				return true;
			}
			if (this.m_ConsentForzado.EsCorrupted(data.estimuloBasico, data.estimulanteParte, data.tag))
			{
				maxEmoValueDeGrupo = valorDeEmovionActual;
				return true;
			}
			return false;
		}

		// Token: 0x040014F9 RID: 5369
		private Personalidad m_personalidad;

		// Token: 0x040014FA RID: 5370
		private ConsentToHero m_ConcentToHeroV2;

		// Token: 0x040014FB RID: 5371
		private Arousal m_arousalV2;

		// Token: 0x040014FC RID: 5372
		private ConsentNecesario m_ConcentNecesario;

		// Token: 0x040014FD RID: 5373
		private ConsentCorrupted m_ConsentForzado;

		// Token: 0x040014FE RID: 5374
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
