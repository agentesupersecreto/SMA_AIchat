using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000495 RID: 1173
	public sealed class RagePorPenetracion : CalculoDeEstimuloPorPenetracionRecibida
	{
		// Token: 0x17000763 RID: 1891
		// (get) Token: 0x06001BD1 RID: 7121 RVA: 0x0000D704 File Offset: 0x0000B904
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor;
			}
		}

		// Token: 0x17000764 RID: 1892
		// (get) Token: 0x06001BD2 RID: 7122 RVA: 0x0006F4C1 File Offset: 0x0006D6C1
		protected override DatosDeUmbral datosDeUmbralPenetracion
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.rage_Penetracion.porPenetracion;
			}
		}

		// Token: 0x17000765 RID: 1893
		// (get) Token: 0x06001BD3 RID: 7123 RVA: 0x0006F4DD File Offset: 0x0006D6DD
		protected override PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesEstimulantes.privacidad;
			}
		}

		// Token: 0x17000766 RID: 1894
		// (get) Token: 0x06001BD4 RID: 7124 RVA: 0x0006F4F4 File Offset: 0x0006D6F4
		protected override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.privacidad;
			}
		}

		// Token: 0x17000767 RID: 1895
		// (get) Token: 0x06001BD5 RID: 7125 RVA: 0x00006060 File Offset: 0x00004260
		protected override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000768 RID: 1896
		// (get) Token: 0x06001BD6 RID: 7126 RVA: 0x00006060 File Offset: 0x00004260
		protected override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion_Velocidad
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000769 RID: 1897
		// (get) Token: 0x06001BD7 RID: 7127 RVA: 0x0006F50B File Offset: 0x0006D70B
		protected override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento_Velocidad
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.privacidad.incPorPenetracion;
			}
		}

		// Token: 0x1700076A RID: 1898
		// (get) Token: 0x06001BD8 RID: 7128 RVA: 0x0005FECA File Offset: 0x0005E0CA
		protected override FloatPorGrupoDicc parteEstimulada_EmocionGeneradaModPorGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.privacidadEstimulados;
			}
		}

		// Token: 0x1700076B RID: 1899
		// (get) Token: 0x06001BD9 RID: 7129 RVA: 0x0006F527 File Offset: 0x0006D727
		protected override FloatPorGrupoDicc parteEstimulante_EmocionGeneradaModPorGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.privacidadEstimulantes;
			}
		}

		// Token: 0x1700076C RID: 1900
		// (get) Token: 0x06001BDA RID: 7130 RVA: 0x0006F53E File Offset: 0x0006D73E
		protected override float bufferParaGenerarEstimuloPorPenetracion
		{
			get
			{
				return this.TiempoDeResistenciaDeHoleAtributos();
			}
		}

		// Token: 0x06001BDB RID: 7131 RVA: 0x0006F548 File Offset: 0x0006D748
		private float TiempoDeResistenciaDeHoleAtributos()
		{
			float num = this.m_arousalV2.value.mod + 1f;
			float num2 = MathfExtension.InverseLerpConMedio(0f, 0.3333333f, 1f, this.m_personalidad.optimismo);
			num2 = MathfExtension.LerpConMedio(0f, 1f, 4.8f, num2);
			return num2 * num;
		}

		// Token: 0x06001BDC RID: 7132 RVA: 0x0005FEE1 File Offset: 0x0005E0E1
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Rage;
		}

		// Token: 0x06001BDD RID: 7133 RVA: 0x0006F5A8 File Offset: 0x0006D7A8
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

		// Token: 0x06001BDE RID: 7134 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnPostUmbralCalculoPenetracion(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001BDF RID: 7135 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, GrupoQueCompartenValores estimulante, EstimuloPenetrante estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x06001BE0 RID: 7136 RVA: 0x0006F6AC File Offset: 0x0006D8AC
		protected sealed override void OnPreUmbralCalculoPenetracion(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambioSuavizado, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			if (!emocionesValoresMods.loaded)
			{
				emocionesValoresMods = this.m_emocionesDeOwner.ObtenerModsFemeninos();
			}
			ModifcadorDeIntervalo cambioVsArousal = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.rage.porPenetracion.cambioVsArousal;
			intervalo = cambioVsArousal.Modificar(intervalo, emocionesValoresMods.arousal);
			ParteDelCuerpoHumano parteDelCuerpoHumano = penetracion.estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana);
			if (parteDelCuerpoHumano != ParteDelCuerpoHumano.bocaInterno && parteDelCuerpoHumano - ParteDelCuerpoHumano.ano > 1)
			{
				throw new NotSupportedException("penetracion es de tipo " + parteDelCuerpoHumano.ToString() + " la cual no es soportada");
			}
			float num;
			float num2;
			if (this.m_ConcentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, parteDelCuerpoHumano, penetracion.estimulanteParte, out num, out num2, 1f, new EmocionesFemeninasValues?(emocionesValoresMods), null, null))
			{
				estimulacionGenerada.moded = 0f;
				return;
			}
			float num3 = emocionesValoresMods.consentToHero * 100f;
			float num4 = Mathf.Abs(num2 - num3);
			float num5 = Mathf.InverseLerp(0f, 5f, num4).OutPow(3f);
			estimulacionGenerada.moded *= num5;
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesMix modificador = this.m_modificablesDeInteraccio.GetModificador(penetracion.estimulo, parteDelCuerpoHumano, penetracion.estimulanteParte, false, null);
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

		// Token: 0x06001BE1 RID: 7137 RVA: 0x0006F848 File Offset: 0x0006DA48
		protected override bool MaximoAlcanzado(CalculoDeEstimuloPorPenetracionHoleResultado data, GrupoQueCompartenValores grupoDeParte, GrupoQueCompartenValores grupoDeParteEstimulante, EstimuloPenetrante estimulo, float valorDeEmovionActual, out float maxEmoValueDeGrupo)
		{
			if (base.MaximoAlcanzado(data, grupoDeParte, grupoDeParteEstimulante, estimulo, valorDeEmovionActual, out maxEmoValueDeGrupo))
			{
				return true;
			}
			if (this.m_ConsentForzado.EsCorrupted(data.estimulo, data.data.estimulanteParte, data.data.tag))
			{
				maxEmoValueDeGrupo = valorDeEmovionActual;
				return true;
			}
			return false;
		}

		// Token: 0x06001BE2 RID: 7138 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x040013AF RID: 5039
		private Personalidad m_personalidad;

		// Token: 0x040013B0 RID: 5040
		private ConsentToHero m_ConcentToHeroV2;

		// Token: 0x040013B1 RID: 5041
		private Arousal m_arousalV2;

		// Token: 0x040013B2 RID: 5042
		private ConsentNecesario m_ConcentNecesario;

		// Token: 0x040013B3 RID: 5043
		private ConsentCorrupted m_ConsentForzado;

		// Token: 0x040013B4 RID: 5044
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
