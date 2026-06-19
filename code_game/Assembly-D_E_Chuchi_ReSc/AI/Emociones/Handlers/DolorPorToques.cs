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
	// Token: 0x02000491 RID: 1169
	public sealed class DolorPorToques : CalculoDeEstimuloPorTactilesRecibidos
	{
		// Token: 0x1700071A RID: 1818
		// (get) Token: 0x06001B54 RID: 6996 RVA: 0x00005F51 File Offset: 0x00004151
		protected override bool estimuloEsValidoSiEsEstimuloDado
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700071B RID: 1819
		// (get) Token: 0x06001B55 RID: 6997 RVA: 0x00006318 File Offset: 0x00004518
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor;
			}
		}

		// Token: 0x06001B56 RID: 6998 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x06001B57 RID: 6999 RVA: 0x00005F51 File Offset: 0x00004151
		protected override UmbralBasico.TipoDeCambio ObtenerTipoDeCambio()
		{
			return UmbralBasico.TipoDeCambio.porSegundo;
		}

		// Token: 0x1700071C RID: 1820
		// (get) Token: 0x06001B58 RID: 7000 RVA: 0x0006DB06 File Offset: 0x0006BD06
		protected sealed override DatosDeUmbral datosDeUmbral
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.dolor_Caricias.porCaricias;
			}
		}

		// Token: 0x1700071D RID: 1821
		// (get) Token: 0x06001B59 RID: 7001 RVA: 0x0006C612 File Offset: 0x0006A812
		protected sealed override PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesEstimulantes.seinsibilidad;
			}
		}

		// Token: 0x1700071E RID: 1822
		// (get) Token: 0x06001B5A RID: 7002 RVA: 0x0006C629 File Offset: 0x0006A829
		protected sealed override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.seinsibilidad;
			}
		}

		// Token: 0x1700071F RID: 1823
		// (get) Token: 0x06001B5B RID: 7003 RVA: 0x00006060 File Offset: 0x00004260
		protected sealed override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000720 RID: 1824
		// (get) Token: 0x06001B5C RID: 7004 RVA: 0x0006C640 File Offset: 0x0006A840
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulada
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.seinsibilidadEstimulados;
			}
		}

		// Token: 0x17000721 RID: 1825
		// (get) Token: 0x06001B5D RID: 7005 RVA: 0x0006CC44 File Offset: 0x0006AE44
		protected sealed override FloatPorGrupoDicc modEstimuloGeneradoPorGrupoDeParteEstimulante
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.seinsibilidadEstimulantes;
			}
		}

		// Token: 0x17000722 RID: 1826
		// (get) Token: 0x06001B5E RID: 7006 RVA: 0x0006C657 File Offset: 0x0006A857
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.sensibilidad.porCaricias.expancion;
			}
		}

		// Token: 0x17000723 RID: 1827
		// (get) Token: 0x06001B5F RID: 7007 RVA: 0x0006C678 File Offset: 0x0006A878
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.sensibilidad.porCaricias.incremento;
			}
		}

		// Token: 0x17000724 RID: 1828
		// (get) Token: 0x06001B60 RID: 7008 RVA: 0x0006C699 File Offset: 0x0006A899
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulante_Expancion
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupoEstimulante.sensibilidad.porCaricias.expancion;
			}
		}

		// Token: 0x17000725 RID: 1829
		// (get) Token: 0x06001B61 RID: 7009 RVA: 0x0006C6BA File Offset: 0x0006A8BA
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulante_Incremento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupoEstimulante.sensibilidad.porCaricias.incremento;
			}
		}

		// Token: 0x17000726 RID: 1830
		// (get) Token: 0x06001B62 RID: 7010 RVA: 0x0006DB22 File Offset: 0x0006BD22
		protected override float bufferParaGenerarEstimulo
		{
			get
			{
				return this.TiempoDeResistenciaDeHoleAtributos();
			}
		}

		// Token: 0x06001B63 RID: 7011 RVA: 0x0006DB2C File Offset: 0x0006BD2C
		private float TiempoDeResistenciaDeHoleAtributos()
		{
			float num = this.m_arousalV2.value.mod + 1f;
			float num2 = MathfExtension.InverseLerpConMedio(0f, 0.3333333f, 1f, this.m_personalidad.optimismo);
			num2 = MathfExtension.LerpConMedio(0f, 1f, 4.8f, num2);
			return num2 * num;
		}

		// Token: 0x06001B64 RID: 7012 RVA: 0x0006C6E6 File Offset: 0x0006A8E6
		protected override bool EstimuloEsValidoV2(ParteQuePuedeEstimular estimulanteParte, [TupleElementNames(new string[] { "original", null, "invertido", "estimulanteInvertido" })] ValueTuple<EstimuloTactil, ValueTuple<EstimuloTactil, int>> par)
		{
			return base.EstimuloEsValidoV2(estimulanteParte, par) && (estimulanteParte != ParteQuePuedeEstimular.semen || par.Item1.ContineParte(ParteDelCuerpoHumano.globosOculares));
		}

		// Token: 0x06001B65 RID: 7013 RVA: 0x0006C6DB File Offset: 0x0006A8DB
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Dolor;
		}

		// Token: 0x06001B66 RID: 7014 RVA: 0x0006DB8C File Offset: 0x0006BD8C
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
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
		}

		// Token: 0x06001B67 RID: 7015 RVA: 0x0006DC39 File Offset: 0x0006BE39
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_emocionesDeOwner.GetComponentsInChildren<IModDeInterDeGenTactil>(this.m_modificadoresDeIntervaloVel);
		}

		// Token: 0x06001B68 RID: 7016 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnPostUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, EstimuloTactil estimulo, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001B69 RID: 7017 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, GrupoQueCompartenValores estimulante, ParteQuePuedeEstimular parteEstimulante, EstimuloTactil estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x06001B6A RID: 7018 RVA: 0x0006DC52 File Offset: 0x0006BE52
		protected sealed override void OnPreUmbralCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, EstimuloTactil estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues? emocionesValoresMods)
		{
			this.ModificarUmbralesDeCalculo(parteEstimulante, parteEstimulada, estimulo, ref cambio, ref intervalo, ref estimulacionGenerada, ref emocionesValoresMods);
		}

		// Token: 0x06001B6B RID: 7019 RVA: 0x0006DC68 File Offset: 0x0006BE68
		public void ModificarUmbralesDeCalculo(ParteQuePuedeEstimular parteEstimulante, ParteDelCuerpoHumano parteEstimulada, InteracionEstimulanteBasica estimulo, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues? emocionesValoresMods)
		{
			emocionesValoresMods = new EmocionesFemeninasValues?(emocionesValoresMods ?? this.m_emocionesDeOwner.ObtenerModsFemeninos());
			if (estimulo.ContineParte(ParteDelCuerpoHumano.globosOculares))
			{
				intervalo.Expandir(15f, 0.0001f);
				estimulacionGenerada.moded = 3f;
				return;
			}
			MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porCaricias = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.dolor.porCaricias;
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
				this.m_modificadoresDeIntervaloVel[i].StackIfGreater(this.m_Emo.reaccion, parteEstimulada, parteEstimulante, ref intervalo);
			}
			if (estimulo.ContineParte(ParteDelCuerpoHumano.clitoris))
			{
				intervalo.Increase(0.45f, 0.0001f);
				estimulacionGenerada.percentModed += 100f;
			}
			if (estimulo.tipo == DireccionDeEstimulo.dada)
			{
				intervalo.Increase(3f, 0.0001f);
				estimulacionGenerada.percentModed += -99f;
			}
		}

		// Token: 0x0400139A RID: 5018
		private Personalidad m_personalidad;

		// Token: 0x0400139B RID: 5019
		private Arousal m_arousalV2;

		// Token: 0x0400139C RID: 5020
		private Placer m_PlacerV2;

		// Token: 0x0400139D RID: 5021
		private List<IModDeInterDeGenTactil> m_modificadoresDeIntervaloVel = new List<IModDeInterDeGenTactil>();

		// Token: 0x0400139E RID: 5022
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;
	}
}
