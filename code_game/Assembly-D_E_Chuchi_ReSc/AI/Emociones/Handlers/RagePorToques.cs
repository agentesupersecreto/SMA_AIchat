using System;
using System.Runtime.CompilerServices;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000496 RID: 1174
	public sealed class RagePorToques : CalculoDeEstimuloPorTactilesRecibidos
	{
		// Token: 0x1700076D RID: 1901
		// (get) Token: 0x06001BE4 RID: 7140 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool estimuloEsValidoSiEsEstimuloDado
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700076E RID: 1902
		// (get) Token: 0x06001BE5 RID: 7141 RVA: 0x0000D704 File Offset: 0x0000B904
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor;
			}
		}

		// Token: 0x06001BE6 RID: 7142 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x06001BE7 RID: 7143 RVA: 0x00005F51 File Offset: 0x00004151
		protected override UmbralBasico.TipoDeCambio ObtenerTipoDeCambio()
		{
			return UmbralBasico.TipoDeCambio.porSegundo;
		}

		// Token: 0x1700076F RID: 1903
		// (get) Token: 0x06001BE8 RID: 7144 RVA: 0x0006F8A1 File Offset: 0x0006DAA1
		protected sealed override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.rage_Caricias.porCaricias;
			}
		}

		// Token: 0x17000770 RID: 1904
		// (get) Token: 0x06001BE9 RID: 7145 RVA: 0x0006F4DD File Offset: 0x0006D6DD
		protected sealed override PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesEstimulantes.privacidad;
			}
		}

		// Token: 0x17000771 RID: 1905
		// (get) Token: 0x06001BEA RID: 7146 RVA: 0x0006F4F4 File Offset: 0x0006D6F4
		protected sealed override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.privacidad;
			}
		}

		// Token: 0x17000772 RID: 1906
		// (get) Token: 0x06001BEB RID: 7147 RVA: 0x00006060 File Offset: 0x00004260
		protected sealed override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000773 RID: 1907
		// (get) Token: 0x06001BEC RID: 7148 RVA: 0x00006060 File Offset: 0x00004260
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000774 RID: 1908
		// (get) Token: 0x06001BED RID: 7149 RVA: 0x0006F8BD File Offset: 0x0006DABD
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.privacidad.incPorCaricias;
			}
		}

		// Token: 0x17000775 RID: 1909
		// (get) Token: 0x06001BEE RID: 7150 RVA: 0x0005FECA File Offset: 0x0005E0CA
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.privacidadEstimulados;
			}
		}

		// Token: 0x17000776 RID: 1910
		// (get) Token: 0x06001BEF RID: 7151 RVA: 0x0006F527 File Offset: 0x0006D727
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulante
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.privacidadEstimulantes;
			}
		}

		// Token: 0x17000777 RID: 1911
		// (get) Token: 0x06001BF0 RID: 7152 RVA: 0x00006060 File Offset: 0x00004260
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulante_Expancion
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000778 RID: 1912
		// (get) Token: 0x06001BF1 RID: 7153 RVA: 0x0006F8D9 File Offset: 0x0006DAD9
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulante_Incremento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupoEstimulante.privacidad.incPorCaricias;
			}
		}

		// Token: 0x17000779 RID: 1913
		// (get) Token: 0x06001BF2 RID: 7154 RVA: 0x0006F8F5 File Offset: 0x0006DAF5
		protected override float bufferParaGenerarEstimulo
		{
			get
			{
				return this.TiempoDeResistenciaDeHoleAtributos();
			}
		}

		// Token: 0x06001BF3 RID: 7155 RVA: 0x0006F900 File Offset: 0x0006DB00
		private float TiempoDeResistenciaDeHoleAtributos()
		{
			float num = this.m_arousalV2.value.mod + 1f;
			float num2 = MathfExtension.InverseLerpConMedio(0f, 0.3333333f, 1f, this.m_personalidad.optimismo);
			num2 = MathfExtension.LerpConMedio(0f, 1f, 4.8f, num2);
			return num2 * num;
		}

		// Token: 0x06001BF4 RID: 7156 RVA: 0x0006F960 File Offset: 0x0006DB60
		protected override bool EstimuloEsValidoV2(ParteQuePuedeEstimular estimulanteParte, [TupleElementNames(new string[] { "original", null, "invertido", "estimulanteInvertido" })] ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> par)
		{
			return base.EstimuloEsValidoV2(estimulanteParte, par);
		}

		// Token: 0x06001BF5 RID: 7157 RVA: 0x0005FEE1 File Offset: 0x0005E0E1
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Rage;
		}

		// Token: 0x06001BF6 RID: 7158 RVA: 0x0006F96C File Offset: 0x0006DB6C
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

		// Token: 0x06001BF7 RID: 7159 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloTactil estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001BF8 RID: 7160 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, GrupoQueCompartenValores estimulante, ParteQuePuedeEstimular parteEstimulante, EstimuloTactil estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x06001BF9 RID: 7161 RVA: 0x0006FA70 File Offset: 0x0006DC70
		protected sealed override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloTactil estimulo, ref float cambioSuavizado, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues? emocionesValoresMods)
		{
			emocionesValoresMods = new EmocionesFemeninasValues?(emocionesValoresMods ?? this.m_emocionesDeOwner.ObtenerModsFemeninos());
			ModifcadorDeIntervalo cambioVsArousal = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.rage.porCaricias.cambioVsArousal;
			intervalo = cambioVsArousal.Modificar(intervalo, emocionesValoresMods.Value.arousal);
			float num;
			if (parteEstimulante == ParteQuePuedeEstimular.semen)
			{
				if (estimulo is EstimuloTactilDeSemen)
				{
					EstimuloTactilDeSemen estimuloTactilDeSemen = (EstimuloTactilDeSemen)estimulo;
					switch (estimuloTactilDeSemen.tipoDeSemen)
					{
					case TipoDeSemen.semen:
						num = 1f;
						estimulacionGenerada.moded *= 10f;
						break;
					case TipoDeSemen.water:
						num = 0.1f;
						estimulacionGenerada.moded *= 0.1f;
						break;
					case TipoDeSemen.lubricante:
						num = 0.5f;
						estimulacionGenerada.moded *= 0.5f;
						break;
					case TipoDeSemen.orine:
						num = 0.75f;
						estimulacionGenerada.moded *= 5f;
						break;
					default:
						throw new ArgumentOutOfRangeException(estimuloTactilDeSemen.tipoDeSemen.ToString());
					}
				}
				else
				{
					num = 1f;
					estimulacionGenerada.moded *= 10f;
				}
			}
			else
			{
				num = 1f;
			}
			float num2;
			float num3;
			if (this.m_ConcentNecesario.EsConsentidoConJerarquia(TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, estimulo.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana), parteEstimulante, out num2, out num3, num, emocionesValoresMods, null, null))
			{
				estimulacionGenerada.moded = 0f;
				return;
			}
			float num4 = emocionesValoresMods.Value.consentToHero * 100f;
			float num5 = Mathf.Abs(num3 - num4);
			float num6 = Mathf.InverseLerp(0f, 10f, num5).OutPow(3f);
			estimulacionGenerada.moded *= num6;
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

		// Token: 0x06001BFA RID: 7162 RVA: 0x0006FCCC File Offset: 0x0006DECC
		protected override bool MaximoAlcanzado(CalculoDeEstimuloPorCariciasResultado data, float valorDeEmovionActual, out float maxEmoValueDeGrupo)
		{
			if (base.MaximoAlcanzado(data, valorDeEmovionActual, out maxEmoValueDeGrupo))
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

		// Token: 0x040013B5 RID: 5045
		private Personalidad m_personalidad;

		// Token: 0x040013B6 RID: 5046
		private ConsentToHero m_ConcentToHeroV2;

		// Token: 0x040013B7 RID: 5047
		private Arousal m_arousalV2;

		// Token: 0x040013B8 RID: 5048
		private ConsentNecesario m_ConcentNecesario;

		// Token: 0x040013B9 RID: 5049
		private ConsentCorrupted m_ConsentForzado;

		// Token: 0x040013BA RID: 5050
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
