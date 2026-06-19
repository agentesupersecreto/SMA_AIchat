using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000493 RID: 1171
	public sealed class PlacerPorToques : CalculoDeEstimuloPorTactilesRecibidos
	{
		// Token: 0x17000747 RID: 1863
		// (get) Token: 0x06001B9F RID: 7071 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool estimuloEsValidoSiEsEstimuloDado
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000748 RID: 1864
		// (get) Token: 0x06001BA0 RID: 7072 RVA: 0x00005F51 File Offset: 0x00004151
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
			}
		}

		// Token: 0x06001BA1 RID: 7073 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x06001BA2 RID: 7074 RVA: 0x00005F51 File Offset: 0x00004151
		protected override UmbralBasico.TipoDeCambio ObtenerTipoDeCambio()
		{
			return UmbralBasico.TipoDeCambio.porSegundo;
		}

		// Token: 0x17000749 RID: 1865
		// (get) Token: 0x06001BA3 RID: 7075 RVA: 0x0005FBC6 File Offset: 0x0005DDC6
		protected sealed override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.erogeno;
			}
		}

		// Token: 0x1700074A RID: 1866
		// (get) Token: 0x06001BA4 RID: 7076 RVA: 0x0006E079 File Offset: 0x0006C279
		protected sealed override PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesEstimulantes.erogeno;
			}
		}

		// Token: 0x1700074B RID: 1867
		// (get) Token: 0x06001BA5 RID: 7077 RVA: 0x0005FBF4 File Offset: 0x0005DDF4
		protected sealed override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.placer_Caricias.porCaricias;
			}
		}

		// Token: 0x1700074C RID: 1868
		// (get) Token: 0x06001BA6 RID: 7078 RVA: 0x0005F8FF File Offset: 0x0005DAFF
		protected sealed override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.maxEmocionValuePorGrupo.placer;
			}
		}

		// Token: 0x1700074D RID: 1869
		// (get) Token: 0x06001BA7 RID: 7079 RVA: 0x0006E090 File Offset: 0x0006C290
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulante
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.erogenoEstimulantes;
			}
		}

		// Token: 0x1700074E RID: 1870
		// (get) Token: 0x06001BA8 RID: 7080 RVA: 0x0005FBDD File Offset: 0x0005DDDD
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.erogenoEstimulados;
			}
		}

		// Token: 0x1700074F RID: 1871
		// (get) Token: 0x06001BA9 RID: 7081 RVA: 0x0006ED8B File Offset: 0x0006CF8B
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.erogeno.porCaricias.incremento;
			}
		}

		// Token: 0x17000750 RID: 1872
		// (get) Token: 0x06001BAA RID: 7082 RVA: 0x0006EDAC File Offset: 0x0006CFAC
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.erogeno.porCaricias.expancion;
			}
		}

		// Token: 0x17000751 RID: 1873
		// (get) Token: 0x06001BAB RID: 7083 RVA: 0x0006EDCD File Offset: 0x0006CFCD
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulante_Incremento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupoEstimulante.erogeno.porCaricias.incremento;
			}
		}

		// Token: 0x17000752 RID: 1874
		// (get) Token: 0x06001BAC RID: 7084 RVA: 0x0006EDEE File Offset: 0x0006CFEE
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulante_Expancion
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupoEstimulante.erogeno.porCaricias.expancion;
			}
		}

		// Token: 0x17000753 RID: 1875
		// (get) Token: 0x06001BAD RID: 7085 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float bufferParaGenerarEstimulo
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x06001BAE RID: 7086 RVA: 0x0005F92D File Offset: 0x0005DB2D
		protected sealed override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Placer;
		}

		// Token: 0x06001BAF RID: 7087 RVA: 0x0006EE10 File Offset: 0x0006D010
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_arousalV2 = this.m_emocionesDeOwner.GetComponentInChildren<Arousal>();
			if (this.m_arousalV2 == null)
			{
				throw new ArgumentNullException("m_arousal", "m_arousal null reference.");
			}
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
		}

		// Token: 0x06001BB0 RID: 7088 RVA: 0x0006EE8E File Offset: 0x0006D08E
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_emocionesDeOwner.GetComponentsInChildren<IModDeInterDeGenTactil>(this.m_modificadoresDeIntervaloVel);
		}

		// Token: 0x06001BB1 RID: 7089 RVA: 0x0006EEA7 File Offset: 0x0006D0A7
		protected override bool EstimuloEsValidoV2(ParteQuePuedeEstimular estimulanteParte, [TupleElementNames(new string[] { "original", null, "invertido", "estimulanteInvertido" })] ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> par)
		{
			return base.EstimuloEsValidoV2(estimulanteParte, par) && par.Item1.PartePrincipalEstimulada(this.contextoDePrioridadDeParteHumana) != ParteDelCuerpoHumano.globosOculares;
		}

		// Token: 0x06001BB2 RID: 7090 RVA: 0x0006EED0 File Offset: 0x0006D0D0
		protected override void AlterarDataGenerada(CalculoDeEstimuloPorCariciasResultado data)
		{
			base.AlterarDataGenerada(data);
			if (data.data.estimulanteParte == ParteQuePuedeEstimular.semen)
			{
				data.data.estado.SetEstimulacionGeneradaEnFrame(Mathf.Clamp(data.data.estado.estimulacionGeneradaEnFrame, 0.01f, 100f));
				data.data.estado.SetEstimulacionGeneradaTotal(Mathf.Clamp(data.data.estado.estimulacionGeneradaTotal, 0.01f, 100f));
			}
		}

		// Token: 0x06001BB3 RID: 7091 RVA: 0x0006EF54 File Offset: 0x0006D154
		protected sealed override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloTactil estimulo, ref float cambioSuavizado, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues? emocionesValoresMods)
		{
			if (!this.aplicarModsDeIntercalosVsEmocion)
			{
				return;
			}
			emocionesValoresMods = new EmocionesFemeninasValues?(emocionesValoresMods ?? this.m_emocionesDeOwner.ObtenerModsFemeninos());
			MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porCaricias = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.placer.porCaricias;
			intervalo = porCaricias.vsArousal.Modificar(intervalo, emocionesValoresMods.Value.arousal);
			intervalo = porCaricias.vsPlacer.Modificar(intervalo, emocionesValoresMods.Value.humanasValues.placer);
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
			for (int i = 0; i < this.m_modificadoresDeIntervaloVel.Count; i++)
			{
				this.m_modificadoresDeIntervaloVel[i].Max(this.m_Emo.reaccion, parteEstimulada, parteEstimulante, ref intervalo);
			}
			if (parteEstimulante == ParteQuePuedeEstimular.semen)
			{
				intervalo.Expandir(1000f, 0.0001f);
			}
			if (estimulo.ContineParte(ParteDelCuerpoHumano.clitoris))
			{
				intervalo.Increase(0.333f, 0.0001f);
				intervalo.Expandir(1.75f, 0.0001f);
				estimulacionGenerada.percentModed += 100f;
			}
		}

		// Token: 0x06001BB4 RID: 7092 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloTactil estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001BB5 RID: 7093 RVA: 0x0006F1EC File Offset: 0x0006D3EC
		protected sealed override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, GrupoQueCompartenValores estimulante, ParteQuePuedeEstimular parteEstimulante, EstimuloTactil estimulo, ref float maxEmotionValue)
		{
			FloatPorGrupoDicc placerModificacionAlArousalMaximo = this.m_emocionesDeOwner.mapas.maxEmocionValuePorGrupo.placerModificacionAlArousalMaximo;
			if (placerModificacionAlArousalMaximo == null)
			{
				return;
			}
			float valor = placerModificacionAlArousalMaximo[grupoEstimulado].valor;
			maxEmotionValue = Mathf.Lerp(maxEmotionValue, maxEmotionValue * valor, this.m_arousalV2.value.mod);
		}

		// Token: 0x040013A7 RID: 5031
		public bool aplicarModsDeIntercalosVsEmocion = true;

		// Token: 0x040013A8 RID: 5032
		private Personalidad m_personalidad;

		// Token: 0x040013A9 RID: 5033
		private Arousal m_arousalV2;

		// Token: 0x040013AA RID: 5034
		private List<IModDeInterDeGenTactil> m_modificadoresDeIntervaloVel = new List<IModDeInterDeGenTactil>();

		// Token: 0x040013AB RID: 5035
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
