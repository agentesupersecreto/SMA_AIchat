using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos
{
	// Token: 0x0200051F RID: 1311
	public sealed class RagePorVerPartesMasculinas : CalculoDeEstimuloPorVerPartesMasculinas<CalculoDeEstimuloVisualResultado>
	{
		// Token: 0x17000881 RID: 2177
		// (get) Token: 0x06001FDD RID: 8157 RVA: 0x0000D704 File Offset: 0x0000B904
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor;
			}
		}

		// Token: 0x06001FDE RID: 8158 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x17000882 RID: 2178
		// (get) Token: 0x06001FDF RID: 8159 RVA: 0x00030684 File Offset: 0x0002E884
		protected sealed override float maxEmocionValuePorGrupoMod
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x17000883 RID: 2179
		// (get) Token: 0x06001FE0 RID: 8160 RVA: 0x0007876E File Offset: 0x0007696E
		protected override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.rage_Vision.mirando;
			}
		}

		// Token: 0x17000884 RID: 2180
		// (get) Token: 0x06001FE1 RID: 8161 RVA: 0x0005FEB3 File Offset: 0x0005E0B3
		protected override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.privacidadVisual;
			}
		}

		// Token: 0x17000885 RID: 2181
		// (get) Token: 0x06001FE2 RID: 8162 RVA: 0x00006060 File Offset: 0x00004260
		protected override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000886 RID: 2182
		// (get) Token: 0x06001FE3 RID: 8163 RVA: 0x0005FECA File Offset: 0x0005E0CA
		protected override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.privacidadEstimulados;
			}
		}

		// Token: 0x06001FE4 RID: 8164 RVA: 0x0005FEE1 File Offset: 0x0005E0E1
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Rage;
		}

		// Token: 0x06001FE5 RID: 8165 RVA: 0x0007878C File Offset: 0x0007698C
		protected override void AwakeUnityEvent()
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
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentCorrupted", "m_ConsentCorrupted null reference.");
			}
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
		}

		// Token: 0x06001FE6 RID: 8166 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPostUmbralCalculo(EstimuloVisual estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001FE7 RID: 8167 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, EstimuloVisual estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x06001FE8 RID: 8168 RVA: 0x00078864 File Offset: 0x00076A64
		protected override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloVisual estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues? emocionesValoresMods)
		{
			emocionesValoresMods = new EmocionesFemeninasValues?(emocionesValoresMods ?? this.m_emocionesDeOwner.ObtenerModsFemeninos());
			float num;
			float num2;
			if (this.m_ConcentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.visual, DireccionDeEstimulo.dada, parteEstimulada, parteEstimulante, out num, out num2, 1f, emocionesValoresMods, null, null))
			{
				estimulacionGenerada.moded = 0f;
				return;
			}
			float num3 = emocionesValoresMods.Value.consentToHero * 100f;
			float num4 = Mathf.Abs(num2 - num3);
			float num5 = Mathf.InverseLerp(0f, 20f, num4).OutPow(2f);
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

		// Token: 0x06001FE9 RID: 8169 RVA: 0x00078989 File Offset: 0x00076B89
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

		// Token: 0x040014FF RID: 5375
		private ConsentToHero m_ConcentToHeroV2;

		// Token: 0x04001500 RID: 5376
		private Arousal m_arousalV2;

		// Token: 0x04001501 RID: 5377
		private ConsentNecesario m_ConcentNecesario;

		// Token: 0x04001502 RID: 5378
		private ConsentCorrupted m_ConsentForzado;

		// Token: 0x04001503 RID: 5379
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
